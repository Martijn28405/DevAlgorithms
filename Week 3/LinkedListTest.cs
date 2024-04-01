using Xunit;

public class LinkedListTests
{
    [Fact]
    public void AddSorted_ShouldAddValuesInSortedOrder()
    {
        // Arrange
        LinkedList<int> list = new LinkedList<int>();

        // Act
        list.AddSorted(10);
        list.AddSorted(20);
        list.AddSorted(30);
        list.AddSorted(40);

        // Assert
        Assert.Equal(new int[] { 10, 20, 30, 40 }, list.ToArray());
    }
}