#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global theta, y_dot, a, restart
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
    # find the closest multiple of 180 to the left of the screen
    theta = math.floor(scene.wnd_width/360) * -180
    a = scene.wnd_height/3 # constant
    y_dot = a * math.sin(theta * math.pi/180)

    # transform turtle into a dot
    turtle.penup()
    turtle.setposition(theta, y_dot)
    turtle.setheading(0)
    turtle.shape("square")
    turtle.shapesize(diameter, diameter)
    turtle.color(dot_colour, dot_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global theta, y_dot, a, restart
    
    if restart:
        turtle.clearstamps()
        restart = False
    
    if theta < scene.wnd_width/2 - 10*turtle.shapesize()[1]:
        y_dot = a * math.sin(theta * math.pi/180)
        # change dot's coordinates
        turtle.setposition(theta, y_dot)
        turtle.stamp()

        theta += 15
        screen.ontimer(play(0,0), 500)
    else:
        theta = 5 - scene.wnd_width/2
        y_dot = a * math.sin(theta * math.pi/180)
        restart = True
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
