Shader "Custom/Simple Transition"
{
	Properties
	{
		[HideInInspector] _MainTex ("Texture", 2D) = "white" {}
		_TransitionTex ("Transition", 2D) = "white" {}
		_Color ("Color", Color) = (0,0,0,0)
		_CutOff ("CutOff", Range(0, 1)) = 0
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
			
			sampler2D _MainTex, _TransitionTex;
			fixed4 _Color;
			float _CutOff;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 trans = tex2D(_TransitionTex, i.uv);

				if(trans.b < _CutOff) 
				{
					return _Color;
				}

				return tex2D(_MainTex, i.uv);;
			}
			ENDCG
		}
	}
}
