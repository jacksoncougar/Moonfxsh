#version 130

in vec4 Position;
out vec4 DiffuseColour;

uniform vec4 Colour;
uniform mat4 WorldMatrixUniform;
uniform mat4 ViewProjectionMatrixUniform;

void main()
{
	DiffuseColour = Colour;
    gl_Position = ViewProjectionMatrixUniform  * WorldMatrixUniform * Position;
	gl_PointSize = 5;
}