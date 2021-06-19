Shader "Unlit/Bullet_Head"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Timer("Timer",float)=0
        _Color("COlor",Color)=(0,0,0,0)
        _Color_dim("COlor_dim",Color)=(0,0,0,0)

    }
    SubShader
    {
  ZTest Always
      Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "CanUseSpriteAtlas"="true" "PreviewType"="Plane" }
        LOD 100
        Cull Off
        Lighting Off
     
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
            float4 _MainTex_ST;
            float4 _Color;
            float4 _Color_dim;
            float _Timer;
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
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                
                if(col.x>0.1)
                {
                col=(_Color*sin(_Timer))+(_Color_dim*(1.0-sin(_Timer)));
                col.a=1.0f;

                }
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
