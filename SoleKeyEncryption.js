"use strict";

function encodeWord(msg, key) {
    // encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
    //                        2
    var encryption = [];
    var n;
    var t1;
    var Tn;
    for (var i = 0; i < msg.length; i++) {
        // get unicode of this character as t1
        t1 = msg.charCodeAt(i);
        // get next key digit as n
        n = Number('0x' + key[i % (key.length - 1)]);
        // use recurrence series equation to encrypt & save in base 16
        Tn = bigInt(3).pow(n - 1).multiply(bigInt(2 * t1 + 1)).subtract(bigInt.one).divide(bigInt(2));
        encryption[i] = Tn.toString(16);
    }

    return encryption;
}

function decodeWord(code, key) {
    // decoding eqn { t1 = 3^1-n(2Tn + 1) - 1 }
    //                        2
    var decryption = [];
    var n;
    var t1;
    var Tn;
    for (var i = 0; i < code.length; i++) {
        Tn = bigInt(code[i], 16);
        // get next key digit as n
        n = Number('0x' + key[i % (key.length - 1)]);
        // use recurrence series equation to decrypt
        t1 = bigInt(2 * Tn + 1).divide(bigInt(3).pow(n - 1)).subtract(bigInt.one).divide(bigInt(2));
        decryption[i] = String.fromCharCode(t1);
    }

    return decryption;
}