#version 130

in vec4 position;
in vec2 texcoord;
in int iNormal;
in int iTangent;
in int iBitangent;

in vec4 colour; 
in mat4 worldMatrix;
in mat4 objectExtents;
in vec3 LightPositionUniform;

out vec3 LightPosition_worldspace;

uniform mat4 viewProjectionMatrix;
uniform mat4 viewMatrix; 
uniform vec4 texcoordRangeUniform;

flat out vec4 DiffuseColour;

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
	mat3 normalMatrix = mat3(viewMatrix);	

	LightPosition_worldspace = LightPositionUniform;
	vec3 vertexPosition_cameraspace = (viewMatrix * worldMatrix * position).xyz;

	EyeDirection_cameraspace = -vertexPosition_cameraspace;

	vec3 lightPosition_cameraspace = (viewMatrix * vec4(LightPositionUniform, 1.0)).xyz;
	LightDirection_cameraspace = lightPosition_cameraspace + EyeDirection_cameraspace;
	
	vec3 vertexNormal_cameraspace =  normalMatrix * unpack(iNormal);
	vec3 vertexTangent_cameraspace = normalMatrix * (unpack(iTangent));
	vec3 vertexBitangent_cameraspace = normalMatrix *  (unpack(iBitangent));

	VertexReflection_worldspace = reflect(vertexPosition_cameraspace, vertexNormal_cameraspace);
	
	mat3 TBN =  transpose(mat3(
		vertexTangent_cameraspace,
		vertexBitangent_cameraspace,
		vertexNormal_cameraspace
	));
	
	VertexPosition_worldspace = vec3(worldMatrix * objectExtents * position);
	LightDirection_tangentspace = TBN * LightDirection_cameraspace;
	EyeDirection_tangentspace = TBN * EyeDirection_cameraspace;

	VertexTexcoord_texturespace = vec2(unpack(texcoord.s, texcoordRangeUniform.xy), unpack(texcoord.t, texcoordRangeUniform.zw));
	
	DiffuseColour  = colour;
    gl_Position = viewProjectionMatrix  * worldMatrix * objectExtents * position;
}