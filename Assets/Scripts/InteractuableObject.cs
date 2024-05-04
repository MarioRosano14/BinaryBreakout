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

    public void Start() {
        GameObject IM = GameObject.FindWithTag("InventoryManager");
        inventoryManager = IM.GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        InventoryItem itemInSlot = inventoryManager.GetSelectedHandItem();
        if (itemInSlot != null) {
            Item item = itemInSlot.item;
            if (item.name == name && itemInSlot.count == count) {
                Destroy(itemInSlot.gameObject);
                inventoryManager.AddItem(solItem);
                // Dialogo obtener objeto
                Debug.Log("Has conseguido " + solItem.name);
            }
        }
    }
}
