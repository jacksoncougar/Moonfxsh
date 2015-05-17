using System;
using System.Collections.Generic;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class LevelManager
    {
        private Program shaded, system;

        public ScenarioStructureBspBlock Level { get; private set; }
        public List<RenderObject> ClusterObjects { get; private set; }
        public List<RenderObject> InstancedGeometryObjects { get; private set; }

        public LevelManager(params Program[] programs)
        {
            shaded = programs.Length > 0 ? programs[0] : null;
            system = programs.Length > 1 ? programs[1] : null;
        }

        public void LoadScenarioStructure(ScenarioStructureBspBlock levelBlock)
        {
            this.Level = levelBlock;
            ClusterObjects = new List<RenderObject>();
            InstancedGeometryObjects = new List<RenderObject>();
            foreach (var cluster in this.Level.Clusters)
            {
                ClusterObjects.Add(new RenderObject(cluster));
            }
            foreach (var item in this.Level.InstancedGeometriesDefinitions)
            {
                InstancedGeometryObjects.Add(new RenderObject(item));
            }
        }

        public void RenderLevel()
        {
            //if (Level == null) return;

            //var worldMatrixAttribute = shaded.GetAttributeLocation("worldMatrix");
            //var objectMatrixAttribute = shaded.GetAttributeLocation("objectExtents");

            //shaded.SetAttribute(worldMatrixAttribute, Matrix4.Identity);
            //shaded.SetAttribute(objectMatrixAttribute, Matrix4.Identity);

            //foreach (var item in ClusterObjects)
            //    item.Render(shaded);
            //foreach (var instance in this.Level.instancedGeometryInstances)
            //{
            //    shaded.SetAttribute(worldMatrixAttribute, instance.WorldMatrix);
            //    InstancedGeometryObjects[(int)instance.instanceDefinition].Render(shaded);
            //}
        }
    }

    public class MeshManager
    {
        private CollisionManager Collision { get; set; }

        private ScenarioBlock scenario;
        private readonly Dictionary<TagIdent, List<ScenarioObject>> objectInstances;

        public IEnumerable<ScenarioObject> this[TagIdent ident]
        {
            get
            {
                List<ScenarioObject> instances;
                if (objectInstances.TryGetValue(ident, out instances))
                    return instances;
                return Enumerable.Empty<ScenarioObject>();
            }
        }

        internal void Add(TagIdent ident, ScenarioObject @object)
        {
            List<ScenarioObject> instanceList;
            if (!objectInstances.TryGetValue(ident, out instanceList))
            {
                instanceList = objectInstances[ident] = new List<ScenarioObject>();
            }
            instanceList.Add(@object);
        }

        public MeshManager()
        {
            objectInstances = new Dictionary<TagIdent, List<ScenarioObject>>();
        }

        public void LoadCollision(CollisionManager collision)
        {
            this.Collision = collision;
            foreach (var item in objectInstances.SelectMany(x => x.Value))
            {
                Collision.World.AddCollisionObject(item.CollisionObject);
            }
        }

        public void LoadScenario(CacheStream map)
        {
            var ident = map.Index.Select((TagClass)"scnr", "").First().Identifier;
            scenario = (ScenarioBlock) map.Deserialize(ident);

            LoadInstances(
                scenario.Scenery.Select(x => (IH2ObjectInstance) x).ToList(),
                scenario.SceneryPalette.Select(x => (IH2ObjectPalette) x).ToList());
            LoadInstances(
                scenario.Crates.Select(x => (IH2ObjectInstance) x).ToList(),
                scenario.CratesPalette.Select(x => (IH2ObjectPalette) x).ToList());
            LoadInstances(
                scenario.Weapons.Select(x => (IH2ObjectInstance) x).ToList(),
                scenario.WeaponPalette.Select(x => (IH2ObjectPalette) x).ToList());
            LoadNetgameEquipment(
                scenario.NetgameEquipment.Select(x => x).ToList());

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
            foreach (var batch in objectInstances.SelectMany(x => x.Value).SelectMany(x => x.Batches))
            {
                Draw(programManager, batch);
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
            if (objectInstances.ContainsKey(item))
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
            this.objectInstances.Remove(item);
        }

        internal void Clear()
        {
            this.objectInstances.Clear();
        }
    }
}