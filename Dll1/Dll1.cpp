#include "pch.h"
#include "Dll1.h"


extern "C" __declspec(dllexport) int __stdcall Launch(Callback func)
{
    return func();
}