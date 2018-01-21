from Combination import Combinatorial

# define a class
class Transposition(Combinatorial):

    def __init__(self):
        super().__init__()

    # till the ground for shuffle to grind on
    def possibleWordPermutations(self, candidates, size):
        self.perm_store = [] # list to hold answers
        self.possibleWordCombinations(candidates, size)
        
        # illegal 'r' value
        if len(self.comb_store) == 0 or self.r == 1:
            self.perm_store = self.comb_store
        else:
            last_two = [[], []]
            for i in range(len(self.comb_store)):
                self.index = self.r - 1
                # copy up last two elements of 'comb_store(i)'
                last_two[0] = [self.comb_store[i][self.index], self.comb_store[i][self.index - 1]]
                last_two[1] = last_two[0][::-1] # reverse last_two[0]
                self.index -= 2

                self.local_store = []
                self.local_store.append(tuple(last_two[0]))
                self.local_store.append(tuple(last_two[1]))
                if self.r > 2:
                    self.shuffleWord(self.local_store, i)
                
                self.perm_store.extend(self.local_store)

        return self.perm_store

    def shuffleWord(self, arg_store, i):
        self.local_store = []
        for option in (arg_store):
            members = []
            members.extend(list(option))
            # add 'index' 'comb_store[i]' element to this list of members
            members.append(self.comb_store[i][self.index])

            shift_index = len(members)
            # shuffle this pack of words
            while shift_index > 0:
                # skip if already in store
                if (tuple(members) in self.local_store) == False:
                    self.local_store.append(tuple(members))
                
                shift_index -= 1
                if shift_index > 0 and members[shift_index] != members[shift_index - 1]:
                    # interchange these two neighbours
                    members[shift_index - 1], members[shift_index] = members[shift_index], members[shift_index - 1]
                    
        # Are there any elements left? repeat if yes
        if self.index > 0:
            self.index -= 1
            self.shuffleWord(self.local_store, i)
