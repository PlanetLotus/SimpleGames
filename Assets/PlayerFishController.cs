using UnityEngine;

public class PlayerFishController : MonoBehaviour
{
    [HideInInspector]
    public bool FacingLeft = true;

    public float MoveForce = 365f;
    public float MaxSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb.velocity.x < MaxSpeed)
        {
            rb.AddForce(Vector2.right * h * MoveForce);
        }

        if (Mathf.Abs(rb.velocity.x) > MaxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * MaxSpeed, rb.velocity.y);
        }

        if ((h > 0 && FacingLeft) || (h < 0 && !FacingLeft))
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingLeft = !FacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private Rigidbody2D rb;
    private BoxCollider2D coll;
}
