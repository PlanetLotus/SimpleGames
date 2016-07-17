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
        Debug.Log(other.gameObject.name);
    }
}
