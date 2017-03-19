// 2017319
// notepad++插件：https://forum.unity3d.com/threads/shaderlab-highlighting-in-notepad.86956/
// 参考文章：http://gad.qq.com/program/translateview/7173930

// 后面继续学习：4. 纹理

Shader "Unlit/MyFirstShader"
{
	// 着色器属性
	Properties
	{
		// 声明属性并赋默认值
		_Tint("Tint", Color) = (1, 0, 0, 1)
	}

	// 子着色器
	SubShader
	{
		// 着色器通道
		Pass
		{
			// 着色器程序
			CGPROGRAM

			// 通过pragma指令告诉编译器使用哪些程序
			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			// 使用#include指令将不同文件的内容加载到当前文件
			#include "UnityCG.cginc"

			// 使用属性前需要先声明
			float4 _Tint;

			// 使用结构使代码更整洁
			struct Interpolators {
				float4 position : SV_POSITION;
				float3 localPosition : TEXCOORD0;
			};

			float4 MyVertexProgram(float4 position:POSITION, out float3 localPosition:TEXCOORD0):SV_POSITION
			{
				// return position;
				localPosition = position.xyz;
				return mul(UNITY_MATRIX_MVP, position);
			}

			float4 MyFragmentProgram(float4 position:POSITION, float3 localPosition: TEXCOORD0):SV_TARGET
			{
				//return 0;
				//return float4(1,1,0,1);
				//return _Tint;
				//return float4(localPosition + 0.5, 1);
				return float4(localPosition + 0.5, 1) * _Tint;
			}
			ENDCG
		}
	}
}
