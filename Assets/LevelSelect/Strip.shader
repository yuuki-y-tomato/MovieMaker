Shader "Unlit/Strip"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _time("time",float)=0.0
        _repeat("repeat",float)=1.0
        _slider("slider",Range(0,1))=1

    }
    SubShader
    {
         Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "CanUseSpriteAtlas"="true" "PreviewType"="Plane" }
        LOD 100
        Cull Off
        Lighting Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _time;
            float _repeat;
            float4 _MainTex_ST;
            float _slider;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 o=i.uv;
                o.y+=_time*_repeat;
                // sample the texture
                fixed4 col = tex2D(_MainTex, o);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col*(i.uv.y<_slider*7);
            }
            ENDCG
        }
    }
}
