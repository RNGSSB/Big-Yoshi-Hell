using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitlag : MonoBehaviour
{
    bool waiting;

    public void Stop(float duration)
    {
        if (waiting)
        {
            return;
        }
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float durations)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(durations);
        Time.timeScale = 1.0f;
        waiting = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
