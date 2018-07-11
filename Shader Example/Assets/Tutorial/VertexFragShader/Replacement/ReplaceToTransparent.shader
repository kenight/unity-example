Shader "Tutorial/Vert Frag Shader/ReplaceToTransparent"
{
	// 使用该 shader 替换场景中的 shader
	// 通过 Camera.SetReplacementShader 方法
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		ZWrite Off // 关闭深度写入
		ZTest Always // 总是通过，总是写入颜色缓存
		Blend one one // 颜色叠加

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

			fixed4 _ReplaceColor; // 通过 ReplacementShader.cs 脚本赋值
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _ReplaceColor;
			}
			ENDCG
		}
	}
}
