Shader "Hidden/Fader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Fade("Fade",Range(0,1))=0.0
        _Overlay("OverlayTex", 2D)="white"{}
        _Rotation("Rotation",float)=0
        _FadeMult("FadeMult",Range(1,2))=1
    }
    SubShader
    {
        // No culling or depth
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _Overlay;

            sampler2D _MainTex;
            float _Fade;
            float _Rotation;
            float _FadeMult;

            fixed4 frag (v2f i) : SV_Target
            {

                float2 rotatedUV=float2
                (
                    i.uv.x*cos(_Rotation)-i.uv.y*sin(_Rotation),
                    i.uv.x*sin(_Rotation)+i.uv.y*cos(_Rotation)

                );

                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 ol=tex2D(_Overlay,rotatedUV);
                ol*=(rotatedUV.x>_Fade*_FadeMult);
        
//            col+=ol;
            if((rotatedUV.x>_Fade*_FadeMult))
            {
                col=ol;
            }

                // just invert the colors
                return col;
            }
            ENDCG
        }
    }
}
