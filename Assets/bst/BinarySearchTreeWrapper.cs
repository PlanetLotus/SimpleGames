using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In order to instantiate objects in Unity, a wrapper class for the Binary Search Tree is needed.
/// </summary>
public class BinarySearchTreeWrapper : MonoBehaviour
{
    public List<int> StartingNodes;

    private BinarySearchTree<Cube> bst;

    public void Insert(Text text)
    {
        int value;
        if (int.TryParse(text.text, out value))
        {
            this.Insert(value);
        }
    }

    private void Insert(int value)
    {
        // Temp hack to put new cube in a reasonable spot
        var numCubes = bst.GetInOrderTraversal().Count();
        var start = new Vector3(0, 4 - numCubes, 0);

        var nodePrefab = (GameObject)Resources.Load("Node");
        var nodeObj = Instantiate(nodePrefab, start, Quaternion.identity);

        var cube = nodePrefab.GetComponent<Cube>();
        cube.Data = value;

        var textMesh = nodeObj.GetComponent<TextMesh>();
        textMesh.text = value.ToString();

        bst.Insert(bst.Root, cube);
    }

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
        // NEXT:
        // - Rewrite this method to take advantage of the fact that T is a Cube
        //   which should make it easier to figure out how/where to draw the cube.
        // - Refactor any common logic between here and Start().
        // - Start working on drawing the cubes in a reasonable way at runtime.
        // The awkward part now is that BST relies on the cubes already existing, which
        // means the visual part exists before the actual structure does. This is kind of odd.
        // But, this only requires that the objects are instantiated; they don't have to be shown
        // or put in the right place right away. Simply instantiating them is trivial.
        // This also means the whole tree shouldn't need recreated on update.
        // Before, we were starting with the underlying BST structure and then refreshing the visual
        // on every update, completely throwing away the game objects and starting from scratch.
        // Now, we can start with a tree and then update it one object at a time as needed by
        // reading the info from the tree structure.
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
