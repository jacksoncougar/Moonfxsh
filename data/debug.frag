#version 430

layout(location = 0) in vec4 coordinate;
layout(location = 1) smooth in vec4 texcoord;

uniform int AlphaFuncUniform;
uniform float AlphaRefUniform = 0.5;

layout(binding = 0) uniform sampler2D diffuseSampler;
layout(binding = 2) uniform sampler2D normalSampler;



out vec4 FragmentColour;

void main()
{
	vec4 colour = texture(diffuseSampler, texcoord.st);
	vec4 normal = texture(normalSampler, texcoord.st);
	// less
	if (AlphaFuncUniform == 0x201 && (normal.a < AlphaRefUniform)) discard;
	FragmentColour = colour;
}