using UnityEngine;

public class PlayerFishController : MonoBehaviour
{
    [HideInInspector]
    public bool FacingLeft = true;

    public float Speed = 100f;

    public Vector2 MaxScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        maxSize = sprite.size * MaxScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "shark")
        {
            Debug.Log("Game over");
            Destroy(gameObject);
        }
        else
        {
            FishManager.NumEnemies--;
            Destroy(other.gameObject);
            animator.SetBool("Eating", true);
            Grow();
        }
    }

    private void Update()
    {
        // For testing
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Grow();
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

    private void Grow()
    {
        if (sprite.size.magnitude >= maxSize.magnitude)
        {
            Debug.Log("Too big!");
            return;
        }

        sprite.size += growBy;
        collider.size += growBy;
    }

    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator animator;
    private SpriteRenderer sprite;

    private Vector2 maxSize;
    private Vector2 growBy = new Vector2(0.5f, 0.5f);
}
