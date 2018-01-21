import turtle

class CanvasLook:
    def __init__(self):
        screen = turtle.getscreen()
        screen.setup(width=0.9, height=0.9, startx=None, starty=None)
        screen.colormode(255)
        screen.title("Use of Maths")
        screen.bgcolor("orange")
