#version 430

layout(location = 0) in vec4 coordinates;
layout(location = 1) in vec4 boneWeights;
layout(location = 2) in vec4 boneIndices;
layout(location = 3) in vec4 textureCoordinates;
layout(location = 4) in vec4 normal;
layout(location = 5) in vec4 bitangent;
layout(location = 6) in vec4 tangent;

layout(location = 7) in mat4 instanceWorldMatrix;

uniform mat4 WorldMatrixUniform;
uniform mat4 ViewProjectionMatrixUniform;
uniform mat4 ViewMatrixUniform;

layout(location = 0) flat out vec4 diffuseColour;

void main()
{

	//diffuseColour = vec4(MV3x3 * normal.xyz, 1);
	mat4 worldMatrix = WorldMatrixUniform;
	if (WorldMatrixUniform == 0)worldMatrix = instanceWorldMatrix;


	mat4 modelViewMatrix = ViewMatrixUniform * worldMatrix;
	mat3 MV3x3 = mat3(modelViewMatrix);

	vec3 t = normalize((MV3x3 * normal.xyz));
	diffuseColour = vec4(t, 1);
	
	gl_Position = ViewProjectionMatrixUniform  * worldMatrix * coordinates;
	gl_PointSize = 5;
}