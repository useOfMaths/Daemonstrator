#include "stdafx.h"
#include "CircularRegion.h"
#include <math.h>


CircularRegion::CircularRegion(HWND hWnd, int window_width, int window_height)
{
	hWindow = hWnd; // save away window handle
	this->window_width = window_width; // save away window width
	this->window_height = window_height; // save away window width

	sq_colour = RGB(255, 255, 0); // give our square a yellow colour
    // coordinates for the ball(circle)
	x_square = 10;
	y_square = 250;
	previous_x = x_square;
	previous_y = y_square;

	//circle coordinates
	a = 500;
	b = 275;
	double discriminant;

	// Pen and brush matching background colour
	background_brush = CreateSolidBrush(RGB(192, 192, 192));

	// pen(purple colour) for circle
	circle_pen = CreatePen(PS_SOLID, 5, RGB(255, 0, 255));

	// brush for travelling square
	sq_brush = CreateSolidBrush(sq_colour);

	hdc = GetDC(hWindow);
}

/*
* draws the ball/circle using the apt color
*/
void CircularRegion::paint() {
	SelectObject(hdc, circle_pen); // use purple colour
	SelectObject(hdc, background_brush); // use background colour
	// draw a circle
	Ellipse(hdc, a - r, b - r, a + r, b + r);

	// erase previous square
	RECT prev_sq;
	prev_sq.left = previous_x;
	prev_sq.top = previous_y;
	prev_sq.right = previous_x + sqLENGTH;
	prev_sq.bottom = previous_y + sqLENGTH;
	FillRect(hdc, &prev_sq, background_brush);

	// draw square
	RECT sq;
	sq.left = x_square;
	sq.top = y_square;
	sq.right = x_square + sqLENGTH;
	sq.bottom = y_square + sqLENGTH;
	FillRect(hdc, &sq, sq_brush);
	
	previous_x = x_square;
	previous_y = y_square;
}

/*
* Repeatedly draws square so as to simulate a continuous motion
*/
void CircularRegion::circledSquare() {
	// condition for continuing motion
	while (x_square + sqLENGTH < window_width) {
		int square_left = x_square;
		int square_right = x_square + sqLENGTH;
		int square_top = y_square;
		int square_bottom = y_square + sqLENGTH;

		// determinants for each side of the square
		int x_left_det = (int)round(sqrt(pow(r, 2) - pow((square_left - a), 2)));
		int x_right_det = (int)round(sqrt(pow(r, 2) - pow((square_right - a), 2)));
		int y_up_det = (int)round(sqrt(pow(r, 2) - pow((square_top - b), 2)));
		int y_down_det = (int)round(sqrt(pow(r, 2) - pow((square_bottom - b), 2)));

		// check the bounds of the circle
		if (square_top > b - x_left_det && square_bottom < b + x_left_det
			&& square_top > b - x_right_det && square_bottom < b + x_right_det
			&& square_left > a - y_up_det && square_right < a + y_up_det
			&& square_left > a - y_down_det && square_right < a + y_down_det) {
			// green colour for our moving body(square) inside our circle
			sq_colour = RGB(0, 255, 0);
		}
		else {
			// yellow color for our moving body(square) outside our circle
			sq_colour = RGB(255, 255, 0);
		}
		DeleteObject(sq_brush); // delete former brush
		sq_brush = CreateSolidBrush(sq_colour); // recreate brush with a new colour

		paint();

		x_square += 10;
		// introduce a delay betweeen renderings
		Sleep(50);
	}
}


CircularRegion::~CircularRegion()
{
	DeleteObject(background_brush);
	DeleteObject(circle_pen);
	DeleteObject(sq_brush);

	ReleaseDC(hWindow, hdc);
}
