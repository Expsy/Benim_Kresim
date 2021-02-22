using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneezeIcon : MonoBehaviour
{

    public GameObject popUp;

    public KidBehaviour myKid;

    private void Awake()
    {
        myKid = transform.GetComponentInParent<KidBehaviour>();
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
        popUp.SetActive(false);
        BarManager.barManager.BeginBarProgressCoroutine(5);
        myKid.GoBathroom();
    }
}
