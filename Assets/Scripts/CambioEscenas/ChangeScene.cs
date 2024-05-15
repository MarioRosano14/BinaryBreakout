using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IPointerClickHandler
{
    public string scene;

    private InventoryManager inventoryManager;
    public string name;
    public int count;

    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;

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

                        SceneManager.LoadScene(scene);
                        check = true;
                        dialogueData = null;
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

            if (!check) {
                dialogueBox.SetActive(true);
                EventoDialogos?.Invoke(dialogueData);
            }
        }
    }
}
