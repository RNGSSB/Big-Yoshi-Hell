using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnpoint;
    public float cooldown = 5f;
    public float initialspawntime = 5f;
    private float nextspawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        initialspawntime -= Time.deltaTime;
        if (initialspawntime <= 0)
        {
            if (Time.time > nextspawn)
            {
                Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
                nextspawn = Time.time + cooldown;

            }


        }
    }
}
