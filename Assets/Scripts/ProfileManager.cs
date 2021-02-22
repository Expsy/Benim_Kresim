using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager profileManager;
    
    public int coin = 0;

    private void Awake()
    {
        if (profileManager != null)
        {
            Destroy(this);
        }
        else
        {
            profileManager = this;
        }
        
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
