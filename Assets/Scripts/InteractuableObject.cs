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

    public bool destroyGameObject;
    private bool check = false;

    public void Start() {
        GameObject IM = GameObject.FindWithTag("InventoryManager");
        inventoryManager = IM.GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        InventoryItem itemInSlot = inventoryManager.GetSelectedHandItem();
        if (!menuScript.inPause && !Dialogue.inDialogue) {
            string[] lines;
            string[] names;
            DialogueData dialogueData;
            if (itemInSlot != null) {
                Item item = itemInSlot.item;
                if (item.name == name) {
                    if (itemInSlot.count == count) {
                        Destroy(itemInSlot.gameObject);
                        inventoryManager.AddItem(solItem);

                        lines = new string[] {"Has conseguido: " + solItem.name.ToString()};
                        names = new string[] {"Luca"};
                        dialogueData = new DialogueData(lines, names);

                        check = true; 
                    }
                    else {
                        lines = new string[] {"Parece que necesito más"};
                        names = new string[] {"Profesor"};
                        dialogueData = new DialogueData(lines, names);
                    }
                }
                else{
                    lines = new string[] {"No parece que funcione"};
                    names = new string[] {"Profesor"};
                    dialogueData = new DialogueData(lines, names);
                }
            }
            else {
                lines = new string[] {"Parece que necesito algo aquí"};
                names = new string[] {"Profesor"};
                dialogueData = new DialogueData(lines, names);
            }

            dialogueBox.SetActive(true);
            EventoDialogos?.Invoke(dialogueData);

            if (check && destroyGameObject) {
                gameObject.SetActive(false);
            }
        }
    }
}
