Shader "Tutorial/Rendering Order/Alpha Test"
{
	// Legacy shader 的写法
	Properties
	{
	}
	SubShader
	{
		Tags { "Queue" = "AlphaTest" }
		Pass
		{
			Color (0, 0, 1, 1)
		}
	}
}
