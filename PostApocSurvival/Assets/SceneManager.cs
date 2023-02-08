using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public enum Scene { Login, Main }

    public GameObject[] scenes;
    public void ChangeScene(Scene scene)
    {
        ChangeScene(((int)scene));
    }
    public void CloseAllScenes()
    {
        foreach(GameObject scene in scenes)
        {
            scene.SetActive(false);
        }
    }
    public void ChangeScene(int SceneID)
    {
        CloseAllScenes();

        scenes[SceneID].SetActive(true);
    }
}
