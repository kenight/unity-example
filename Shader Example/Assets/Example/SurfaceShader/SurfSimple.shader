Shader "Tutorial/Surface Shader/Simple" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		// 输入结构体的定义有一定要求，具体看官方文档 Surface Shader input structure
		// https://docs.unity3d.com/Manual/SL-SurfaceShaders.html
		struct Input {
			float2 uv_MainTex; // Texture coordinates must be named “uv” followed by texture name
		};

		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo:来自贴图与颜色混合
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb; // Albedo 类型为 fixed3，tex2D 返回值是 float4，所以进行一个转换，使用 c.xyz 一样
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
