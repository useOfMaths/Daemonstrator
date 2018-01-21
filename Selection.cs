using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Selection
    {
        public string[] words;
        public int r; // min length of word
        protected List<string[]> complete_group;
        private int i;

        public Selection()
        {
        }

        public List<string[]> groupSelection(string[] candidates, int size) {
            words = candidates;
            r = size;
            complete_group = new List<string[]>();
            i = 0;
            recursiveFillUp(new List<string>());

            return complete_group;
        }

        // pick elements recursively
        protected void recursiveFillUp(List<string> temp) {
            List<string>[] picked_elements = new List<string>[words.Length];
            int j = i;
            while (j < words.Length) {
                picked_elements[j] = new List<string>();
                picked_elements[j].AddRange(temp);
                picked_elements[j].Add(words[j]);
                // recoil factor
                if (i >= words.Length) {
                    i = j;
                }
                // satisfied yet?
                if (picked_elements[j].Count == r) {
                    complete_group.Add(picked_elements[j].ToArray());
                }
                else if (picked_elements[j].Count < r) {
                    recursiveFillUp(picked_elements[j]);
                }
                j++;
            }
            if (picked_elements[--j] != null && picked_elements[j].Count == r) {
                i++; // keep recoil factor straightened out
            }
        }
    }
}
