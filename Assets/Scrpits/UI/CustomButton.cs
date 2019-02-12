using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CustomButton : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip focusSound;
    public AudioClip clickSound;

    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = FindObjectOfType<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(focusSound);
    }

    public void StartGame()
    {
        Cursor.visible = false;
        animator.SetTrigger("fade");
        audioSource.PlayOneShot(clickSound);
    }
}
