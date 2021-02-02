using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Transform point;
    public GameObject bullet;
    public float cooldown = 0.8f;
    private float nextshot;
    public Rigidbody2D rb;
    public float speed = 9;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextshot)
        {
            Instantiate(bullet, point.position, point.rotation);
            nextshot = Time.time + cooldown;



        }
    }
}
