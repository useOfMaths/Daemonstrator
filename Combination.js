var words, r; // min length of word
var separator = ", ";
var comb_store;
var i;

// point of entry
function possibleWordCombinations(candidates, size) {
    words = candidates;
    r = size;
    comb_store = [];
    i = 0;
    // check for conformity
    if (r <= 0 || r > words.length) {
        comb_store = [];
    } else if (r == 1) {
        comb_store = words;
    } else {
        progressiveCombination();
    }
    return comb_store;
}

// do combinations for all 'words' element
function progressiveCombination() {
    repetitivePairing(words[i], i + 1);
    if (i + r <= words.length) {
        // move on to next degree
        i++;
        progressiveCombination();
    }
}

// do all possible combinations for 1st element of this array
function repetitivePairing(prefix_word, position) {
    var auxiliary_store = [];
    for (var j = 0; position < words.length; position++, j++) {
        // check if desired -- r -- size will be realised
        if (j + i + r <= words.length) {
            auxiliary_store[j] = prefix_word + separator + words[position];
            if (auxiliary_store[j].split(separator).length < r) {
                // see to adding next word on
                repetitivePairing(auxiliary_store[j], position + 1);
            } else {
                comb_store.push(auxiliary_store[j]);
            }
        }
    }
}