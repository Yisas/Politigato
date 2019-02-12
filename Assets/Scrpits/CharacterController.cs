﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class CharacterController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;

    public AudioClip bucketPickupSound;
    public AudioClip distressSound;
    public TrailRenderer trailRenderer;

    private Vector3 initialPosition;
    private float verticalInput;

    private Rigidbody2D rb;
    private GManager gManager;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gManager = FindObjectOfType<GManager>();
        audioSource = GetComponent<AudioSource>();

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalSpeed, verticalInput * verticalSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bucket")
        {
            audioSource.PlayOneShot(bucketPickupSound);
            gManager.Score();
            collision.gameObject.SetActive(false);
        } else
        
        if(collision.tag == "Bullet")
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        audioSource.PlayOneShot(distressSound);
        trailRenderer.time = 0;
        transform.position = initialPosition;
        trailRenderer.Clear();
        trailRenderer.time = 1;
        gManager.ResetScore();
    }
}
