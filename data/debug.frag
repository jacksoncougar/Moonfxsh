#version 430

layout(location = 0) in vec4 coordinate;
layout(location = 1) smooth in vec4 texcoord;

uniform int AlphaFuncUniform;
uniform float AlphaRefUniform = 0.5;

layout(binding = 0) uniform sampler2D diffuseSampler;
layout(binding = 2) uniform sampler2D normalSampler;

out vec4 FragmentColour;

bool AlphaTest(int AlphaFunct, float alpha, float alphaRef);

void main()
{
	vec4 colour = texture(diffuseSampler, texcoord.st);
	vec4 normal = texture(normalSampler, texcoord.st) * 2.0 - 1.0;

	if (AlphaTest(AlphaFuncUniform, normal.a, AlphaRefUniform)) discard;

	FragmentColour = colour;
}

// Implements GL.AlphaTest
bool AlphaTest(int alphaFunc, float srcAlpha, float alphaRef)
{
	// less
	if (alphaFunc == 0x201 && (srcAlpha < alphaRef)) return true;
	return false;
}