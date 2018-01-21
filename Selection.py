# Sure enough this is a module

# define a class
class Choice:

    def __init__(self):
        self.i = 0

    def groupSelection(self, candidates, size):
        self.words = candidates
        self.r = size
        self.complete_group = []
        self.i = 0
        
        self.recursiveFillUp([])

        return self.complete_group

    # pick elements recursively
    def recursiveFillUp(self, temp):
        picked_elements = [[] for k in range(len(self.words))]
        j = self.i
        while j < len(self.words):
            picked_elements[j].extend(temp)
            picked_elements[j].append(self.words[j])
            # recoil factor
            if self.i >= len(self.words):
                self.i = j
                
            # satisfied yet?
            if len(picked_elements[j]) == self.r:
                self.complete_group.append(picked_elements[j])
            elif len(picked_elements[j]) < self.r:
                self.recursiveFillUp(picked_elements[j])
            
            j += 1
        
        j -= 1
        if picked_elements[j] != None and len(picked_elements[j]) == self.r:
            self.i += 1 # keep recoil factor straightened out
        
