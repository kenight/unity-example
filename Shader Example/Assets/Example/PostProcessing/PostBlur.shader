Shader "Tutorial/Post Processing/Blur"
{
	Properties
	{
		// _MainTex 是必须保留的，作为 OnRenderImage 的 source 通过此 Shader 渲染后，最终得到 destination
		_MainTex ("Texture", 2D) = "white" {}
		_Distance ("Distance", Range(0.0, 1.0)) = 0.1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _Distance;

			fixed4 frag (v2f i) : SV_Target
			{
				// 高斯模糊后期特效
				// 原理是取中心点及周围的点进行平均
				float dis = _Distance / 100;

				fixed4 center = tex2D(_MainTex, i.uv);
				fixed4 left = tex2D(_MainTex, i.uv + float2(-dis, 0));
				fixed4 right = tex2D(_MainTex, i.uv + float2(dis, 0));
				fixed4 top = tex2D(_MainTex, i.uv + float2(0, dis));
				fixed4 bottom = tex2D(_MainTex, i.uv + float2(0, -dis));

				fixed4 col = (center + left + right + top + bottom) / 5.0;

				return col;
			}
			ENDCG
		}
	}
}
