#include "stdafx.h"
#include "QuadraticRegion.h"
#include <math.h>


QuadraticRegion::QuadraticRegion(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	ball_colour = RGB(255, 255, 0); // yellow for our travelling ball colour
	x_ball = 50;
	y_ball = 200;
	previous_x = x_ball;
	previous_y = y_ball;

	xq_start = 300;
	yq_start = 150;
	xq_min = 450;
	yq_min = 400;
	xq_stop = 600;
	x = xq_start;
	y = yq_start;

    // constants
	a = (double)(yq_start - yq_min) / pow((xq_start - xq_min), 2);
	b = -2 * a * xq_min;
	c = yq_min + a * pow(xq_min, 2);

	discriminant = sqrt(b * b - 4 * a * (c - (y_ball + (double)(ballHEIGHT / 2))));
	if (a < 0) {// a is negative
		xq_lb = (double)(-b + discriminant) / (2 * a); // upper boundary
		xq_ub = (double)(-b - discriminant) / (2 * a); // lower boundary
	}
	else {
		xq_lb = (double)(-b - discriminant) / (2 * a); // lower boundary
		xq_ub = (double)(-b + discriminant) / (2 * a); // upper boundary
	}

	// Pen and brush matching background colour
	background_pen = CreatePen(PS_SOLID, 1, RGB(192, 192, 192));
	background_brush = CreateSolidBrush(RGB(192, 192, 192));

	// Pen and brush for travelling ball
	ball_pen = CreatePen(PS_SOLID, 1, RGB(0, 0, 0));
	ball_brush = CreateSolidBrush(ball_colour);

	// drawing brush for our curve
	curve_brush = CreateSolidBrush(RGB(0, 0, 0));

	hdc = GetDC(hWindow);
}

/*
* draws the ball/circle using the apt color
*/
void QuadraticRegion::paint() {
	SelectObject(hdc, ball_pen); // use a black pen
	SelectObject(hdc, curve_brush); // use a black brush
	//draw quadratic curve
	for (; x < xq_stop; x++) {
		// redraw dot
		y = (int)round(a * x * x + b * x + c);
		Ellipse(hdc, x, y, x + aWIDTH, y + aHEIGHT);
	}
	x = xq_start;

	SelectObject(hdc, background_pen); // select background colour
	SelectObject(hdc, background_brush); // select background colour
	// erase previous circle
	Ellipse(hdc, previous_x, previous_y, previous_x + ballWIDTH, previous_y + ballHEIGHT);

	SelectObject(hdc, ball_pen); // select ball colour
	SelectObject(hdc, ball_brush);
	// draw a circle
	Ellipse(hdc, x_ball, y_ball, x_ball + ballWIDTH, y_ball + ballHEIGHT);
	
	previous_x = x_ball;
	previous_y = y_ball;
}

/*
Repeatedly draws ball so as to simulate a continuous motion
*/
void QuadraticRegion::checkBoundary() {
	// condition for continuing motion
	while (x_ball + ballWIDTH <= window_width) {
		if ((x_ball <= xq_lb && x_ball + ballWIDTH >= xq_lb)
			|| (x_ball <= xq_ub && x_ball + ballWIDTH >= xq_ub)) {
			ball_colour = RGB(255, 0, 0); // trespassing color(red) for our moving body(circle)
		}
		else if (x_ball >= xq_lb && x_ball + ballWIDTH <= xq_ub) {
			ball_colour = RGB(0, 255, 0); // zone color(green) for our moving body(circle)
		}
		else {
			ball_colour = RGB(255, 255, 0); // out of zone color(yellow) for our moving body(circle)
		}
		DeleteObject(ball_brush); // delete former brush
		ball_brush = CreateSolidBrush(ball_colour); // recreate brush with a new colour

		paint();

		x_ball += 5;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


QuadraticRegion::~QuadraticRegion()
{
	DeleteObject(background_pen);
	DeleteObject(background_brush);

	DeleteObject(ball_pen);
	DeleteObject(ball_brush);

	DeleteObject(curve_brush);

	ReleaseDC(hWindow, hdc);
}
