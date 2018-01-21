#pragma once

#define aWIDTH 10
#define aHEIGHT 10

class CircularPath
{
public:
	CircularPath(HWND, int, int);
	virtual ~CircularPath();
	void paint();
	void moveCyclic();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;

	//circle coordinates
	int a;
	int b;
	const int r = 150;
	int x;
	int y;

	HPEN ball_pen;
	HBRUSH ball_brush;
};

