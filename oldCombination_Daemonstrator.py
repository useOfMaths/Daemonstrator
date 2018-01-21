import turtle
import random

def environment():
    global wnd, wnd_width, wnd_height

    wnd = turtle.Screen()
    wnd.title("useOfMaths.com -- Combination Daemonstration")
    wnd.setup(width=0.98, height=0.95, startx=0, starty=0)
    wnd.colormode(255)

    wnd.delay(20)
    turtle.speed(1)

    wnd_width = wnd.window_width()
    wnd_height = wnd.window_height()

    turtle.resizemode("user")
    wnd.setworldcoordinates(-30, 0, wnd_width+30, wnd_height)

# draw text at some position
def placeText(text, x, y, colour='#000000'):
    turtle.color(colour)
    turtle.penup()
    turtle.setposition(x, y)
    turtle.pendown()
    turtle.write(text, align="center", font=("Arial",16,"bold"))

# draw line at some position
def placeLine(x1, y1, x2, y2, colour='#000000', dir=0):
    turtle.color(colour)
    turtle.setheading(dir)
    turtle.penup()
    turtle.setposition(x1, y1)
    turtle.pendown()
    turtle.setposition(x2, y2)

# point of entry
def setOut(candidates, size):
    global words, r, word_x_coords, top_y, indice, line_height, text_height, hexadecimal

    words = candidates
    r = size
    word_x_coords = [] # list to hold word positions
    top_y = wnd_height - 50
    indice = 0
    hexadecimal = ['0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f']
    
    line_height = wnd_height / len(words)
    text_height = 30
    # draw and record 'words' and their positions overhead
    for i in range(len(words)):
        word_x_coords.append(i * wnd_width/len(words))
        placeText(words[i], word_x_coords[i], top_y)

    # check for conformity
    if r <= 0 or r > len(words):
        # point direction
        placeLine(0, wnd_height, wnd_width, 0, -45)
        placeLine(wnd_width, wnd_height, 0, 0, 225)

    elif r == 1:
        for i in range(len(words)):
            colour = '#' + ''.join([random.choice(hexadecimal) for _ in range(6)])
            placeLine(word_x_coords[i], top_y, word_x_coords[i], top_y - line_height, col_string, -90)
            placeText(words[i], word_x_coords[i], top_y - line_height - text_height, col_string)

    else:
        top_y += text_height
        line_height -= text_height
        
        progressiveCombination()


# do combinations for all 'words' element
def progressiveCombination():
    global words, r, indice, word_y_coords, retract_height

    word_y_coords = [top_y for _ in range(indice+1)]
    retract_height = 0
    #            single member list
    repetitivePairing([words[indice]], indice + 1)
    if len(words) - indice >= r:
        # move on to next degree
        indice += 1
        #progressiveCombination()

    turtle.done()

# do all possible combinations for 1st element of this array
def repetitivePairing(prefix, position):
    global words, r, word_x_coords, word_y_coords, top_y, line_height, retract_height, text_height, hexadecimal

    word_y_coords.append(word_y_coords[len(word_y_coords) - 1] - line_height)
    print ("\nposition = ", position, "; len(word_y_coords) = ", len(word_y_coords), "\n")
    auxiliary_store = [[] for _ in range(len(words) - position)]
    for j in range(len(words) - position):
        auxiliary_store[j].extend(prefix)
        auxiliary_store[j].append(words[position])

        colour = '#' + ''.join([random.choice(hexadecimal) for _ in range(6)])
        if retract_height == 0: placeLine(word_x_coords[position - j - 1], word_y_coords[position - j - 1] - text_height, word_x_coords[position], word_y_coords[position - j], colour, -75)
        else: placeLine(word_x_coords[position - j - 1], retract_height - text_height, word_x_coords[position], word_y_coords[position - j], colour, -75)
        placeLine(word_x_coords[position], top_y - text_height, word_x_coords[position], word_y_coords[position - j], colour, 225)
        placeText(' + '.join(auxiliary_store[j]), word_x_coords[position], word_y_coords[position - j] - text_height, colour)

        print (' + '.join(auxiliary_store[j]), "\nj = ", j, "; position = ", position, "\n")

        if position > 1 and position - j == r - 2:
            retract_height = word_y_coords[position - j]
        if len(auxiliary_store[j]) < r:
            prev_pos = position - j
            # see to adding next word on
            repetitivePairing(auxiliary_store[j], position + 1)

        position += 1

    retract_height = 0
    print("Loop completed!!!")


# Call point
environment()
broadcast = setOut(["Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda"], 3)

