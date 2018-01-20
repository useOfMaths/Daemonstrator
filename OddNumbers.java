package arithmetic;

public class OddNumbers {

    private int start; // Our starting point
    private final int stop; // where we will stop
    private String result; // Store result here.

    public OddNumbers(int first, int last) {
        start = first;
        stop = last;
        result = "Odd numbers between " + first + " and " + last + " are: \n";
    }

    String prepResult() {
        /*
        * Loop from start to stop and rip out odd numbers;
         */
        while (start <= stop) {
            if (start % 2 != 0) {
                result += start + "; "; // Mind the '+' in front of the '='
            }
            start++; // increase start by 1(same as start = start + 1
        }
        return result;
    }
    
}
