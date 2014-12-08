This library contains code that allows us to manipulate and solve a Rubik's Cube. The solution I've developed finds the shortest possible solution to any randomized Rubik's Cube. For more information about my solution please check out Richard E. Korf's paper here - https://www.cs.princeton.edu/courses/archive/fall06/cos402/papers/korfrubik.pdf

A Rubik's Cube consists of 26 visible "cubies". There are 8 corner cubies that have 3 visible colours each, 12 edge cubies that have 2 colours each, and 6 center cubies that never move so we can ignore them. Instead of rotating an assembled cube you can simulate the twists and turns of a real cube by taking the cube apart and lining up all 20 cubies on a table and twisting and turning them individuallly instead. Doing this makes it easier for us to examine each individual cubie and any time.

Notice that corner cubies can be one of 8 different locations and one of 3 different orientations per location for a total of 24 different positions. Edge cubies can be in one of 12 different locations in one of 2 different orientations for a total of 24 different positions. This means that each of our 20 cubies can be enumerated as one of 24 different positions.

Step 1:

The first step in solving a Rubik's Cube is to come up with a heuristic that can estimate the number of moves a solution might have. We can't get an exact estimate but we can generate a heuristic that acts as a lower bound. This heuristic will guide our algorithm and will hopefully make it faster. If you have a choice of 18 different moves to make on a cube (3 moves per side x 6 sides) you will want to start with the one that has a smaller bound on the solution depth. So you will want to try the move that yields a cube with an estimate of 8 before trying ones that have estimates of of 9, 10, or 11.

One of the problems with solving a Rubik's Cube is the sheer size of the problem. There are 43,252,003,274,489,856,000 possible cubes, far too many to fit in memory. One effective way to generate a heuristic is to reduce the size of the problem.

If you think of a pattern as being a Rubik's Cube with some stickers taken off, then a pattern set would be the set of all cubes that you can possibly generate starting with a particilar pattern. For example a corners only pattern that starts with a cube that has all edge stickers taken off has 88,179,840 cubes in it. This is a much more manageable number of cubes. Our goal is to generate each one of these 88 million cubes while keeping track of how many twists each cube took to generate. Now we can look at the corners of any Rubik's Cube and know at least how many moves it will take to solve it.

One thing that I think Korf could have explained better is the "lookup table" used to look cubes up in the pattern database. I opted to implement a minimal perfect hash for this. The MPH is capable of mapping all of the cubes in a set to an index between 0 ... N where n is the number of cubes in the set. The benefit is that it allows us to map the cubes to a unique index in O(1) time without actually having to store the cubes in memory. While the MPH does take up a fair amount of memory it is far less than storing the actual cubes in each pattern set wouloud be.

These pattern sets and their minimal perfect hashes are pre-compiled once and then can be reused over and over again to solve Rubik's Cubes. The more pattern sets you have the more accurate your lower bound estimate will be.

Step 2:

The normal way to find any shortest solution to a problem is to use a breadth first search. But with over 43,000,000,000,000,000,000 cubes we just don't have enopugh memory for all of that. Korf Proposes an Iterative Depth A* Algorith. The normal A* algorithm is a depth first search guided by a heuristic. This isn't guaranteed to find the shortest solution though. The iterative A* algorithm does several A* searches but limits the depth to which it will search on any given iteration. If no solution is found at a given depth then we do the search again but this time increase the depth. Using this strategy we still visit all of the nodes in a BFS manner, but maintain the memory efficiency of a DFS search.

So at each step, we get the list of valid moves that can be made to the cube then order the moves such that we will try the moves that yield the lowest heuristic value first. If we complete the depth limited A* search unsuccesfully then try again but with a higher limit on the depth.

On my computer it takes about 12 hours to generate the pattern sets and MPH for these patterns.

* Corners only
* 6 different groups containing 6 edges each
* 4 hybrid groups containing a mix of corneres and edges

The App.config file can be adjusted so that the pattern set generator makes use of multiple threads.

The IDA* algorithm comes in both single threaded and parallel versions. It takes a LONG time to find the minimal solution to a cube. My timings indicate that a solution of depth 16 could take 30 - 60 minutes on my computer while a solution of depth 17 could take over 14 hours. I would expect a solution of depth 18 to take a couple days and a solution of depth 20 could take even longer than that. A week maybe? More testing is required.