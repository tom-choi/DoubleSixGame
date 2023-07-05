using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRawImageAlpha : MonoBehaviour
{
    public float alphaValue = 0.5f; // set the default alpha value here

    IEnumerator ChangeAlpha()
    {
        RawImage image = GetComponent<RawImage>(); // get the RawImage component
        Color color = image.color; // get the current color

        // loop indefinitely
        while (true)
        {
            // calculate the new alpha value based on time
            float newAlpha = Mathf.Sin(Time.time) * 0.5f + 0.5f; // range from 0 to 1

            // set the alpha value
            color.a = newAlpha;

            // apply the new color
            image.color = color;

            // wait for the next frame
            yield return null;
        }
    }

    void Start()
    {
        StartCoroutine(ChangeAlpha());
    }
}