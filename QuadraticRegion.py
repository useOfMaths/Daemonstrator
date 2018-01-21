#!usr/bin/env python3

import math
from Facet import Template

def prep():
    global ball_colour, x_ball, y_ball, xq_lb, xq_ub, turtle_radius

    # bind fun function
    scene.button.onrelease(play)
    
    turtle.penup()
    # button text
    turtle.setposition(scene.button.xcor(), scene.button.ycor()-10)
    turtle.pendown()
    turtle.write("Move", align="center", font=("Arial",16,"bold"))

    # ball parameters
    diameter = 5
    ball_colour = "#ffff00"
    x_ball = 100 - scene.wnd_width/2; y_ball = 0

    # quadratic curve parameters
    xq_start = -200; yq_start = scene.wnd_height/3
    xq_min = 0; yq_min = -scene.wnd_height/3
    
    a = (yq_start - yq_min) / math.pow((xq_start - xq_min), 2)
    b = -2*a*xq_min
    c = yq_min + a*math.pow(xq_min, 2)

    # curve bounds
    discriminant = math.sqrt(b*b - 4*a*(c - y_ball))
    if a < 0: # a is -ve
        xq_lb = (-b + discriminant) / (2*a) # upper boundary
        xq_ub = (-b - discriminant) / (2*a) # lower boundary
    else: # a is +ve
        xq_lb = (-b - discriminant) / (2*a) # lower boundary
        xq_ub = (-b + discriminant) / (2*a) # upper boundary

    # draw quadratic curve
    xq = xq_start; yq = yq_start
    turtle.penup()
    turtle.setposition(xq, yq)
    turtle.pendown()
    while xq <= -xq_start:
        yq = a*xq*xq + b*xq + c
        turtle.setposition(xq, yq)
        xq += 1
    
    screen.delay(20)
    
    # transform turtle into a ball
    turtle.penup()
    turtle.setposition(x_ball, y_ball)
    turtle.setheading(0)
    turtle.shape("turtle")
    turtle.shapesize(diameter, diameter)
    turtle.color(ball_colour, ball_colour)
    
    turtle_radius = 10*turtle.shapesize()[1]

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_ball, y_ball, ball_colour, xq_lb, xq_ub, turtle_radius
    
    if x_ball < scene.wnd_width/2 - turtle_radius:
        # yellow outside the quadratic region
        ball_colour = "#ffff00"
        if (x_ball - turtle_radius <= xq_lb and x_ball + turtle_radius >= xq_lb) or\
           (x_ball - turtle_radius <= xq_ub and x_ball + turtle_radius >= xq_ub):
            # red on the quadratic outline
            ball_colour = "#ff0000"
        elif x_ball - turtle_radius >= xq_lb and x_ball + turtle_radius <= xq_ub:
            # green inside the quadratic region
            ball_colour = "#00ff00"
        turtle.color(ball_colour, ball_colour)
            
        # change ball's coordinates
        turtle.setposition(x_ball, y_ball)

        x_ball += 10
        screen.ontimer(play(0,0), 500)
    else:
        x_ball = 100 - scene.wnd_width/2; y_ball = 0
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
