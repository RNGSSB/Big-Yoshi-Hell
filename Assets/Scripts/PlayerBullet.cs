using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 9;
    public float life = 2f;
   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    
    }

 

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);


        }

       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
     
            Destroy(gameObject);

        
        

        


    }
}
