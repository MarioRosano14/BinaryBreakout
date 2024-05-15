using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFadeInFadeOut : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    [SerializeField] private float secondsAppear; // Tiempo antes de iniciar el fade in
    [SerializeField] private float secondsDisappear; // Tiempo antes de iniciar el fade out
    private Color originalColor;
    private bool fadeIn = false;
    private bool fadeOut = false;

    private void Start()
    {
        // Almacenamos el color original del texto
        originalColor = textObject.color;
        
        // Hacemos el texto inicialmente invisible
        textObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        
        // Llamamos al fade in después del tiempo especificado
        Invoke("StartFadeIn", secondsAppear);
        // Llamamos al fade out después del tiempo especificado
        if(secondsDisappear!=0)
        {
            Invoke("StartFadeOut", secondsDisappear);
        }
        
    }

    private void StartFadeIn()
    {
        fadeIn = true;
        fadeOut = false;
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
        Color targetColor = fadeIn ? originalColor : new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        Color currentColor = textObject.color;
        float targetAlpha = targetColor.a;

        float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, Time.deltaTime);

        textObject.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        if (Mathf.Approximately(newAlpha, targetAlpha))
        {
            // Se alcanzó el objetivo de transparencia, detener el efecto
            if (fadeIn)
            {
                this.fadeIn = false;
            }
            else
            {
                this.fadeOut = false;
                // El texto se vuelve invisible
                textObject.gameObject.SetActive(false);
            }
        }
    }
}


