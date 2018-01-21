#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global sq_colour, x_square, y_square, a, b, r, turtle_radius

    # bind fun function
    scene.button.onrelease(play)
    
    # square parameters
    diameter = 5
    sq_colour = "#ffff00"
    x_square = 100 - scene.wnd_width/2; y_square = 0

    # centre point
    a = 0
    b = 0
    r = round(scene.wnd_height / 3) # circle radius
    # draw circle
    turtle.penup()
    turtle.setposition(a+r, b)
    turtle.pendown()
    turtle.circle(r)
    
    turtle.penup()
    # button text
    turtle.setposition(scene.button.xcor(), scene.button.ycor()-10)
    turtle.pendown()
    turtle.write("Move", align="center", font=("Arial",16,"bold"))

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
    global sq_colour, x_square, y_square, a, b, r, turtle_radius
    
    if x_square < scene.wnd_width/2 - turtle_radius:

        square_left = x_square - turtle_radius
        square_right = x_square + turtle_radius
        square_top = y_square + turtle_radius
        square_bottom = y_square - turtle_radius

        # determinants for each side of the square
        x_left_det = math.sqrt(abs(math.pow(r, 2) - math.pow((square_left - a), 2)))
        x_right_det = math.sqrt(abs(math.pow(r, 2) - math.pow((square_right - a), 2)))
        y_up_det = math.sqrt(abs(math.pow(r, 2) - math.pow((square_top - b), 2)))
        y_down_det = math.sqrt(abs(math.pow(r, 2) - math.pow((square_bottom - b), 2)))

        # yellow outside the circle
        sq_colour = "#ffff00"
        if square_top > b - x_left_det and square_bottom < b + x_left_det and\
           square_top > b - x_right_det and square_bottom < b + x_right_det and\
           square_left > a - y_up_det and square_right < a + y_up_det and\
           square_left > a - y_down_det and square_right < a + y_down_det:
            # green inside the circle
            sq_colour = "#00ff00"
        turtle.color(sq_colour, sq_colour)
            
        # change ball's coordinates
        turtle.setposition(x_square, y_square)

        x_square += 10
        screen.ontimer(play(0,0), 500)
    else:
        x_square = 100 - scene.wnd_width/2; y_square = 0
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
