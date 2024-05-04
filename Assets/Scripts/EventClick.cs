using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler
{
    private InventoryManager inventoryManager;

    public void Start() {
        GameObject IM = GameObject.FindWithTag("InventoryManager");
        inventoryManager = IM.GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        ScriptableItemHandler SIH = GetComponent<ScriptableItemHandler>();
        if (SIH != null) {
            Item item = SIH.item;
            inventoryManager.AddItem(item);
            Debug.Log("Has obtenido " + item.name);
            Destroy(gameObject);
        }
    }
}
