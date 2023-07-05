using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour
{
    public GameObject menu; // Reference to the menu GameObject
    public GameObject CharacterImage; // CG 
    public bool TabFlag = false;
    private bool isAnimating = false; // Flag to track whether the animation is currently running
    private float animationDuration = 0.3f; // Duration of the animation in seconds
    private float animationStartTime; // Time at which the animation started
    private Vector3 OrgPosition;

    void Start()
    {
        OrgPosition = CharacterImage.transform.position;

        // Alpha = 0
        Image characterImage = CharacterImage.GetComponent<Image>();
        Color imageColor = characterImage.color;
        imageColor.a = 0;
        characterImage.color = imageColor;

        menu.SetActive(false);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || TabFlag)
        {
            // Toggle the menu on/off
            menu.SetActive(!menu.activeSelf);

            // If the animation is not already running, start it
            if (!isAnimating)
            {
                isAnimating = true;
                animationStartTime = Time.time;
            }
            TabFlag = false;
        }

        // If the animation is running, update the alpha value of the CharacterImage
        if (isAnimating)
        {
            // Calculate the elapsed time since the animation started
            float elapsedTime = Time.time - animationStartTime;
            float animationProgress = Mathf.Clamp01(elapsedTime / animationDuration);

            // Calculate the new alpha value for the CharacterImage
            float alphaValue = Mathf.Lerp(0f, 1f, animationProgress);

            Image characterImage = CharacterImage.GetComponent<Image>();
            Color imageColor = characterImage.color;
            imageColor.a = alphaValue;
            characterImage.color = imageColor;

            // Calculate the new y position for the CharacterImage using a sine function
            float yPosition = Mathf.Sin(animationProgress * Mathf.PI * 2f) * 2.0f ;
            Vector3 characterImagePosition = OrgPosition;
            characterImagePosition.y += yPosition;
            CharacterImage.transform.position = characterImagePosition;

            // If the animation is complete, stop it
            if (animationProgress >= 1f)
            {
                isAnimating = false;
            }
        }
    }
}