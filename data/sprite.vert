	#version 130

	in vec4 position;
	in vec4 diffuseColor;

		uniform mat4 objectExtents;
		uniform mat4 objectWorldMatrix;
		uniform mat4 viewProjectionMatrix;
		
	smooth out vec4 frag_diffuse_color;

	void main()
	{
		gl_Position = viewProjectionMatrix  * objectWorldMatrix * position;
		frag_diffuse_color = diffuseColor;
	}