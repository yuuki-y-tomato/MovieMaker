Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _Thickness("Thickness",Range(0,0.5))=0.05
        
        _OutlineColor("Color",Color)=(0,0,0,0)
        
        _InsideColor("InsideColor",Color)=(0,0,0,0)

        _Opacity("Opacity",Range(0,1))=0.05

    }
    SubShader
    {
        Tags {  "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True"}
        LOD 100
     Blend SrcAlpha OneMinusSrcAlpha
              ZWrite off

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
            float _Opacity;

            sampler2D _MainTex;
            float _Thickness;
            float4 _MainTex_ST;
            float4 _OutlineColor;
            fixed4 _InsideColor;
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
                fixed4 col = _InsideColor;
                if(i.uv.x>1-_Thickness||i.uv.x<_Thickness||i.uv.y>1-_Thickness||i.uv.y<_Thickness)
                {
                    col=_OutlineColor;
                }
                col*=_OutlineColor.a;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
