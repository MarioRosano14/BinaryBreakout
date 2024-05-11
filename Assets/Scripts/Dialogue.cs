using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public float textSpeed;
    private DialogueData dialogueData;
    //public GameObject panel;
    private int index;
    public static bool inDialogue = false;

    public GameObject HandSlot;
    public GameObject QButton;
    public GameObject AButton;
    public GameObject DButton;

    // Start is called before the first frame update
    void Start()
    {
        // Suscribirse al evento OnButtonPressed
        EventClick.EventoDialogos += StartDialogue;
        InteractuableObject.EventoDialogos += StartDialogue;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !menuScript.inPause)
        {
            if(textComponent.text == dialogueData.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueData.lines[index];
            }
        }
    }

    void StartDialogue(DialogueData dD)
    {
        inDialogue = true;
        HandSlot.SetActive(false);
        if (CamSwitch.inSpecial) QButton.SetActive(false);
        if (!CamSwitch.inSpecial) AButton.SetActive(false);
        if (!CamSwitch.inSpecial) DButton.SetActive(false);

        dialogueData = dD;
        nameComponent.text = dialogueData.names[0];
        textComponent.text = string.Empty;
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor dentro de la ventana del juego
        Cursor.visible = false; // Oculta el cursor
        index=0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in dialogueData.lines[index].ToCharArray())
        {
            textComponent.text+=c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < dialogueData.lines.Length - 1)
        {
            index++;
            nameComponent.text = dialogueData.names[index];
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
            Cursor.visible = true; // Muestra el cursor
            inDialogue = false;
            HandSlot.SetActive(true);
            if (CamSwitch.inSpecial) QButton.SetActive(true);
            if (!CamSwitch.inSpecial) AButton.SetActive(true);
            if (!CamSwitch.inSpecial) DButton.SetActive(true);

            gameObject.SetActive(false);
            index=0;
        }
    }
}


public class DialogueData {
    public string[] lines;
    public string[] names;

    public DialogueData(string[] lines, string[] names) {
        this.lines = lines;
        this.names = names;
    }
}