using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject objToSpawn;
    public float minDelay;
    public float maxDelay;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minDelay, maxDelay) + timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = timeToSpawn;
            Instantiate(objToSpawn, transform.position, transform.rotation);
        }
    }
}
