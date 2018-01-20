var common_factors = []; // factors common to our group_of_numbers
var index = 0; // index into array common_factors
var state_all_round_factor = false; // variable to keep state
var i = 2; // start checking for factors from variable 2
/* Pass of Array(according to javascript) is by reference;
 so make a copy that will be passed instead. */
var arg_copy = [];

/*
 * Our function checks 'group_of_numbers';
 * If it finds a factor common to all fo it, it records this factor;
 * then divides 'group_of_numbers' by the common factor found
 * and makes this the new 'group_of_numbers'.
 * It continues recursively until all common factors are found.
 */
function getHCFFactors(operate_on) {
    while (i <= operate_on[0]) {
        state_all_round_factor = true;
        // STEP 2:
        for (var j = 0; j < operate_on.length; j++) {
            if (!(state_all_round_factor == true && (operate_on[j] % i) == 0)) {
                state_all_round_factor = false;
            }
        }
        // STEP 3:
        if (state_all_round_factor == true) {
            for (var j = 0; j < operate_on.length; j++) {
                operate_on[j] /= i;
            }
            common_factors[index++] = i;
            // STEP 4:
            return getHCFFactors(operate_on);
        }
        i++;
    }
    return;
}

function getHCF(group) {
    // STEP 1:
    // Sort in ascending order
    group_of_numbers.sort(
            function (a, b) {
                return a - b;
            }
    );
    
    for (var j = 0; j < group.length; j++) {
        arg_copy[j] = group[j];
    }
    getHCFFactors(arg_copy);

    var HCF = 1;
    for (var k = 0; k < common_factors.length; k++) {
        HCF *= common_factors[k];
    }

    return HCF;
}