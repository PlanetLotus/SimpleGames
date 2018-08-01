﻿using UnityEngine;

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
    }

    protected Rigidbody2D rigidbody;
}
