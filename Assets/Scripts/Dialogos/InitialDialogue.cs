using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogue : MonoBehaviour
{
    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;

    public string[] lines;
    public string[] names;

    private bool check = false;

    void Update() 
    {
        if (!check && EventoDialogos != null) {
            DialogueData dialogueData = new DialogueData(lines, names);
            dialogueBox.SetActive(true);
            EventoDialogos?.Invoke(dialogueData);
            check = true;
        }
    }
}
