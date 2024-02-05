#pragma once

typedef int(__stdcall* Callback)();

extern "C" __declspec(dllexport) int __stdcall Launch(Callback func);