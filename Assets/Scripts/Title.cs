﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene");
    }
    public void ChangeHard()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene2");
    }


    public void ChangeTitle()
    {//タイトルに戻ってくるとき
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title");
    }
}
