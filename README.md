This is the primary repository for all of my personal development. A lot of it is related so it makes sense to store it all in one repository.

I have set up individual READMEs for each of my libraries so for more in depth information please check them out.

Overview of Libraries:

* Foat.Collections - contains some additional generic collections that aren't provided by default in the .NET framework including
	* AVL Tree
	* Red Black Tree
	* Iterative Binary Search Tree
	* Skip List
	* Min / Max Heap
	* Small int array
* Foat.Hashing
	* Fnv Hash - Short, quick hash function that generally produces a good distribution of keys
	* Minimal Perfect Hash - Maps any set the indecies 0 ... N - 1 with no collisions where N is the number of elements in the set. 
* Foat.Puzzles
	* NPuzzle A sliding tile puzzle on an N x N board with one empty space so that the tiles can slide around and be re-ordered. This puzzle is dynamic and can be used to play an 8 Puzzle or a 15 Puzzle.
	* Rubiks Cube puzzle and shortest solution implementation