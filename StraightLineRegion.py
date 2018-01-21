#!usr/bin/env python3

from Facet import Template

def prep():
    global x_line, x_ball, y_ball

    # bind fun function
    scene.button.onrelease(play)
    screen.delay(20)
    
    turtle.penup()
    # button text
    turtle.setposition(scene.button.xcor(), scene.button.ycor()-10)
    turtle.pendown()
    turtle.write("Move", align="center", font=("Arial",16,"bold"))

    # diagonal parameters
    x1 = 0; y1 = scene.wnd_height/3
    x2 = 200; y2 = -scene.wnd_height/3
    m = (y2 - y1) / (x2 - x1) # slope
    c = (x2*y1 - x1*y2) / (x2 - x1) # y-intercept

    # ball parameters
    diameter = 5
    ball_colour = "#ffff00"
    x_ball = 100 - scene.wnd_width/2; y_ball = 0
    
    # x-coordinate where ball will cross line
    x_line = (y_ball - c) / m

    # draw diagonal
    turtle.penup()
    turtle.setposition(x1, y1)
    turtle.pendown()
    turtle.setposition(x2, y2)
    
    # transform turtle into a ball
    turtle.penup()
    turtle.setposition(x_ball, y_ball)
    turtle.setheading(0)
    turtle.shape("turtle")
    turtle.shapesize(diameter, diameter)
    turtle.color(ball_colour, ball_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_ball, y_ball, x_line
    
    if x_ball < scene.wnd_width/2 - 10*turtle.shapesize()[1]:
        # yellow to the left of the line
        ball_colour = "#ffff00"
        if x_ball >= x_line:
            # green to the right of the line
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
