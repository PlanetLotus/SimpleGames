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

        foreach (var value in StartingNodes)
        {
            var obj = Instantiate(node, new Vector3(), Quaternion.identity);
        }
    }

    private void Update()
    {

    }
}
