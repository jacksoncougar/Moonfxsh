#version 140

in vec4 position;
in vec3 boneIndices;
in vec3 boneWeights;
in vec2 texcoord;
in vec3 normal;
in vec3 tangent;
in vec3 bitangent;
in vec4 colour; 
in mat4 instanceWorldMatrix;


uniform mat4 WorldMatrixUniform;
uniform mat4 ObjectSpaceMatrixUniform;
uniform vec4 LightPositionUniform;

uniform mat4 ViewProjectionMatrixUniform;
uniform mat4 ViewMatrixUniform; 
uniform vec4 TexcoordRangeUniform;

uniform mat4 BoneMatrices[64];

flat out vec4 DiffuseColour;
out vec3 LightPosition_worldspace;

smooth out vec3 VertexPosition_worldspace;
smooth out vec3 VertexReflection_worldspace;

smooth out vec3 EyeDirection_cameraspace;
smooth out vec3 LightDirection_cameraspace;

smooth out vec3 EyeDirection_tangentspace;
smooth out vec3 LightDirection_tangentspace;

smooth out vec2 VertexTexcoord_texturespace;

float unpack(in float value, in vec2 bounds)
{
	const float ushortMaxInverse = 1.0 / 65535.0;
	const float ushortHalf = 32767.0;
    return (((value + ushortHalf) * ushortMaxInverse ) * (bounds.y - bounds.x)) + bounds.x;
}

vec3 unpack(in int packedVector)
{
	int x10 = (packedVector & 0x000007FF);
	if ((x10 & 0x00000400) == 0x00000400)
	{
		x10 = -(~x10 & 0x000003FF);
	}
	int y11 = (packedVector >> 11) & 0x000007FF;
	if ((y11 & 0x00000400) == 0x00000400)
	{
		y11 = -(~y11 & 0x000003FF);
	}
	int z11 = (packedVector >> 22) & 0x000003FF;
	if ((z11 & 0x00000200) == 0x00000200)
	{
		z11 = -(~z11 & 0x000001FF);
	}

	float x = float(x10) / 1023.0;
	float y = float(y11) / 1023.0;
	float z = float(z11) / 511.0;
	
	vec3 value = ( vec3(x, y, z) );
	return value;
}

void main()
{
	vec3 weights = boneWeights;
	if(length(weights) < 1) weights = vec3(1.0, 0.0, 0.0);
	vec4 transformedPosition = position;// (BoneMatrices[int(boneIndices.x)] * position) * boneWeights.x;
	//transformedPosition  += (BoneMatrices[int(boneIndices.y)] * position) * boneWeights.y;
	//transformedPosition  += (BoneMatrices[int(boneIndices.z)] * position) * boneWeights.z;
	mat3 normalMatrix = mat3(ViewMatrixUniform);	

	LightPosition_worldspace = LightPositionUniform.xyz;
	vec3 vertexPosition_cameraspace = (ViewMatrixUniform * instanceWorldMatrix * transformedPosition).xyz;

	EyeDirection_cameraspace = -vertexPosition_cameraspace;

	vec3 lightPosition_cameraspace = (ViewMatrixUniform * LightPositionUniform).xyz;
	LightDirection_cameraspace = lightPosition_cameraspace + EyeDirection_cameraspace;
	
	vec3 vertexNormal_cameraspace =  normalMatrix * normal;
	vec3 vertexTangent_cameraspace = normalMatrix * tangent;
	vec3 vertexBitangent_cameraspace = normalMatrix *  bitangent;

	VertexReflection_worldspace = reflect(vertexPosition_cameraspace, vertexNormal_cameraspace);
	
	mat3 TBN =  transpose(mat3(
		vertexBitangent_cameraspace,
		vertexTangent_cameraspace,
		vertexNormal_cameraspace
	));
	
	VertexPosition_worldspace = vec3(instanceWorldMatrix * transformedPosition);
	LightDirection_tangentspace = TBN * LightDirection_cameraspace;
	EyeDirection_tangentspace = TBN * EyeDirection_cameraspace;

	VertexTexcoord_texturespace = vec2(unpack(texcoord.s, TexcoordRangeUniform.xy), unpack(texcoord.t, TexcoordRangeUniform.zw));
	
    gl_Position = ViewProjectionMatrixUniform * transformedPosition;
}