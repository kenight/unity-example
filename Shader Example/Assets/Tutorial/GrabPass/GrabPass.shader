Shader "Unlit/GrabPass"
{
	SubShader
	{
		Tags { "Queue"="Transparent" }

		GrabPass
        {
            "_BackgroundTexture"
        }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag2
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 grabPos : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _BackgroundTexture;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.grabPos = ComputeGrabScreenPos(o.vertex); // 计算经过投影矩阵变换后的坐标，再进行透视除法则是最终的屏幕坐标
				return o;
			}
			
			// 将按照模型的 uv 进行采样
			// 将在 cube 中显示整个屏幕图像
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_BackgroundTexture, i.uv);
				return col;
			}

			// 按照屏幕坐标采样
			fixed4 frag2 (v2f i) : SV_Target
			{
				// tex2Dproj is i.grabPos.xy / i.grabPos.w
				fixed4 col = tex2Dproj(_BackgroundTexture, i.grabPos);
				return col;
			}
			ENDCG
		}
	}
}
