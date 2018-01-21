#pragma once

#define sqLENGTH 100

class EllipticalRegion
{
public:
	EllipticalRegion(HWND, int, int);
	virtual ~EllipticalRegion();
	void paint();
	void ellipsedSquare();
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

	//ellipse coordinates
	int h; // vertice
	int k; // vertice
	const int a = 200; // major axis
	const int b = 125; // minor axis
	int x;
	int y;

	HBRUSH background_brush;
	HPEN circle_pen;
	HBRUSH sq_brush;
};

