namespace Solution;

public class FloydWarshall
{
public static Tuple<double[,], int[,]> Init(double[,] graph)
{
    int length = graph.GetLength(0);
    double[,] dist = new double[length, length];
    int[,] next = new int[length, length];

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (!double.IsPositiveInfinity(graph[i, j]))
            {
                dist[i, j] = graph[i, j];
                next[i, j] = j;
            }
            else
            {
                dist[i, j] = double.PositiveInfinity;
                next[i, j] = -1;
            }
        }
    }

    return new Tuple<double[,], int[,]>(dist, next);
}
    
    public static Tuple<double[,], int[,]> AllPairShortestPath(double[,] graph)
{
    var (dist, next) = Init(graph);
    int length = graph.GetLength(0);

    for (int k = 0; k < length; k++)
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (!double.IsPositiveInfinity(dist[i, k]) && !double.IsPositiveInfinity(dist[k, j]) && dist[i, k] + dist[k, j] < dist[i, j])
                {
                    dist[i, j] = dist[i, k] + dist[k, j];
                    next[i, j] = next[i, k];
                }
            }
        }
    }

    return new Tuple<double[,], int[,]>(dist, next);
}
}