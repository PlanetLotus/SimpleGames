using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 1;

    public Vector3 Direction;

    public int level = 0;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boundary")
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            rigidbody.velocity = -rigidbody.velocity;
        }
    }

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Direction * Speed;

        level = GetLevel();

        // Scale change is a placeholder for other sprites
        // Can be replaced with new sprite once that's done
        var scale = level * 0.2f;
        var levelScale = new Vector3(scale, scale);
        transform.localScale += levelScale;

        Debug.Log(string.Format("Spawning level {0}", level));
    }

    /// <summary>
    /// Favors lower levels over higher levels.
    /// More complex spawning could take player level into account
    /// and ensure a balanced number of fish per level, rather than
    /// it just being based on chance.
    /// </summary>
    private int GetLevel()
    {
        var rand = Random.value;
        if (rand < 0.4)
        {
            return 0;
        }
        else if (rand < 0.75)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    protected Rigidbody2D rigidbody;
}
