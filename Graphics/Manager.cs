using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MeshManager
    {
        public ProgramManager ProgramManager { get; set; }
        private readonly Dictionary<TagIdent, List<ScenarioObject>> _objectInstances;
        private ScenarioBlock _scenario;

        public MeshManager()
        {
            _objectInstances = new Dictionary<TagIdent, List<ScenarioObject>>();
            ClusterObjects = new List<RenderObject>();
            InstancedGeometryObjects = new List<RenderObject>();
        }

        private CollisionManager Collision { get; set; }
        public ScenarioStructureBspBlock Level { get; private set; }
        public List<RenderObject> ClusterObjects { get; private set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public IEnumerable<ScenarioObject> this[TagIdent ident]
        {
            get
            {
                List<ScenarioObject> instances;
                if (_objectInstances.TryGetValue(ident, out instances))
                    return instances;
                return Enumerable.Empty<ScenarioObject>();
            }
        }

        public void LoadScenarioStructure(ScenarioStructureBspBlock levelBlock, CacheStream cacheStream)
        {
            Level = levelBlock;
            ClusterObjects = new List<RenderObject>();
            InstancedGeometryObjects = new List<RenderObject>();
            foreach (var cluster in Level.Clusters)
            {
                ClusterObjects.Add(new RenderObject(cluster));
            }
            foreach (var item in Level.InstancedGeometriesDefinitions)
            {
                InstancedGeometryObjects.Add(new RenderObject(item));
            }
            ProgramManager.LoadMaterials(Level.Materials, cacheStream);
        }

        internal void Add(TagIdent ident, ScenarioObject @object)
        {
            List<ScenarioObject> instanceList;
            if (!_objectInstances.TryGetValue(ident, out instanceList))
            {
                instanceList = _objectInstances[ident] = new List<ScenarioObject>();
            }
            instanceList.Add(@object);
        }

        public void LoadCollision(CollisionManager collision)
        {
            Collision = collision;
            foreach (var item in _objectInstances.SelectMany(x => x.Value))
            {
                Collision.World.AddCollisionObject(item.CollisionObject);
            }
        }

        public void LoadScenario(CacheStream map)
        {
            var ident = map.Index.Select((TagClass) "scnr", "").First().Identifier;
            _scenario = (ScenarioBlock) map.Deserialize(ident);

            LoadScenarioStructure((ScenarioStructureBspBlock) _scenario.StructureBSPs.First().StructureBSP.Get(), map);

            LoadInstances(
                _scenario.Scenery.Select(x => (IH2ObjectInstance) x).ToList(),
                _scenario.SceneryPalette.Select(x => (IH2ObjectPalette) x).ToList());
            LoadInstances(
                _scenario.Crates.Select(x => (IH2ObjectInstance) x).ToList(),
                _scenario.CratesPalette.Select(x => (IH2ObjectPalette) x).ToList());
            LoadInstances(
                _scenario.Weapons.Select(x => (IH2ObjectInstance) x).ToList(),
                _scenario.WeaponPalette.Select(x => (IH2ObjectPalette) x).ToList());
            LoadNetgameEquipment(
                _scenario.NetgameEquipment.Select(x => x).ToList());

            Log.Info(GL.GetError().ToString());
        }

        private void LoadNetgameEquipment(List<ScenarioNetgameEquipmentBlock> list)
        {
            foreach (var item in list.Where(x => !TagIdent.IsNull(x.ItemVehicleCollection.Ident)
                                                 &&
                                                 (x.ItemVehicleCollection.Class.ToString() == "vehc" ||
                                                  x.ItemVehicleCollection.Class.ToString() == "itmc")))
            {
                try
                {
                    Add(item.ItemVehicleCollection.Ident, new ScenarioObject(Halo2.GetReferenceObject<ModelBlock>(
                        Halo2.GetReferenceObject<ObjectBlock>(
                            item.ItemVehicleCollection.Class.ToString() == "itmc"
                                ? Halo2.GetReferenceObject<ItemCollectionBlock>(item.ItemVehicleCollection)
                                    .ItemPermutations.First()
                                    .Item
                                : Halo2.GetReferenceObject<VehicleCollectionBlock>(item.ItemVehicleCollection)
                                    .VehiclePermutations.First()
                                    .Vehicle).Model))
                    {
                        WorldMatrix = item.WorldMatrix
                    }
                        );
                }
                catch (NullReferenceException)
                {
                }
            }
        }

        private void LoadInstances(List<IH2ObjectInstance> instances, List<IH2ObjectPalette> objectPalette)
        {
            var join = (from instance in instances
                join palette in objectPalette on (int) instance.PaletteIndex equals objectPalette.IndexOf(palette)
                    into gj
                from items in gj.DefaultIfEmpty()
                select new {instance, Object = items.ObjectReference}).ToArray();

            foreach (var item in join)
            {
                Add(item.Object.Ident, new ScenarioObject(
                    Halo2.GetReferenceObject<ModelBlock>(Halo2.GetReferenceObject<ObjectBlock>(item.Object).Model))
                {
                    WorldMatrix = item.instance.WorldMatrix
                }
                    );
            }
        }

        public void Draw(ProgramManager programManager)
        {
            DrawLevel();
            return;
            foreach (var batch in _objectInstances.SelectMany(x => x.Value).SelectMany(x => x.Batches))
            {
                Draw(programManager, batch);
            }
        }

        private void DrawLevel()
        {
            foreach (var batch in ClusterObjects.SelectMany(x => x.Batches))
            {
                var index = batch.Shader.Ident;
                batch.Shader.Ident = (int)Level.Materials[index].Shader.Ident;
                Draw(ProgramManager, batch);
            }
        }

        public void Draw(ProgramManager programManager, RenderBatch batch)
        {
            if (batch.BatchObject == null) return;
            var program = programManager.GetProgram(batch.Shader);
            if (program == null) return;

            var usingProgram = program.Use();

            GL.BindVertexArray(batch.BatchObject.VertexArrayObjectIdent);
            foreach (var attribute in batch.Attributes.Select(x => new {Name = x.Key, x.Value}))
            {
                var attributeLocation = program.GetAttributeLocation(attribute.Name);
                Program.SetAttribute(attributeLocation, attribute.Value);
            }
            foreach (var uniform in batch.Uniforms.Select(x => new {Name = x.Key, x.Value}))
            {
                var uniformLocation = program.GetUniformLocation(uniform.Name);
                program.SetUniform(uniformLocation, uniform.Value);
            }
            var openGLStates =
                batch.RenderStates.Select(x => new {Capability = x.Key, Enabled = x.Value})
                    .Select(state => state.Enabled
                        ? OpenGL.Enable(state.Capability)
                        : OpenGL.Disable(state.Capability)).ToList();

            batch.SetupGLRenderState();
            GL.DrawElements(batch.PrimitiveType, batch.ElementLength, batch.DrawElementsType, batch.ElementStartIndex);
            batch.CleanupGLRenderState();

            // Cleanup states
            foreach (var state in openGLStates) state.Dispose();
            usingProgram.Dispose();
        }

        public void Draw(TagIdent item)
        {
            if (_objectInstances.ContainsKey(item))
            {
                //IRenderable @object = objects[item] as IRenderable;
                //@object.Render( new[] { program, systemProgram } );
            }
            else
            {
                var data = Halo2.GetReferenceObject(item);
                //objects[item] = new ScenarioObject( (ModelBlock)data );
            }
        }

        internal void Remove(TagIdent item)
        {
            _objectInstances.Remove(item);
        }

        internal void Clear()
        {
            _objectInstances.Clear();
        }
    }
}