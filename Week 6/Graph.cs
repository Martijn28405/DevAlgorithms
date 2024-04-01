namespace Solution;

public class Graph
{
    public double[,] AdjacencyMatrix { get; set; }
    public int Count { get { return AdjacencyMatrix.GetLength(0); } }  //Number of nodes in the graph

    public Graph(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new System.ArgumentException("The adjacency matrix must be a square matrix");
        AdjacencyMatrix = matrix;
    }

    //Breadth First Traversal
    public string BFT(int root)
    {
        // create empty queue and enqueue the root
        Queue<string> queue = new Queue<string>();

        // create array of booleans to keep track of visited nodes and set the root flag to true
        bool[] visited = Enumerable.Repeat(false, Count).ToArray();
        visited[root] = true;
        

        // Loop until queue is empty
        while (queue.Count > 0)
        {
            // dequeue a node
            string node = queue.Dequeue();
            // add the current node (followed by a space) to the string
            string result = node.ToString() + " "; 
            
            // find neighbors of current
            List<int> neighbors = Neighbors(int.Parse(node));
            


            // enqueue all neighbors which are not visited yet and set them to visited
            foreach (int neighbor in neighbors)
            {
                if (!visited[neighbor])
                {
                    queue.Enqueue(neighbor.ToString());
                    visited[neighbor] = true;
                }
            }
        }

        return default;
    }

    //Nodes adjacent to a given node
    public List<int> Neighbors(int node)
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        return neighbors;
    }

    //Nodes (adjacent to a given node) to be visited in reversed order
    public List<int> NeighborsReversed(int node) 
    {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        neighbors.Reverse();
        return neighbors;
    }
    
    //Depth First Traveral
    public string DFT(int root)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(root);

        bool[] visited = new bool[vertices.Length];
        string result = "";

        while (stack.Count > 0)
        {
            int current = stack.Pop();

            if (!visited[current])
            {
                result += current + " ";
                visited[current] = true;

                var neighbors = GetNeighbors(current).Reverse();

                foreach (var neighbor in neighbors)
                {
                    if (!visited[neighbor])
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }

        return result.TrimEnd();
    }

    //Dijkstra's algorithm SingleSourceShortestPath 
    public Tuple<double[], int[]> SingleSourceShortestPath(int source) //distance and prev arrays
    {
        // initialization of distance, prev and unvisitedNodes
        // default distance: double.PositiveInfinity
        // default previous node: -1

        // set distance of source
        
        // Loop until unvisitedNodes is empty
  
            // find closest node in unvisitedNodes
       
            // remove the closest node from unvisitedNodes

            //considering all neighbors of the closest node

                // calculate distance and update distance (and previous node) if smaller

        throw new NotImplementedException();
    }

}


