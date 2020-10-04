using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HulaDefeat : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxSpeed = 15.0f;
    private Rigidbody2D rb;
    private float vert;
    private float horz;

    void Start()
    {
        vert = Random.Range(0f, 10.0f);
        horz = Mathf.Sqrt((speed * speed) - (vert * vert));

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horz, vert);
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
