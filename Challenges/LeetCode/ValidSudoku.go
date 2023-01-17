package main

import "fmt"

func main() {
}

func isValidSudoku(board [][]byte) bool {
	var inrow [9]map[byte]bool
	var incol [9]map[byte]bool
	var insquare [9]map[byte]bool

	for i := 0; i < 9; i++ {
		inrow[i] = make(map[byte]bool)
		incol[i] = make(map[byte]bool)
		insquare[i] = make(map[byte]bool)
	}
	for rowix, row := range board {
		for colix, b := range row {
			if b == 46 {
				continue
			}
			fmt.Printf("%d %d => %v\n", rowix, colix, b)

			squareix := getSquare(rowix, colix)
			if inrow[rowix][b] {
				fmt.Printf("row %d has repeated %v\n", rowix, b)
				return false
			}
			if incol[colix][b] {
				fmt.Printf("col %d has repeated %v\n", colix, b)
				return false
			}
			if insquare[squareix][b] {
				fmt.Printf("square %d (%d, %d) has repeated %v\n", squareix, rowix, colix, b)
				return false
			}

			inrow[rowix][b] = true
			incol[colix][b] = true
			insquare[squareix][b] = true
		}
	}
	return true
}

func getSquare(i int, j int) int {
	if i >= 0 && i < 3 {
		if j >= 0 && j < 3 {
			return 0
		} else if j >= 3 && j < 6 {
			return 1
		} else {
			return 2
		}
	} else if i >= 3 && i < 6 {
		if j >= 0 && j < 3 {
			return 3
		} else if j >= 3 && j < 6 {
			return 4
		} else {
			return 5
		}
	} else {
		if j >= 0 && j < 3 {
			return 6
		} else if j >= 3 && j < 6 {
			return 7
		} else {
			return 8
		}
	}
}
