using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float Speed = 2;

    [HideInInspector]
    public Vector3 Direction;

    private void Start()
    {
        Direction = Vector3.right;

        GetComponent<Rigidbody2D>().velocity = Direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player hit by enemy");
            Destroy(gameObject);
        }
        else if (other.name.Contains("Zapper"))
        {
            Debug.Log("Now would be a good time to zap...");
        }
    }
}
