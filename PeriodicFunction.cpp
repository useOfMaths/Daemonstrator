#include "stdafx.h"
#include "PeriodicFunction.h"
#include <math.h>


PeriodicFunction::PeriodicFunction(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 0, 0);
	theta = 0;
	a = 100; // constant

    // convert theta from degree to radians (work in a little translate for y)
	y = (int)round(a * sin(theta * (long double)PI / 180)) + int(window_height / 2);

	// Pen and brush for travelling ball
	ball_pen = CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
	ball_brush = CreateSolidBrush(ball_colour);

	hdc = GetDC(hWindow);

	SelectObject(hdc, ball_pen); // select ball pen colour
	SelectObject(hdc, ball_brush); // select ball brush colour

	// draw a second demarcation line
	MoveToEx(hdc, 0, 80, NULL);
	LineTo(hdc, window_width, 80);

	// draw x-axis
	MoveToEx(hdc, 0, int(window_height/2 + aHEIGHT/2), NULL);
	LineTo(hdc, window_width, int(window_height/2 + aHEIGHT/2));
}

/*
* draws the ball/circle using the apt color
*/
void PeriodicFunction::paint() {
	// draw a dot
	Ellipse(hdc, theta, y, theta + aWIDTH, y + aHEIGHT);
}

void PeriodicFunction::moveSinusoidal() {
	// condition for continuing motion
	while (theta + aWIDTH < window_width) {
		// work in a little translate for y
		y = (int)round(a * sin(theta * (long double)PI / 180)) + int(window_height / 2);
		paint();

		theta += 15;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


PeriodicFunction::~PeriodicFunction()
{
	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
