using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public void TakeScreenShot(string fullPath)
    {
        if (GetComponent<Camera>() == null)
        {
            camera = GetComponent<Camera>();
        }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        GetComponent<Camera>().targetTexture = rt;
        Texture2D screenshot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        GetComponent<Camera>().Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        GetComponent<Camera>().targetTexture = null;
        RenderTexture.active = null;

        if(Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, bytes);
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
