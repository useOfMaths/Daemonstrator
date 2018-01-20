
var x_3coeff = [2, 4, 2];
var y_3coeff = [1, -1, 3];
var z_3coeff = [1, -2, -8];
var eq_3coeff = [4, 1, -3];
eliminator = [];
eliminator[0] = [];
eliminator[1] = [];
eliminator[2] = [];
var z_variable;

x_2coeff = [];
y_2coeff = [];
eq_2coeff = [];

function solveSimultaneous3D() {
    var lcm;
    // find the LCM z coefficients
    lcm = getLCM([Math.abs(z_3coeff[0]), Math.abs(z_3coeff[1]), Math.abs(z_3coeff[2])]);

    // STEP 1:
    eliminator[0][0] = (lcm * x_3coeff[0]) / z_3coeff[0];
    eliminator[0][1] = (lcm * y_3coeff[0]) / z_3coeff[0];
    eliminator[0][2] = (lcm * eq_3coeff[0]) / z_3coeff[0];

    eliminator[1][0] = (lcm * x_3coeff[1]) / z_3coeff[1];
    eliminator[1][1] = (lcm * y_3coeff[1]) / z_3coeff[1];
    eliminator[1][2] = (lcm * eq_3coeff[1]) / z_3coeff[1];

    eliminator[2][0] = (lcm * x_3coeff[2]) / z_3coeff[2];
    eliminator[2][1] = (lcm * y_3coeff[2]) / z_3coeff[2];
    eliminator[2][2] = (lcm * eq_3coeff[2]) / z_3coeff[2];

    // STEP 2:
    x_2coeff = [
        eliminator[0][0] - eliminator[1][0],
        eliminator[1][0] - eliminator[2][0]
    ];
    y_2coeff = [
        eliminator[0][1] - eliminator[1][1],
        eliminator[1][1] - eliminator[2][1]
    ];
    eq_2coeff = [
        eliminator[0][2] - eliminator[1][2],
        eliminator[1][2] - eliminator[2][2]
    ];

    try {
        // STEP 3:
        solveSimultaneous2D();
        // STEP 4:
        z_variable = (eq_3coeff[0] - x_3coeff[0] * x_variable -
                y_3coeff[0] * y_variable) / z_3coeff[0];
    } catch (ex) {
        throw ex;
    }
}
