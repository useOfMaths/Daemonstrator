var start = 1
var end = 99;
var progress = 9;
var do_next_iteration = false;
var prime_numbers = []; // This array variable would hold our prime numbers as they get verified.

/*
 * STEP 1: 
 */
prime_numbers[0] = 2;
prime_numbers[1] = 3;
prime_numbers[2] = 5;
prime_numbers[3] = 7;
var square_root = 0;
var index = 0; // index into our array
var current = 3; // Points to the current occupied array position.

/*
 * STEP 2:
 */
for (; progress < end; progress += 2) {

    do_next_iteration = false; // a flag

    //STEPS 3, 4:
    /*
     * Alright, one last check.
     * See to it that no prime number less than variable progress is a factor. 
     */
    square_root = Math.abs(Math.sqrt(progress));

    index = 0;
    for (; prime_numbers[index] <= square_root; index++) {
        if ((progress % prime_numbers[index]) == 0) {
            do_next_iteration = true;
            break;
        }
    }
    if (do_next_iteration) {
        continue;
    }

    /* 
     * If 'progress' cleared all those hurdles, then it is definitely a prime number. 
     * We'll also get our subset of smaller prime numbers from here.
     */
    prime_numbers[++current] = progress;
}