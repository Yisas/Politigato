using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerritoTrigger : MonoBehaviour
{
    public Animator animator;
    public float outTime;

    private bool outTriggered = false;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outTriggered)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                animator.SetTrigger("out");
                outTriggered = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("in");
        }

        timer = outTime;
        outTriggered = true;
    }
}
