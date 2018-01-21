#pragma once

class Facet
{
public:
	Facet(HWND, int, int);
	virtual ~Facet();
	bool decorateButton(WPARAM, LPARAM);
	bool actionPerformed(HWND, WPARAM, LPARAM);
	void informPaint();
};

