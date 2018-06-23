Shader "Tutorial/Surface Shader/Custom Vertex Data" {

	// 自定义数据传递给 surf 函数

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert

		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 customColor; // 自定义数据 (内置数据可直接传递给 surf)
		};

		void vert (inout appdata_full v, out Input o) { // 必须增加 out Input 参数
			UNITY_INITIALIZE_OUTPUT(Input,o); // 必须进行初始化，才能成功传递给 surf Input IN
			o.customColor = abs(v.normal); // 与顶点数据进行计算
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed3 col = tex2D (_MainTex, IN.uv_MainTex).rgb;
			o.Albedo = col * IN.customColor;  // 然后可直接使用 IN 调用自定义数据
		}
		ENDCG
	}
	FallBack "Diffuse"
}
