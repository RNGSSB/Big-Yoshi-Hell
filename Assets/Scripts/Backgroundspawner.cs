using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundspawner : MonoBehaviour
{
    public GameObject background;
    public Transform spawnpoint;
    public float cooldown = 5f;
    private float nextspawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > nextspawn)
        {
            Instantiate(background, spawnpoint.position, spawnpoint.rotation);
            nextspawn = Time.time + cooldown;

        }
    }
}
