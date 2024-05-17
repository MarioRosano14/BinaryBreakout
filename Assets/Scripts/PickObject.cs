using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickObject : MonoBehaviour, IPointerClickHandler
{
    private InventoryManager inventoryManager;

    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;

    public void Start() {
        GameObject IM = GameObject.FindWithTag("InventoryManager");
        inventoryManager = IM.GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        ScriptableItemHandler SIH = GetComponent<ScriptableItemHandler>();
        if (!menuScript.inPause && !Dialogue.inDialogue && SIH != null) {
            Item item = SIH.item;
            inventoryManager.AddItem(item);

            string[] lines = new string[] {"Has obtenido: " + item.name.ToString() + "."};
            string[] names = new string[] {"Luca"};
            DialogueData dialogueData = new DialogueData(lines, names);
            dialogueBox.SetActive(true);
            EventoDialogos?.Invoke(dialogueData);

            Destroy(gameObject);
        }
    }
}
