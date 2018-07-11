Shader "Tutorial/Rendering Order/Transparent"
{
	// Legacy shader 的写法
	Properties
	{
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" }
		Pass
		{
			Color (0.5, 0.5, 0.5, 1)
		}
	}
}
