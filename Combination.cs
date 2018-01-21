using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Combination
    {
        public List<string> words;
        public int r; // min length of word
        protected List<string[]> comb_store;
        private int i;

        public Combination()
        {
        }

        // point of entry
        public List<string[]> possibleWordCombinations(List<string> candidates, int size) {
            words = candidates;
            r = size;
            comb_store = new List<string[]>();
            i = 0;
            // check for conformity
            if (r <= 0 || r > words.Count) {
                comb_store = new List<string[]>();
            }
            else if (r == 1) {
                for (; i < words.Count; i++) {
                    comb_store.Add(new string[] { words[i] });
                }
            }
            else {
                progressiveCombination();
            }
            return comb_store;
        }

        // do combinations for all 'words' element
        private void progressiveCombination() {
            //                  single member list
            repetitivePairing(new List<string>() {words[i]}, i + 1);
            if (i + r <= words.Count) {
                // move on to next degree
                i++;
                progressiveCombination();
            }
        }

        // do all possible combinations for 1st element of this array
        private void repetitivePairing(List<string> prefix, int position) {
            List<string>[] auxiliary_store = new List<string>[words.Count - position];
            for (int j = 0; position < words.Count; position++, j++) {
                // check if desired -- r -- size will be realised
                if (j + i + r <= words.Count) {
                    auxiliary_store[j] = new List<string>();
                    auxiliary_store[j].AddRange(prefix);
                    auxiliary_store[j].Add(words[position]);
                    if (auxiliary_store[j].Count < r) {
                        // see to adding next word on
                        repetitivePairing(auxiliary_store[j], position + 1);
                    }
                    else {
                        comb_store.Add(auxiliary_store[j].ToArray());
                    }
                }
            }
        }
    }
}
