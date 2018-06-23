Shader "Tutorial/Surface Shader/Effect Flow" {

	// 使用 surface shader 改写 VertFragEffectFlow.shader

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Speed ("Flow Speed", Float) = 1
	}
	SubShader {

		CGPROGRAM
		#pragma surface surf Lambert

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex; // Texture coordinates must be named “uv” followed by texture name
		};

		float _Speed;

		void surf (Input IN, inout SurfaceOutput o) {
			float2 uvs = IN.uv_MainTex;
			uvs.y += _Time.y * _Speed;
			o.Albedo = tex2D (_MainTex, uvs).rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
