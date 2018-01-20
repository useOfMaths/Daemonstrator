package arithmetic;

public class EvenNumbers {
    private int start; // Our starting point
    private final int stop; // where we will stop
    private String result; // Store result here.
    
    // Our constructor
    public EvenNumbers(int first, int last) {
        start = first;
        stop = last;
        result = "Even numbers between " + first + " and " + last + " are: \n";
    }

    public String prepResult() {
        /*
        * Loop from start to stop and rip out even numbers;
         */
        while (start <= stop) {
            if (start % 2 == 0) { // modulo(%) is explained below
                result = result + start + "; ";
            }
            start = start + 1; // increase start by 1
        }
        return result;
    }
}
