using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nail : MonoBehaviour
{
    private Rigidbody2D rBody;
    private int forceMultiplier = 300;
    private DirtyHand _hand;

    public GameObject bacteria;
    
    private void Awake()
    {
        _hand = GetComponentInParent<DirtyHand>();
        rBody = GetComponent<Rigidbody2D>();
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
        KidManager.kidManager.currentKid.myKid.dirtyNailCount -= 1;
        KidManager.kidManager.CheckIfCleaned();
        Invoke("BacteriaShrink", 0.5f);
        _hand.nailCount -= 1;
        _hand.checkIfClean();
        BarManager.barManager.BeginBarProgressCoroutine(1);
        LaunchNail();
    }

    void LaunchNail()
    {
        int randomX = Random.Range(-60, 60);
        rBody.AddTorque(20, ForceMode2D.Force);
        Vector2 forceVector = new Vector2(randomX, 50);
        rBody.AddForce(forceVector.normalized * forceMultiplier, ForceMode2D.Force);
        rBody.gravityScale = 2;
    }

    IEnumerator BacteriaShrinkCoroutine()
    {
        while (bacteria.transform.localScale.magnitude > 0.1f)
        {
            if (bacteria.transform.localScale.x > 0)
            {
                bacteria.transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
            }
            else if (bacteria.transform.localScale.x < 0)
            {
                bacteria.transform.localScale -= new Vector3(-1f, 1f, 1f) * Time.deltaTime;
            }
            yield return null;
        }

        if (bacteria.transform.localScale.magnitude  <= 0.1f)
        {
            bacteria.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void BacteriaShrink()
    {
        StartCoroutine(BacteriaShrinkCoroutine());
    }
}
