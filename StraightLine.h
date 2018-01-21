#pragma once

#define aWIDTH 10
#define aHEIGHT 10

class StraightLine
{
public:
	StraightLine(HWND, int, int);
	virtual ~StraightLine();
	void paint();
	void moveInLine();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;
	int x1;
	int x2;
	int y1;
	int y2;
	int x;
	int y;
	double m, c; // slope and y-intercept of a straight line
	HPEN ball_pen;
	HBRUSH ball_brush;
};

