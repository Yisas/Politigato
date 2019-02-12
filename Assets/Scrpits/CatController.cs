using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class CatController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;

    public float respawnDelay;

    public GameObject powerUpHair;
    public float powerUpInterval;

    public AudioClip bucketPickupSound;
    public AudioClip distressSound;
    public AudioClip bumpSound;
    public AudioClip powerUpSound;
    public TrailRenderer trailRenderer;

    private float initialHorizontalSpeed;
    private float initialVerticalSpeed;
    private Vector3 initialPosition;
    private float verticalInput;
    private float powerUpTimer;
    public bool poweredUp = false;
    private float respawnTimer;
    private bool respawning = false;

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
        initialHorizontalSpeed = horizontalSpeed;
        initialVerticalSpeed = verticalSpeed;
        powerUpTimer = powerUpInterval;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        if (poweredUp)
        {
            powerUpTimer -= Time.deltaTime;
            if(powerUpTimer < 0)
            {
                EndPowerUp();
            }
        }

        if (respawning)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer < 0)
            {
                FinishRespawn();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalSpeed, verticalInput * verticalSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            StartRespawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bucket")
        {
            audioSource.PlayOneShot(bucketPickupSound);
            gManager.Score();
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "Bullet")
        {
            if(!poweredUp)
                StartRespawn();
        }
        else if (collision.tag == "Powerup")
        {
            collision.gameObject.SetActive(false);
            PickupPowerUp();
        }
    }

    public void PickupPowerUp()
    {
        powerUpHair.SetActive(true);
        powerUpHair.GetComponent<AudioSource>().Play();
        audioSource.PlayOneShot(powerUpSound);
        powerUpTimer = powerUpInterval;
        poweredUp = true;
    }

    public void EndPowerUp()
    {
        powerUpHair.GetComponent<AudioSource>().Stop();
        powerUpHair.SetActive(false);
        poweredUp = false;
    }

    private void StartRespawn()
    {
        audioSource.PlayOneShot(bumpSound);
        horizontalSpeed = 0;
        verticalSpeed = 0;
        respawning = true;
        respawnTimer = respawnDelay;
        EndPowerUp();
    }

    private void FinishRespawn()
    {
        respawning = false;
        audioSource.PlayOneShot(distressSound);
        trailRenderer.time = 0;
        transform.position = initialPosition;
        horizontalSpeed = initialHorizontalSpeed;
        verticalSpeed = initialVerticalSpeed;
        trailRenderer.Clear();
        trailRenderer.time = 1;
        gManager.ResetScore();
    }
}
