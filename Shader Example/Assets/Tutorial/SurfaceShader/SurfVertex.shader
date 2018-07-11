Shader "Tutorial/Surface Shader/Vertex" {

	// 使用 Lambert lighting model，Lambert 后，inout 参数相应的也要使用 SurfaceOutput
	// 使用一个自定义顶点函数,修改顶点位置

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Amount ("Extrusion Amount", Range(0,1)) = 0
	}
	SubShader {

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex; // Texture coordinates must be named “uv” followed by texture name
		};

		fixed4 _Color;
		float _Amount;

		// 使用 appdata_full 预定义的结构体作为参数
		void vert (inout appdata_full v) {
			v.vertex.xyz += v.normal * _Amount;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
