Shader "Custom/celeyebrow"
{
	Properties
	{
        _MainTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
        Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

		Pass
        {
            Stencil
            {
                Ref 1
                Comp Equal
                Pass replace
                ZFail IncrSat
            }
        }
        Pass
        {
            ZTest Greater
            ZWrite On

            Stencil
            {
                Ref 2
                Comp Equal
            }

            Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            //
            CGPROGRAM
            // use "vert" function as the vertex shader
            #pragma vertex vert
            // use "frag" function as the pixel (fragment) shader
            #pragma fragment frag
            #include "UnityCG.cginc"


            // vertex shader outputs ("vertex to fragment")
            struct v2f
            {
                float2 uv : TEXCOORD0; // texture coordinate
                float4 vertex : SV_POSITION; // clip space position
            };

            // vertex shader
            v2f vert(appdata_base v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            // texture we will sample
            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
        Pass
        {
            Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            //
            CGPROGRAM
            // use "vert" function as the vertex shader
            #pragma vertex vert
            // use "frag" function as the pixel (fragment) shader
            #pragma fragment frag
            #include "UnityCG.cginc"


            // vertex shader outputs ("vertex to fragment")
            struct v2f
            {
                float2 uv : TEXCOORD0; // texture coordinate
                float4 vertex : SV_POSITION; // clip space position
            };

            // vertex shader
            v2f vert(appdata_base v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            // texture we will sample
            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
	}
}
