This is one part of a larger project. Please head here to see the entire solution. https://github.com/afoat/Projects

This is a set of custom generic collections originally located here: https://github.com/afoat/Common.

That repository has since been depreciated so that all of my code can live together under the same repository.

* AVLTree - An AVL Tree is a balanced binary search tree that keeps the tree as flat as possible. Inserts and deletes are a bit slower than other trees, but lookups are faster. Useful for instances where there will be lots of lookups but few changes.
* RedBlackTree - A Red Black Tree is a balanced binary search tree that keeps the tree relatively flat. Inserts and deletes are faster than in an AVLTree and lookups are a bit slower, but still pretty quick. Useful for instances where there will be lots of changes to the tree.
* BinarySearchTree - This is an iterative implementation of a basic binary search tree. This tree is unbalanced and so does not necessarily guarantee any run times on additions, deletions, or lookups.
* SkipList - A Skip List is an alternative to any of the Binary Search Trees above. It's easier to implement but provides nearly the same performance as the other ones.
* Heap - This heap can be set up as either a min heap or a max heap.
* SmallIntArray - This array can pack integers smaller than one byte into a byte array such that there is no wasted space.