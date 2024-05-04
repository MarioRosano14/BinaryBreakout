using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainInventory;
    void Start()
    {
        mainInventory = GameObject.FindWithTag("MainInventory");
        mainInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (mainInventory.activeSelf) mainInventory.SetActive(false);
            else mainInventory.SetActive(true);
        }
    }
}
