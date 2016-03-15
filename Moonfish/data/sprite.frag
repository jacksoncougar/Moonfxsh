#version 130

smooth in vec4 frag_diffuse_color;

out vec4 frag_color;

in float pointSize;
in vec4 pointCoordinate;

void main()
{
    frag_color = frag_diffuse_color;
}