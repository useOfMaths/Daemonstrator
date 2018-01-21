#pragma once

#define aWIDTH 10
#define aHEIGHT 10
#define PI 3.1415926535897932384626433832795

class PeriodicFunction
{
public:
	PeriodicFunction(HWND, int, int);
	virtual ~PeriodicFunction();
	void paint();
	void moveSinusoidal();
protected:
	HWND hWindow;
	HDC hdc;
	
	int window_width;
	int window_height;
	COLORREF ball_colour;
	int theta;
	int a; // constant
	int y;
	HPEN ball_pen;
	HBRUSH ball_brush;
};

