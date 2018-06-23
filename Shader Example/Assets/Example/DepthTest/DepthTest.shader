Shader "Tutorial/Depth Test"
{
	SubShader
	{
		// 预设环境是 back Z值大
		ZWrite On
		// 测试结果：
		// Less LEqual Equal 不通过，不能透过 front
		// Greater GEqual 与前面的 front 测试是通过，可以透过 front，但与天空盒测试是不通过
		// NotEqual Always 不管与 front 还是天空盒测试都通过，颜色将覆盖 front 与 天空盒
		ZTest Less      

		Pass
		{
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
