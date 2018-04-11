﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using Facebook.Unity;

public class GameStart : MonoBehaviour
{

    private bool loadScene = false;

    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;

    void Update()
    {
        if (FB.IsLoggedIn && loadScene == false)
        {
            loadScene = true;
            loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());
        }
        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!async.isDone)
        {
            yield return null;
        }

    }

}
