Shader "Unlit/Turret_Meter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Meter("Meter",Range(0,1))=0
        _Outline("Outline",Range(0,1))=0
        _BGcolor("BGColor",Color)=(0,0,0,0)
        _Fillcolor("FillColor",Color)=(0,0,0,0)
        _Timer("Timer",float)=0
        
    }
    SubShader
    {
      Tags { "QUEUE"="Transparent" "RenderType"="Transparent" "CanUseSpriteAtlas"="true" "PreviewType"="Plane" }
        LOD 100
       // Cull Off
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
            float _Outline;
            float _Meter;
            float4 _Fillcolor;
            float4 _BGcolor;
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
                fixed4 col;// = tex2D(_MainTex, i.uv);

                if(i.uv.x>1-_Outline||i.uv.x<_Outline||i.uv.y>1-_Outline||i.uv.y<_Outline)
                {
                    return float4(0,0,0,1);
                }
                col=(_BGcolor*!(i.uv.y<_Meter));
                col+=(_Fillcolor*(i.uv.y<_Meter))*((sin(_Timer-i.uv.y*10)/4)+0.75);
                
                col.a=1;

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;//*=(i.uv.y<_Meter);
            }
            ENDCG
        }
    }

    
}
