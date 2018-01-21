#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global x_max, y_max, x_min, y_min, x_dot, y_dot, a, b, c, d, x_start, x_stop, restart
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
    x_max = 20 - scene.wnd_width/4; y_max = scene.wnd_height/3
    x_min = scene.wnd_width/4 - 20; y_min = -scene.wnd_height/3
    # constants
    a = -2*(y_max - y_min) / math.pow((x_max - x_min), 3)
    b = -(3/2)*a*(x_max + x_min)
    c = 3*a*x_max*x_min
    d = y_max + (a/2)*(x_max - 3*x_min)*math.pow(x_max, 2)

    x_start = 2*x_max; x_stop = -x_start
    x_dot = x_start
    y_dot = a*math.pow(x_dot, 3) + b*math.pow(x_dot, 2) + c*x_dot + d

    # transform turtle into a dot
    turtle.penup()
    turtle.setposition(x_dot, y_dot)
    turtle.setheading(0)
    turtle.shape("arrow")
    turtle.shapesize(diameter, diameter)
    turtle.color(dot_colour, dot_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_max, y_max, x_min, y_min, x_dot, y_dot, a, b, c, d, x_start, x_stop, restart

    if restart:
        turtle.clearstamps()
        restart = False
    
    if x_dot <= x_stop:
        y_dot = a*math.pow(x_dot, 3) + b*math.pow(x_dot, 2) + c*x_dot + d
        
        # change dot's coordinates
        turtle.setposition(x_dot, y_dot)
        turtle.stamp()

        x_dot += 20
        screen.ontimer(play(0,0), 500)
    else:
        x_dot = x_start
        y_dot = a*math.pow(x_dot, 3) + b*math.pow(x_dot, 2) + c*x_dot + d
        restart = True
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
