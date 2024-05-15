using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CastObject : MonoBehaviour, IPointerClickHandler
{
    private InventoryManager inventoryManager;
    public string name;
    public int count;
    public GameObject[] castGameObjects;

    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;
    private bool check = false;
    public bool deactivateChangeScene;
    public bool deactivateCollider;
    private Collider collider;

    private int iter = 0;

    public void Start() {
        collider = GetComponent<Collider>();
        if (GetComponent<Collider>() == null) {
            collider = GetComponentInChildren<Collider>();
        }

        foreach(GameObject gO in castGameObjects) {
            gO.SetActive(false);
        }
        
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
                        foreach(GameObject gO in castGameObjects) {
                            gO.SetActive(true);
                        }

                        check = true;
                        dialogueData = null;
                        if (deactivateCollider) {
                            GetComponent<Collider>().enabled = false;
                        }

                        if (!deactivateChangeScene) {
                            Invoke("CambiarEscena", 1.5f);
                        }
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

    private void CambiarEscena() {
        SceneManager.LoadScene("Pasillo");
    }
}
