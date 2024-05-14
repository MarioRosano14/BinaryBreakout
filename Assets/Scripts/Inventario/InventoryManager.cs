using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItem = 6;
    public InventorySlot[] inventorySlots;
    public InventorySlot[] combineSlots;
    public InventorySlot handSlot;
    public Item[] newCombinedItems;

    public delegate void DelegarDialogos(DialogueData dialogueData);
    public static event DelegarDialogos EventoDialogos;
    public GameObject dialogueBox;
    public Button combineButton;

    public GameObject inventoryItemPrefab;

    void Start() {
        combineButton.onClick.AddListener(CombineItems);
    }

    public bool AddItem(Item item) {
        // Comprobar si algún espacio tiene el mismo item con contador
        // menor que el máximo
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item 
                && itemInSlot.count < maxStackedItem && itemInSlot.item.stackable == true) {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Encontrar cualquier espacio vaccio
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null) {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false; 
    }

    void SpawnNewItem(Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public InventoryItem GetSelectedHandItem() {
        InventorySlot slot = handSlot;
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        return itemInSlot;
    }

    public void CombineItems() {
        InventorySlot slot1 = combineSlots[0];
        InventorySlot slot2 = combineSlots[1];
        InventoryItem itemInSlot1 = slot1.GetComponentInChildren<InventoryItem>();
        InventoryItem itemInSlot2 = slot2.GetComponentInChildren<InventoryItem>();

        string[] lines;
        string[] names;
        DialogueData dialogueData;

        if (itemInSlot1 != null && itemInSlot2 != null) {
            Item item1 = itemInSlot1.item;
            Item item2 = itemInSlot2.item;
            Item newItem = null;

            if ((item1.name == "Basura" && item2.name == "Pico") ||
                (item1.name == "Pico" && item2.name == "Basura")) {
                foreach (Item cI in newCombinedItems) {
                    if (cI.name == "Banco") {
                        newItem = cI;

                        Destroy(itemInSlot1.gameObject);
                        Destroy(itemInSlot2.gameObject);
                        AddItem(newItem);
                        break;
                    }
                }
            }

            if ((item1.name == "Parte de madera (Pomo)" && item2.name == "Parte de hierro (Pomo)") ||
                (item1.name == "Parte de hierro (Pomo)" && item2.name == "Parte de madera (Pomo)")) {
                foreach (Item cI in newCombinedItems) {
                    if (cI.name == "Pomo") {
                        newItem = cI;

                        Destroy(itemInSlot1.gameObject);
                        Destroy(itemInSlot2.gameObject);
                        AddItem(newItem);
                        break;
                    }
                }
            }
            
            if (newItem != null) {
                lines = new string[] {"Has fabricado: " + newItem.name};
                names = new string[] {"Luca"};
                dialogueData = new DialogueData(lines, names);
            }
            else {
                lines = new string[] {"No creo que sirvan estos objetos"};
                names = new string[] {"Profesor"};
                dialogueData = new DialogueData(lines, names);
            }
        }
        else {
            lines = new string[] {"No es suficiente para combinar"};
            names = new string[] {"Profesor"};
            dialogueData = new DialogueData(lines, names);
        }

        dialogueBox.SetActive(true);    
        EventoDialogos?.Invoke(dialogueData);
    }
}