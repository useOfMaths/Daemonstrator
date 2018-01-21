#include "stdafx.h"
#include "EllipticalPath.h"
#include <math.h>


EllipticalPath::EllipticalPath(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 0, 0);
	//ellipse coordinates
	h = 250;
	k = 275;
	a = 150;
	b = 100;
	x = h - a;
	y = k;

	// Pen and brush for travelling ball
	ball_pen = CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
	ball_brush = CreateSolidBrush(ball_colour);

	hdc = GetDC(hWindow);

	SelectObject(hdc, ball_pen); // select ball pen colour
	SelectObject(hdc, ball_brush); // select ball brush colour
}

/*
* draws the ball/circle using the apt color
*/
void EllipticalPath::paint() {
	// draw a dot
	Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
}

/*
* Repeatedly draws ball so as to simulate a continuous motion
*/
void EllipticalPath::moveElliptic() {
	// condition for continuing motion
	while (x <= h + a) {
		y = (int)round(k - ((double)b / a) * sqrt(pow(a, 2) - pow((x - h), 2)));
		paint();

		y = (int)round(k + ((double)b / a) * sqrt(pow(a, 2) - pow((x - h), 2)));
		paint();

		x += 20;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


EllipticalPath::~EllipticalPath()
{
	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
