var numerators = [1, 1, 1, 1];//enter your own numerators
var denominators = [4, 4, 4, 4];//enter your own denominators
var new_numerators = [];
var answer = 0;
var LCM = 0;

all_factors = [];
state_check = false;
i = 2;
index = 0;

function canonizeFraction() {
    // find the LCM of denominators
    // STEP 1:
    LCM = getLCM(denominators);

    // transform fractions so they all have same denominator
    // STEP 2:
    for (var i = 0; i < denominators.length; i++) {
        new_numerators[i] = LCM / denominators[i] * numerators[i];
    }
}

function doAdd() {
    canonizeFraction();

    // add all transformed numerators
    // STEP 3:
    for (var i = 0; i < new_numerators.length; i++) {
        answer += new_numerators[i];
    }
}
