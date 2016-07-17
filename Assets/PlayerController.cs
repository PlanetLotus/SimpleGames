using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Health = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health--;
        if (Health > 0)
        {
            Debug.Log(string.Format("Player was hit and has {0} health remaining.", Health));
        }
        else
        {
            Debug.Log("Game over.");
            Destroy(gameObject);
        }
    }
}
