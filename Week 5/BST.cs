
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
        TreeNode<T> parent;

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
            else if (value.CompareTo(current.Value) > 0)
            {
                current = current.Right;
                if (current == null)
                {
                    parent.Right = newNode;
                    return;
                }
            }
            else
            {
                // Ignore duplicates
                return;
            }
        }
    }
}

   private void Insert(T value, TreeNode<T>? node)
{
    // case Root is null
    if (node == null)
    {
        Root = new TreeNode<T>(value);
        return;
    }

    // right child
    if(value.CompareTo(node.Value) > 0)
    {
        if(node.Right == null)
        {
            node.Right = new TreeNode<T>(value);
        }
        else
        {
            Insert(value, node.Right);
        }
    }
    // left child
    else if(value.CompareTo(node.Value) < 0)
    {
        if(node.Left == null)
        {
            node.Left = new TreeNode<T>(value);
        }
        else
        {
            Insert(value, node.Left);
        }
    }
}

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);
    private string PreOrderTraversal(TreeNode<T>? currNode)
    {
        if(currNode == null)
        {
            return string.Empty;
        }
        return currNode.Value + " " + PreOrderTraversal(currNode.Left) + PreOrderTraversal(currNode.Right);
    }

    public string InOrderTraversal() => InOrderTraversal(Root);
    private string InOrderTraversal(TreeNode<T>? currNode)
    {
        if(currNode == null)
        {
            return string.Empty;
        }
        return InOrderTraversal(currNode.Left) + currNode.Value + " " + InOrderTraversal(currNode.Right);        
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);
    private string PostOrderTraversal(TreeNode<T>? currNode)
    {
        if (currNode == null)
        {
            return String.Empty;
        }
        return PostOrderTraversal(currNode.Left) + PostOrderTraversal(currNode.Right) + " " + currNode.Value;    
        

    }
    #endregion

    public bool Contains(T value) => Search(Root, value) != null;

    private TreeNode<T> Search(TreeNode<T>? node, T value)
    {
        // node does not exist
        if (node == null)
        {
            return null;
        }
        
        // value in the node is the same we are looking for
        if (node.Value.CompareTo(value) == 0)
        {
            return node;
        }

        // value in the node is smaller than the one we are looking for
        if(node.Value.CompareTo(value) < 0)
        {
            return Search(node.Right, value);
        }
 
        // value in the node is bigger than the one we are looking for
        if(node.Value.CompareTo(value) > 0)
        {
            return Search(node.Left, value);
        }

        return null;

    }

    #region  Remove Delete

    public bool Remove(T value) => DeleteValue(this, value);

    private bool DeleteValue(BST<T>? tree, T value)
    {
        if (tree == null)
        {
            return false;
        }
        // special case if the value to delete is in the root (and the root has 0 children or 1 child)
        if (Root.Value.CompareTo(value) == 0)
        {
            if (Root.Left == null && Root.Right == null)
            {
                Root = null;
                return true;
            }
            if (Root.Left == null)
            {
                Root = Root.Right;
                return true;
            }
            if (Root.Right == null)
            {
                Root = Root.Left;
                return true;
            }
        }

        // there are no children:
        if(Root.Left == null && Root.Right == null)
        {
            Root = null;
            return true;
        }

        // there is only left child, the right does not exist
        if (Root.Left != null && Root.Right == null)
        {
            Root = Root.Left;
            return true;
        }

        // there is only right child, the left does not exist
        if (Root.Right != null && Root.Left == null)
        {
            Root = Root.Right;
            return true;
        }


        // all other cases. Find first the node corresponding to the value we want to delete
        TreeNode<T>? nodeToDelete = Search(Root, value);
        if (nodeToDelete == null)
        {
            return false;
        }

        // actually perform the deletion
        delete(nodeToDelete);
        return true;

    }

    private bool delete(TreeNode<T> nodeToDelete)
    {
        // CASE 1 : LEAF
        if (nodeToDelete.Right == null && nodeToDelete.Left == null)
        {
            if (isLeft(nodeToDelete, nodeToDelete.Parent))
            {
                nodeToDelete.Parent.Left = null;
            }
            else
            {
                nodeToDelete.Parent.Right = null;
            }
            return true;
        }

        // CASE 2 : ONE CHILD
        if (nodeToDelete.Right == null || nodeToDelete.Left == null)
        {
            if (nodeToDelete.Right != null)
            {
                if (isLeft(nodeToDelete, nodeToDelete.Parent))
                {
                    nodeToDelete.Parent.Left = nodeToDelete.Right;
                }
                else
                {
                    nodeToDelete.Parent.Right = nodeToDelete.Right;
                }
            }
            else
            {
                if (isLeft(nodeToDelete, nodeToDelete.Parent))
                {
                    nodeToDelete.Parent.Left = nodeToDelete.Left;
                }
                else
                {
                    nodeToDelete.Parent.Right = nodeToDelete.Left;
                }
            }
            return true;
        }

        // CASE 3 : TWO CHILDREN
        if(nodeToDelete.Right != null && nodeToDelete.Left != null)
        {
            TreeNode<T>? inOrderSucc = findInOrderSucc(nodeToDelete);
            nodeToDelete.Value = inOrderSucc.Value;
            delete(inOrderSucc);
            return true;
        }

        // find inordersucc == smallest element of right subtree

        // copy value to nodeToDelete

        // call recursively delete on inordersucc 
return false;

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

