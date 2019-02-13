using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    
    private Vector3 offset;
    private bool shaking = false;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (!shaking)
        {
            transform.position = player.transform.position + offset;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    public void ShakeCamera(float magnitude, float duration)
    {
        shaking = true;
        StartCoroutine(ShakeCameraEnumarator(magnitude, duration));
    }

    private IEnumerator ShakeCameraEnumarator(float magnitude, float duration)
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.position = new Vector3(x + originalCamPos.x, y + originalCamPos.y, originalCamPos.z);

            yield return null;
        }

        transform.position = originalCamPos;
        shaking = false;
    }
}