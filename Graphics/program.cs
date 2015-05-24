using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Program : IDisposable
    {
        public string Name { get; private set; }

        private readonly Dictionary<string, int> _uniforms;
        private readonly Dictionary<string, int> _attributes;

        public int Ident { get; private set; }

        public Program(string name)
        {
            Name = name;

            _attributes = new Dictionary<string, int>();
            _uniforms = new Dictionary<string, int>();

            Ident = GL.CreateProgram();
        }

        public void Link(List<Shader> shaderList)
        {
            foreach (Shader shader in shaderList)
            {
                GL.AttachShader(Ident, shader.ID);
            }

            GL.LinkProgram(Ident);

            int status;
            GL.GetProgram(Ident, GetProgramParameterName.LinkStatus, out status);
            if (status == 0)
            {
                string program_log = GL.GetProgramInfoLog(Ident);
                MessageBox.Show(String.Format("Linker failure: {0}\n", program_log));
            }
            GL.ValidateProgram(Ident);
            int valid;
            GL.GetProgram(Ident, GetProgramParameterName.ValidateStatus, out valid);
            if (valid == 0)
            {
                string program_log = GL.GetProgramInfoLog(Ident);
                MessageBox.Show(String.Format("Validation failure {0}", program_log));
            }

            foreach (Shader shader in shaderList)
            {
                GL.DetachShader(Ident, shader.ID);
            }
        }

        public int GetAttributeLocation(string name)
        {
            int location;
            if (!_attributes.TryGetValue(name, out location))
            {
                _attributes[name] = location = GL.GetAttribLocation(Ident, name);
#if DEBUG
#endif
            }
            return location;
        }

        public static void SetAttribute(int location, Vector4 value)
        {
            GL.VertexAttrib4(location + 0, value);
#if DEBUG
#endif
        }

        public static void SetAttribute(int location, float[] values)
        {
            GL.VertexAttrib4(location + 0, values);
#if DEBUG
#endif
        }

        public static void SetAttribute(int location, Matrix4 value)
        {
            GL.VertexAttrib4(location + 0, value.Row0);
            GL.VertexAttrib4(location + 1, value.Row1);
            GL.VertexAttrib4(location + 2, value.Row2);
            GL.VertexAttrib4(location + 3, value.Row3);
#if DEBUG
#endif
        }

        public int GetUniformLocation(string name)
        {
            int location;
            if (!_uniforms.TryGetValue(name, out location))
            {
                location = _uniforms[name] = GL.GetUniformLocation(Ident, name);
#if DEBUG
#endif
            }
            return location;
        }

        public int[] GetUniformIndices(string[] names)
        {
            var indices = new int[names.Length];
            GL.GetUniformIndices(Ident, names.Length, names, indices);
#if DEBUG
#endif
            return indices;
        }

        public int[] GetUniformOffsets(int[] indices)
        {
            int[] offsets = new int[indices.Length];
            GL.GetActiveUniforms(Ident, indices.Length, indices, ActiveUniformParameter.UniformOffset, offsets);
#if DEBUG
#endif
            return offsets;
        }

        public void SetUniform(int location, Matrix4 value)
        {
            GL.UniformMatrix4(location, false, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, ref Matrix4 value)
        {
            GL.UniformMatrix4(location, false, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, Matrix3 value)
        {
            GL.UniformMatrix3(location, false, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, ref Matrix3 value)
        {
            GL.UniformMatrix3(location, false, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, Vector3 value)
        {
            GL.Uniform3(location, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, ref Vector3 value)
        {
            GL.Uniform3(location, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, Vector4 value)
        {
            GL.Uniform4(location, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, ref Vector4 value)
        {
            GL.Uniform4(location, ref value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, float value)
        {
            GL.Uniform1(location, value);
#if DEBUG
#endif
        }

        public void SetUniform(int location, int value)
        {
            GL.Uniform1(location, value);
#if DEBUG
#endif
        }

        public void Assign( )
        {
            GL.UseProgram(Ident);
        }


        public IDisposable Use()
        {
            GL.UseProgram(Ident);
            return new Handle(0);
        }

        private class Handle : IDisposable
        {
            private readonly int _previousProgramId;

            public Handle(int prev)
            {
                _previousProgramId = prev;
            }

            public void Dispose()
            {
                GL.UseProgram(_previousProgramId);
            }
        }

        public void Dispose()
        {
            GL.DeleteProgram(Ident);
            GL.UseProgram(0);
        }
    }

    public enum Uniforms
    {
        WorldMatrix = 1,
        NormalizationMatrix = 2,
        ViewProjectionMatrix = 3,
    }
}