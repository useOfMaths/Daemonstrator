#pragma once

#define aWIDTH 10
#define aHEIGHT 10

class EllipticalPath
{
public:
	EllipticalPath(HWND, int, int);
	virtual ~EllipticalPath();
	void paint();
	void moveElliptic();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;

	//ellipse coordinates
	int h;
	int k;
	int a;
	int b;
	int x;
	int y;

	HPEN ball_pen;
	HBRUSH ball_brush;
};

