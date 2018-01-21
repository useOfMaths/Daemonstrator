#pragma once

#define aWIDTH 10
#define aHEIGHT 10

class CubicPath
{
public:
	CubicPath(HWND, int, int);
	virtual ~CubicPath();
	void paint();
	void moveCubic();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;
	int x_start;
	int x_max;
	int y_max;
	int x_min;
	int y_min;
	int x;
	int y;
	double a, b, c, d; // coefficients and constant
	HPEN ball_pen;
	HBRUSH ball_brush;
};

