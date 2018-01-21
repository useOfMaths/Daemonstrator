#include "stdafx.h"
#include "MovingBody.h"

#define aWIDTH 80
#define aHEIGHT 80


MovingBody::MovingBody(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window height

	ball_colour = RGB(255, 0, 0); // travelling ball colour
	x = 10; // x-coordinate of ball
	y = 110; // y-coordinate of ball

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
void MovingBody::paint() {
	// erase previous circle
	SelectObject(hdc, background_pen); // select background colour
	SelectObject(hdc, background_brush); // select background colour
	Ellipse(hdc, x - 10, y, x - 10 + aWIDTH, y + aHEIGHT);

	// draw a circle
	SelectObject(hdc, ball_pen); // select ball colour
	SelectObject(hdc, ball_brush);
	Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
}

/*
Repeatedly draws ball so as to simulate a continuous motion
*/
void MovingBody::doGlide() {
	// condition for continuing motion
	while (x + aWIDTH <= window_width) {
		paint();

		x += 10;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}

MovingBody::~MovingBody()
{
	DeleteObject(background_pen);
	DeleteObject(background_brush);

	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	ReleaseDC(hWindow, hdc);
}
