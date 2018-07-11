Shader "Custom/Color Constrast" {
	Properties {
		_PrimaryColor ("Primary Color", Color) = (1,1,1,1)
		_SecondColor ("Primary Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Threshold ("Threshold", Range(0, 1)) = 0.5
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _PrimaryColor, _SecondColor;
		float _Threshold;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed mask = tex2D (_MainTex, IN.uv_MainTex).r; // 采样出来的值为 0 ~ 1 之间
			mask = mask * 0.98 + 0.01;
			float flag = (_Threshold < mask); // 作用是，当小于时完全显示 _PrimaryColor，反之完全显示 _SecondColor
			o.Albedo = flag * _PrimaryColor + (1 - flag) * _SecondColor; // 颜色根据采样结果进行渐变
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
