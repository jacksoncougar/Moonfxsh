#version 430

layout(location = 0) in vec4 coordinates;
layout(location = 1) in vec4 boneWeights;
layout(location = 2) in vec4 boneIndices;
layout(location = 3) in vec4 textureCoordinates;
layout(location = 4) in vec4 normal;
layout(location = 5) in vec4 bitangent;
layout(location = 6) in vec4 tangent;

layout(location = 7) in mat4 instanceWorldMatrix;

uniform vec4 ShaderArguments;

uniform mat4 WorldMatrixUniform = mat4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);

uniform mat4 ViewProjectionMatrixUniform;
uniform mat4 ViewMatrixUniform;

layout(location = 0) flat out vec4 diffuseColour;
layout(location = 1) out vec4 oTextureCoordinates;

void main()
{	
	mat4 worldMatrix = WorldMatrixUniform;
	mat4 modelViewMatrix = ViewMatrixUniform * worldMatrix;
	mat3 MV3x3 = mat3(modelViewMatrix);

	vec3 t = normalize((MV3x3 * normal.xyz));
	diffuseColour = vec4(t, 1);
	oTextureCoordinates = textureCoordinates;

	gl_Position = ViewProjectionMatrixUniform  * worldMatrix * coordinates;
	gl_PointSize = 5;
}