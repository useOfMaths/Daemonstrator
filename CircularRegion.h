#pragma once

#define sqLENGTH 100

class CircularRegion
{
public:
	CircularRegion(HWND, int, int);
	virtual ~CircularRegion();
	void paint();
	void circledSquare();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	
	COLORREF sq_colour;
	// coordinates for the ball(circle)
	int x_square;
	int y_square;
	int previous_x;
	int previous_y;

	//circle coordinates
	int a;
	int b;
	const int r = 150;
	double discriminant;

	HBRUSH background_brush;
	HPEN circle_pen;
	HBRUSH sq_brush;
};

