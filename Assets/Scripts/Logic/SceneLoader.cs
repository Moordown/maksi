﻿using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioMixer Mixer;
    public Animator sceneTransitionAnimator;

    protected void StartLoading(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        Debug.Log("Loading new scene");
        sceneTransitionAnimator.Play("end");
        yield return new WaitForSeconds(1.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneName);
        RestoreGlobalValues();
    }

    void RestoreGlobalValues()
    {
        foreach (var kv in Config.mixerValues)
            Mixer.SetFloat(kv.Key, kv.Value);
    }
}
