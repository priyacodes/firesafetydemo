using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    // Start is called before the first frame update

    public Material faderMat;

    private void Start()
    {
        FadeIn();
    }
    public void FadeIn()
    {
        StartCoroutine(FadeTo(1,0, 5));
    }
    
    public void FadeOut()
    {
       StartCoroutine(FadeTo(0,1, 5));
    }

    IEnumerator FadeTo(float startAlpha, float targetAlpha, float duration)
    {
        
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Increment the elapsed time by the time passed since the last frame
            elapsedTime += Time.deltaTime;
            // Calculate the percentage of completion (0 to 1)
            float percentageComplete = elapsedTime / duration;

            // Lerp the alpha value from the start to the target
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, percentageComplete);

            // Create a temporary color variable to modify the alpha
            Color tempColor = faderMat.color;
            tempColor.a = currentAlpha;

            // Assign the modified color back to the material
            faderMat.color = tempColor;

            // Wait until the next frame
            yield return null;
        }

        // Ensure the final alpha value is set precisely
        Color finalColor = faderMat.color;
        finalColor.a = targetAlpha;
        faderMat.color = finalColor;

       
    }
}
