using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Slimeball : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxSpeed = 15.0f;
    private Rigidbody2D rb;
    private float vert;
    private float horz;

    public GameObject splatParticle;

    // Start is called before the first frame update
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

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Player")
            {
               
                Destroy(gameObject);
                GameObject splat = Instantiate(splatParticle);
            }       
    }
}
