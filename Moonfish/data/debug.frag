#version 430

layout(location = 0) in vec4 coordinate;
layout(location = 1) smooth in vec4 texcoord;

uniform bool AlphaTestAnable = false;
uniform int AlphaFuncUniform = 0;
uniform float AlphaRefUniform = 0.5;

layout(binding = 0) uniform sampler2D diffuseSampler;
layout(binding = 2) uniform sampler2D normalSampler;

out vec4 FragmentColour;

bool AlphaTest(int AlphaFunct, float alpha, float alphaRef);

void main()
{
	vec4 colour = texture(diffuseSampler, texcoord.st);
	vec4 normal = texture(normalSampler, texcoord.st) * 2.0 - 1.0;

	if (AlphaTestAnable && AlphaTest(AlphaFuncUniform, normal.a, AlphaRefUniform)) discard;

	FragmentColour = colour;
}

// Implements GL.AlphaTest
bool AlphaTest(int alphaFunc, float srcAlpha, float alphaRef)
{
	// less
	if (alphaFunc == 0x200) return false;
	if (alphaFunc == 0x201 && (srcAlpha < alphaRef)) return true;
	if (alphaFunc == 0x202 && (srcAlpha == alphaRef)) return true;
	if (alphaFunc == 0x203 && (srcAlpha <= alphaRef)) return true;
	if (alphaFunc == 0x204 && (srcAlpha > alphaRef)) return true;
	if (alphaFunc == 0x205 && (srcAlpha != alphaRef)) return true;
	if (alphaFunc == 0x206 && (srcAlpha >= alphaRef)) return true;
	if (alphaFunc == 0x207) return true;
	return false;
}