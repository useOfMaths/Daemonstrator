var numerators = [16, 20, 27, 20];
var denominators = [9, 9, 640, 7];
var answer = [1, 1];
var n_index = 0;
var d_index = 0;
var trial_factor = 0;
var mutual_factor = false;

// search for largest numerator or denominator
function maxMember() {
    for (var i = 0; i < numerators.length; i++) {
        if (numerators[i] > trial_factor) {
            trial_factor = numerators[i];
        }
        if (denominators[i] > trial_factor) {
            trial_factor = denominators[i];
        }
    }
}


function doMultiply() {
    // STEP 3:
    // We are counting down to test for mutual factors 
    while (trial_factor > 1) {
        // STEP 1:
        // iterate through numerators and check for factors
        while (n_index < numerators.length) {
            mutual_factor = false;
            if ((numerators[n_index] % trial_factor) === 0) { // do we have a factor
                // iterate through denominators and check for factors
                while (d_index < denominators.length) {
                    if ((denominators[d_index] % trial_factor) === 0) { // is this factor mutual?
                        mutual_factor = true;
                        break; // stop as soon as we find a mutual factor so preserve the corresponding index
                    }
                    d_index++;
                }
                break; // stop as soon as we find a mutual factor so as to preserve the corresponding index
            }
            n_index++;
        }
        // STEP 3:
        // where we have a mutual factor, cancel it out
        if (mutual_factor) {
            numerators[n_index] /= trial_factor;
            denominators[d_index] /= trial_factor;
            continue; // continue with next iteration repeating the current value of trial_factor
        }
        n_index = 0;
        d_index = 0;
        trial_factor--;
    }
    // multiply whatever is left after cancelling
    for (var i = 0; i < numerators.length; i++) {
        answer[0] *= numerators[i];
        answer[1] *= denominators[i];
    }
}
