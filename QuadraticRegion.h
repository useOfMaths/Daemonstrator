#pragma once

#define aWIDTH 5
#define aHEIGHT 5
#define ballWIDTH 100
#define ballHEIGHT 100

class QuadraticRegion
{
public:
	QuadraticRegion(HWND, int, int);
	virtual ~QuadraticRegion();
	void paint();
	void checkBoundary();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;
	int x_ball;
	int y_ball;
	int previous_x;
	int previous_y;

	int xq_start;
	int yq_start;
	int xq_min;
	int yq_min;
	double xq_lb;
	double xq_ub;
	int xq_stop;
	int x;
	int y;
	
	double a, b, c; // coefficients and constant
	double discriminant;

	HPEN background_pen;
	HBRUSH background_brush;
	HPEN ball_pen;
	HBRUSH ball_brush;
	HBRUSH curve_brush;
};

