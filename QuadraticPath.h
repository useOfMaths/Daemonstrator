#pragma once

#define aWIDTH 10
#define aHEIGHT 10

class QuadraticPath
{
public:
	QuadraticPath(HWND, int, int);
	virtual ~QuadraticPath();
	void paint();
	void moveQuadratic();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;
	int x_start;
	int y_start;
	int x_max;
	int y_max;
	int x;
	int y;
	double a, b, c; // coefficients and constant
	HPEN ball_pen;
	HBRUSH ball_brush;
};

