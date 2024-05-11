using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractuableObject : MonoBehaviour, IPointerClickHandler
{
    private InventoryManager inventoryManager;
    public string name;
    public int count;
    public Item solItem;

    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;

    public void Start() {
        GameObject IM = GameObject.FindWithTag("InventoryManager");
        inventoryManager = IM.GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        InventoryItem itemInSlot = inventoryManager.GetSelectedHandItem();
        if (!menuScript.inPause && !Dialogue.inDialogue && itemInSlot != null) {
            Item item = itemInSlot.item;
            if (item.name == name && itemInSlot.count == count) {
                Destroy(itemInSlot.gameObject);
                inventoryManager.AddItem(solItem);

                string[] lines = new string[] {"Has conseguido: " + solItem.name.ToString()};
                string[] names = new string[] {"Luca"};
                DialogueData dialogueData = new DialogueData(lines, names);
                dialogueBox.SetActive(true);
                EventoDialogos?.Invoke(dialogueData);
            }
        }
    }
}
