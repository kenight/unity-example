Shader "Custom/Sprite Deformer 2"
{
	// 这是一个参考 Sprites-Default 的 2D shader
	// 以 Sprite Deformer 为基础
	// Mask 可以调节 offset
	Properties
	{
		[HideInInspector] _MainTex ("Texture", 2D) = "white" {}
		_DeformerTex ("Deformer", 2D) = "Grey" {}
		_MaskTex ("Deformer Mask", 2D) = "White"{}
		_Intensity ("Intensity", Range(0, 0.5)) = 0
		_Speed ("Speed", Range(-5, 5)) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }

		Cull Off
		Lighting Off
		ZWrite Off
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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uvDeformer : TEXCOORD1;
				float2 uvMask : TEXCOORD2;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex, _DeformerTex, _MaskTex;
			float4 _DeformerTex_ST, _MaskTex_ST;
			float _Intensity, _Speed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uvDeformer = TRANSFORM_TEX(v.uv, _DeformerTex);
				o.uvMask = TRANSFORM_TEX(v.uv, _MaskTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed2 deformer = tex2D(_DeformerTex, i.uvDeformer + _Time * _Speed);
				fixed4 mask = tex2D(_MaskTex, i.uvMask);
				float2 uvOffset = deformer * mask.r * _Intensity * 0.5;
				fixed4 col = tex2D(_MainTex, i.uv + uvOffset);
				col.rgb *= col.a;
				return col;
			}
			ENDCG
		}
	}
}
