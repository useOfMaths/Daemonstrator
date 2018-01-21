#include "stdafx.h"
#include "StraightLineRegion.h"


StraightLineRegion::StraightLineRegion(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 255, 0); // yellow for our travelling ball colour
	x_ball = 50;
	y_ball = 200;
	previous_x = x_ball;
	previous_y = y_ball;

	x1 = 400;
	x2 = 600;
	y1 = 410;
	y2 = 110;

	m = (double)(y2 - y1) / (x2 - x1); // slope
	c = (double)(x2 * y1 - x1 * y2) / (x2 - x1); // y-intercept

	x_line = (double)(y_ball - c) / m;

	// Pen and brush matching background colour
	background_pen = CreatePen(PS_SOLID, 1, RGB(192, 192, 192));
	background_brush = CreateSolidBrush(RGB(192, 192, 192));

	// Pen and brush for travelling ball
	ball_pen = CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
	ball_brush = CreateSolidBrush(ball_colour);

	hdc = GetDC(hWindow);
}

/*
* draws the ball/circle using the apt color
*/
void StraightLineRegion::paint() {
	SelectObject(hdc, ball_pen); // use a black pen
	//draw diagonal line
	MoveToEx(hdc, x1, y1, NULL);
	LineTo(hdc, x2, y2);

	SelectObject(hdc, background_pen); // select background colour
	SelectObject(hdc, background_brush); // select background colour
	// erase previous circle
	Ellipse(hdc, previous_x, previous_y, previous_x + aWIDTH, previous_y + aHEIGHT);

	SelectObject(hdc, ball_pen); // select ball colour
	SelectObject(hdc, ball_brush);
	// draw a circle
	Ellipse(hdc, x_ball, y_ball, x_ball + aWIDTH, y_ball + aHEIGHT);
	
	previous_x = x_ball;
}

/*
Repeatedly draws ball so as to simulate a continuous motion
*/
void StraightLineRegion::checkBoundary() {
	// condition for continuing motion
	while (x_ball + aWIDTH <= window_width) {
		if (x_ball >= x_line) { // we could make this happen just once, but...
			ball_colour = RGB(0, 255, 0); // green color for our moving body(circle)

			DeleteObject(ball_brush); // delete former brush
			ball_brush = CreateSolidBrush(ball_colour); // recreate brush with a new colour
		}
		paint();

		x_ball += 10;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


StraightLineRegion::~StraightLineRegion()
{
	DeleteObject(background_pen);
	DeleteObject(background_brush);

	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
