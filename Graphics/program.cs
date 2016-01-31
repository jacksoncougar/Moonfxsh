using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Program : IDisposable
    {
        private static int activeProgram;

        private readonly Dictionary<string, int> _attributes;
        private readonly Dictionary<string, int> _uniforms;

        public Program( string name )
        {
            Name = name;

            _attributes = new Dictionary<string, int>( );
            _uniforms = new Dictionary<string, int>( );

            Ident = GL.CreateProgram( );
        }

        public int Ident { get; private set; }
        public string Name { get; private set; }

        public void Dispose( )
        {
            GL.DeleteProgram( Ident );
            GL.UseProgram( 0 );
        }

        public void Assign( )
        {
            AssignActiveProgram( Ident );
        }

        private static void AssignActiveProgram( int program )
        {
            if ( activeProgram != program )
                GL.UseProgram( activeProgram = program );
        }

        public int GetAttributeLocation( string name )
        {
            int location;
            if ( !_attributes.TryGetValue( name, out location ) )
            {
                _attributes[ name ] = location = GL.GetAttribLocation( Ident, name );
            }
            return location;
        }

        public int[] GetUniformIndices( string[] names )
        {
            var indices = new int[names.Length];
            GL.GetUniformIndices( Ident, names.Length, names, indices );
            return indices;
        }

        public int GetUniformLocation( string name )
        {
            int location;
            if ( !_uniforms.TryGetValue( name, out location ) )
            {
                location = _uniforms[ name ] = GL.GetUniformLocation( Ident, name );
            }
            return location;
        }

        public int[] GetUniformOffsets( int[] indices )
        {
            var offsets = new int[indices.Length];
            GL.GetActiveUniforms( Ident, indices.Length, indices, ActiveUniformParameter.UniformOffset, offsets );
            return offsets;
        }

        public void Link( List<Shader> shaderList )
        {
            foreach ( var shader in shaderList )
            {
                GL.AttachShader( Ident, shader.ID );
            }

            GL.LinkProgram( Ident );

            int status;
            GL.GetProgram( Ident, GetProgramParameterName.LinkStatus, out status );
            if ( status == 0 )
            {
                var program_log = GL.GetProgramInfoLog( Ident );
                MessageBox.Show( $"Linker failure: {program_log}\n" );
            }
            GL.ValidateProgram( Ident );
            int valid;
            GL.GetProgram( Ident, GetProgramParameterName.ValidateStatus, out valid );
            int activeUniforms;
            GL.GetProgram( Ident, GetProgramParameterName.ActiveUniforms, out activeUniforms );
            if ( valid == 0 )
            {
                var program_log = GL.GetProgramInfoLog( Ident );
                MessageBox.Show( $"Validation failure {program_log}" );
            }

            foreach ( var shader in shaderList )
            {
                GL.DetachShader( Ident, shader.ID );
                GL.DeleteShader( shader.ID );
            }
        }

        public static void SetAttribute( int location, Vector4 value )
        {
            GL.VertexAttrib4( location + 0, value );
        }

        public static void SetAttribute( int location, float[] values )
        {
            GL.VertexAttrib4( location + 0, values );
        }

        public static void SetAttribute( int location, Matrix4 value )
        {
            GL.VertexAttrib4( location + 0, value.Row0 );
            GL.VertexAttrib4( location + 1, value.Row1 );
            GL.VertexAttrib4( location + 2, value.Row2 );
            GL.VertexAttrib4( location + 3, value.Row3 );
        }

        public void SetUniform( int location, Matrix4 value )
        {
            GL.UniformMatrix4( location, false, ref value );
        }

        public void SetUniform( int location, ref Matrix4 value )
        {
            GL.UniformMatrix4( location, false, ref value );
        }

        public void SetUniform( int location, Matrix3 value )
        {
            GL.UniformMatrix3( location, false, ref value );
        }

        public void SetUniform( int location, ref Matrix3 value )
        {
            GL.UniformMatrix3( location, false, ref value );
        }

        public void SetUniform( int location, Vector3 value )
        {
            GL.Uniform3( location, ref value );
        }

        public void SetUniform( int location, ref Vector3 value )
        {
            GL.Uniform3( location, ref value );
        }

        public void SetUniform( int location, Vector4 value )
        {
            GL.Uniform4( location, ref value );
        }

        public void SetUniform( int location, ref Vector4 value )
        {
            GL.Uniform4( location, ref value );
        }

        public void SetUniform( int location, float value )
        {
            GL.Uniform1( location, value );
        }

        public void SetUniform( int location, int value )
        {
            GL.Uniform1( location, value );
        }

        public IDisposable Use( )
        {
            AssignActiveProgram(Ident);
            return new Handle( 0 );
        }

        private class Handle : IDisposable
        {
            private readonly int _previousProgramId;

            public Handle( int prev )
            {
                _previousProgramId = prev;
            }

            public void Dispose( )
            {
                AssignActiveProgram( _previousProgramId );
            }
        }
    }

    public class SystemProgram : Program
    {
        public SystemProgram(List<Shader> shaders)
            : base("system")
        {
            GL.BindAttribLocation(Ident, 0, "position");
            GL.BindAttribLocation(Ident, 1, "boneIndices");
            GL.BindAttribLocation(Ident, 2, "boneWeights");
            GL.BindAttribLocation(Ident, 3, "texcoord");
            GL.BindAttribLocation(Ident, 4, "normal");
            GL.BindAttribLocation(Ident, 5, "tangent");
            GL.BindAttribLocation(Ident, 6, "bitangent");
            GL.BindAttribLocation(Ident, 7, "colour");

            Link(shaders);

            var p8NormalColourUniform = GetUniformLocation("P8NormalColour");
            var p8NormalMapUniform = GetUniformLocation("P8NormalMap");
            var diffuseMapUniform = GetUniformLocation("DiffuseMap");
            var environmentMapUniform = GetUniformLocation("EnvironmentMap");

           Use();
           SetUniform(p8NormalColourUniform, 0);
           SetUniform(p8NormalMapUniform, 3);
           SetUniform(diffuseMapUniform, 1);
           SetUniform(environmentMapUniform, 2);
        }
    }
}