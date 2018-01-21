#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global x_start, y_start, x_max, y_max, x_dot, y_dot, a, b, c, restart
    restart = False
    
    # bind fun function
    scene.button.onrelease(play)
    screen.delay(20)
    
    turtle.penup()
    # button text
    turtle.setposition(scene.button.xcor(), scene.button.ycor()-10)
    turtle.pendown()
    turtle.write("Move", align="center", font=("Arial",16,"bold"))

    # dot parameters
    diameter = 1
    dot_colour = "#ffff00"
    x_start = 100 - scene.wnd_width/2; y_start = -scene.wnd_height/3
    x_max = 0; y_max = scene.wnd_height/3
    x_dot = x_start; y_dot = y_start

    # constants
    a = (y_start - y_max) / math.pow((x_start - x_max), 2)
    b = -2*a*x_max
    c = y_max + a*math.pow(x_max, 2)

    # transform turtle into a dot
    turtle.penup()
    turtle.setposition(x_dot, y_dot)
    turtle.setheading(0)
    turtle.shape("triangle")
    turtle.shapesize(diameter, diameter)
    turtle.color(dot_colour, dot_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_start, y_start, x_max, y_max, x_dot, y_dot, a, b, c, restart

    if restart:
        turtle.clearstamps()
        restart = False
    
    if x_dot <= 10*turtle.shapesize()[1] - x_start:
        y_dot = a*x_dot*x_dot + b*x_dot + c
        
        # change dot's coordinates
        turtle.setposition(x_dot, y_dot)
        turtle.stamp()

        x_dot += 20
        screen.ontimer(play(0,0), 500)
    else:
        x_dot = x_start; y_dot = y_start
        restart = True
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
