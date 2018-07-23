using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private void Start()
    {
        enemy = (GameObject)Resources.Load("Enemy");

        // Spawn an enemy every 2 seconds
        InvokeRepeating("SpawnEnemy", 0, 2);
    }

    private void SpawnEnemy()
    {
        Direction direction = (Direction)Random.Range(1, 5);
        Vector3 startPosition;
        Quaternion rotation;
        GameObject newEnemy;
        Vector3 heading;

        if (direction == Direction.Down)
        {
            startPosition = new Vector3(0, 10);
            rotation = new Quaternion();
            heading = Vector3.down;
        }
        else if (direction == Direction.Right)
        {
            startPosition = new Vector3(-10, 0);
            rotation = Quaternion.Euler(0, 0, 90);
            heading = Vector3.right;
        }
        else if (direction == Direction.Up)
        {
            startPosition = new Vector3(0, -10);
            rotation = Quaternion.Euler(0, 0, 180);
            heading = Vector3.up;
        }
        else
        {
            startPosition = new Vector3(10, 0);
            rotation = Quaternion.Euler(0, 0, 270);
            heading = Vector3.left;
        }

        newEnemy = (GameObject)Instantiate(enemy, startPosition, rotation);
        newEnemy.GetComponent<EnemyManager>().Direction = heading;
    }

    private enum Direction
    {
        Down = 1,
        Right = 2,
        Up = 3,
        Left = 4
    }

    private GameObject enemy;
}
