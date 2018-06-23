Shader "Tutorial/Stencil Test/Green"
{
	SubShader
	{
		Pass
		{
			// 在 ref = 2 时，当 Green 覆盖到 stencil buffer = 2 的像素点时，这部分覆盖的像素点将被渲染
			// 当 Green 被 Red 遮挡时将有部分或全部像素点出现 ZTest 失败的情况，这时触发 ZFail，这部分像素点的 buffer 值将更改为 1 
			Stencil
			{
				Ref 2
				Comp Equal
				Pass Keep
				ZFail DecrWrap // 将 ZTest 失败的像素点的 buffer 值减少 1
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
