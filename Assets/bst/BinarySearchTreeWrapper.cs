using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In order to instantiate objects in Unity, a wrapper class for the Binary Search Tree is needed.
/// </summary>
public class BinarySearchTreeWrapper : MonoBehaviour
{
    public List<int> StartingNodes;

    private BinarySearchTree<int> bst;
    private GameObject node;

    private void Start()
    {
        node = (GameObject)Resources.Load("Node");

        bst = new BinarySearchTree<int>(StartingNodes);

        UpdateVisualBst();
    }

    /// <summary>
    /// Recreates the visual tree based on the current underlying BST structure.
    /// </summary>
    private void UpdateVisualBst()
    {
        var nodePrefab = (GameObject)Resources.Load("Node");

        var nodes = bst.GetInOrderTraversal();
        foreach (var node in nodes)
        {
            var nodeObj = Instantiate(nodePrefab, new Vector3(), Quaternion.identity);
            var textMesh = nodeObj.GetComponent<TextMesh>();
            textMesh.text = node.ToString();
        }
    }
}
