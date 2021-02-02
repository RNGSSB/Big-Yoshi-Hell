using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    public float frogcooldown;
    private float nextfrog = 0;
    public GameObject minifrog;
    public Transform frogshot;
    public Transform frogshot2;
    public Transform frogshot3;
    public Rigidbody2D rb;
    public float speed = 9;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextfrog)
        {
            Instantiate(minifrog, frogshot.position, frogshot.rotation);
            Instantiate(minifrog, frogshot2.position, frogshot2.rotation);
            Instantiate(minifrog, frogshot3.position, frogshot3.rotation);
            nextfrog = Time.time + frogcooldown;
        } 
    }
}
