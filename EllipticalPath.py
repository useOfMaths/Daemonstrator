#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global x_dot, y_dot, h, k, a, b, restart
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
    # centre point
    h = 0
    k = 0
    # major/minor axis
    a = scene.wnd_width / 3
    b = scene.wnd_height / 3
    x_dot = h - a; y_dot = k

    # transform turtle into a dot
    turtle.penup()
    turtle.setposition(x_dot, y_dot)
    turtle.setheading(270)
    turtle.shape("triangle")
    turtle.shapesize(diameter, diameter)
    turtle.color(dot_colour, dot_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_dot, y_dot, h, k, a, b, restart
    
    if restart:
        turtle.clearstamps()
        restart = False
    
    if x_dot <= h + a:
        y_dot = k - (b/a)*math.sqrt(math.pow(a, 2) - math.pow((x_dot - h), 2))
        # change dot's coordinates
        turtle.setposition(x_dot, y_dot)
        turtle.stamp()
        
        y_dot = k + (b/a)*math.sqrt(math.pow(a, 2) - math.pow((x_dot - h), 2))
        # change dot's coordinates
        turtle.setposition(x_dot, y_dot)
        turtle.stamp()

        x_dot += 20
        screen.ontimer(play(0,0), 500)
    else:
        x_dot = h - a; y_dot = k
        restart = True
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
