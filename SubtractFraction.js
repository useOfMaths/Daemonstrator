numerators = [1, 1, 1, 1];//enter your own numerators
denominators = [4, 4, 4, 4];//enter your own denominators

function doSubtract() {
    canonizeFraction();

    // subtract all transformed numerators
    // STEP 3:
    answer = new_numerators[0];
    for (var i = 1; i < new_numerators.length; i++) {
        answer -= new_numerators[i];
    }
}
