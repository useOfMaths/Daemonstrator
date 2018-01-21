#include "stdafx.h"
#include "EllipticalRegion.h"
#include <math.h>


EllipticalRegion::EllipticalRegion(HWND hWnd, int window_width, int window_height)
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

	//ellipse coordinates
	h = 450; // vertice
	k = 275; // vertice
	x = h - a;
	y = k - b;

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
void EllipticalRegion::paint() {
	SelectObject(hdc, circle_pen); // use purple colour
	SelectObject(hdc, background_brush); // use background colour
	// draw an ellipse
	Ellipse(hdc, x, y, h + a, k + b);

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
void EllipticalRegion::ellipsedSquare() {
	// condition for continuing motion
	while (x_square + sqLENGTH < window_width) {
		int square_left = x_square;
		int square_right = x_square + sqLENGTH;
		int square_top = y_square;
		int square_bottom = y_square + sqLENGTH;

		// determinants for each side of the square
		int x_left_det = (int)round(((double)b / a)
			* sqrt(pow(a, 2) - pow((square_left - h), 2)));
		int x_right_det = (int)round(((double)b / a)
			* sqrt(pow(a, 2) - pow((square_right - h), 2)));
		int y_up_det = (int)round(((double)a / b)
			* sqrt(pow(b, 2) - pow((square_top - k), 2)));
		int y_down_det = (int)round(((double)a / b)
			* sqrt(pow(b, 2) - pow((square_bottom - k), 2)));

		if (square_top > k - x_left_det && square_bottom < k + x_left_det
			&& square_top > k - x_right_det && square_bottom < k + x_right_det
			&& square_left > h - y_up_det && square_right < h + y_up_det
			&& square_left > h - y_down_det && square_right < h + y_down_det) {
			// green colour for our moving body(square) inside our ellipse
			sq_colour = RGB(0, 255, 0);
		}
		else {
			// yellow colour for our moving body(square) outside our ellipse
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


EllipticalRegion::~EllipticalRegion()
{
	DeleteObject(background_brush);
	DeleteObject(circle_pen);
	DeleteObject(sq_brush);
	
	ReleaseDC(hWindow, hdc);
}
