using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    private float sideScrollSpeed = 7;
    private float edgeSize = 50f;

    private float mostLeft = -7;
    private float mostRight = 7;

    private Camera cam;

    public bool edgeScrollingXActive = false;
    public bool edgeScrollingYActive = false;

    private float defaultYPos;
    
    

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
        
        if (SceneManager.GetActiveScene().name == "Kindergarten")
        {
            edgeScrollingXActive = true;
        }
        else
        {
            edgeScrollingXActive = false;
        }
        
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (edgeScrollingXActive)
        {
            EdgeScrollingX();
        }
        else if(edgeScrollingYActive)
        {
            // EdgeScrollingY();
        }
    }

    void EdgeScrollingX()
    {
        if (edgeScrollingXActive)
        {
            if (Input.mousePosition.x > Screen.width - edgeSize && transform.position.x < 20)
            {
                transform.position += new Vector3(sideScrollSpeed * Time.deltaTime, 0, 0); 
            }
            else if (Input.mousePosition.x < 0 + edgeSize && transform.position.x > -7)
            {
                transform.position += new Vector3(-sideScrollSpeed * Time.deltaTime, 0, 0); 
            }
        }
    }

    void EdgeScrollingY()
    {
        if (edgeScrollingYActive)
        {
            if (Input.mousePosition.y > Screen.height - edgeSize && transform.position.y < 2f)
            {
                transform.position += new Vector3(0, sideScrollSpeed * Time.deltaTime, 0); 
            }
            else if (Input.mousePosition.y < 0 + edgeSize && transform.position.y > 0)
            {
                transform.position += new Vector3(0, -sideScrollSpeed * Time.deltaTime, 0); 
            }
        }
    }

    public void LockOnBookCase(Vector3 bookCasePos)
    {
        edgeScrollingXActive = false;
        Vector3 bookCasePosWithZ = new Vector3(bookCasePos.x, bookCasePos.y, -10);
        transform.DOMove(bookCasePosWithZ, 2, false);
        cam.DOOrthoSize(4f, 2);

        edgeScrollingYActive = true;
    }

    public void ReleaseCam()
    {
        edgeScrollingXActive = true;
        cam.DOOrthoSize(5, 2);
        transform.DOMoveY(defaultYPos, 2);
    }
}
