using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RawImageFadeOut : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float fadeDuration; // Duración de la transición
    [SerializeField] private float fadeTimePassed; // Duración de antes la transición
    [SerializeField] private string nextSceneName; // Nombre de la siguiente escena
    private float timer = 0f;
    private Color startColor;
    private Color targetColor = Color.black;
    private bool startTransitionOut = false;

    private void Start()
    {
        startColor = rawImage.color;
        Invoke("StartFadeOut", fadeTimePassed); // Iniciar la transición después de 15 segundos
    }

    private void StartFadeOut()
    {
        startTransitionOut = true; // Iniciar la transición
    }

    private void Update()
    {
        if (startTransitionOut)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;
            rawImage.color = Color.Lerp(startColor, targetColor, normalizedTime);

            if (normalizedTime >= 1f)
            {
                // La transición ha terminado, cambiar a la siguiente escena
                ChangeScene();
            }
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
