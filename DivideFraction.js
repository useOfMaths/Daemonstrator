numerators = [16, 9, 640, 7];
denominators = [9, 20, 27, 20];

function doDivide() {
    var temp;
    // Invert every other fraction but the first
    for (var i = 1; i < numerators.length; i++) {
        temp = numerators[i];
        numerators[i] = denominators[i];
        denominators[i] = temp;
    }
    doMultiply();
}
