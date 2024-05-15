using UnityEngine;

public class MaterialMovement : MonoBehaviour
{
    public string propertyName = "_MainTex";
    public Vector2 movementSpeed = new Vector2(1.0f, 0.0f);

    private Material material;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }
        else
        {
            Debug.LogError("No renderer found on object " + gameObject.name);
        }
    }

    void Update()
    {
        if (material != null)
        {
            Vector2 offset = material.GetTextureOffset(propertyName);
            offset += movementSpeed * Time.deltaTime;
            material.SetTextureOffset(propertyName, offset);
        }
    }
}