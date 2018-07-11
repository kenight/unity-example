Shader "Tutorial/Vert Frag Shader/Object Normal"
{
	// 使用模型自身法线 (v.normal) 进行简单的光照计算
	SubShader
	{
		// 必须定义 LightMode 才能拿到 _WorldSpaceLightPos0
		Tags { "LightMode" = "ForwardBase" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// 最简单的光照
				// saturate是CG语言的函数，功能是返回不小于标量或每个向量分量的最小整数 return max(0, min(1, x))
				return saturate(dot(i.normal, _WorldSpaceLightPos0));
			}
			ENDCG
		}
	}
}
