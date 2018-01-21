"use strict";

function hashWord(msg) {
    // encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
    var hash;
    var n;
    var t1;
    var x;
    for (var i = 0; i < msg.length; i++) {
        // get unicode of this character as n
        n = msg.charCodeAt(i);
        t1 = i + 1;
        // use recurrence series equation to hash
        x = bigInt(n).subtract(2).multiply(t1).add(bigInt(2).pow(n));
        if (i === 0) {
            hash = x;
            continue;
        }
        // bitwise rotate left with the modulo of x
        var binary = bigInt(hash).toString(2);
        x = bigInt(x).mod(binary.length);
        
        var slice_1 = binary.slice(x).split('');
        // keep as '1' to preserve hash size
        slice_1[0] = 1;
        slice_1 = slice_1.join('');
        var slice_2 = binary.slice(0, x);
        
        hash = String(slice_1) + String(slice_2);
        hash = bigInt(hash, 2);
    }
    hash = bigInt(hash).toString(16);
    hash = hash.toUpperCase();

    return hash;
}