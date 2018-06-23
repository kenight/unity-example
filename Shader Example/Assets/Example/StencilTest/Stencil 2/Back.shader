Shader "Tutorial/Stencil Test/Back"
{
	SubShader
	{
		Pass
		{
			// 此 shader 渲染的像素在 buffer = 2 的像素点上将被渲染
			Stencil
			{
				Ref 2
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
				return fixed4(0, 1, 0, 1);
			}
			ENDCG
		}
	}
}
