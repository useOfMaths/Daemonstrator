using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Permutation : Combination
    {
        private List<string[]> local_store;
        protected List<string[]> perm_store;
        private int index;

        public Permutation() : base()
        {
        }

        // till the ground for shuffle to grind on
        public List<string[]> possibleWordPermutations(List<string> candidates, int size) {
            perm_store = new List<string[]>();
            possibleWordCombinations(candidates, size);
            // illegal 'r' value
            if (comb_store.Count == 0 || r == 1) {
                    perm_store = comb_store;
            }
            else {
                List<string[]> last_two;
                last_two = new List<string[]>(){ new string[]{ "", "" }, new string[]{ "", "" } };
                for (int i = 0; i < comb_store.Count; i++) {
                    index = r - 1;
                    // copy up last two elements of 'comb_store[i]'
                    last_two[0][0] = last_two[1][1] = comb_store[i][index--];
                    last_two[0][1] = last_two[1][0] = comb_store[i][index--];
                    local_store = new List<string[]>();
                    local_store.Add(last_two[0]);
                    local_store.Add(last_two[1]);
                    if (r > 2) {
                        shuffleWord(local_store, i);
                    }
                    perm_store.AddRange(local_store);
                }
            }
            return perm_store;
        }

        private void shuffleWord(List<string[]> arg_store, int i) {
            local_store = new List<string[]>();
            List<string> members;
            for (int j = 0; j < arg_store.Count; j++) {
                members = new List<string>();
                members.AddRange(arg_store[j]);
                // add 'index' 'comb_store[i]' element to this list of members
                members.Add(comb_store[i][index]);

                string temp_char;
                int shift_index = members.Count;
                // shuffle this pack of words
                while (shift_index > 0) {
                    // skip if already in store
                    if (!local_store.Contains(members.ToArray())) {
                        local_store.Add(members.ToArray());
                    }
                    // interchange these two neighbours
                    if (--shift_index > 0 && !members[shift_index].Equals(members[shift_index - 1])) {
                        temp_char = members[shift_index];
                        members[shift_index] = members[shift_index - 1];
                        members[shift_index - 1] = temp_char;
                    }
                }
            }
            // Are there any elements left? repeat if yes
            if (index-- > 0) {
                shuffleWord(local_store, i);
            }
        }
    }
}
