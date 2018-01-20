package arithmetic;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /* Use the Even Number class. */
        String answer;
        
        EvenNumbers even_data = new EvenNumbers(1, 100); // even numbers between 1 and 100
        answer = even_data.prepResult();

        System.out.println(answer);

        System.out.println();
    }

}
