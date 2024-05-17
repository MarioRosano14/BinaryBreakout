using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosetScript : MonoBehaviour, IPointerClickHandler
{
    private InventoryManager inventoryManager;
    public string name;
    public int count;

    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;
    private bool check = false;

    public GameObject chains;
    public GameObject padlock;
    public GameObject leftDoor;
    public GameObject rightDoor;

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
                        Destroy(chains);
                        Destroy(padlock);

                        leftDoor.transform.rotation = Quaternion.Euler(leftDoor.transform.rotation.eulerAngles +
                                                         new Vector3(0, 90, 0));
                        rightDoor.transform.rotation = Quaternion.Euler(rightDoor.transform.rotation.eulerAngles +
                                                         new Vector3(0, -37, 0));

                        check = true;
                        dialogueData = null;
                    }
                    else {
                        lines = new string[] {"Parece que necesito más."};
                        names = new string[] {"Profesor"};
                        dialogueData = new DialogueData(lines, names);
                    }
                }
                else{
                    lines = new string[] {"No parece que funcione."};
                    names = new string[] {"Profesor"};
                    dialogueData = new DialogueData(lines, names);
                }
            }
            else {
                lines = new string[] {"Parece que necesito algo aquí."};
                names = new string[] {"Profesor"};
                dialogueData = new DialogueData(lines, names);

            }

            if (!check) {
                dialogueBox.SetActive(true);
                EventoDialogos?.Invoke(dialogueData);
            }
        }
    }
}
