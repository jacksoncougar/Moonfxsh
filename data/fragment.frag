#version 130

smooth in vec4 varyingTexcoord;

flat in vec4 DiffuseColour;

smooth in vec3 VertexPosition_worldspace;
smooth in vec3 VertexReflection_worldspace;

in vec3 EyeDirection_cameraspace;
in vec3 LightDirection_cameraspace;

smooth in vec3 EyeDirection_tangentspace;
smooth in vec3 LightDirection_tangentspace;

smooth in vec2 VertexTexcoord_texturespace;

in vec3 LightPosition_worldspace;

uniform sampler1D P8NormalColour;
uniform sampler2D P8NormalMap;
uniform sampler2D DiffuseMap;
uniform samplerCube EnvironmentMap;

out vec4 frag_color; 

void main()
{
	vec4 lightColor = vec4(1.0, 1.0, 1.0, 1.0);
	float lightPower = 1.0;
	float specularPower = 16.0;
	
	float index = texture(P8NormalMap, VertexTexcoord_texturespace.st);
	vec3 textureNormal_tangentspace = texture( P8NormalColour, index ).bgr * 2.0 - 1.0;
	
	vec4 diffuseColour = texture(DiffuseMap, VertexTexcoord_texturespace.st);
	vec4 environmentColour = texture(EnvironmentMap, VertexReflection_worldspace);
	
	float distance = length( LightPosition_worldspace - VertexPosition_worldspace );
	float distance_squared = distance * distance;

	vec3 n = textureNormal_tangentspace;
	vec3 l = normalize(LightDirection_tangentspace);
	float cosTheta = clamp( dot( n,l ), 0.0, 1.0 );
	vec3 E = normalize(EyeDirection_tangentspace);
	vec3 R = reflect(-l,n);
	float cosAlpha = clamp( dot( E,R ), 0.0, 1.0 );

	vec4 lightAccumulative = DiffuseColour * lightColor * lightPower;
	
	vec4 color = 
		// Ambient : simulates indirect lighting
		environmentColour * 0.5 * diffuseColour * 0.5 + DiffuseColour * 0.1 +
		// Diffuse : "color" of the object
		environmentColour * diffuseColour.a * lightColor * lightPower * cosTheta / distance_squared +
		// Specular : reflective highlight, like a mirror
		environmentColour * diffuseColour.a * lightColor * lightPower * pow(cosAlpha, specularPower) / distance_squared;

	
	frag_color =  color;
}
