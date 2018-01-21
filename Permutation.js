var origin = [];
var local_store = [];
var perm_store = [];

// till the ground for shuffle to grind on
function possibleWordPermutations(candidates, size) {
    var combination = possibleWordCombinations(candidates, size);
    // illegal 'r' value
    if (combination[0] === undefined || r == 1) {
        perm_store = combination;
    } else {
        for (var i in combination) {
            origin = combination[i].split(separator);
            local_store = [];
            // store up last two words of this element
            local_store.unshift(origin.slice(-2, -1) + separator + origin.slice(-1));
            // store up last two words interchanged;
            // leaving 'origin' without its last 2 elements
            local_store.unshift(origin.pop() + separator + origin.pop());

            if (r > 2) {
                shuffleWord(local_store.slice(0));
            }
            perm_store = perm_store.concat(local_store);
        }
    }
    return perm_store;
}

function shuffleWord(temp_store) {
    local_store = [];
    for (var i in temp_store) {
        var members = temp_store[i].split(separator);
        // add last 'origin' element to this list of members
        members.push(origin.slice(-1));

        var shift_index = members.length;
        var temp_char;
        // shuffle this pack of words
        while (shift_index > 0) {
            var candidate = members.join(separator);
            var find = local_store.indexOf(candidate);
            // skip if already in store
            if (find == -1) {
                local_store.push(candidate);
            }
            shift_index--;
            // interchange these two neighbours
            if (shift_index > 0 && members[shift_index] != members[shift_index - 1]) {
                temp_char = members[shift_index];
                members[shift_index] = members[shift_index - 1];
                members[shift_index - 1] = temp_char;
            }
        }
    }
    // Leave 'origin' without its current last element
    origin.pop();
    // Are there any elements left in origin?
    // if yes, then repeat
    if (origin.length > 0) {
        shuffleWord(local_store);
    }
}
