using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItem = 6;
    public InventorySlot[] inventorySlots;
    public InventorySlot[] combineSlots;
    public InventorySlot handSlot;

    public GameObject inventoryItemPrefab;

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

    public Item CombineItems() {
        InventorySlot slot1 = combineSlots[0];
        InventorySlot slot2 = combineSlots[1];
        InventoryItem item1 = slot1.GetComponentInChildren<InventoryItem>();
        InventoryItem item2 = slot2.GetComponentInChildren<InventoryItem>();

        if (item1 != null && item2 != null) {
            Item item;
            if (/*Comprobar que se puedan combinar*/true) {
                //item = Combine(item1, item2);
            }

            //return item; 
        }

        return null;
    }
}