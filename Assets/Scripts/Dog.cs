using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject explosion;
    public Transform pos;
    public Rigidbody2D rb;
    public float speed = 9;
    public float lifetime;
    public SpriteRenderer render;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);


        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, pos.position, pos.rotation);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Dogkiller"))
        {
            rb.velocity = transform.right * speed * 1.2f;
            render.flipX = true;
        }

    }
}
