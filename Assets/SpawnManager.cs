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
        Vector3 startingPosition = new Vector3(-5, 0, 0);
        GameObject newEnemy = (GameObject)Instantiate(enemy, startingPosition, new Quaternion(0, 0, 90, 90));
    }

    private GameObject enemy;
}
