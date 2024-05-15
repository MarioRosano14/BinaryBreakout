using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public GameObject dialogue;
    //public string name;
    public static string[] lines;
    public static string[] name;

    // Declaración de un delegado para el evento
    public delegate void ButtonPressedAction();
    // Evento que se activará cuando se presione el botón
    public static event ButtonPressedAction OnButtonPressed;

    void OnMouseDown()
    {
        // Comprueba si el objeto tiene la etiqueta "NPC" antes de iniciar el diálogo
        if (gameObject.CompareTag("Player"))
        {
            lines=new string[] { "hola", "NOOOO", "JFJFJFJFJ" };
            name=new string[] { "f", "a", "JJ" };
            dialogue.SetActive(true);
            OnButtonPressed?.Invoke();
        }
        // Comprueba si el objeto tiene la etiqueta "NPC" antes de iniciar el diálogo
        if (gameObject.CompareTag("Finish"))
        {
            lines=new string[] { "ey","no veas" };
            name=new string[] { "af", "aa" };
            dialogue.SetActive(true);
            OnButtonPressed?.Invoke();
        }
    }
}
