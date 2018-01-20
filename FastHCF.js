var common_factors = []; // factors common to our group_of_numbers
var index = 0; // index into array common_factors
var state_all_round_factor = false; // variable to keep state
var found_prime_factors = [];
var count = 0; // index into array 'found_prime_factors'

/* Pass of Array(according to javascript) is by reference;
 so make a copy that will be passed instead. */
var arg_copy = [];

var i;

// STEP 2:
/*
 Compiles only the factors of the smallest member of 'group_of_numbers'
 */
function onlyPrimeFactors(sub_level) {
    var temp_limit = Math.ceil(Math.sqrt(sub_level));

    while (i <= temp_limit) {
        if (i != 1 && (sub_level % i) == 0) { // avoid an infinte loop with the i != 1 check.
            found_prime_factors[count++] = i;
            return onlyPrimeFactors(sub_level / i);
        }
        i++;
    }
    found_prime_factors[count] = sub_level;

    return;
}

/*
 * Our function checks 'group_of_numbers';
 * If it finds a factor common to all fo it, it records this factor;
 * then divides 'group_of_numbers' by the common factor found
 * and makes this the new 'group_of_numbers'.
 * It continues recursively until all common factors are found.
 */
function getHCFFactors(operate_on) {
    while (i < found_prime_factors.length) {
        state_all_round_factor = true;
        // STEP 3:
        for (var j = 0; j < operate_on.length; j++) {
            if (state_all_round_factor == true && (operate_on[j] % found_prime_factors[i]) == 0) {
                state_all_round_factor = true;
            } else {
                state_all_round_factor = false;
            }
        }
        // STEP 4:
        if (state_all_round_factor == true) {
            for (var j = 0; j < operate_on.length; j++) {
                operate_on[j] /= found_prime_factors[i];
            }
            common_factors[index++] = found_prime_factors[i];
        }
        i++;
    }
    return;
}

function getFastHCF(group) {
    // STEP 1:
    // Sort in ascending order
    group_of_numbers.sort(
            function (a, b) {
                return a - b;
            }
    );
    i = 2; // start checking for factors from variable 2
    onlyPrimeFactors(group[0]);

    for (var j = 0; j < group.length; j++) {
        arg_copy[j] = group[j];
    }
    i = 0;
    getHCFFactors(arg_copy); // call to our function

    var HCF = 1;
    for (var k = 0; k < common_factors.length; k++) {
        HCF *= common_factors[k];
    }

    return HCF;
}