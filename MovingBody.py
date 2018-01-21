#!usr/bin/env python3

from Facet import Template

def prep():
    global x_ball, y_ball
    
    # bind fun function
    scene.button.onrelease(play)
    screen.delay(20)
    
    # ball parameters
    x_ball = 100 - scene.wnd_width/2; y_ball = 0
    diameter = 5
    ball_colour = "#ffff00"
    
    turtle.penup()
    # button text
    turtle.setposition(scene.button.xcor(), scene.button.ycor()-10)
    turtle.pendown()
    turtle.write("Move", align="center", font=("Arial",16,"bold"))

    # transform turtle into a ball
    turtle.penup()
    turtle.setposition(x_ball, y_ball)
    turtle.shape("circle")
    turtle.shapesize(diameter, diameter)
    turtle.color(ball_colour, ball_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_ball, y_ball
    
    if x_ball <= scene.wnd_width/2 - 10*turtle.shapesize()[1]:
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
