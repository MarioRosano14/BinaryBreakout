using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AccessKeypad : MonoBehaviour
{
    public GameObject charger;

    public void Start() {
        charger.SetActive(false);
    }

    public void ChargerKeypad() {
        charger.SetActive(true);
    }

    public void SceneKeypad() {
        Invoke("CambiarEscena", 1.5f);
    }

    private void CambiarEscena() {
        SceneManager.LoadScene("Pasillo");
    }
}
