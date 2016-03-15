 #version 130

in vec4 Position;
in vec4 Colour;

	uniform mat4 OrthoProjectionMatrixUniform;

out vec4 DiffuseColour;

void main()
{
    vec4 viewPosition = OrthoProjectionMatrixUniform  *  Position;
	DiffuseColour = Colour;
	gl_Position = viewPosition;
}