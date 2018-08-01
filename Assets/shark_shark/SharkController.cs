using UnityEngine;

public class SharkController : EnemyController
{
    public int StateChangeIntervalInSeconds;
    public float ChargeSpeed;
    public float ChargeChance;
    public float ChargeDrag;

    protected override void Start()
    {
        // Every X seconds, decide whether to continue wandering
        // or charge toward player
        InvokeRepeating("PickState", 0, StateChangeIntervalInSeconds);

        // Assumes player max level is 4
        level = 4;

        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        var enemy = other.gameObject.GetComponent<EnemyController>();
        if (enemy == null)
        {
            return;
        }

        if (enemy.level <= level)
        {
            Destroy(other.gameObject);
        }
    }

    private void PickState()
    {
        // Wander is the default state
        // Every X seconds, it will generate a random state
        // Once charging, it will automatically return to wander
        // Downside: This doesn't support separate intervals for charging + picking a state
        switch (CurrentState)
        {
            case State.Start:
            case State.Charging:
                Wander();
                break;
            case State.Wandering:
                PickRandomState();
                break;
        }
    }

    private void PickRandomState()
    {
        var charge = Random.value < ChargeChance;
        if (charge)
        {
            Charge();
        }
        else
        {
            Wander();
        }
    }

    private void Charge()
    {
        Debug.Log("Charging!");
        CurrentState = State.Charging;

        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Direction = (playerPosition - gameObject.transform.position).normalized;

        Debug.Log(Direction);

        rigidbody.velocity = Direction * ChargeSpeed;
        rigidbody.drag = ChargeDrag;
    }

    private void Wander()
    {
        Debug.Log("Wandering...");

        if (CurrentState == State.Wandering)
        {
            // Don't mess with velocity if already wandering
            return;
        }

        CurrentState = State.Wandering;

        var xDirection = rigidbody.velocity.x > 0 ? 1 : -1;
        Direction = new Vector3(xDirection, 0, 0);
        rigidbody.velocity = Direction * Speed;
        rigidbody.drag = 0;
    }

    private State CurrentState;

    private enum State
    {
        Start = 0,
        Wandering = 1,
        Charging = 2
    }
}
