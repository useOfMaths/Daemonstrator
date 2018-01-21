#pragma once

#define aWIDTH 80
#define aHEIGHT 80

class StraightLineRegion
{
public:
	StraightLineRegion(HWND, int, int);
	virtual ~StraightLineRegion();
	void paint();
	void checkBoundary();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;
	// coordinates for the ball(circle)
	int x_ball;
	int y_ball;
	int previous_x;
	int previous_y;

	int x1;
	int x2;
	int y1;
	int y2;
	// x-coordinate for diagonal line
	double x_line;
	double m, c; // slope and y-intercept of a straight line

	HPEN background_pen;
	HBRUSH background_brush;
	HPEN ball_pen;
	HBRUSH ball_brush;
};

