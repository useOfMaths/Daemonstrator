"use strict";

/*
 * STEP VI:
 */
function encodeWord(msg, key, semi_prime) {
    var encryption = [];
    var x;
    for (var i = 0; i < msg.length; i++) {
        // get unicode of this character as x
        x = msg.charCodeAt(i);
        // use RSA to encrypt & save in base 16
        encryption[i] = bigInt(x).modPow(key, semi_prime).toString(16);
    }

    return encryption;
}

/*
 * STEP VII:
 */
function decodeWord(code, key, semi_prime) {
    var decryption = "";
    var c;
    for (var i = 0; i < code.length; i++) {
        // use RSA to decrypt
        c = bigInt(code[i], 16).modPow(key, semi_prime);
        decryption += String.fromCharCode(c);
    }

    return decryption;
}