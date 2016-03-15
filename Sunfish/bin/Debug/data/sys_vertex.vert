#version 130

in vec4 Position;
in vec4 Colour;
out vec4 DiffuseColour;

uniform mat4 WorldMatrixUniform;
uniform mat4 ViewProjectionMatrixUniform;

void main()
{
	DiffuseColour = Colour;
    gl_Position = ViewProjectionMatrixUniform  * Position;
	gl_PointSize = 5;
}