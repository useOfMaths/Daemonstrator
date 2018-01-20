
var x_2coeff = [2, 3];
var y_2coeff = [1, -1];
var eq_2coeff = [3, 2];
var eliminator = [];
eliminator[0] = [];
eliminator[1] = [];
var x_variable;
var y_variable;

function solveSimultaneous2D() {
    // STEP 2:
    eliminator[0][0] = y_2coeff[1] * x_2coeff[0];
    eliminator[0][1] = y_2coeff[1] * eq_2coeff[0];
    // STEP 3:
    eliminator[1][0] = y_2coeff[0] * x_2coeff[1];
    eliminator[1][1] = y_2coeff[0] * eq_2coeff[1];

    try {
        // STEPS 4, 5:
        x_variable = (eliminator[0][1] - eliminator[1][1]) / 
                (eliminator[0][0] - eliminator[1][0]);
        // STEP 6:
        y_variable = (eq_2coeff[0] - x_2coeff[0]*x_variable) / y_2coeff[0];
    } catch (ex) {
        throw ex;
    }
}
