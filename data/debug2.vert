#version 430

layout(location = 0) in vec4 coordinates;
layout(location = 1) in vec4 colour;

uniform mat4 ViewProjectionMatrixUniform;

layout(location = 0) flat out vec4 diffuseColour;

void main()
{
	diffuseColour = colour;
	
	gl_Position = ViewProjectionMatrixUniform * coordinates;
	gl_PointSize = 5;
}