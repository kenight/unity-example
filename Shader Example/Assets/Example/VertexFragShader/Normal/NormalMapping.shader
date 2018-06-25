Shader "Tutorial/Vert Frag Shader/NormalMapping"
{
	// 使用法线贴图(非模型法线)进行光照计算

	// 总结：
	// 1. 法线贴图是对原法线(模型自带法线)的扰动
	// 2. 需要模型自带法线、切线来计算并构造切线空间矩阵
	// 3. 该矩阵用于将法线贴图由切线空间转换到世界空间（常见的偏蓝色的法线贴图都是切线空间下的）

	Properties
	{
		_BumpMap("Normal Map", 2D) = "bump" {}
	}
	SubShader
	{
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
				float4 tangent : TANGENT;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				// 3x3 矩阵，由顶点切线空间转换到世界空间下
				half3 tanToWorX : TEXCOORD1; // tangent.x, bitangent.x, normal.x
				half3 tanToWorY : TEXCOORD2; // tangent.y, bitangent.y, normal.y
				half3 tanToWorZ : TEXCOORD3; // tangent.z, bitangent.z, normal.z
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				half3 wNormal = UnityObjectToWorldNormal(v.normal);
				half3 wTan = UnityObjectToWorldDir(v.tangent.xyz); // tangent is float4
				// compute bitangent from cross product of normal and tangent
				half3 wBitan = cross(wNormal, wTan) * v.tangent.w * unity_WorldTransformParams.w;

				o.tanToWorX = half3(wTan.x, wBitan.x, wNormal.x);
				o.tanToWorY = half3(wTan.y, wBitan.y, wNormal.y);
				o.tanToWorZ = half3(wTan.z, wBitan.z, wNormal.z);

				return o;
			}

			sampler2D _BumpMap;
			
			fixed4 frag (v2f i) : SV_Target
			{
				half3 tNormal = UnpackNormal(tex2D(_BumpMap, i.uv)); // UnpackNormal 可以把 -1, 1 转换到 0, 1
				// transform normal from tangent to world space
				half3 worldNormal;
				worldNormal.x = dot(i.tanToWorX, tNormal);
                worldNormal.y = dot(i.tanToWorY, tNormal);
                worldNormal.z = dot(i.tanToWorZ, tNormal);

				return dot(worldNormal, _WorldSpaceLightPos0);
			}
			ENDCG
		}
	}
}
