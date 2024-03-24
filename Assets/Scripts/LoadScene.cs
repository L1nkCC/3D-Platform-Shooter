using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public enum SceneIDs
    {
        PlayScene = 0,
        Menu = 1,
    }
    public void LoadSceneWithID(int sceneId)
    {
        SceneManager.LoadScene(sceneId);

    }
    public void LoadSceneID(SceneIDs sceneId)
    {
        SceneManager.LoadScene((int)sceneId);

    }
}
