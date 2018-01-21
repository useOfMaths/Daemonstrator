#pragma once
class MovingBody
{
public:
	MovingBody(HWND, int, int);
	virtual ~MovingBody();
	void paint();
	void doGlide();
protected:
	HWND hWindow;
	HDC hdc;
	int window_width;
	int window_height;
	COLORREF ball_colour;
	int x;
	int y;
	HPEN background_pen;
	HBRUSH background_brush;
	HPEN ball_pen;
	HBRUSH ball_brush;
};