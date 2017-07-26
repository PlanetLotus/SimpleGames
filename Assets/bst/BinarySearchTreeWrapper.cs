using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In order to instantiate objects in Unity, a wrapper class for the Binary Search Tree is needed.
/// </summary>
public class BinarySearchTreeWrapper : MonoBehaviour
{
    public List<int> StartingNodes;

    private BinarySearchTree<Cube> bst;

    private void Start()
    {
        var nodePrefab = (GameObject)Resources.Load("Node");
        var start = new Vector3(0, 4, 0);
        var cubes = new List<Cube>();

        foreach (var node in StartingNodes)
        {
            var nodeObj = Instantiate(nodePrefab, start, Quaternion.identity);

            var cube = nodePrefab.GetComponent<Cube>();
            cube.Data = node;

            var textMesh = nodeObj.GetComponent<TextMesh>();
            textMesh.text = node.ToString();

            cubes.Add(cube);
            start.y -= 1;
        }

        bst = new BinarySearchTree<Cube>(cubes);

        //UpdateVisualBst();
    }

    /// <summary>
    /// Recreates the visual tree based on the current underlying BST structure.
    /// </summary>
    private void UpdateVisualBst()
    {
        var nodePrefab = (GameObject)Resources.Load("Node");
        var start = new Vector3(0, 5, 0);

        var nodes = bst.GetPreOrderTraversal();
        foreach (var node in nodes)
        {
            start.y -= 1;
            var nodeObj = Instantiate(nodePrefab, start, Quaternion.identity);
            var textMesh = nodeObj.GetComponent<TextMesh>();
            textMesh.text = node.ToString();
            Debug.Log(node.ToString());
        }
    }
}
