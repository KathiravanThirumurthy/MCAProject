using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAnimation : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade-out animation in seconds

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

       
    }
    public void Play()
    {
        // Call the Coroutine to start the fade-out animation at the beginning
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // Set the initial alpha value to 1 (fully opaque)
        Color startColor = spriteRenderer.color;
        startColor.a = 1f;
        spriteRenderer.color = startColor;

        // Calculate the step value for each frame
        float step = Time.deltaTime / fadeDuration;
       

        // Reduce alpha value over time until it reaches 0 (fully transparent)
        while (spriteRenderer.color.a > 0f)
        {
            Color newColor = spriteRenderer.color;
            newColor.a -= step;
            spriteRenderer.color = newColor;
            yield return null;
           
        }

        // After the fade-out animation is complete, you may want to deactivate or destroy the GameObject
        gameObject.SetActive(false);
        // Alternatively, you can use Destroy(gameObject) to remove the GameObject from the scene entirely.
    }
}
