﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public int health = 5;
    public GameObject explosion;
    public GameObject item;
    public int RNG;
    public int chance;
    public Transform pos;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        RNG = Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (RNG == chance)
            {

                Instantiate(item, spawn.position, spawn.rotation);

            }
            Instantiate(explosion, pos.position, pos.rotation);
            Destroy(gameObject);

        }
    }

    public void GetHurt(int damage, float hitlag)
    {
        Debug.Log("Took " + damage);
        FindObjectOfType<Hitlag>().Stop(hitlag);
        health -= damage;
    }

    IEnumerator WaitForSpawn()
    {
        while (Time.time != 1.0f)
        {
            yield return null;
        }
   
    }
}
