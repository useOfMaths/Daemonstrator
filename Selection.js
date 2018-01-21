var words;
var r; // min length of word
var separator = ", ";
var i;
var complete_group = [];


function groupSelection(candidates, size) {
    words = candidates;
    r = size;

    i = 0;
    recursiveFillUp("");
    return complete_group;
}

// pick elements recursively
function recursiveFillUp(temp) {
    var picked_elements = [];
    var j = i;
    while (j < words.length) {
        picked_elements[j] = temp + words[j];
        // recoil factor
        if (i >= words.length) {
            i = j;
        }
        // satisfied yet?
        if (picked_elements[j].split(separator).length == r) {
            complete_group.push(picked_elements[j]);
        } else if (picked_elements[j].split(separator).length < r) {
            recursiveFillUp(picked_elements[j] + separator);
        }
        j++;
    }
    if (picked_elements[--j] !== undefined &&
            picked_elements[j].split(separator).length == r) {
        i++; // keep recoil factor straightened out
    }
}