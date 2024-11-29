// Assets/Shaders/EdgeDetectionShader.shader
Shader "Custom/EdgeDetectionShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _EdgeColor ("Edge Color", Color) = (1,1,1,1)
        _EdgeThreshold ("Edge Threshold", Range(0.0, 1.0)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

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

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float4 _EdgeColor;
            float _EdgeThreshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float3 color = tex2D(_MainTex, i.uv).rgb;

                // 计算边缘检测
                float3 dx = tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, 0)).rgb - tex2D(_MainTex, i.uv - float2(_MainTex_TexelSize.x, 0)).rgb;
                float3 dy = tex2D(_MainTex, i.uv + float2(0, _MainTex_TexelSize.y)).rgb - tex2D(_MainTex, i.uv - float2(0, _MainTex_TexelSize.y)).rgb;

                float edge = length(dx) + length(dy);
                if (edge > _EdgeThreshold)
                {
                    return _EdgeColor;
                }

                return float4(color, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}