#include <Windows.h>
#include <tchar.h>
#include <string>

#define BUFFSIZE 100
#define IDC_BTN_REMOVE_SPECIAL_CHARS 1001
#define IDC_BTN_REMOVE_SPACES 1002
#define IDC_BTN_CLEAR_TEXT 1003
#define IDC_STATIC_TEXT_LENGTH 1004

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
    TCHAR szClassName[] = _T("Window");
    TCHAR szTitle[] = _T("텍스트 변환기");

    WNDCLASSEX wc;
    MSG msg;
    HWND hWnd;

    wc.cbSize = sizeof(wc);
    wc.style = CS_HREDRAW | CS_VREDRAW;
    wc.lpfnWndProc = WndProc;
    wc.cbClsExtra = 0;
    wc.cbWndExtra = 0;
    wc.hInstance = hInstance;
    wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wc.hCursor = LoadCursor(NULL, IDC_ARROW);
    wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wc.lpszMenuName = NULL;
    wc.lpszClassName = szClassName;
    wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

    if (!RegisterClassEx(&wc))
    {
        MessageBox(NULL, _T("Window Registration Failed!"), _T("Error"), MB_ICONEXCLAMATION | MB_OK);
        return 0;
    }

    hWnd = CreateWindowEx(
        WS_EX_CLIENTEDGE,
        szClassName,
        szTitle,
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, CW_USEDEFAULT, 600, 400,  // 크기 조정
        NULL, NULL, hInstance, NULL);

    if (hWnd == NULL)
    {
        MessageBox(NULL, _T("Window Creation Failed!"), _T("Error"), MB_ICONEXCLAMATION | MB_OK);
        return 0;
    }

    ShowWindow(hWnd, nCmdShow);
    UpdateWindow(hWnd);

    while (GetMessage(&msg, NULL, 0, 0) > 0)
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return msg.wParam;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
    static HWND hEdit1, hEdit2, hBtnConv1, hBtnConv2, hBtnRemoveSpecialChars, hBtnRemoveSpaces, hBtnClearText;
    static HWND hStaticTextLength;

    switch (uMsg)
    {
    case WM_CREATE:
        // Create first edit control
        hEdit1 = CreateWindowEx(WS_EX_CLIENTEDGE, _T("EDIT"), _T("Enter Text Here"), WS_CHILD | WS_VISIBLE | ES_MULTILINE | ES_AUTOVSCROLL | ES_AUTOHSCROLL, 10, 10, 560, 80, hWnd, NULL, GetModuleHandle(NULL), NULL);
        if (hEdit1 == NULL)
        {
            MessageBox(hWnd, _T("Could not create edit box."), _T("Error"), MB_OK | MB_ICONERROR);
            return -1;
        }

        // Create buttons
        hBtnRemoveSpecialChars = CreateWindow(_T("BUTTON"), _T("특수문자 제거"), WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 10, 100, 150, 28, hWnd, (HMENU)IDC_BTN_REMOVE_SPECIAL_CHARS, GetModuleHandle(NULL), NULL);
        hBtnRemoveSpaces = CreateWindow(_T("BUTTON"), _T("공백 제거"), WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 170, 100, 100, 28, hWnd, (HMENU)IDC_BTN_REMOVE_SPACES, GetModuleHandle(NULL), NULL);
        hBtnClearText = CreateWindow(_T("BUTTON"), _T("텍스트 지우기"), WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 280, 100, 150, 28, hWnd, (HMENU)IDC_BTN_CLEAR_TEXT, GetModuleHandle(NULL), NULL);

        // Create buttons for text conversion
        hBtnConv1 = CreateWindow(_T("BUTTON"), _T("소문자로 변환"), WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 10, 140, 150, 28, hWnd, NULL, GetModuleHandle(NULL), NULL);
        hBtnConv2 = CreateWindow(_T("BUTTON"), _T("대문자로 변환"), WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 170, 140, 150, 28, hWnd, NULL, GetModuleHandle(NULL), NULL);

        // Create second edit control
        hEdit2 = CreateWindowEx(WS_EX_CLIENTEDGE, _T("EDIT"), _T(""), WS_CHILD | WS_VISIBLE | ES_MULTILINE | ES_AUTOVSCROLL | ES_AUTOHSCROLL | ES_READONLY, 10, 180, 560, 80, hWnd, NULL, GetModuleHandle(NULL), NULL);
        if (hEdit2 == NULL)
        {
            MessageBox(hWnd, _T("Could not create edit box."), _T("Error"), MB_OK | MB_ICONERROR);
            return -1;
        }

        // Create static text for displaying text length
        hStaticTextLength = CreateWindow(_T("STATIC"), _T("Text Length: 0"), WS_CHILD | WS_VISIBLE, 10, 270, 100, 20, hWnd, (HMENU)IDC_STATIC_TEXT_LENGTH, GetModuleHandle(NULL), NULL);

        return 0;

    case WM_COMMAND:
        if (lParam == (LPARAM)hBtnConv1)
        {
            // Get text from first edit control
            TCHAR szText1[BUFFSIZE];
            GetWindowText(hEdit1, szText1, BUFFSIZE);

            // Convert text to lowercase
            TCHAR szText2[BUFFSIZE];
            for (int i = 0; i < lstrlen(szText1); i++)
            {
                szText2[i] = _totlower(szText1[i]);
            }
            szText2[lstrlen(szText1)] = '\0';

            // Set converted text to second edit control
            SetWindowText(hEdit2, szText2);
            // Update text length display
            SetWindowText(hStaticTextLength, (std::wstring(L"Text Length: ") + std::to_wstring(lstrlen(szText2))).c_str());
        }
        else if (lParam == (LPARAM)hBtnConv2)
        {
            // Get text from first edit control
            TCHAR szText1[BUFFSIZE];
            GetWindowText(hEdit1, szText1, BUFFSIZE);

            // Convert text to uppercase
            TCHAR szText2[BUFFSIZE];
            for (int i = 0; i < lstrlen(szText1); i++)
            {
                szText2[i] = _totupper(szText1[i]);
            }
            szText2[lstrlen(szText1)] = '\0';

            // Set converted text to second edit control
            SetWindowText(hEdit2, szText2);

            // Update text length display
            SetWindowText(hStaticTextLength, (std::wstring(L"Text Length: ") + std::to_wstring(lstrlen(szText2))).c_str());
        }
        else if (lParam == (LPARAM)hBtnRemoveSpecialChars)
        {
            // Get text from first edit control
            TCHAR szText1[BUFFSIZE];
            GetWindowText(hEdit1, szText1, BUFFSIZE);

            // Remove special characters
            TCHAR szText2[BUFFSIZE];
            int j = 0;
            for (int i = 0; i < lstrlen(szText1); i++)
            {
                if ((szText1[i] >= 'a' && szText1[i] <= 'z') || (szText1[i] >= 'A' && szText1[i] <= 'Z'))
                {
                    szText2[j] = szText1[i];
                    j++;
                }
            }
            szText2[j] = '\0';

            // Set converted text to second edit control
            SetWindowText(hEdit2, szText2);

            // Update text length display
            SetWindowText(hStaticTextLength, (std::wstring(L"Text Length: ") + std::to_wstring(lstrlen(szText2))).c_str());
        }
        else if (lParam == (LPARAM)hBtnRemoveSpaces)
        {
            // Get text from first edit control
            TCHAR szText1[BUFFSIZE];
            GetWindowText(hEdit1, szText1, BUFFSIZE);

            // Remove spaces
            TCHAR szText2[BUFFSIZE];
            int j = 0;
            for (int i = 0; i < lstrlen(szText1); i++)
            {
                if (szText1[i] != ' ')
                {
                    szText2[j] = szText1[i];
                    j++;
                }
            }
            szText2[j] = '\0';

            // Set converted text to second edit control
            SetWindowText(hEdit2, szText2);

            // Update text length display
            SetWindowText(hStaticTextLength, (std::wstring(L"Text Length: ") + std::to_wstring(lstrlen(szText2))).c_str());
        }
        else if (lParam == (LPARAM)hBtnClearText)
        {
            // Clear both edit controls
            SetWindowText(hEdit1, _T(""));
            SetWindowText(hEdit2, _T(""));

            // Update text length display
            SetWindowText(hStaticTextLength, _T("Text Length: 0"));
        }
        return 0;

    case WM_DESTROY:
        PostQuitMessage(0);
        return 0;
    }

    return DefWindowProc(hWnd, uMsg, wParam, lParam);
}