 #version 430
	 
 layout(location = 0) in vec4 coordinates;
 layout(location = 3) in vec4 textureCoordinates;

 uniform mat2x2 ViewportMatrixUniform;

 layout(location = 0) flat out vec4 diffuseColour;
 layout(location = 1) out vec4 oTextureCoordinates;

 void main()
 {
	 gl_Position.xy = ViewportMatrixUniform * coordinates.xy;
     oTextureCoordinates = textureCoordinates;
	 gl_Position.w = 1.0;
	 gl_PointSize = 5;
 }