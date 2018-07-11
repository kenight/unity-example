Shader "Tutorial/Rendering Order/Geometry1"
{
	// Legacy shader 的写法
	Properties
	{
	}
	SubShader
	{
		Tags { "Queue" = "Geometry+1" }
		Pass
		{
			Color (0, 1, 0, 1)
		}
	}
}
