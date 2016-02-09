using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Scene
    {
        public Scene( )
        {
            Initialize( );
        }

        public Camera Camera { get; set; }
        public NewSceneManager Manager { get; set; }
        public Performance Performance { get; private set; }
        public ProgramManager ProgramManager { get; set; }
        private Stopwatch Timer { get; set; }

        public event EventHandler OnFrameReady;

        public void RenderFrame( float timeStep )
        {
            BeginFrame( );
            Draw(timeStep);
            EndFrame( );
        }

        private DrawCommand[] WalkScene( )
        {
            return new DrawCommand[0];
            //  foreach object => by instance Id (can use the id in scenario)
            //  get location of object

            //var objectPosition = Vector3.Zero;
            //var viewerPosition = Camera.Position;

            //var objectDistance = ( viewerPosition - objectPosition ).Length;

            //var modelBlock = Manager._objectBlock.Model.Get<ModelBlock>( );
            //var renderModelBlock = modelBlock.RenderModel.Get<RenderModelBlock>( );

            //var lodBias = GetDetailBias( modelBlock, objectDistance );
            //var permutation = 0;

            //var sections = new int[renderModelBlock.Regions.Length];
            //for ( var index = 0; index < renderModelBlock.Regions.Length; index++ )
            //{
            //    var renderModelRegionBlock = renderModelBlock.Regions[ index ];
            //    sections[ index ] = GetSectionIndex( renderModelRegionBlock, permutation, lodBias );
            //}
            //var commands = new List<DrawCommand>( );
            //foreach ( var index in sections )
            //{
            //    commands.AddRange(
            //        Manager.bucketManager.GetDrawCommands(
            //            renderModelBlock.Sections[ index ].SectionData[ 0 ].Section ) );
            //}
            //return commands.ToArray(  );
        }

        private static int GetSectionIndex( RenderModelRegionBlock region, int permutation, int levelOfDetail )
        {
            var renderModelPermutationBlock = region.Permutations[ permutation ];
            switch ( levelOfDetail )
            {
                case 1:
                    return renderModelPermutationBlock.L1SectionIndex;
                case 2:
                    return renderModelPermutationBlock.L2SectionIndex;
                case 3:
                    return renderModelPermutationBlock.L3SectionIndex;
                case 4:
                    return renderModelPermutationBlock.L4SectionIndex;
                case 5:
                    return renderModelPermutationBlock.L5SectionIndex;
            }
            return -1;
        }

        private static int GetDetailBias( ModelBlock modelBlock, float distanceToViewer )
        {
            if (distanceToViewer > modelBlock.ReduceToL1) return 1;
            if (distanceToViewer > modelBlock.ReduceToL2) return 2;
            if (distanceToViewer > modelBlock.ReduceToL3) return 3;
            return distanceToViewer > modelBlock.ReduceToL4 ? 4 : 5;
        }

        public virtual void Update( )
        {
            Camera.Update( );
        }

        protected virtual void Draw( float delta )
        {
            var commands = Manager.GetLevelGeometryDrawCommands( );
            Manager.Draw( ProgramManager, commands );
        }

        private void BeginFrame( )
        {
            Performance.BeginFrame( );
        }

        private void Camera_ViewMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            foreach ( var program in ProgramManager )
            {
                program.Assign(  );
                var viewMatrixUniform = program.GetUniformLocation( "ViewMatrixUniform" );
                program.SetUniform( viewMatrixUniform,  e.Matrix  );
            }
        }

        private void Camera_ViewProjectionMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            foreach ( var program in ProgramManager )
            {
                program.Use( );
                var viewProjectionMatrixUniform = program.GetUniformLocation("ViewProjectionMatrixUniform");
                program.SetUniform(viewProjectionMatrixUniform, ref e.Matrix);
            }
        }

        private void EndFrame( )
        {
            Performance.EndFrame( );
            OnFrameReady?.Invoke( this, new EventArgs( ) );
            GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        }

        private void Initialize( )
        {
            Console.WriteLine( GL.GetString( StringName.Version ) );
            Timer = new Stopwatch( );
            Camera = new Camera( );
            Manager = new NewSceneManager( );
            ProgramManager = new ProgramManager( );
            Performance = new Performance( );

            Camera.ViewProjectionMatrixChanged += Camera_ViewProjectionMatrixChanged;
            Camera.ViewMatrixChanged += Camera_ViewMatrixChanged;
            Camera.Viewport.ViewportChanged += Viewport_ViewportChanged;

            GL.ClearColor( Color.FromArgb( ~Colours.Green.ToArgb( ) ) );
            GL.FrontFace( FrontFaceDirection.Ccw );
            GL.Enable( EnableCap.CullFace );
            GL.Enable( EnableCap.DepthTest );
            GL.PointSize( 5.0f );
        }

        private void Viewport_ViewportChanged( object sender, Viewport.ViewportEventArgs e )
        {
            GL.Viewport( 0, 0, e.Viewport.Width, e.Viewport.Height );
        }
    };
}