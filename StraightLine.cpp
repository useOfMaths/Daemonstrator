#include "stdafx.h"
#include "StraightLine.h"
#include <math.h>


StraightLine::StraightLine(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 0, 0);
	x1 = 20;
	x2 = 800;
	y1 = 100;
	y2 = 400;
	x = x1;
	y = y1;

	m = (double)(y2 - y1) / (x2 - x1); // slope
	c = (double)(x2 * y1 - x1 * y2) / (x2 - x1); // y-intercept

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
void StraightLine::paint() {
	// draw a dot
	Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
}

/*
Repeatedly draws ball so as to simulate a continuous motion
*/
void StraightLine::moveInLine() {
	// condition for continuing motion
	while (x + aWIDTH <= window_width) {
		y = (int)ceil(m * x + c);
		paint();

		x += 20;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}

StraightLine::~StraightLine()
{
	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
