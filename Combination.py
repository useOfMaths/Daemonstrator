# Sure enough this is a module

# define a class
class Combinatorial:

    def __init__(self):
        self.i = 0

    # point of entry
    def possibleWordCombinations(self, candidates, size):
        self.words = candidates
        self.r = size
        self.comb_store = [] # list to hold answers
        self.i = 0
        # check for conformity
        if self.r <= 0 or self.r > len(self.words):
            self.comb_store = ()
        elif self.r == 1:
            for word in self.words:
                self.comb_store.append((word))
        else:
            self.progressiveCombination()

        return self.comb_store


    # do combinations for all 'words' element
    def progressiveCombination(self):
        #            single member list
        self.repetitivePairing([self.words[self.i]], self.i + 1)
        if self.i + self.r <= len(self.words):
            # move on to next degree
            self.i += 1
            self.progressiveCombination()

    # do all possible combinations for 1st element of this array
    def repetitivePairing(self, prefix, position):
        auxiliary_store = [[] for k in range(len(self.words) - position)]
        for j in range(len(self.words) - position):
            # check if desired -- r -- size will be realised
            if j + self.i + self.r <= len(self.words):
                auxiliary_store[j].extend(prefix)
                auxiliary_store[j].append(self.words[position])
                if len(auxiliary_store[j]) < self.r:
                    # see to adding next word on
                    self.repetitivePairing(auxiliary_store[j], position + 1)
                else:
                    self.comb_store.append(tuple(auxiliary_store[j]))
            position += 1
