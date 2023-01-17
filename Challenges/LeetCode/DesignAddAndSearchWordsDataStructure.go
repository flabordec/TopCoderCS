type WordDictionary struct {
	root *WordNode
}

type WordNode struct {
	Ending   bool
	children map[rune]*WordNode
}

func (wn *WordNode) GetOrAdd(r rune) *WordNode {
	var node *WordNode
	node, ok := wn.children[r]
	if !ok {
		node = &WordNode{
			children: make(map[rune]*WordNode),
		}
		wn.children[r] = node
	}

	return wn.children[r]
}

func Constructor() WordDictionary {
	return WordDictionary{
		root: &WordNode{
			children: make(map[rune]*WordNode),
		},
	}
}

func (this *WordDictionary) AddWord(word string) {
	curr := this.root
	for ix, r := range word {
		next := curr.GetOrAdd(r)
		curr = next
		if ix == len(word)-1 {
			next.Ending = true
		}
	}
}

func (this *WordDictionary) Search(word string) bool {
	w := []rune(word)

	type state struct {
		ix int
		wn *WordNode
	}
	queue := make([]state, 0)
	queue = append(queue, state{ix: 0, wn: this.root})
	for len(queue) > 0 {
		curr := queue[len(queue)-1]
		queue = queue[:len(queue)-1]
		if curr.ix == len(w) {
			if curr.wn.Ending {
				return true
			}
			continue
		}

		r := w[curr.ix]
		if r == '.' {
			for _, c := range curr.wn.children {
				queue = append(queue, state{ix: curr.ix + 1, wn: c})
			}
		} else if c, ok := curr.wn.children[r]; ok {
			queue = append(queue, state{ix: curr.ix + 1, wn: c})
		}
	}

	return false
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * obj := Constructor();
 * obj.AddWord(word);
 * param_2 := obj.Search(word);
 */
