Shader "Tutorial/Vert Frag Shader/Visualizing UVs"
{
	// 官方文档上的可视化 UVs Shader
	// 黑色对应 uv 0，0 位置
	// 绿色对应 uv 0, 1 位置
	// 纯红对应 uv 1, 0 位置
	// 黄色对应 uv 1, 1 位置
	// 有蓝色代表该处 uv 有超过0-1范围（开始重复的UV）

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
				float4 uv : TEXCOORD0; // default is float2
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = float4(v.uv.xy, 0, 0); // frag 函数返回 Color 的类型是 fixed4，在这里转换一下
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = frac( i.uv ); // 获取 uv (x,y,z,w) 每个分量的小数部分设置给 Color，如 1.23 只取 0.23

				// any() : True if any components of the x parameter are non-zero; otherwise, false.
				// saturate() : Clamps the specified value within the range of 0 to 1.
				// 如果 uv 在 0 - 1 之间，相减为 0, any return false
				// 如果 uv 超过 1，相减为非 0，any return true
				if (any(saturate(i.uv) - i.uv))
					col.b = 0.5;

				return col;
			}
			ENDCG
		}
	}
}
