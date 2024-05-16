using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int scene = 1;
    
    public void SavePlayer() {
        //SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        scene = data.scene;
        GameObject player = GameObject.FindWithTag("Player");

        switch (scene)
        {
            case 1:
                Vector3 pos = new Vector3(0, 0, 0);
                player.transform.position = pos;
                break;        
            case 2:
                //...
                break;    
            default:
                break;
        }
    }
}