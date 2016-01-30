// Compiled shader for PC, Mac & Linux Standalone, uncompressed size: 0.6KB

// Skipping shader variants that would not be included into build of current scene.

Shader "Unlit/Color" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 100
 Tags { "RenderType"="Opaque" }


 // Stats for Vertex shader:
 //      opengl : 1 math
 Pass {
  Tags { "RenderType"="Opaque" }
  GpuProgramID 29821
Program "vp" {
SubProgram "opengl " {
// Stats: 1 math
"!!GLSL
#ifdef VERTEX

void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
}


#endif
#ifdef FRAGMENT
uniform vec4 _Color;
void main ()
{
  vec4 col_1;
  col_1.xyz = _Color.xyz;
  col_1.w = 1.0;
  gl_FragData[0] = col_1;
}


#endif
"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
}
 }
}
}