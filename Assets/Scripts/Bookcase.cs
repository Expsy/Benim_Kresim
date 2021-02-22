using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookcase : MonoBehaviour
{
    public static Bookcase instance;
    public Transform shelves;
    public bool isBookCaseActive = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        shelves = transform.GetChild(0);
    }
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
        Debug.Log(isBookCaseActive);
        if (!isBookCaseActive)
        {
            isBookCaseActive = true;
            CameraController.instance.LockOnBookCase(transform.position);
        }
        else if (isBookCaseActive)
        {
            isBookCaseActive = false;
            CameraController.instance.ReleaseCam();
        }
    }

}
