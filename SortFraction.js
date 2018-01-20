numerators = [3, 5, 2, 1];//enter your own numerators
denominators = [4, 4, 4, 4];//enter your own denominators
var final_numerators = [];
var final_denominators = [];

function sortAscending() {
        var copy_numerators = [];

        canonizeFraction();

        // copy numerators of transformed fractions
        for (var i = 0; i < new_numerators.length; i++) {
            copy_numerators[i] = new_numerators[i];
        }

        // sort it
        copy_numerators.sort(function (a, b) {return a - b; });

        // map sorted (transformed) fractions to the original ones
        // STEP 3:
        for (var i = 0; i < copy_numerators.length; i++) {
            index = new_numerators.indexOf(copy_numerators[i]);
            final_numerators[i] = numerators[index];
            final_denominators[i] = denominators[index];
        }
}

function sortDescending() {
        var copy_numerators = [];

        canonizeFraction();

        // copy numerators of transformed fractions
        for (var i = 0; i < new_numerators.length; i++) {
            copy_numerators[i] = new_numerators[i];
        }

        // sort it
        copy_numerators.sort(function (a, b) {return b - a; });

        // map sorted (transformed) fractions the original ones
        // STEP 3:
        for (var i = 0; i < copy_numerators.length; i++) {
            index = new_numerators.indexOf(copy_numerators[i]);
            final_numerators[i] = numerators[index];
            final_denominators[i] = denominators[index];
        }
}
