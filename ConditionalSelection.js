function limitedSelection(candidates, size, minimum, maximum) {
    var final_elements = [];
    selection = groupSelection(candidates, size);
    for (var x = 0; x < selection.length; x++) {
        var state;
        var members = selection[x].split(separator);
        for (var y = 0; y < words.length; y++) {
            // get 'words[y]' frequency/count in group
            var count = 0, z = -1;
            while ((z = members.indexOf(String(words[y]), ++z)) > -1) {
                count++;
            }
            if (count >= minimum[y] && count <= maximum[y]) {
                 state = true;
            } else {
                state = false;
                break;
            }
        }
        // skip if already in net
        if (state) {
            final_elements.push(selection[x]);
        }
    }
    return final_elements;
}