using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D bruh)
    {
        if (bruh.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddScore(5);
            Destroy(gameObject);
        }


    }
}
