Shader "Tutorial/Rendering Order/Geometry"
{
	// Legacy shader 的写法
	Properties
	{
	}
	SubShader
	{
		Tags { "Queue" = "Geometry" }
		Pass
		{
			Color (1, 0, 0, 1)
		}
	}
}
