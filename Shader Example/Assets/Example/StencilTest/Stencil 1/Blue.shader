Shader "Tutorial/Stencil Test/Blue"
{
	SubShader
	{
		Pass
		{
			// 当 Blue 覆盖到 stencil buffer = 1 的像素点时，这部分像素将渲染
			Stencil
			{
				Ref 1
				Comp Equal
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return fixed4(0, 0, 1, 1);
			}
			ENDCG
		}
	}
}
