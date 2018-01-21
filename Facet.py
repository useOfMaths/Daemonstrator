import turtle

class Template:
    def __init__(self):
        screen = turtle.getscreen()
        screen.title("useOfMaths.com")
        screen.setup(width=0.9, height=0.9, startx=None, starty=None)
        screen.colormode(255)
        self.bgcolour = "#cccccc"
        screen.bgcolor(self.bgcolour)
        screen.delay(0)
        self.screen = screen

        self.wnd_width = self.screen.window_width()
        self.wnd_height = self.screen.window_height()

    def controlButtons(self):
        self.button = turtle.clone()
        
        turtle.speed(0)
        turtle.penup()
        turtle.setposition(-self.wnd_width/2, self.wnd_height/2)
        turtle.color("black", "pink")

        turtle.pendown()
        # draw button region
        turtle.begin_fill()
        turtle.forward(self.wnd_width)
        turtle.right(90)
        turtle.forward(50)
        turtle.right(90)
        turtle.forward(self.wnd_width)
        turtle.right(90)
        turtle.forward(50)
        turtle.end_fill()

        self.button.speed(0)
        self.button.penup()
        # draw button
        self.button.setposition(0, self.wnd_height/2 - 25)
        self.button.shape("square")
        self.button.resizemode("user")
        self.button.shapesize(2, 8)
        self.button.color("black", (255, 0, 255))

        return turtle.getturtle()
