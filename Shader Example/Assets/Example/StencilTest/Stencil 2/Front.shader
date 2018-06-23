Shader "Tutorial/Stencil Test/Front"
{
	SubShader
	{
		ZWrite Off // 关闭深度测试，否则在深度测试环节也会 Z 值大渲染对象屏蔽掉

		Pass
		{
			// 更新此 shader 渲染的像素点的 stencil buffer
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
				return fixed4(1, 1, 1, 1);
			}
			ENDCG
		}
	}
}
