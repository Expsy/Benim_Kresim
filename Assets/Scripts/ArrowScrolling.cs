using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowScrolling : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public bool isitUp = true;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Bookcase.instance.isBookCaseActive)
        {
            if (isitUp)
            {
                Debug.Log("shelves moving up");
                if (Bookcase.instance.shelves.transform.localPosition.y <= 12)
                {
                    Debug.Log("moving up");
                    Bookcase.instance.shelves.Translate(Vector2.up * Time.deltaTime * scrollSpeed);
                }
            }
            else
            {
                if (Bookcase.instance.shelves.transform.localPosition.y >= 0)
                {
                    Bookcase.instance.shelves.Translate(Vector2.up * Time.deltaTime * -scrollSpeed);
                }
            }
        }
    }
}
