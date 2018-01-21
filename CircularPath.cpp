#include "stdafx.h"
#include "CircularPath.h"
#include <math.h>


CircularPath::CircularPath(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 0, 0);
	//circle coordinates
	a = 250;
	b = 265;
	
	x = a - r;
	y = b;

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
void CircularPath::paint() {
	// draw a dot
	Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
}

/*
* Repeatedly draws ball so as to simulate a continuous motion
*/
void CircularPath::moveCyclic() {
	// condition for continuing motion
	while (x <= a + r) {
		y = b - (int)round(sqrt(pow(r, 2) - pow((x - a), 2)));
		paint();

		y = b + (int)round(sqrt(pow(r, 2) - pow((x - a), 2)));
		paint();

		x += 20;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


CircularPath::~CircularPath()
{
	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
