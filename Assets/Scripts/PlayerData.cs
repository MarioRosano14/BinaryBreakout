using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[System.Serializable]
public class PlayerData : ISerializationCallbackReceiver {

    public int scene;
    [SerializeField] private int serializedScene;

    public PlayerData () {
        scene = PlayerPrefs.GetInt("sceneInGame", 0);
    }

    /*void Start() {
        scene = PlayerPrefs.GetInt("sceneInGame", 0);


    }*/

    // Implementación de ISerializationCallbackReceiver
    public void OnBeforeSerialize() {
        // Guardar los valores en las variables de respaldo antes de la serialización
        serializedScene = scene;
    }

    public void OnAfterDeserialize() {
        // Recuperar los valores de las variables de respaldo después de la deserialización
        scene = serializedScene;
    }

    public void SavePlayerData() {
        SaveSystem.SavePlayer(this);
    }
}