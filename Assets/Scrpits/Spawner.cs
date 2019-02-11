using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject objToSpawn;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeToSpawn;
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
