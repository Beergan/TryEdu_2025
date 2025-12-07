#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
237,
249,
250,
251,
252,
253,
254,
255,
256,
257,
260,
261,
262,
437,
438,
439,
468,
469,
470,
490,
491,
492,
493,
610,
611,
612,
615,
659,
660,
661,
664,
665,
667,
669,
670,
672,
677,
685,
686,
687,
688,
689,
690,
691,
692,
693,
694,
695,
696,
697,
698,
699,
700,
701,
703,
704,
705,
706,
707,
708,
709,
805,
806,
807,
808,
809,
810,
811,
812,
813,
814,
815,
816,
817,
818,
819,
820,
821,
823,
824,
825,
826,
827,
828,
829,
896,
897,
966,
973,
976,
978,
983,
984,
986,
987,
991,
992,
994,
996,
997,
1000,
1001,
1002,
1005,
1007,
1010,
1012,
1014,
1023,
1091,
1093,
1095,
1105,
1106,
1107,
1108,
1110,
1117,
1118,
1119,
1120,
1121,
1129,
1130,
1131,
1135,
1136,
1138,
1142,
1143,
1144,
1428,
1623,
1624,
10109,
10110,
10112,
10113,
10114,
10115,
10116,
10118,
10120,
10122,
10123,
10134,
10136,
10144,
10146,
10148,
10150,
10201,
10207,
10208,
10210,
10211,
10212,
10213,
10214,
10216,
10218,
11408,
11412,
11414,
11415,
11416,
11417,
11680,
11681,
11682,
11683,
11704,
11705,
11706,
11707,
11709,
11711,
11712,
11770,
11864,
11866,
11868,
11878,
11879,
11880,
11881,
11882,
12377,
12378,
12383,
12384,
12421,
12441,
12448,
12455,
12466,
12470,
12495,
12520,
12586,
12588,
12599,
12601,
12602,
12603,
12610,
12624,
12644,
12645,
12653,
12655,
12662,
12663,
12666,
12668,
12673,
12680,
12681,
12688,
12690,
12701,
12704,
12707,
12708,
12709,
12721,
12731,
12737,
12738,
12739,
12741,
12742,
12760,
12762,
12778,
12800,
12801,
12802,
12827,
12832,
12833,
12834,
12871,
12872,
13454,
13468,
13571,
13572,
13836,
13837,
13845,
13846,
13847,
13853,
13963,
14664,
14665,
15408,
15410,
15411,
15416,
15426,
16445,
16466,
16468,
16470,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
void ves_icall_System_Enum_InternalBoxEnum_raw (int,int,int64_t,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
int ves_icall_System_GC_GetCollectionCount (int);
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
void ves_icall_System_GC_WaitForPendingFinalizers ();
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
int64_t ves_icall_System_GC_GetTotalMemory (int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Acosh (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Asinh (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Atanh (double);
double ves_icall_System_Math_Cbrt (double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Exp (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_FusedMultiplyAdd (double,double,double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Acos (float);
float ves_icall_System_MathF_Acosh (float);
float ves_icall_System_MathF_Asin (float);
float ves_icall_System_MathF_Asinh (float);
float ves_icall_System_MathF_Atan (float);
float ves_icall_System_MathF_Atan2 (float,float);
float ves_icall_System_MathF_Atanh (float);
float ves_icall_System_MathF_Cbrt (float);
float ves_icall_System_MathF_Ceiling (float);
float ves_icall_System_MathF_Cos (float);
float ves_icall_System_MathF_Cosh (float);
float ves_icall_System_MathF_Exp (float);
float ves_icall_System_MathF_Floor (float);
float ves_icall_System_MathF_Log (float);
float ves_icall_System_MathF_Log10 (float);
float ves_icall_System_MathF_Pow (float,float);
float ves_icall_System_MathF_Sin (float);
float ves_icall_System_MathF_Sinh (float);
float ves_icall_System_MathF_Sqrt (float);
float ves_icall_System_MathF_Tan (float);
float ves_icall_System_MathF_Tanh (float);
float ves_icall_System_MathF_FusedMultiplyAdd (float,float,float);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_System_RuntimeType_AllocateValueType_raw (int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsComObject_raw (int,int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
void ves_icall_System_Threading_Thread_StartInternal_raw (int,int,int);
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_DestroyStructure_raw (int,int,int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
void ves_icall_System_Runtime_InteropServices_Marshal_PtrToStructureInternal_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetFunctionPointerForDelegateInternal_raw (int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw (int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
int ves_icall_GetCurrentMethod_raw (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodBodyInternal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw (int,int);
void ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw (int,int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
int ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_RuntimePropertyInfo_GetTypeModifiers_raw (int,int,int,int);
int ves_icall_property_info_get_default_value_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_CustomAttributeBuilder_GetBlob_raw (int,int,int,int,int,int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_Debugger_IsLogging ();
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 237,
ves_icall_System_Array_InternalCreate,
// token 249,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 250,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 251,
ves_icall_System_Array_CanChangePrimitive,
// token 252,
ves_icall_System_Array_FastCopy,
// token 253,
ves_icall_System_Array_GetLengthInternal_raw,
// token 254,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 255,
ves_icall_System_Array_GetGenericValue_icall,
// token 256,
ves_icall_System_Array_GetValueImpl_raw,
// token 257,
ves_icall_System_Array_SetGenericValue_icall,
// token 260,
ves_icall_System_Array_SetValueImpl_raw,
// token 261,
ves_icall_System_Array_InitializeInternal_raw,
// token 262,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 437,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 438,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 439,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 468,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 469,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 470,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 490,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 491,
ves_icall_System_Enum_InternalBoxEnum_raw,
// token 492,
ves_icall_System_Enum_InternalGetCorElementType,
// token 493,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 610,
ves_icall_System_Environment_get_ProcessorCount,
// token 611,
ves_icall_System_Environment_get_TickCount,
// token 612,
ves_icall_System_Environment_get_TickCount64,
// token 615,
ves_icall_System_Environment_FailFast_raw,
// token 659,
ves_icall_System_GC_GetCollectionCount,
// token 660,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 661,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 664,
ves_icall_System_GC_WaitForPendingFinalizers,
// token 665,
ves_icall_System_GC_SuppressFinalize_raw,
// token 667,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 669,
ves_icall_System_GC_GetTotalMemory,
// token 670,
ves_icall_System_GC_GetGCMemoryInfo,
// token 672,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 677,
ves_icall_System_Object_MemberwiseClone_raw,
// token 685,
ves_icall_System_Math_Acos,
// token 686,
ves_icall_System_Math_Acosh,
// token 687,
ves_icall_System_Math_Asin,
// token 688,
ves_icall_System_Math_Asinh,
// token 689,
ves_icall_System_Math_Atan,
// token 690,
ves_icall_System_Math_Atan2,
// token 691,
ves_icall_System_Math_Atanh,
// token 692,
ves_icall_System_Math_Cbrt,
// token 693,
ves_icall_System_Math_Ceiling,
// token 694,
ves_icall_System_Math_Cos,
// token 695,
ves_icall_System_Math_Cosh,
// token 696,
ves_icall_System_Math_Exp,
// token 697,
ves_icall_System_Math_Floor,
// token 698,
ves_icall_System_Math_Log,
// token 699,
ves_icall_System_Math_Log10,
// token 700,
ves_icall_System_Math_Pow,
// token 701,
ves_icall_System_Math_Sin,
// token 703,
ves_icall_System_Math_Sinh,
// token 704,
ves_icall_System_Math_Sqrt,
// token 705,
ves_icall_System_Math_Tan,
// token 706,
ves_icall_System_Math_Tanh,
// token 707,
ves_icall_System_Math_FusedMultiplyAdd,
// token 708,
ves_icall_System_Math_Log2,
// token 709,
ves_icall_System_Math_ModF,
// token 805,
ves_icall_System_MathF_Acos,
// token 806,
ves_icall_System_MathF_Acosh,
// token 807,
ves_icall_System_MathF_Asin,
// token 808,
ves_icall_System_MathF_Asinh,
// token 809,
ves_icall_System_MathF_Atan,
// token 810,
ves_icall_System_MathF_Atan2,
// token 811,
ves_icall_System_MathF_Atanh,
// token 812,
ves_icall_System_MathF_Cbrt,
// token 813,
ves_icall_System_MathF_Ceiling,
// token 814,
ves_icall_System_MathF_Cos,
// token 815,
ves_icall_System_MathF_Cosh,
// token 816,
ves_icall_System_MathF_Exp,
// token 817,
ves_icall_System_MathF_Floor,
// token 818,
ves_icall_System_MathF_Log,
// token 819,
ves_icall_System_MathF_Log10,
// token 820,
ves_icall_System_MathF_Pow,
// token 821,
ves_icall_System_MathF_Sin,
// token 823,
ves_icall_System_MathF_Sinh,
// token 824,
ves_icall_System_MathF_Sqrt,
// token 825,
ves_icall_System_MathF_Tan,
// token 826,
ves_icall_System_MathF_Tanh,
// token 827,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 828,
ves_icall_System_MathF_Log2,
// token 829,
ves_icall_System_MathF_ModF,
// token 896,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 897,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 966,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 973,
ves_icall_RuntimeType_make_array_type_raw,
// token 976,
ves_icall_RuntimeType_make_byref_type_raw,
// token 978,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 983,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 984,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 986,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 987,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 991,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 992,
ves_icall_System_RuntimeType_AllocateValueType_raw,
// token 994,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 996,
ves_icall_System_RuntimeType_getFullName_raw,
// token 997,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 1000,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 1001,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 1002,
ves_icall_RuntimeType_GetFields_native_raw,
// token 1005,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 1007,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 1010,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 1012,
ves_icall_RuntimeType_GetName_raw,
// token 1014,
ves_icall_RuntimeType_GetNamespace_raw,
// token 1023,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1091,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1093,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1095,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1105,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1106,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1107,
ves_icall_RuntimeTypeHandle_IsComObject_raw,
// token 1108,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1110,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1117,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1118,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1119,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1120,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1121,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1129,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1130,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1131,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1135,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1136,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1138,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1142,
ves_icall_System_String_FastAllocateString_raw,
// token 1143,
ves_icall_System_String_InternalIsInterned_raw,
// token 1144,
ves_icall_System_String_InternalIntern_raw,
// token 1428,
ves_icall_System_Type_internal_from_handle_raw,
// token 1623,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1624,
ves_icall_System_ValueType_Equals_raw,
// token 10109,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 10110,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 10112,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 10113,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 10114,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 10115,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 10116,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 10118,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 10120,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 10122,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 10123,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 10134,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 10136,
mono_monitor_exit_icall_raw,
// token 10144,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 10146,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 10148,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 10150,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 10201,
ves_icall_System_Threading_Thread_StartInternal_raw,
// token 10207,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 10208,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 10210,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 10211,
ves_icall_System_Threading_Thread_GetState_raw,
// token 10212,
ves_icall_System_Threading_Thread_SetState_raw,
// token 10213,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 10214,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 10216,
ves_icall_System_Threading_Thread_YieldInternal,
// token 10218,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 11408,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 11412,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 11414,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 11415,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 11416,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 11417,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 11680,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 11681,
ves_icall_System_GCHandle_InternalFree_raw,
// token 11682,
ves_icall_System_GCHandle_InternalGet_raw,
// token 11683,
ves_icall_System_GCHandle_InternalSet_raw,
// token 11704,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 11705,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 11706,
ves_icall_System_Runtime_InteropServices_Marshal_DestroyStructure_raw,
// token 11707,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 11709,
ves_icall_System_Runtime_InteropServices_Marshal_PtrToStructureInternal_raw,
// token 11711,
ves_icall_System_Runtime_InteropServices_Marshal_GetFunctionPointerForDelegateInternal_raw,
// token 11712,
ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw,
// token 11770,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 11864,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 11866,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw,
// token 11868,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 11878,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 11879,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 11880,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 11881,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw,
// token 11882,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 12377,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 12378,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 12383,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 12384,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 12421,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 12441,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 12448,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 12455,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 12466,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 12470,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 12495,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 12520,
ves_icall_GetCurrentMethod_raw,
// token 12586,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 12588,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 12599,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 12601,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 12602,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 12603,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 12610,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 12624,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 12644,
ves_icall_reflection_get_token_raw,
// token 12645,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 12653,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 12655,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 12662,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 12663,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 12666,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 12668,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 12673,
ves_icall_reflection_get_token_raw,
// token 12680,
ves_icall_get_method_info_raw,
// token 12681,
ves_icall_get_method_attributes,
// token 12688,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 12690,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 12701,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodBodyInternal_raw,
// token 12704,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 12707,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 12708,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 12709,
ves_icall_reflection_get_token_raw,
// token 12721,
ves_icall_InternalInvoke_raw,
// token 12731,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 12737,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 12738,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 12739,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 12741,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 12742,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 12760,
ves_icall_InvokeClassConstructor_raw,
// token 12762,
ves_icall_InternalInvoke_raw,
// token 12778,
ves_icall_reflection_get_token_raw,
// token 12800,
ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw,
// token 12801,
ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw,
// token 12802,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 12827,
ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw,
// token 12832,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 12833,
ves_icall_RuntimePropertyInfo_GetTypeModifiers_raw,
// token 12834,
ves_icall_property_info_get_default_value_raw,
// token 12871,
ves_icall_reflection_get_token_raw,
// token 12872,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 13454,
ves_icall_CustomAttributeBuilder_GetBlob_raw,
// token 13468,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 13571,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 13572,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 13836,
ves_icall_ModuleBuilder_basic_init_raw,
// token 13837,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 13845,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 13846,
ves_icall_ModuleBuilder_getToken_raw,
// token 13847,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 13853,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 13963,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 14664,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 14665,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 15408,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 15410,
ves_icall_System_Diagnostics_Debugger_IsLogging,
// token 15411,
ves_icall_System_Diagnostics_Debugger_Log,
// token 15416,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 15426,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 16445,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 16466,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 16468,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 16470,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
0,
4,
4,
0,
4,
4,
0,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
};
