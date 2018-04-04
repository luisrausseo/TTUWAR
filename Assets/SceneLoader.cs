using UnityEngine;
using System.Collections;
using Vuforia;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
        if (level == 1)
        {
            VuforiaRuntime.Instance.InitVuforia();
        }
        else
        {
            VuforiaBehaviour.Instance.enabled = false;
        }
        Debug.Log("Hello!");
        //Application.LoadLevel(level);
    }
}