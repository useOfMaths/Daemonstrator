#include "stdafx.h"
#include "Facet.h"
#include "EllipticalPath.h"

EllipticalPath* elp_path;

/*
* Our custom class that interfaces between the parent window
* and the subsequent daemonstrator classes
*/
Facet::Facet(HWND hWnd, int window_width, int window_height)
{
	elp_path = new EllipticalPath(hWnd, window_width, window_height);
}


/*
* This guy decorates buttons with colour and title text
*/
bool Facet::decorateButton(WPARAM wParam, LPARAM lParam) {
	// button glide calling
	if (wParam == 12321)
	{
		LPDRAWITEMSTRUCT lpDIS = (LPDRAWITEMSTRUCT)lParam;
		
		SetDCBrushColor(lpDIS->hDC, RGB(255, 192, 203));
		SelectObject(lpDIS->hDC, GetStockObject(DC_BRUSH));

		RECT rect = { 0 };
		rect.left = lpDIS->rcItem.left;
		rect.right = lpDIS->rcItem.right;
		rect.top = lpDIS->rcItem.top;
		rect.bottom = lpDIS->rcItem.bottom;

		RoundRect(lpDIS->hDC, rect.left, rect.top, rect.right, rect.bottom, 50, 50);
		// button text
		DrawText(lpDIS->hDC, TEXT("MOVE"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
		
		return TRUE;
	}
	return FALSE;
}

/*
* Call the target class' draw method
*/
void Facet::informPaint() {
	elp_path->paint();
}


/*
* Say there is more than a single push button,
* this guy picks out the correct button that got clicked
* and calls the corresponding apt function
*/
bool Facet::actionPerformed(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))
	{
	case 12321:
		elp_path->moveElliptic();
		return TRUE;
	default:
		return FALSE;
	}
}

Facet::~Facet()
{
	delete elp_path;
}
