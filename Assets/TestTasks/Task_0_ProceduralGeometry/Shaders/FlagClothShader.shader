// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/FlagClothShader"
{
    Properties
    {
        // we have removed support for texture tiling/offset,
        // so make them not be displayed in material inspector
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        [Toggle(IsAnimatedVertex)] _IsAnimatedVertex("Is Animated Vertex", Int) = 0
        [Toggle(IsAnimatedUV)] _IsAnimatedUV("Is Animated UV", Int) = 0
        _Speed ("Speed", Float) = 0
        _Frequency ("Frequency", Float) = 0
        _Amplitude ("Amplitude", Float) = 0
        
        _UVScrollSpeed ("UV Scroll Speed", Float) = 0
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            // use "vert" function as the vertex shader
            #pragma vertex vert
            // use "frag" function as the pixel (fragment) shader
            #pragma fragment frag

            #pragma multi_compile __ IsAnimatedVertex
            #pragma multi_compile __ IsAnimatedUV

            #include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			float _Speed;
			float _Frequency;
			float _Amplitude;
			float _UVScrollSpeed;

            int _IsAnimatedVertex;
            int _IsAnimatedUV;

            // vertex shader
            v2f vert (appdata_base v)
            {
                v2f o;
                
                if(_IsAnimatedVertex > 0)
                {
                    v.vertex.y += cos((v.vertex.x + _Time.y * _Speed) * _Frequency) * _Amplitude * (v.vertex.x - 5);
                }

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                
                return o;
            }
            
            

            // pixel shader; returns low precision ("fixed4" type)
            // color ("SV_Target" semantic)
            fixed4 frag (v2f i) : SV_Target
            {

                float2 uv = i.uv;
                if(_IsAnimatedUV > 0)
                {
                    uv.x += _UVScrollSpeed;
                }
                
                fixed4 col = tex2D(_MainTex, uv);

                
                
                return col;
            }
            ENDCG
        }
    }
}