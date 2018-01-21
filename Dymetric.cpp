#include "stdafx.h"
#include "Dymetric.h"
#include "Facet.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

/*PoI* _____________________________________________________ *PoI*/
COLORREF window_background_color = RGB(192, 192, 192);
/*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/


// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_DYMETRIC, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_DYMETRIC));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_DYMETRIC));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_DYMETRIC);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
HBITMAP hBitmap = NULL;
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	/*PoI* _______________________________________________________________________ *PoI*/

	int window_width = NULL;
	int window_height = NULL;
	RECT window_rect;
	int button_x_position = 100;
	int button_y_position = 10;
	int button_width = 150;
	int button_height = 50;

	if (GetClientRect(hWnd, &window_rect))
	{
		window_width = window_rect.right - window_rect.left;
		window_height = window_rect.bottom - window_rect.top;

		button_x_position = window_width / 2 - button_width / 2;
	}

	Facet * window_details = new Facet(hWnd, window_width, window_height);

    switch (message)
    {
		case WM_CREATE:
			{
				// Owner draw button
				if (window_width != NULL)
				{
					CreateWindow(L"BUTTON", L"", WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON | BS_OWNERDRAW,
						button_x_position, button_y_position, button_width, button_height, hWnd, (HMENU)12321, hInst, NULL);
				}
				return 0;
			}
		/*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/
		case WM_COMMAND:
			{
	            int wmId = LOWORD(wParam);
		        // Parse the menu selections:
			    switch (wmId)
				{
					case IDM_ABOUT:
						DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
						break;
					case IDM_EXIT:
						DestroyWindow(hWnd);
						break;
					default:
						/*PoI* _____________________________________________________ *PoI*/
						if (window_details->actionPerformed(hWnd, wParam, lParam))
							return 0;
						/*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/
						return DefWindowProc(hWnd, message, wParam, lParam);
	            }
		    }
			break;

		/*PoI* _____________________________________________________ *PoI*/
		// Owner draw button
		case WM_DRAWITEM:
			if (window_width != NULL)
				return window_details->decorateButton(wParam, lParam);
			break;
		/*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/

		case WM_CTLCOLORBTN:
			{ // make the colour of our button's background match window's background
				return (LRESULT)CreateSolidBrush(window_background_color);
			}
		case WM_PAINT:
			{
				PAINTSTRUCT ps;
	            HDC hdc = BeginPaint(hWnd, &ps);

				/*PoI* ___________________________________________________________________________________ *PoI*/
				if (window_width != NULL) {
					// Colour window background
					FillRect(hdc, &ps.rcPaint, (HBRUSH)CreateSolidBrush(window_background_color));

					// and draw a demarcation line
					MoveToEx(hdc, 0, button_height + 2 * button_y_position, NULL);
					LineTo(hdc, window_width, button_height + 2 * button_y_position);

					window_details->informPaint();
				}
				else {
					MessageBox(hWnd, L"Something is not up to specification!", L"Version Error!", MB_ICONEXCLAMATION);
				}
				/*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/

		        EndPaint(hWnd, &ps);
			}
	        break;
		case WM_DESTROY:
			PostQuitMessage(0);
	        return 0;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
    }
	/*PoI* ______________ *PoI*/
	delete window_details;
	/*^^^^^^^^^^^^^^^^^^^^*/
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
