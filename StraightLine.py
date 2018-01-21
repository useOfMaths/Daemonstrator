#!usr/bin/env python3

from Facet import Template

def prep():
    global x1, y1, x_dot, y_dot, m, c, restart
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
    x1 = 30 - scene.wnd_width/2; y1 = scene.wnd_height/3
    x2 = scene.wnd_width/2 - 30; y2 = -scene.wnd_height/3
    x_dot = x1; y_dot = y1

    m = (y2 - y1) / (x2 - x1) # slope
    c = (x2*y1 - x1*y2) / (x2 - x1) # y-intercept

    # transform turtle into a dot
    turtle.penup()
    turtle.setposition(x_dot, y_dot)
    turtle.setheading(0)
    turtle.shape("classic")
    turtle.shapesize(diameter, diameter)
    turtle.color(dot_colour, dot_colour)

# fun function when button is clicked
# just moves turtle until it hits the right boundary
def play(x, y):
    global x_dot, y_dot, m, c, x1, y1, restart
    
    if restart:
        turtle.clearstamps()
        restart = False
    
    if x_dot < scene.wnd_width/2 - 10*turtle.shapesize()[1]:
        y_dot = m*x_dot + c
        # change dot's coordinates
        turtle.setposition(x_dot, y_dot)
        turtle.stamp()

        x_dot += 20
        screen.ontimer(play(0,0), 500)
    else:
        x_dot = x1; y_dot = y1
        restart = True
        screen.mainloop()

# Let fly
scene = Template();
turtle = scene.controlButtons()
screen = scene.screen

prep()
