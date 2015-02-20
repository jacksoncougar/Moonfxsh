using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.ES30;
using System.IO;
using System.Windows.Forms;
using OpenTK;

namespace Moonfish.Graphics
{
    public class Program : IDisposable
    {
        public readonly string Name;

        Dictionary<string, int> uniforms;
        Dictionary<string, int> attributes;

        public int Ident { get; private set; }

        public Program(string name)
        {
            this.Name = name;

            attributes = new Dictionary<string, int>();
            uniforms = new Dictionary<string, int>();

            Ident = GL.CreateProgram();
            //kk;hhdfdfdfd
        }

        public void Link(List<Shader> shader_list)
        {
            foreach (Shader shader in shader_list)
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

            foreach (Shader shader in shader_list)
            {
                GL.DetachShader(Ident, shader.ID);
            }
        }

        public int GetAttributeLocation(string name)
        {
            int location;
            if (!attributes.TryGetValue(name, out location))
            {
                attributes[name] = location = GL.GetAttribLocation(this.Ident, name);
            }
            return location;
        }

        public void SetAttribute(int location, Vector4 value)
        {
            GL.VertexAttrib4(location + 0, value);
        }
        public void SetAttribute(int location, float[] values)
        {
            GL.VertexAttrib4(location + 0, values);
        }
        public void SetAttribute(int location, Matrix4 value)
        {
            GL.VertexAttrib4(location + 0, value.Row0);
            GL.VertexAttrib4(location + 1, value.Row1);
            GL.VertexAttrib4(location + 2, value.Row2);
            GL.VertexAttrib4(location + 3, value.Row3);
        }

        public int GetUniformLocation(string name)
        {
            int location;
            if (!uniforms.TryGetValue(name, out location))
            {
                location = uniforms[name] = GL.GetUniformLocation(this.Ident, name);
            }
            return location;
        }

        public void SetUniform(int location, Matrix4 value)
        {
            GL.UniformMatrix4(location, false, ref value);
        }
        public void SetUniform(int location, ref Matrix4 value)
        {
            GL.UniformMatrix4(location, false, ref value);
        }
        public void SetUniform(int location, ref Matrix3 value)
        {
            GL.UniformMatrix3(location, false, ref value);
        }
        public void SetUniform(int location, ref Vector3 value)
        {
            GL.Uniform3(location, ref value);
        }
        public void SetUniform(int location, ref Vector4 value)
        {
            GL.Uniform4(location, ref value);
        }
        public void SetUniform(int location, float value)
        {
            GL.Uniform1(location, value);
        }
        public void SetUniform(int location, int value)
        {
            GL.Uniform1(location, value);
        }


        public IDisposable Use()
        {
            GL.UseProgram(this.Ident);
            return new Handle(0);
        }

        private class Handle : IDisposable
        {
            int previous_program_id;

            public Handle(int prev)
            {
                previous_program_id = prev;
            }

            public void Dispose()
            {
                GL.UseProgram(previous_program_id);
            }
        }

        public void Dispose()
        {
            GL.DeleteProgram(this.Ident);
            GL.UseProgram(0);
        }
    }

    public enum Uniforms : int
    {
        WorldMatrix = 1,
        NormalizationMatrix = 2,
        ViewProjectionMatrix = 3,
    }
}
