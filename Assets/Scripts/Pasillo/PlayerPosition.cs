using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject luca;
    
    public Vector3 playerPosition1;
    public Vector3 playerRotation1;
    public Vector3 lucaPosition1;
    public Vector3 lucaRotation1;

    public Vector3 playerPosition2;
    public Vector3 playerRotation2;
    public Vector3 lucaPosition2;
    public Vector3 lucaRotation2;

    public static bool moved = false;
    private bool check = false;

    void Start() {
        if (/*PlayerPrefs.GetInt("sceneInGame", 0) == 2*/false) {
            transform.position = playerPosition1;
            transform.rotation = Quaternion.Euler(playerRotation1);

            luca.transform.position = lucaPosition1;
            luca.transform.rotation = Quaternion.Euler(lucaRotation1);
        }
        else if (/*PlayerPrefs.GetInt("sceneInGame", 0) == 4*/true) {
            transform.position = playerPosition2;
            transform.rotation = Quaternion.Euler(playerRotation2);

            luca.transform.position = lucaPosition2;
            luca.transform.rotation = Quaternion.Euler(lucaRotation2);
        }
    }

    void Update() {
        if (transform.position == playerPosition1 ||
            transform.position == playerPosition2) {
                moved = true; 
            }
    }
}
