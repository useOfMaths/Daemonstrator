#include "stdafx.h"
#include "CubicPath.h"
#include <math.h>


CubicPath::CubicPath(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 0, 0);
	x_start = 50;
	x_max = 200;
	y_max = 110;
	x_min = 500;
	y_min = 410;
	x = x_start;

	// constants
	a = (double)(-2 * (y_max - y_min)) / pow((x_max - x_min), 3);
	b = -((double)3 / 2) * a * (x_max + x_min);
	c = 3 * a * x_max * x_min;
	d = y_max + ((double)a / 2) * (x_max - 3 * x_min) * pow(x_max, 2);

	y = (int)round(a * pow(x, 3) + b * pow(x, 2) + c * x + d);

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
void CubicPath::paint() {
	// draw a dot
	Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
}

/*
Repeatedly draws ball so as to simulate a continuous motion
*/
void CubicPath::moveCubic() {
	// condition for continuing motion
	while (x + aWIDTH <= window_width && y >= y_max) {
		paint();

		x += 20;
		y = (int)round(a * pow(x, 3) + b * pow(x, 2) + c * x + d);
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


CubicPath::~CubicPath()
{
	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
