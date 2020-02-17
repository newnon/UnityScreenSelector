// ScreenSelector.cpp : Определяет точку входа для приложения.
//

#include "stdafx.h"
#include "ScreenSelector.h"
#include <string>

bool DisplayScreenSelector(std::wstring& commandline);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Разместите код здесь.

	std::wstring line;

	DisplayScreenSelector(line);

    return 0;
}