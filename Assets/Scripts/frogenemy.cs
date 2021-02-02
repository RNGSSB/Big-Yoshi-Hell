using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);


        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            health = health - 1;

        }
        if (other.gameObject.CompareTag("FullCharge"))
        {
            health = health - 5;

        }
        if (other.gameObject.CompareTag("mediumCharge"))
        {
            health = health - 4;

        }
        if (other.gameObject.CompareTag("smallCharge"))
        {
            health = health - 2;

        }



    }
}
