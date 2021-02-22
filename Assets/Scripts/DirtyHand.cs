using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyHand : MonoBehaviour
{
    public GameObject blinks;
    public int nailCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBlinks()
    {
        blinks.SetActive(true);
    }

    public void checkIfClean()
    {
        if (nailCount <= 0 && !blinks.activeSelf)
        {
            Invoke(nameof(ActivateBlinks), 1.5f);
        }
    }
}
