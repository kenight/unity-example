Shader "Custom/Sprite Deformer"
{
	// https://www.youtube.com/watch?v=mRxNN_TalCU
	Properties
	{
		[HideInInspector] _MainTex ("Texture", 2D) = "white" {} // 用于接收 sprite ，不能更改
		_DeformerTex ("Deformer", 2D) = "Grey" {}
		_MaskTex ("Deformer Mask", 2D) = "White"{}

		_Intensity ("Deformer Intensity", Range(-1, 1)) = 0
		_Speed ("Deformer Speed", Range(-5, 5)) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

        Blend One OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uvDeformer : TEXCOORD1; // 两个 uv 其实是一样的，可省略一个
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uvDeformer : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;

			sampler2D _DeformerTex;
			float4 _DeformerTex_ST;

			sampler2D _MaskTex;

			float _Intensity;
			float _Speed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uvDeformer = v.uvDeformer;
				// o.uvDeformer = TRANSFORM_TEX(v.uvDeformer, _DeformerTex); // 直接用 v.uv 替代 v.uvDeformer 效果一样
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 uvDeformer = i.uvDeformer * _DeformerTex_ST.xy; // 这一句等同于 TRANSFORM_TEX;
				fixed2 deformer = tex2D(_DeformerTex, uvDeformer + _Time * _Speed);
				float2 uvOffset = deformer * _Intensity * 0.5;

				fixed4 mask = tex2D(_MaskTex, i.uv); // 使用 _MaskTex 进行遮盖
				fixed4 col = tex2D(_MainTex, i.uv + uvOffset * mask.r); // 接近 r = 0 的部分将不进行 offset

				return col * col.a; // sprite 透明部分只有a通道是0(其他通道并不是0)，相乘使像素为 (0,0,0,0)，结合 Blend One OneMinusSrcAlpha 则可显示为透明像素
			}
			ENDCG
		}
	}
}
