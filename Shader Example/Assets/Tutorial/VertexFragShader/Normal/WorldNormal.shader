Shader "Tutorial/Vert Frag Shader/World Normal"
{
	// 使用世界空间法线进行简单的光照计算 (将自身空间法线转换到世界空间，实际上只需要修改一句代码 UnityObjectToWorldNormal)

	// 除了空间的转换外和 objectNormal.shader 还做了一点小区别
	// 1. 在逐 vert 函数中计算光照颜色，而不是在逐 frag 函数中
	// 2. 增加了光照颜色
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

			// for _LightColor0
			#include "UnityLightingCommon.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				fixed4 diff : COLOR;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				float3 worldNormal = UnityObjectToWorldNormal(v.normal);

				// dot product between normal and light direction for
                // standard diffuse (Lambert) lighting
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.diff = nl * _LightColor0;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return i.diff;
			}
			ENDCG
		}
	}
}
