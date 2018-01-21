#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global sq_colour, x_square, y_square, h, k, a, b, turtle_radius

    # bind fun function
    scene.button.onrelease(play)
    
    turtle.penup()
    # button text
    turtle.setposition(scene.button.xcor(), scene.button.ycor()-10)
    turtle.pendown()
    turtle.write("Move", align="center", font=("Arial",16,"bold"))

    # square parameters
    diameter = 5
    sq_colour = "#ffff00"
    x_square = 50 - scene.wnd_width/2; y_square = 0

    # centre point
    h = 0
    k = 0
    # major/minor axis
    a = scene.wnd_width / 3
    b = scene.wnd_height / 3
    x_dot = h - a; y_dot = k
    # draw ellipse
    turtle.penup()
    turtle.color("red")
    turtle.setposition(x_dot, y_dot)
    turtle.pendown()
    while x_dot < h + a:
        y_dot = k - (b/a)*math.sqrt(math.pow(a, 2) - math.pow((x_dot - h), 2))
        turtle.setposition(x_dot, y_dot)
        y_dot = k + (b/a)*math.sqrt(math.pow(a, 2) - math.pow((x_dot - h), 2))
        turtle.setposition(x_dot, y_dot)
        x_dot += 1
    
    screen.delay(20)
    
    # transform turtle into a square
    turtle.penup()
    turtle.setposition(x_square, y_square)
    turtle.setheading(0)
    turtle.shape("turtle")
    turtle.shapesize(diameter, diameter)
    turtle.color(sq_colour, sq_colour)
    
    turtle_radius = 10*turtle.shapesize()[1]

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global sq_colour, x_square, y_square, h, k, a, b, turtle_radius
    
    if x_square < scene.wnd_width/2 - turtle_radius:

        square_left = x_square - turtle_radius
        square_right = x_square + turtle_radius
        square_top = y_square + turtle_radius
        square_bottom = y_square - turtle_radius

        # determinants for each side of the square
        x_left_det = (b/a)*math.sqrt(abs(math.pow(a, 2) - math.pow((square_left - h), 2)))
        x_right_det = (b/a)*math.sqrt(abs(math.pow(a, 2) - math.pow((square_right - h), 2)))
        y_up_det = (a/b)*math.sqrt(abs(math.pow(b, 2) - math.pow((square_top - k), 2)))
        y_down_det = (a/b)*math.sqrt(abs(math.pow(b, 2) - math.pow((square_bottom - k), 2)))

        # yellow outside the ellipse
        sq_colour = "#ffff00"
        if square_top > k - x_left_det and square_bottom < k + x_left_det and\
           square_top > k - x_right_det and square_bottom < k + x_right_det and\
           square_left > h - y_up_det and square_right < h + y_up_det and\
           square_left > h - y_down_det and square_right < h + y_down_det:
            # green inside the ellipse
            sq_colour = "#00ff00"
        turtle.color(sq_colour, sq_colour)
            
        # change ball's coordinates
        turtle.setposition(x_square, y_square)

        x_square += 10
        screen.ontimer(play(0,0), 500)
    else:
        x_square = 50 - scene.wnd_width/2; y_square = 0
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
