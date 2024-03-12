
namespace Solution;

public class BST<T> : IBST<T> where T : IComparable<T>
{
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);
    public void InsertIterative(T value)
{
    var newNode = new TreeNode<T>(value);

    if (Root == null)
    {
        Root = newNode;
    }
    else
    {
        TreeNode<T> current = Root;
        TreeNode<T> parent = null;

        while (true)
        {
            parent = current;
            if (value.CompareTo(current.Value) < 0)
            {
                current = current.Left;
                if (current == null)
                {
                    parent.Left = newNode;
                    return;
                }
            }
            else
            {
                current = current.Right;
                if (current == null)
                {
                    parent.Right = newNode;
                    return;
                }
            }
        }
    }
}

    private void Insert(T value, TreeNode<T>? node)
{
    if (node == null)
    {
        Root = new TreeNode<T>(value);
        return;
    }
    else if (value.CompareTo(node.Value) < 0)
    {
        if (node.Left == null)
        {
            node.Left = new TreeNode<T>(value);
            return;
        }
        Insert(value, node.Left);
    }
    else
    {
        if (node.Right == null)
        {
            node.Right = new TreeNode<T>(value);
            return;
        }
        Insert(value, node.Right);
    }
}

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);
    private string PreOrderTraversal(TreeNode<T>? currNode)
{
    if (currNode == null)
    {
        return string.Empty;
    }
    return PreOrderTraversal(currNode.Left) + " " + PreOrderTraversal(currNode.Right) + " " + currNode.Value.ToString();
}

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
{
    if (currNode == null)
    {
        return string.Empty;
    }
    return InOrderTraversal(currNode.Left) + " " + currNode.Value.ToString() + " " + InOrderTraversal(currNode.Right);
    
}

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
{
    if (currNode == null)
    {
        return string.Empty;
    }
    return PostOrderTraversal(currNode.Left) + " " + PostOrderTraversal(currNode.Right) + " " + currNode.Value.ToString();
}
    #endregion

    public bool Contains(T value) => Search(Root, value) != null; 

    private TreeNode<T> Search(TreeNode<T>? node, T value)
{
    if (node == null)
    {
        return null;
    }

    if (value.CompareTo(node.Value) == 0)
    {
        return node;
    }
    else if (value.CompareTo(node.Value) < 0)
    {
        return Search(node.Left, value);
    }
    else
    {
        return Search(node.Right, value);
    }
}

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(BST<T>? tree, T value)
{

    if (tree.Root.Value.CompareTo(value) == 0)
    {
        // Special case: root to delete
        if (tree.Root.Left == null && tree.Root.Right == null)
        {
            // No children
            tree.Root = null;
        }
        else if (tree.Root.Left != null && tree.Root.Right == null)
        {
            // Only left child
            tree.Root = tree.Root.Left;
        }
        else if (tree.Root.Left == null && tree.Root.Right != null)
        {
            // Only right child
            tree.Root = tree.Root.Right;
        }
        else
        {
            // Two children
            TreeNode<T> inOrderSucc = findInOrderSucc(tree.Root);
            tree.Root.Value = inOrderSucc.Value;
            delete(tree.Root, inOrderSucc);
        }
        return true;
    }
    else
    {
        // Find the node to delete and its parent
        TreeNode<T> parent = null;
        TreeNode<T> current = tree.Root;
        while (current != null)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        if (current == null)
        {
            // Node to delete not found
            return false;
        }

        // Delete the node
        return delete(parent, current);
    }
}

    private bool delete(TreeNode<T>? parent, TreeNode<T> nodeToDelete)
{
    if (nodeToDelete.Left == null && nodeToDelete.Right == null)
    {
        // CASE 1 : LEAF
        if (isLeft(nodeToDelete, parent))
        {
            parent.Left = null;
        }
        else
        {
            parent.Right = null;
        }
    }
    else if (nodeToDelete.Left != null && nodeToDelete.Right == null)
    {
        // CASE 2 : ONE CHILD
        if (isLeft(nodeToDelete, parent))
        {
            parent.Left = nodeToDelete.Left;
        }
        else
        {
            parent.Right = nodeToDelete.Left;
        }
    }
    else if (nodeToDelete.Left == null && nodeToDelete.Right != null)
    {
        // CASE 2 : ONE CHILD
        if (isLeft(nodeToDelete, parent))
        {
            parent.Left = nodeToDelete.Right;
        }
        else
        {
            parent.Right = nodeToDelete.Right;
        }
    }
    else
    {
        // CASE 3 : TWO CHILDREN
        // find inordersucc == smallest element of right subtree
        TreeNode<T> inOrderSucc = findInOrderSucc(nodeToDelete);

        // copy value to nodeToDelete
        nodeToDelete.Value = inOrderSucc.Value;

        // call recursively delete on inordersucc
        return delete(nodeToDelete, inOrderSucc);
    }

    return true;
}

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? findInOrderSucc(TreeNode<T> node)
    {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }
 
    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // The comparison is based on the values of the nodes.
    private bool isLeft(TreeNode<T> node, TreeNode<T> parent)
    {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    public List<T> Traversal(TraversalOrder traversalOrder) //Optional
    {
        throw new NotImplementedException();
    }
    #endregion
}

