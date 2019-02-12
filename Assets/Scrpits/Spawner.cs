using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objToSpawn;
    public float minTime;
    public float maxTime;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = Random.Range(minTime, maxTime);
            Instantiate(objToSpawn[Random.Range(0, objToSpawn.Length)], transform.position, transform.rotation);
        }
    }
}
