Shader "Custom/pupil"
{
	Properties
	{
        _PupilTex("Texture", 2D) = "white" {}
        _EyeMaskTex("Texture", 2D) = "white" {}
        _XOffset("X Offset", float) = 0
        _YOffset("Y Offset", float) = 0
        _Scale("Scale", float) = 1
	}
	SubShader
	{
        Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
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
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _PupilTex;
            sampler2D _EyeMaskTex;
			float4 _PupilTex_ST;
            float _XOffset;
            float _YOffset;
            float _Scale;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _PupilTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
                // sample texture and return it
                float2 scaleCenter = float2(0.5f, 0.5f);
                float2 finalUv = (i.uv + float2(_XOffset, _YOffset) - scaleCenter) * _Scale + scaleCenter;
                fixed4 col = tex2D(_PupilTex, finalUv);
                fixed4 mask = tex2D(_EyeMaskTex, i.uv);
                col *= mask;
                return col;
            }
			ENDCG
		}
	}
}
