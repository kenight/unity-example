Shader "Tutorial/Vert Frag Shader/Effect Wave"
{
	// 实现思路
	// 更改 y 轴顶点，通过 y=Asin(ωx+φ)
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Speed ("Speed", Float) = 0.5
		_Amplitude ("Amplitude", Float) = 1
		_Frenquncy ("Frenquncy", Float) = 0.5
	}
	SubShader
	{
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

			float _Speed;
			float _Amplitude;
			float _Frenquncy;

			v2f vert (appdata v)
			{
				v2f o;

				// wave = Asin(ωx+φ)
				float wave = _Amplitude * sin(_Frenquncy * v.vertex.x + _Time.y * _Speed);
				v.vertex.y = v.vertex.y + wave;

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
				// col.rgb = 1 - col.rgb;
				return col;
			}
			ENDCG
		}
	}
}
