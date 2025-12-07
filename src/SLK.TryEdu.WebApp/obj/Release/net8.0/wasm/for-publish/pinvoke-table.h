// GENERATED FILE, DO NOT MODIFY

int CompressionNative_Crc32 (int,int,int);
int CompressionNative_Deflate (int,int);
int CompressionNative_DeflateEnd (int);
int CompressionNative_DeflateInit2_ (int,int,int,int,int,int);
int CompressionNative_Inflate (int,int);
int CompressionNative_InflateEnd (int);
int CompressionNative_InflateInit2_ (int,int);
void GlobalizationNative_ChangeCase (int,int,int,int,int);
void GlobalizationNative_ChangeCaseInvariant (int,int,int,int,int);
void GlobalizationNative_ChangeCaseTurkish (int,int,int,int,int);
void GlobalizationNative_CloseSortHandle (int);
int GlobalizationNative_CompareString (int,int,int,int,int,int);
int GlobalizationNative_EndsWith (int,int,int,int,int,int,int);
int GlobalizationNative_EnumCalendarInfo (int,int,int,int,int);
int GlobalizationNative_GetCalendarInfo (int,int,int,int,int);
int GlobalizationNative_GetCalendars (int,int,int);
int GlobalizationNative_GetDefaultLocaleName (int,int);
int GlobalizationNative_GetJapaneseEraStartDate (int,int,int,int);
int GlobalizationNative_GetLatestJapaneseEra ();
int GlobalizationNative_GetLocaleInfoGroupingSizes (int,int,int,int);
int GlobalizationNative_GetLocaleInfoInt (int,int,int);
int GlobalizationNative_GetLocaleInfoString (int,int,int,int,int);
int GlobalizationNative_GetLocaleName (int,int,int);
int GlobalizationNative_GetLocales (int,int);
int GlobalizationNative_GetLocaleTimeFormat (int,int,int,int);
int GlobalizationNative_GetSortHandle (int,int);
int GlobalizationNative_GetSortKey (int,int,int,int,int,int);
int GlobalizationNative_IndexOf (int,int,int,int,int,int,int);
void GlobalizationNative_InitICUFunctions (int,int,int,int);
void GlobalizationNative_InitOrdinalCasingPage (int,int);
int GlobalizationNative_IsNormalized (int,int,int);
int GlobalizationNative_IsPredefinedLocale (int);
int GlobalizationNative_LastIndexOf (int,int,int,int,int,int,int);
int GlobalizationNative_LoadICU ();
int GlobalizationNative_NormalizeString (int,int,int,int,int);
int GlobalizationNative_StartsWith (int,int,int,int,int,int,int);
int GlobalizationNative_ToAscii (int,int,int,int,int);
int GlobalizationNative_ToUnicode (int,int,int,int,int);
int SystemNative_CanGetHiddenFlag ();
int SystemNative_Close (int);
int SystemNative_CloseDir (int);
int SystemNative_ConvertErrorPalToPlatform (int);
int SystemNative_ConvertErrorPlatformToPal (int);
int SystemNative_Dup (int);
int SystemNative_FAllocate (int,int64_t,int64_t);
int SystemNative_FLock (int,int);
void SystemNative_Free (int);
int SystemNative_FStat (int,int);
int SystemNative_FSync (int);
int SystemNative_FTruncate (int,int64_t);
int SystemNative_GetCryptographicallySecureRandomBytes (int,int);
int SystemNative_GetCwd (int,int);
int SystemNative_GetEnv (int);
int SystemNative_GetErrNo ();
int SystemNative_GetFileSystemType (int);
void SystemNative_GetNonCryptographicallySecureRandomBytes (int,int);
int SystemNative_GetReadDirRBufferSize ();
int64_t SystemNative_GetSystemTimeAsTicks ();
uint64_t SystemNative_GetTimestamp ();
int SystemNative_GetTimeZoneData (int,int);
int SystemNative_LChflagsCanSetHiddenFlag ();
void SystemNative_LowLevelMonitor_Acquire (int);
int SystemNative_LowLevelMonitor_Create ();
void SystemNative_LowLevelMonitor_Destroy (int);
void SystemNative_LowLevelMonitor_Release (int);
void SystemNative_LowLevelMonitor_Signal_Release (int);
int SystemNative_LowLevelMonitor_TimedWait (int,int);
void SystemNative_LowLevelMonitor_Wait (int);
int64_t SystemNative_LSeek (int,int64_t,int);
int SystemNative_LStat (int,int);
int SystemNative_Malloc (int);
int SystemNative_MkDir (int,int);
int SystemNative_Open (int,int,int);
int SystemNative_OpenDir (int);
int SystemNative_PosixFAdvise (int,int64_t,int64_t,int);
int SystemNative_PRead (int,int,int,int64_t);
int64_t SystemNative_PReadV (int,int,int,int64_t);
int SystemNative_PWrite (int,int,int,int64_t);
int64_t SystemNative_PWriteV (int,int,int,int64_t);
int SystemNative_Read (int,int,int);
int SystemNative_ReadDirR (int,int,int,int);
int SystemNative_ReadLink (int,int,int);
int SystemNative_Realloc (int,int);
int SystemNative_RmDir (int);
int SystemNative_SchedGetCpu ();
void SystemNative_SetErrNo (int);
int SystemNative_Stat (int,int);
int SystemNative_StrErrorR (int,int,int);
void SystemNative_SysLog (int,int,int);
int SystemNative_Unlink (int);
int SystemNative_Write (int,int,int);
static PinvokeImport libSystem_Native_imports [] = {
{"SystemNative_CanGetHiddenFlag", SystemNative_CanGetHiddenFlag}, // System.Private.CoreLib
{"SystemNative_Close", SystemNative_Close}, // System.Private.CoreLib
{"SystemNative_CloseDir", SystemNative_CloseDir}, // System.Private.CoreLib
{"SystemNative_ConvertErrorPalToPlatform", SystemNative_ConvertErrorPalToPlatform}, // System.Console, System.Private.CoreLib
{"SystemNative_ConvertErrorPlatformToPal", SystemNative_ConvertErrorPlatformToPal}, // System.Console, System.Private.CoreLib
{"SystemNative_Dup", SystemNative_Dup}, // System.Console
{"SystemNative_FAllocate", SystemNative_FAllocate}, // System.Private.CoreLib
{"SystemNative_FLock", SystemNative_FLock}, // System.Private.CoreLib
{"SystemNative_Free", SystemNative_Free}, // System.Private.CoreLib
{"SystemNative_FStat", SystemNative_FStat}, // System.Private.CoreLib
{"SystemNative_FSync", SystemNative_FSync}, // System.Private.CoreLib
{"SystemNative_FTruncate", SystemNative_FTruncate}, // System.Private.CoreLib
{"SystemNative_GetCryptographicallySecureRandomBytes", SystemNative_GetCryptographicallySecureRandomBytes}, // System.Private.CoreLib, System.Security.Cryptography
{"SystemNative_GetCwd", SystemNative_GetCwd}, // System.Private.CoreLib
{"SystemNative_GetEnv", SystemNative_GetEnv}, // System.Private.CoreLib
{"SystemNative_GetErrNo", SystemNative_GetErrNo}, // System.Private.CoreLib
{"SystemNative_GetFileSystemType", SystemNative_GetFileSystemType}, // System.Private.CoreLib
{"SystemNative_GetNonCryptographicallySecureRandomBytes", SystemNative_GetNonCryptographicallySecureRandomBytes}, // System.Private.CoreLib
{"SystemNative_GetReadDirRBufferSize", SystemNative_GetReadDirRBufferSize}, // System.Private.CoreLib
{"SystemNative_GetSystemTimeAsTicks", SystemNative_GetSystemTimeAsTicks}, // System.Private.CoreLib
{"SystemNative_GetTimestamp", SystemNative_GetTimestamp}, // System.Private.CoreLib
{"SystemNative_GetTimeZoneData", SystemNative_GetTimeZoneData}, // System.Private.CoreLib
{"SystemNative_LChflagsCanSetHiddenFlag", SystemNative_LChflagsCanSetHiddenFlag}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_Acquire", SystemNative_LowLevelMonitor_Acquire}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_Create", SystemNative_LowLevelMonitor_Create}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_Destroy", SystemNative_LowLevelMonitor_Destroy}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_Release", SystemNative_LowLevelMonitor_Release}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_Signal_Release", SystemNative_LowLevelMonitor_Signal_Release}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_TimedWait", SystemNative_LowLevelMonitor_TimedWait}, // System.Private.CoreLib
{"SystemNative_LowLevelMonitor_Wait", SystemNative_LowLevelMonitor_Wait}, // System.Private.CoreLib
{"SystemNative_LSeek", SystemNative_LSeek}, // System.Private.CoreLib
{"SystemNative_LStat", SystemNative_LStat}, // System.Private.CoreLib
{"SystemNative_Malloc", SystemNative_Malloc}, // System.Private.CoreLib
{"SystemNative_MkDir", SystemNative_MkDir}, // System.Private.CoreLib
{"SystemNative_Open", SystemNative_Open}, // System.Private.CoreLib
{"SystemNative_OpenDir", SystemNative_OpenDir}, // System.Private.CoreLib
{"SystemNative_PosixFAdvise", SystemNative_PosixFAdvise}, // System.Private.CoreLib
{"SystemNative_PRead", SystemNative_PRead}, // System.Private.CoreLib
{"SystemNative_PReadV", SystemNative_PReadV}, // System.Private.CoreLib
{"SystemNative_PWrite", SystemNative_PWrite}, // System.Private.CoreLib
{"SystemNative_PWriteV", SystemNative_PWriteV}, // System.Private.CoreLib
{"SystemNative_Read", SystemNative_Read}, // System.Private.CoreLib
{"SystemNative_ReadDirR", SystemNative_ReadDirR}, // System.Private.CoreLib
{"SystemNative_ReadLink", SystemNative_ReadLink}, // System.Private.CoreLib
{"SystemNative_Realloc", SystemNative_Realloc}, // System.Private.CoreLib
{"SystemNative_RmDir", SystemNative_RmDir}, // System.Private.CoreLib
{"SystemNative_SchedGetCpu", SystemNative_SchedGetCpu}, // System.Private.CoreLib
{"SystemNative_SetErrNo", SystemNative_SetErrNo}, // System.Private.CoreLib
{"SystemNative_Stat", SystemNative_Stat}, // System.Private.CoreLib
{"SystemNative_StrErrorR", SystemNative_StrErrorR}, // System.Console, System.Private.CoreLib
{"SystemNative_SysLog", SystemNative_SysLog}, // System.Private.CoreLib
{"SystemNative_Unlink", SystemNative_Unlink}, // System.Private.CoreLib
{"SystemNative_Write", SystemNative_Write}, // System.Console, System.Private.CoreLib
{NULL, NULL}
};
static PinvokeImport libSystem_IO_Compression_Native_imports [] = {
{"CompressionNative_Crc32", CompressionNative_Crc32}, // System.IO.Compression
{"CompressionNative_Deflate", CompressionNative_Deflate}, // System.IO.Compression
{"CompressionNative_DeflateEnd", CompressionNative_DeflateEnd}, // System.IO.Compression
{"CompressionNative_DeflateInit2_", CompressionNative_DeflateInit2_}, // System.IO.Compression
{"CompressionNative_Inflate", CompressionNative_Inflate}, // System.IO.Compression
{"CompressionNative_InflateEnd", CompressionNative_InflateEnd}, // System.IO.Compression
{"CompressionNative_InflateInit2_", CompressionNative_InflateInit2_}, // System.IO.Compression
{NULL, NULL}
};
static PinvokeImport libSystem_Globalization_Native_imports [] = {
{"GlobalizationNative_ChangeCase", GlobalizationNative_ChangeCase}, // System.Private.CoreLib
{"GlobalizationNative_ChangeCaseInvariant", GlobalizationNative_ChangeCaseInvariant}, // System.Private.CoreLib
{"GlobalizationNative_ChangeCaseTurkish", GlobalizationNative_ChangeCaseTurkish}, // System.Private.CoreLib
{"GlobalizationNative_CloseSortHandle", GlobalizationNative_CloseSortHandle}, // System.Private.CoreLib
{"GlobalizationNative_CompareString", GlobalizationNative_CompareString}, // System.Private.CoreLib
{"GlobalizationNative_EndsWith", GlobalizationNative_EndsWith}, // System.Private.CoreLib
{"GlobalizationNative_EnumCalendarInfo", GlobalizationNative_EnumCalendarInfo}, // System.Private.CoreLib
{"GlobalizationNative_GetCalendarInfo", GlobalizationNative_GetCalendarInfo}, // System.Private.CoreLib
{"GlobalizationNative_GetCalendars", GlobalizationNative_GetCalendars}, // System.Private.CoreLib
{"GlobalizationNative_GetDefaultLocaleName", GlobalizationNative_GetDefaultLocaleName}, // System.Private.CoreLib
{"GlobalizationNative_GetJapaneseEraStartDate", GlobalizationNative_GetJapaneseEraStartDate}, // System.Private.CoreLib
{"GlobalizationNative_GetLatestJapaneseEra", GlobalizationNative_GetLatestJapaneseEra}, // System.Private.CoreLib
{"GlobalizationNative_GetLocaleInfoGroupingSizes", GlobalizationNative_GetLocaleInfoGroupingSizes}, // System.Private.CoreLib
{"GlobalizationNative_GetLocaleInfoInt", GlobalizationNative_GetLocaleInfoInt}, // System.Private.CoreLib
{"GlobalizationNative_GetLocaleInfoString", GlobalizationNative_GetLocaleInfoString}, // System.Private.CoreLib
{"GlobalizationNative_GetLocaleName", GlobalizationNative_GetLocaleName}, // System.Private.CoreLib
{"GlobalizationNative_GetLocales", GlobalizationNative_GetLocales}, // System.Private.CoreLib
{"GlobalizationNative_GetLocaleTimeFormat", GlobalizationNative_GetLocaleTimeFormat}, // System.Private.CoreLib
{"GlobalizationNative_GetSortHandle", GlobalizationNative_GetSortHandle}, // System.Private.CoreLib
{"GlobalizationNative_GetSortKey", GlobalizationNative_GetSortKey}, // System.Private.CoreLib
{"GlobalizationNative_IndexOf", GlobalizationNative_IndexOf}, // System.Private.CoreLib
{"GlobalizationNative_InitICUFunctions", GlobalizationNative_InitICUFunctions}, // System.Private.CoreLib
{"GlobalizationNative_InitOrdinalCasingPage", GlobalizationNative_InitOrdinalCasingPage}, // System.Private.CoreLib
{"GlobalizationNative_IsNormalized", GlobalizationNative_IsNormalized}, // System.Private.CoreLib
{"GlobalizationNative_IsPredefinedLocale", GlobalizationNative_IsPredefinedLocale}, // System.Private.CoreLib
{"GlobalizationNative_LastIndexOf", GlobalizationNative_LastIndexOf}, // System.Private.CoreLib
{"GlobalizationNative_LoadICU", GlobalizationNative_LoadICU}, // System.Private.CoreLib
{"GlobalizationNative_NormalizeString", GlobalizationNative_NormalizeString}, // System.Private.CoreLib
{"GlobalizationNative_StartsWith", GlobalizationNative_StartsWith}, // System.Private.CoreLib
{"GlobalizationNative_ToAscii", GlobalizationNative_ToAscii}, // System.Private.CoreLib
{"GlobalizationNative_ToUnicode", GlobalizationNative_ToUnicode}, // System.Private.CoreLib
{NULL, NULL}
};
static void *pinvoke_tables[] = { libSystem_Native_imports,libSystem_IO_Compression_Native_imports,libSystem_Globalization_Native_imports,};
static char *pinvoke_names[] = { "libSystem.Native","libSystem.IO.Compression.Native","libSystem.Globalization.Native",};
InterpFtnDesc wasm_native_to_interp_ftndescs[51];
typedef void  (*WasmInterpEntrySig_0) (int*,int*);
void wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ReleaseDelegateProxyImplementation (int arg0) { 
((WasmInterpEntrySig_0)wasm_native_to_interp_ftndescs [0].func) ((int*)&arg0, wasm_native_to_interp_ftndescs [0].arg);
}
typedef void  (*WasmInterpEntrySig_1) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GetTableDelegateProxyImplementation (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_1)wasm_native_to_interp_ftndescs [1].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [1].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_2) (int*,int*);
void wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ReleaseDelegateProxyImplementationForMulti (int arg0) { 
((WasmInterpEntrySig_2)wasm_native_to_interp_ftndescs [2].func) ((int*)&arg0, wasm_native_to_interp_ftndescs [2].arg);
}
typedef void  (*WasmInterpEntrySig_3) (int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_FontExtentsProxyImplementation (int arg0,int arg1,int arg2,int arg3) { 
int res;
((WasmInterpEntrySig_3)wasm_native_to_interp_ftndescs [3].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, wasm_native_to_interp_ftndescs [3].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_4) (int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_NominalGlyphProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4) { 
int res;
((WasmInterpEntrySig_4)wasm_native_to_interp_ftndescs [4].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, wasm_native_to_interp_ftndescs [4].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_5) (int*,int*,int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_NominalGlyphsProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5,int arg6,int arg7) { 
int res;
((WasmInterpEntrySig_5)wasm_native_to_interp_ftndescs [5].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, (int*)&arg6, (int*)&arg7, wasm_native_to_interp_ftndescs [5].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_6) (int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_VariationGlyphProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5) { 
int res;
((WasmInterpEntrySig_6)wasm_native_to_interp_ftndescs [6].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, wasm_native_to_interp_ftndescs [6].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_7) (int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphAdvanceProxyImplementation (int arg0,int arg1,int arg2,int arg3) { 
int res;
((WasmInterpEntrySig_7)wasm_native_to_interp_ftndescs [7].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, wasm_native_to_interp_ftndescs [7].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_8) (int*,int*,int*,int*,int*,int*,int*,int*,int*);
void wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphAdvancesProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5,int arg6,int arg7) { 
((WasmInterpEntrySig_8)wasm_native_to_interp_ftndescs [8].func) ((int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, (int*)&arg6, (int*)&arg7, wasm_native_to_interp_ftndescs [8].arg);
}
typedef void  (*WasmInterpEntrySig_9) (int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphOriginProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5) { 
int res;
((WasmInterpEntrySig_9)wasm_native_to_interp_ftndescs [9].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, wasm_native_to_interp_ftndescs [9].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_10) (int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphKerningProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4) { 
int res;
((WasmInterpEntrySig_10)wasm_native_to_interp_ftndescs [10].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, wasm_native_to_interp_ftndescs [10].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_11) (int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphExtentsProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4) { 
int res;
((WasmInterpEntrySig_11)wasm_native_to_interp_ftndescs [11].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, wasm_native_to_interp_ftndescs [11].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_12) (int*,int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphContourPointProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5,int arg6) { 
int res;
((WasmInterpEntrySig_12)wasm_native_to_interp_ftndescs [12].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, (int*)&arg6, wasm_native_to_interp_ftndescs [12].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_13) (int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphNameProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5) { 
int res;
((WasmInterpEntrySig_13)wasm_native_to_interp_ftndescs [13].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, wasm_native_to_interp_ftndescs [13].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_14) (int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphFromNameProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5) { 
int res;
((WasmInterpEntrySig_14)wasm_native_to_interp_ftndescs [14].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, wasm_native_to_interp_ftndescs [14].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_15) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_CombiningClassProxyImplementation (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_15)wasm_native_to_interp_ftndescs [15].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [15].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_16) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GeneralCategoryProxyImplementation (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_16)wasm_native_to_interp_ftndescs [16].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [16].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_17) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_MirroringProxyImplementation (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_17)wasm_native_to_interp_ftndescs [17].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [17].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_18) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ScriptProxyImplementation (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_18)wasm_native_to_interp_ftndescs [18].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [18].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_19) (int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ComposeProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4) { 
int res;
((WasmInterpEntrySig_19)wasm_native_to_interp_ftndescs [19].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, wasm_native_to_interp_ftndescs [19].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_20) (int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_DecomposeProxyImplementation (int arg0,int arg1,int arg2,int arg3,int arg4) { 
int res;
((WasmInterpEntrySig_20)wasm_native_to_interp_ftndescs [20].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, wasm_native_to_interp_ftndescs [20].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_21) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKBitmapReleaseDelegateProxyImplementation (int arg0,int arg1) { 
((WasmInterpEntrySig_21)wasm_native_to_interp_ftndescs [21].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [21].arg);
}
typedef void  (*WasmInterpEntrySig_22) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKDataReleaseDelegateProxyImplementation (int arg0,int arg1) { 
((WasmInterpEntrySig_22)wasm_native_to_interp_ftndescs [22].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [22].arg);
}
typedef void  (*WasmInterpEntrySig_23) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKImageRasterReleaseDelegateProxyImplementationForCoTaskMem (int arg0,int arg1) { 
((WasmInterpEntrySig_23)wasm_native_to_interp_ftndescs [23].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [23].arg);
}
typedef void  (*WasmInterpEntrySig_24) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKImageRasterReleaseDelegateProxyImplementation (int arg0,int arg1) { 
((WasmInterpEntrySig_24)wasm_native_to_interp_ftndescs [24].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [24].arg);
}
typedef void  (*WasmInterpEntrySig_25) (int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKImageTextureReleaseDelegateProxyImplementation (int arg0) { 
((WasmInterpEntrySig_25)wasm_native_to_interp_ftndescs [25].func) ((int*)&arg0, wasm_native_to_interp_ftndescs [25].arg);
}
typedef void  (*WasmInterpEntrySig_26) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKSurfaceReleaseDelegateProxyImplementation (int arg0,int arg1) { 
((WasmInterpEntrySig_26)wasm_native_to_interp_ftndescs [26].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [26].arg);
}
typedef void  (*WasmInterpEntrySig_27) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_DelegateProxies_GRGlGetProcDelegateProxyImplementation (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_27)wasm_native_to_interp_ftndescs [27].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [27].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_28) (int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_DelegateProxies_GRVkGetProcDelegateProxyImplementation (int arg0,int arg1,int arg2,int arg3) { 
int res;
((WasmInterpEntrySig_28)wasm_native_to_interp_ftndescs [28].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, wasm_native_to_interp_ftndescs [28].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_29) (int*,int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_DelegateProxies_SKGlyphPathDelegateProxyImplementation (int arg0,int arg1,int arg2) { 
((WasmInterpEntrySig_29)wasm_native_to_interp_ftndescs [29].func) ((int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [29].arg);
}
typedef void  (*WasmInterpEntrySig_30) (int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_ReadInternal (int arg0,int arg1,int arg2,int arg3) { 
int res;
((WasmInterpEntrySig_30)wasm_native_to_interp_ftndescs [30].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, wasm_native_to_interp_ftndescs [30].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_31) (int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_PeekInternal (int arg0,int arg1,int arg2,int arg3) { 
int res;
((WasmInterpEntrySig_31)wasm_native_to_interp_ftndescs [31].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, wasm_native_to_interp_ftndescs [31].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_32) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_IsAtEndInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_32)wasm_native_to_interp_ftndescs [32].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [32].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_33) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_HasPositionInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_33)wasm_native_to_interp_ftndescs [33].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [33].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_34) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_HasLengthInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_34)wasm_native_to_interp_ftndescs [34].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [34].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_35) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_RewindInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_35)wasm_native_to_interp_ftndescs [35].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [35].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_36) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_GetPositionInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_36)wasm_native_to_interp_ftndescs [36].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [36].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_37) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_SeekInternal (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_37)wasm_native_to_interp_ftndescs [37].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [37].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_38) (int*,int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_MoveInternal (int arg0,int arg1,int arg2) { 
int res;
((WasmInterpEntrySig_38)wasm_native_to_interp_ftndescs [38].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, wasm_native_to_interp_ftndescs [38].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_39) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_GetLengthInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_39)wasm_native_to_interp_ftndescs [39].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [39].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_40) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_DuplicateInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_40)wasm_native_to_interp_ftndescs [40].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [40].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_41) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_ForkInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_41)wasm_native_to_interp_ftndescs [41].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [41].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_42) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_DestroyInternal (int arg0,int arg1) { 
((WasmInterpEntrySig_42)wasm_native_to_interp_ftndescs [42].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [42].arg);
}
typedef void  (*WasmInterpEntrySig_43) (int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_WriteInternal (int arg0,int arg1,int arg2,int arg3) { 
int res;
((WasmInterpEntrySig_43)wasm_native_to_interp_ftndescs [43].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, wasm_native_to_interp_ftndescs [43].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_44) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_FlushInternal (int arg0,int arg1) { 
((WasmInterpEntrySig_44)wasm_native_to_interp_ftndescs [44].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [44].arg);
}
typedef void  (*WasmInterpEntrySig_45) (int*,int*,int*,int*);
int wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_BytesWrittenInternal (int arg0,int arg1) { 
int res;
((WasmInterpEntrySig_45)wasm_native_to_interp_ftndescs [45].func) ((int*)&res, (int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [45].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_46) (int*,int*,int*);
void wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_DestroyInternal (int arg0,int arg1) { 
((WasmInterpEntrySig_46)wasm_native_to_interp_ftndescs [46].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [46].arg);
}
typedef void  (*WasmInterpEntrySig_47) (int*,int*,int*,int*,int*,int*,int*,int*);
int wasm_native_to_interp_System_Private_CoreLib_ComponentActivator_GetFunctionPointer (int arg0,int arg1,int arg2,int arg3,int arg4,int arg5) { 
int res;
((WasmInterpEntrySig_47)wasm_native_to_interp_ftndescs [47].func) ((int*)&res, (int*)&arg0, (int*)&arg1, (int*)&arg2, (int*)&arg3, (int*)&arg4, (int*)&arg5, wasm_native_to_interp_ftndescs [47].arg);
return res;
}
typedef void  (*WasmInterpEntrySig_48) (int*,int*,int*);
void wasm_native_to_interp_System_Private_CoreLib_CalendarData_EnumCalendarInfoCallback (int arg0,int arg1) { 
((WasmInterpEntrySig_48)wasm_native_to_interp_ftndescs [48].func) ((int*)&arg0, (int*)&arg1, wasm_native_to_interp_ftndescs [48].arg);
}
typedef void  (*WasmInterpEntrySig_49) (int*);
void wasm_native_to_interp_System_Private_CoreLib_TimerQueue_TimerHandler () { 
((WasmInterpEntrySig_49)wasm_native_to_interp_ftndescs [49].func) (wasm_native_to_interp_ftndescs [49].arg);
}
typedef void  (*WasmInterpEntrySig_50) (int*);
void wasm_native_to_interp_System_Private_CoreLib_ThreadPool_BackgroundJobHandler () { 
((WasmInterpEntrySig_50)wasm_native_to_interp_ftndescs [50].func) (wasm_native_to_interp_ftndescs [50].arg);
}
static void *wasm_native_to_interp_funcs[] = { wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ReleaseDelegateProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GetTableDelegateProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ReleaseDelegateProxyImplementationForMulti,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_FontExtentsProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_NominalGlyphProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_NominalGlyphsProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_VariationGlyphProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphAdvanceProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphAdvancesProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphOriginProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphKerningProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphExtentsProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphContourPointProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphNameProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GlyphFromNameProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_CombiningClassProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_GeneralCategoryProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_MirroringProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ScriptProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_ComposeProxyImplementation,wasm_native_to_interp_HarfBuzzSharp_DelegateProxies_DecomposeProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKBitmapReleaseDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKDataReleaseDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKImageRasterReleaseDelegateProxyImplementationForCoTaskMem,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKImageRasterReleaseDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKImageTextureReleaseDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKSurfaceReleaseDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_GRGlGetProcDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_GRVkGetProcDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_DelegateProxies_SKGlyphPathDelegateProxyImplementation,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_ReadInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_PeekInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_IsAtEndInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_HasPositionInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_HasLengthInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_RewindInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_GetPositionInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_SeekInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_MoveInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_GetLengthInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_DuplicateInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_ForkInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedStream_DestroyInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_WriteInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_FlushInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_BytesWrittenInternal,wasm_native_to_interp_SkiaSharp_SKAbstractManagedWStream_DestroyInternal,wasm_native_to_interp_System_Private_CoreLib_ComponentActivator_GetFunctionPointer,wasm_native_to_interp_System_Private_CoreLib_CalendarData_EnumCalendarInfoCallback,wasm_native_to_interp_System_Private_CoreLib_TimerQueue_TimerHandler,wasm_native_to_interp_System_Private_CoreLib_ThreadPool_BackgroundJobHandler,};
static const char *wasm_native_to_interp_map[] = { "HarfBuzzSharp_DelegateProxies_ReleaseDelegateProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GetTableDelegateProxyImplementation",
"HarfBuzzSharp_DelegateProxies_ReleaseDelegateProxyImplementationForMulti",
"HarfBuzzSharp_DelegateProxies_FontExtentsProxyImplementation",
"HarfBuzzSharp_DelegateProxies_NominalGlyphProxyImplementation",
"HarfBuzzSharp_DelegateProxies_NominalGlyphsProxyImplementation",
"HarfBuzzSharp_DelegateProxies_VariationGlyphProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphAdvanceProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphAdvancesProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphOriginProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphKerningProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphExtentsProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphContourPointProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphNameProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GlyphFromNameProxyImplementation",
"HarfBuzzSharp_DelegateProxies_CombiningClassProxyImplementation",
"HarfBuzzSharp_DelegateProxies_GeneralCategoryProxyImplementation",
"HarfBuzzSharp_DelegateProxies_MirroringProxyImplementation",
"HarfBuzzSharp_DelegateProxies_ScriptProxyImplementation",
"HarfBuzzSharp_DelegateProxies_ComposeProxyImplementation",
"HarfBuzzSharp_DelegateProxies_DecomposeProxyImplementation",
"SkiaSharp_DelegateProxies_SKBitmapReleaseDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_SKDataReleaseDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_SKImageRasterReleaseDelegateProxyImplementationForCoTaskMem",
"SkiaSharp_DelegateProxies_SKImageRasterReleaseDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_SKImageTextureReleaseDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_SKSurfaceReleaseDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_GRGlGetProcDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_GRVkGetProcDelegateProxyImplementation",
"SkiaSharp_DelegateProxies_SKGlyphPathDelegateProxyImplementation",
"SkiaSharp_SKAbstractManagedStream_ReadInternal",
"SkiaSharp_SKAbstractManagedStream_PeekInternal",
"SkiaSharp_SKAbstractManagedStream_IsAtEndInternal",
"SkiaSharp_SKAbstractManagedStream_HasPositionInternal",
"SkiaSharp_SKAbstractManagedStream_HasLengthInternal",
"SkiaSharp_SKAbstractManagedStream_RewindInternal",
"SkiaSharp_SKAbstractManagedStream_GetPositionInternal",
"SkiaSharp_SKAbstractManagedStream_SeekInternal",
"SkiaSharp_SKAbstractManagedStream_MoveInternal",
"SkiaSharp_SKAbstractManagedStream_GetLengthInternal",
"SkiaSharp_SKAbstractManagedStream_DuplicateInternal",
"SkiaSharp_SKAbstractManagedStream_ForkInternal",
"SkiaSharp_SKAbstractManagedStream_DestroyInternal",
"SkiaSharp_SKAbstractManagedWStream_WriteInternal",
"SkiaSharp_SKAbstractManagedWStream_FlushInternal",
"SkiaSharp_SKAbstractManagedWStream_BytesWrittenInternal",
"SkiaSharp_SKAbstractManagedWStream_DestroyInternal",
"System_Private_CoreLib_ComponentActivator_GetFunctionPointer",
"System_Private_CoreLib_CalendarData_EnumCalendarInfoCallback",
"System_Private_CoreLib_TimerQueue_TimerHandler",
"System_Private_CoreLib_ThreadPool_BackgroundJobHandler",
};
