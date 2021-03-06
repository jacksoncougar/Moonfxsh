﻿using System;
using System.IO;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Shader
    {
        private int shader_id;

        public int ID
        {
            get { return shader_id; }
        }

        public Shader(string filename, ShaderType shader_type)
        {
            shader_id = GL.CreateShader(shader_type);
            var wd = Directory.GetCurrentDirectory();

            string shader_source = File.ReadAllText(filename);
            GL.ShaderSource(shader_id, shader_source);

            GL.CompileShader(shader_id);

            int status;
            GL.GetShader(shader_id, ShaderParameter.CompileStatus, out status);
            if (status == 0)
            {
                string shader_log = GL.GetShaderInfoLog(shader_id);
                MessageBox.Show(String.Format("Compiler failure in {0} shader:\n{1}\n", shader_type, shader_log));
            }
        }
    }
}