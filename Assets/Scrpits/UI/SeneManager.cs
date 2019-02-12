using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeneManager : MonoBehaviour
{
    public void AnimationCallback()
    {
        SceneManager.LoadScene(1);
    }
}
