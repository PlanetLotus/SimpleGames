using UnityEngine;

public class FishManager : MonoBehaviour
{
    public int MaxEnemies;
    public int SpawnRateInSeconds;

    [HideInInspector]
    public static int NumEnemies;

    private void Start()
    {
        NumEnemies = 0;
        fish = Resources.Load<GameObject>("enemy");

        // Try to spawn a fish every so often
        InvokeRepeating("SpawnFish", 0, SpawnRateInSeconds);
    }

    private void SpawnFish()
    {
        if (NumEnemies >= MaxEnemies)
        {
            return;
        }

        var randomX = Random.Range(-10, 10);
        var randomY = Random.Range(-5, 5);

        Vector3 startPosition = new Vector3(randomX, randomY, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        GameObject newFish;

        newFish = Instantiate(fish, startPosition, rotation);
        NumEnemies++;
    }

    private GameObject fish;
}
