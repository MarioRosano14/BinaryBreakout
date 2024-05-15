using UnityEngine;
using UnityEngine.UI;

public class RawImageFadeIn : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float fadeDuration; // Duración de la transición

    private Color startColor = Color.black;
    private Color targetColor;
    private bool startTransition = false;
    private float timer = 0f;

    private void Start()
    {
        targetColor = rawImage.color; // Almacenar el color original de la imagen
        rawImage.color = startColor; // Iniciar con el color negro
        startTransition = true; // Iniciar la transición
    }

    private void Update()
    {
        if (startTransition)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            rawImage.color = Color.Lerp(startColor, targetColor, normalizedTime);

            if (normalizedTime >= 1f)
            {
                // La transición ha terminado
                startTransition = false; // Detener la transición aquí si no quieres cambiar de escena
            }
        }
    }
}

