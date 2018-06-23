Shader "Debug Tool/UVs"
{
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
				float4 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 uv : TEXCOORD0; // default is float2
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = float4( v.texcoord.xy, 0, 0 ); // float2 convert to float4
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				half4 c = frac( i.uv ); // 获取 uv (x,y,z,w) 每个分量的小数部分设置给 Color，如 1.23 只取 0.23
				
				// any() : True if any components of the x parameter are non-zero; otherwise, false.
				// saturate() : Clamps the specified value within the range of 0 to 1.
				// 如果 uv 在 0 - 1 之间，相减为 0, any return false
				// 如果 uv 超过 1，相减为非 0，any return true
				if (any(saturate(i.uv) - i.uv))
					c.b = 0.5;
				return c;
			}
			ENDCG
		}
	}
}
