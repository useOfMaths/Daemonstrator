#include "stdafx.h"
#include "QuadraticPath.h"
#include <math.h>


QuadraticPath::QuadraticPath(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 0, 0);
	x_start = 50;
	y_start = 400;
	x_max = 350;
	y_max = 150;
	x = x_start;
	y = y_start;

	// constants
	a = (double) (y_start - y_max) / pow((x_start - x_max), 2);
	b = -2 * a * x_max;
	c = y_max + a * pow(x_max, 2);

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
void QuadraticPath::paint() {
	// draw a dot
	Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
}

/*
Repeatedly draws ball so as to simulate a continuous motion
*/
void QuadraticPath::moveQuadratic() {
	// condition for continuing motion
	while (x + aWIDTH <= window_width && y <= y_start) {
		paint();

		x += 20;
		y = (int)round(a*x*x + b*x + c);
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


QuadraticPath::~QuadraticPath()
{
	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
 