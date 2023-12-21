using System;
using System.Reflection;
using System.Reflection.Emit;

internal class Class59
{
	private static ModuleHandle moduleHandle_0 = typeof(Class59).Assembly.ManifestModule.ModuleHandle;

	public static void smethod_0(int int_0, int int_1, int int_2)
	{
		int_0--;
		int_1++;
		int_0 = (int_0 + 1) ^ 0x2FD004C0 ^ 0x9740ABF ^ 0x2FD004C0;
		int num = int_2 & 0xFF;
		int_2 ^= num;
		num += 15;
		RuntimeTypeHandle handle = moduleHandle_0.ResolveTypeHandle(int_0);
		int_1 = (int_1 - 1) ^ num ^ 0x1086F41D ^ num;
		RuntimeMethodHandle handle2 = moduleHandle_0.ResolveMethodHandle(int_1);
		int_2 = (int_2 | (num - 15)) ^ 0x2FD004C0;
		FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle(moduleHandle_0.ResolveFieldHandle(int_2));
		Type typeFromHandle = Type.GetTypeFromHandle(handle);
		MethodInfo methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(handle2);
		FieldInfo fieldInfo = fieldFromHandle;
		MethodInfo methodInfo2 = methodInfo;
		Type type = typeFromHandle;
		FieldInfo fieldInfo2 = fieldInfo;
		if (methodInfo2.IsStatic)
		{
			fieldInfo2.SetValue(null, Delegate.CreateDelegate(fieldInfo2.FieldType, methodInfo2));
			return;
		}
		ParameterInfo[] parameters = methodInfo2.GetParameters();
		int num2 = parameters.Length + 1;
		Type[] array = new Type[num2];
		array[0] = (methodInfo2.DeclaringType.IsValueType ? methodInfo2.DeclaringType.MakeByRefType() : typeof(object));
		for (int i = 1; i < num2; i++)
		{
			array[i] = parameters[i - 1].ParameterType;
		}
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo2.ReturnType, array, type, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		ILGenerator iLGenerator2 = iLGenerator;
		int num3 = num2;
		ILGenerator iLGenerator3 = iLGenerator2;
		for (int j = 1; j < num3; j++)
		{
			switch (j)
			{
			case 0:
				iLGenerator3.Emit(OpCodes.Ldarg_0);
				break;
			case 1:
				iLGenerator3.Emit(OpCodes.Ldarg_1);
				break;
			case 2:
				iLGenerator3.Emit(OpCodes.Ldarg_2);
				break;
			case 3:
				iLGenerator3.Emit(OpCodes.Ldarg_3);
				break;
			default:
				iLGenerator3.Emit(OpCodes.Ldarg_S, j);
				break;
			}
		}
		iLGenerator.Emit(fieldInfo2.IsAssembly ? OpCodes.Callvirt : OpCodes.Call, methodInfo2);
		iLGenerator.Emit(OpCodes.Ret);
		Delegate value = dynamicMethod.CreateDelegate(type);
		fieldInfo2.SetValue(null, value);
	}

	public static void smethod_1(int int_0, int int_1, int int_2, int int_3)
	{
		int_0--;
		int_3++;
		int_2--;
		int_0 = (int_0 + 1) ^ 0x1086F41D ^ 0x9740ABF ^ 0x1086F41D;
		int num = int_1 & 0xFF;
		int_1 ^= num;
		num += 15;
		RuntimeTypeHandle handle = moduleHandle_0.ResolveTypeHandle(int_0);
		int_3 = (int_3 - 1) ^ num ^ 0x2FD004C0 ^ num;
		int_1 = (int_1 | (num - 15)) ^ 0x1086F41D;
		FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle(moduleHandle_0.ResolveFieldHandle(int_3));
		int_2 = (int_2 + 1) ^ 0x2FD004C0 ^ 0x9740ABF ^ 0x2FD004C0;
		Type typeFromHandle = Type.GetTypeFromHandle(handle);
		MethodInfo methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(moduleHandle_0.ResolveMethodHandle(int_1), moduleHandle_0.ResolveTypeHandle(int_2));
		Type type = typeFromHandle;
		MethodInfo methodInfo2 = methodInfo;
		Type type2 = type;
		FieldInfo fieldInfo = fieldFromHandle;
		if (methodInfo2.IsStatic)
		{
			fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo2));
			return;
		}
		ParameterInfo[] parameters = methodInfo2.GetParameters();
		int num2 = parameters.Length + 1;
		Type[] array = new Type[num2];
		array[0] = (methodInfo2.DeclaringType.IsValueType ? methodInfo2.DeclaringType.MakeByRefType() : typeof(object));
		for (int i = 1; i < num2; i++)
		{
			array[i] = parameters[i - 1].ParameterType;
		}
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo2.ReturnType, array, type2, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		ILGenerator iLGenerator2 = iLGenerator;
		int num3 = num2;
		ILGenerator iLGenerator3 = iLGenerator2;
		for (int j = 1; j < num3; j++)
		{
			switch (j)
			{
			case 0:
				iLGenerator3.Emit(OpCodes.Ldarg_0);
				break;
			case 1:
				iLGenerator3.Emit(OpCodes.Ldarg_1);
				break;
			case 2:
				iLGenerator3.Emit(OpCodes.Ldarg_2);
				break;
			case 3:
				iLGenerator3.Emit(OpCodes.Ldarg_3);
				break;
			default:
				iLGenerator3.Emit(OpCodes.Ldarg_S, j);
				break;
			}
		}
		iLGenerator.Emit(fieldInfo.IsAssembly ? OpCodes.Callvirt : OpCodes.Call, methodInfo2);
		iLGenerator.Emit(OpCodes.Ret);
		Delegate value = dynamicMethod.CreateDelegate(type2);
		fieldInfo.SetValue(null, value);
	}

	public static void smethod_2(int int_0, int int_1, int int_2)
	{
		int_0++;
		int_1--;
		int_0 = (int_0 - 1) ^ 0x2FD004C0 ^ 0x9740ABF ^ 0x2FD004C0;
		int num = int_2 & 0xFF;
		int_2 ^= num;
		num += 15;
		RuntimeTypeHandle handle = moduleHandle_0.ResolveTypeHandle(int_0);
		int_1 = (int_1 + 1) ^ num ^ 0x9824A02 ^ num;
		RuntimeMethodHandle handle2 = moduleHandle_0.ResolveMethodHandle(int_1);
		int_2 = (int_2 | (num - 15)) ^ 0x2FD004C0;
		FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle(moduleHandle_0.ResolveFieldHandle(int_2));
		Type typeFromHandle = Type.GetTypeFromHandle(handle);
		ConstructorInfo constructorInfo = (ConstructorInfo)MethodBase.GetMethodFromHandle(handle2);
		FieldInfo fieldInfo = fieldFromHandle;
		ConstructorInfo constructorInfo2 = constructorInfo;
		Type type = typeFromHandle;
		FieldInfo fieldInfo2 = fieldInfo;
		ParameterInfo[] parameters = constructorInfo2.GetParameters();
		int num2 = parameters.Length;
		Type[] array = new Type[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, constructorInfo2.DeclaringType, array, type, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ILGenerator iLGenerator2 = iLGenerator;
		int num3 = num2;
		ILGenerator iLGenerator3 = iLGenerator2;
		for (int j = 0; j < num3; j++)
		{
			switch (j)
			{
			case 0:
				iLGenerator3.Emit(OpCodes.Ldarg_0);
				break;
			case 1:
				iLGenerator3.Emit(OpCodes.Ldarg_1);
				break;
			case 2:
				iLGenerator3.Emit(OpCodes.Ldarg_2);
				break;
			case 3:
				iLGenerator3.Emit(OpCodes.Ldarg_3);
				break;
			default:
				iLGenerator3.Emit(OpCodes.Ldarg_S, j);
				break;
			}
		}
		iLGenerator.Emit(OpCodes.Newobj, constructorInfo2);
		iLGenerator.Emit(OpCodes.Ret);
		Delegate value = dynamicMethod.CreateDelegate(type);
		fieldInfo2.SetValue(null, value);
	}

	public static void smethod_3(int int_0, int int_1, int int_2, int int_3)
	{
		int_0++;
		int_1--;
		int_2++;
		int_0 = (int_0 - 1) ^ 0x1086F41D ^ 0x9740ABF ^ 0x1086F41D;
		int num = int_3 & 0xFF;
		int_3 ^= num;
		num += 15;
		RuntimeTypeHandle handle = moduleHandle_0.ResolveTypeHandle(int_0);
		int_1 = (int_1 + 1) ^ num ^ 0x9824A02 ^ num;
		int_3 = (int_3 | (num - 15)) ^ 0x2FD004C0;
		FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle(moduleHandle_0.ResolveFieldHandle(int_3));
		int_2 = (int_2 - 1) ^ 0x1086F41D ^ 0x9740ABF ^ 0x1086F41D;
		Type typeFromHandle = Type.GetTypeFromHandle(handle);
		ConstructorInfo constructorInfo = (ConstructorInfo)MethodBase.GetMethodFromHandle(moduleHandle_0.ResolveMethodHandle(int_1), moduleHandle_0.ResolveTypeHandle(int_2));
		Type type = typeFromHandle;
		ConstructorInfo constructorInfo2 = constructorInfo;
		Type type2 = type;
		FieldInfo fieldInfo = fieldFromHandle;
		ParameterInfo[] parameters = constructorInfo2.GetParameters();
		int num2 = parameters.Length;
		Type[] array = new Type[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, constructorInfo2.DeclaringType, array, type2, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ILGenerator iLGenerator2 = iLGenerator;
		int num3 = num2;
		ILGenerator iLGenerator3 = iLGenerator2;
		for (int j = 0; j < num3; j++)
		{
			switch (j)
			{
			case 0:
				iLGenerator3.Emit(OpCodes.Ldarg_0);
				break;
			case 1:
				iLGenerator3.Emit(OpCodes.Ldarg_1);
				break;
			case 2:
				iLGenerator3.Emit(OpCodes.Ldarg_2);
				break;
			case 3:
				iLGenerator3.Emit(OpCodes.Ldarg_3);
				break;
			default:
				iLGenerator3.Emit(OpCodes.Ldarg_S, j);
				break;
			}
		}
		iLGenerator.Emit(OpCodes.Newobj, constructorInfo2);
		iLGenerator.Emit(OpCodes.Ret);
		Delegate value = dynamicMethod.CreateDelegate(type2);
		fieldInfo.SetValue(null, value);
	}
}
