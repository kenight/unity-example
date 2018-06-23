Shader "Tutorial/Post Processing/Displacement"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Displacement ("Displacement Texture", 2D) = "white" {}
		_Magnitude ("Magnitude", Range(0.0, 0.1)) = 1
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
			sampler2D _Displacement;
			float _Magnitude;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 disp = tex2D(_Displacement, i.uv).xy; // 通过 uv 在 _Displacement 贴图中抓取像素的 red green 通道的值
				disp = ((disp * 2) -1) * _Magnitude; // 将 disp 转换为 -1 到 1 再乘参数
				fixed4 col = tex2D(_MainTex, i.uv + disp);
				return col;
			}
			ENDCG
		}
	}
}
