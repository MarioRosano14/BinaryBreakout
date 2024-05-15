using UnityEngine;

public class SkyboxMovement : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}