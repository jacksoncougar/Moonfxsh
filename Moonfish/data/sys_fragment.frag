#version 130

in vec4 DiffuseColour;
out vec4 FragmentColour;

void main()
{
	FragmentColour = DiffuseColour;
}