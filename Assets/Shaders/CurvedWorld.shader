Shader "Dungeon/CurvedWorld"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _VCurvature ("_VCurvature", float) = 0.0
        _HCurvature ("_HCurvature", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert addshadow

            uniform sampler2D _MainTex;
            uniform float _VCurvature;
            uniform float _HCurvature;

            struct Input 
            {
                float2 uv_MainTex;
            };

            void vert(inout appdata_full v)
			{
                float4 worldSpace = mul(unity_ObjectToWorld, v.vertex);
                worldSpace.xyz -= _WorldSpaceCameraPos.xyz;
                worldSpace = float4(0.0f, -_VCurvature * worldSpace.z * worldSpace.z, 0.0f, 0.0f);
                v.vertex += mul(unity_WorldToObject, worldSpace);
            }

            void surf(Input input, inout SurfaceOutput output)
            {
                half4 c = tex2D(_MainTex, input.uv_MainTex);
                output.Albedo = c.rgb;
                output.Alpha = c.a;
            }

        ENDCG
    }
}
