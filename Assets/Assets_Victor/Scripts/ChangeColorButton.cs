using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    public Button buttonObject;
    private Color originalColor;
    public Color wantedColor; // Color para el estado pulsado

    void Start()
    {
        buttonObject.onClick.AddListener(ChangeColor);
    }

    public void ChangeColor()
    {
        ColorBlock cb=buttonObject.colors;
        cb.normalColor=wantedColor;
        cb.highlightedColor=wantedColor;
        cb.pressedColor=wantedColor;
        buttonObject.colors=cb;
    }

}

