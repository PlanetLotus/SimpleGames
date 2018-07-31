using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 1;

    public Vector3 Direction;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        rigidbody.velocity = -rigidbody.velocity;
    }

    protected void Start()
    {
        Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Direction * Speed;
    }

    private Rigidbody2D rigidbody;
}
