using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateObjects : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] gameObjects;
    public Vector3 offset;
    private bool moved = false;

    public void OnPointerClick(PointerEventData eventData) {
        if (!menuScript.inPause && !Dialogue.inDialogue && !moved) {
            foreach(GameObject go in gameObjects) {
                go.transform.rotation = Quaternion.Euler(go.transform.rotation.eulerAngles + offset);
            }

            moved = true;
        }
    }
}
