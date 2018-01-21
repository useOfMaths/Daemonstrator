from Selection import Choice

# define a class
class ConditionedChoice(Choice):

    def __init__(self):
        super().__init__()

    # pick only those groups that meet occurrence conditions
    def limitedSelection(self, candidates, size, minimum, maximum):
        self.final_elements = []

        self.groupSelection(candidates, size)
        for option in self.complete_group:
            state = False
            for j in range(len(self.words)):
                # get 'word[j]' frequency/count in group
                frequency = option.count(self.words[j])

                # Productive boundary check
                if frequency >= minimum[j] and frequency <= maximum[j]:
                    state = True
                else:
                    state = False
                    break

            # skip if already in net
            if state:
                self.final_elements.append(option)

        return self.final_elements
