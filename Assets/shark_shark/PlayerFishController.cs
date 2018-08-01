using System.Collections.Generic;
using UnityEngine;

public class PlayerFishController : MonoBehaviour
{
    [HideInInspector]
    public bool FacingLeft = true;

    public float Speed = 100f;

    public List<int> numEatenPerLevel = new List<int> { 0, 5, 10, 20, 30, int.MaxValue };

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<EnemyController>();
        if (enemy == null)
        {
            return;
        }

        if (enemy.level > level)
        {
            Debug.Log("Game over");
            Destroy(gameObject);
        }
        else
        {
            if (other.tag != "shark")
            {
                FishManager.NumEnemies--;
            }

            numEaten++;
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
        if (numEaten < numEatenPerLevel[level])
        {
            return;
        }

        level++;
        Debug.Log(string.Format("Player has eaten {0} fish and is now level {1}", numEaten, level));

        sprite.size += growBy;
        collider.size += growBy;
    }

    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator animator;
    private SpriteRenderer sprite;

    private Vector2 growBy = new Vector2(0.3f, 0.3f);

    private int numEaten = 0;
    private int level = 0;
}
