#version 430

layout(location = 0) in vec4 coordinate;



out vec4 FragmentColour;

void main()
{
	FragmentColour = (coordinate + 1) / 2;
}