using UnityEngine;

public class PlayerFishController : MonoBehaviour
{
    [HideInInspector]
    public bool FacingLeft = true;

    public float Speed = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Add logic for different types of units
        // For now, player only collides with fish it can eat
        Destroy(other.gameObject);
        animator.SetBool("Eating", true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var eating = animator.GetBool("Eating");
            animator.SetBool("Eating", !eating);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * Speed);

        if ((moveHorizontal > 0 && FacingLeft) || (moveHorizontal < 0 && !FacingLeft))
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
    private Animator animator;
}
