﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameLauncher : MonoBehaviour
{

    public int gameID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SceneController.sceneController.GoTargetScene(gameID);
    }
}
