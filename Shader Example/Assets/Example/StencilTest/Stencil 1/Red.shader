Shader "Tutorial/Stencil Test/Red"
{
	SubShader
	{
		Pass
		{
			// 将使用此 shader 渲染的像素点的 stencil buffer 改为 2，通常这是使用 Stencil Test 的第一步
			// 未通过此 shader 渲染的物体的 stencil buffer 默认为 0
			Stencil
			{
				Ref 2
				Comp Always
				Pass Replace
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
				return fixed4(1, 0, 0, 1);
			}
			ENDCG
		}
	}
}
