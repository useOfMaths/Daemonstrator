using System;
using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class ConditionalSelection : Selection
    {
        private List<string[]> final_elements;

        public ConditionalSelection() : base()
        {
        }

        public List<string[]> limitedSelection(string[] candidates, int size, int[] minimum, int[] maximum) {
            final_elements = new List<string[]>();
            groupSelection(candidates, size);
            for (int i = 0; i < complete_group.Count; i++) {
                bool state = false;
                for (int j = 0; j < words.Length; j++) {
                    // get 'words[j]' frequency/count in group
                    int count = 0, k = -1;
                    while ((k = Array.IndexOf(complete_group[i], words[j], ++k)) > -1) {
                        count++;
                    }
                    if (count >= minimum[j] && count <= maximum[j]) {
                        state = true;
                    }
                    else {
                        state = false;
                        break;
                    }
                }
                // skip if already in net
                if (state) {
                    final_elements.Add(complete_group[i]);
                }
            }
            return final_elements;
        }
    }
}