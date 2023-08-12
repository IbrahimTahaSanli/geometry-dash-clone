// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TransparencyDiffuseBlocky"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		_AlphaTex("Alpha Texture", 2D) = "white" {}
        _TransparentZone ("Transparent Zone", float) = 1
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			//"Queue" = "Transparent+1"
			"IgnoreProjector"="True" 
			//"RenderType" = "Opaque"
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
			"DisableBatching" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM

            static const float PI = 3.14159265f;

			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				float2 texcoord  : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
			};

            sampler2D _MainTex;			
			sampler2D _AlphaTex;

            float4 _Color;
            float _TransparentZone;
			
			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.texcoord = IN.texcoord;

                float4 baseWorldPos = ComputeScreenPos(UnityObjectToClipPos(float3(0,0,0)));

                if((baseWorldPos.x < _TransparentZone) || baseWorldPos.x > (1 - _TransparentZone)){
                    float4 pos = IN.vertex;
					float mul = sin(baseWorldPos.x / _TransparentZone*PI/2);
                    pos.xyz *= mul < 0 ? 0 : mul;
                    OUT.vertex = UnityObjectToClipPos( pos);
                }
                else{
					OUT.vertex = UnityObjectToClipPos(IN.vertex);
				}
				OUT.screenPos = ComputeScreenPos(OUT.vertex);




				return OUT;
			}



			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = _Color;
                //c.a = sin(((pos > 1) ? PI ? PI: pos * PI));
                if(IN.screenPos.x < _TransparentZone || IN.screenPos.x > (1 - _TransparentZone))
                    c.a = sin(IN.screenPos.x / _TransparentZone*PI/2);
                else
                    c.a = 1;
                return c;
			}
		ENDCG
		}
	}
}