using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float Speed = 2;

    [HideInInspector]
    public Vector3 Direction;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
