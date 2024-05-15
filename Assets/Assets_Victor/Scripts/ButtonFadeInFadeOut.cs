using UnityEngine;
using UnityEngine.UI;

public class ButtonFadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private float secondsAppear; // Tiempo antes de iniciar el fade in
    [SerializeField] private float secondsDisappear; // Tiempo antes de iniciar el fade out
    private ColorBlock originalColors;
    private bool fadeIn = false;
    private bool fadeOut = false;

    private void Start()
    {
        // Almacenamos los colores originales del botón
        originalColors = button.colors;
        
        // Desactivamos el botón inicialmente
        button.interactable = false;

        // Llamamos al fade in después del tiempo especificado
        Invoke("StartFadeIn", secondsAppear);
        // Llamamos al fade out después del tiempo especificado
        if (secondsDisappear != 0)
        {
            Invoke("StartFadeOut", secondsDisappear);
        }
    }

    private void StartFadeIn()
    {
        fadeIn = true;
        fadeOut = false;
        button.interactable = true;
    }

    private void StartFadeOut()
    {
        fadeIn = false;
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            FadeEffect(true);
        }
        else if (fadeOut)
        {
            FadeEffect(false);
        }
    }

    private void FadeEffect(bool fadeIn)
    {
        ColorBlock targetColors = fadeIn ? originalColors : new ColorBlock()
        {
            normalColor = new Color(0f, 0f, 0f, 0f), // Botón invisible en fade out
            highlightedColor = new Color(0f, 0f, 0f, 0f),
            pressedColor = new Color(0f, 0f, 0f, 0f),
            selectedColor = new Color(0f, 0f, 0f, 0f),
            disabledColor = new Color(0f, 0f, 0f, 0f)
        };

        float transitionSpeed = Time.deltaTime / 0.5f; // Velocidad de transición

        // Interpolating the colors manually
        Color currentNormalColor = button.colors.normalColor;
        Color targetNormalColor = targetColors.normalColor;
        Color newNormalColor = Color.Lerp(currentNormalColor, targetNormalColor, transitionSpeed);

        // Apply the new color to the button
        ColorBlock newColors = button.colors;
        newColors.normalColor = newNormalColor;
        button.colors = newColors;

        if (fadeIn && Mathf.Approximately(newNormalColor.a, originalColors.normalColor.a))
        {
            this.fadeIn = false;
        }
        else if (fadeOut && Mathf.Approximately(newNormalColor.a, 0f))
        {
            this.fadeOut = false;
            button.interactable = false; // Desactivamos el botón después del fade out
        }
    }
}
