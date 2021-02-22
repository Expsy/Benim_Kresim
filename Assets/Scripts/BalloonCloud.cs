using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class BalloonCloud : MonoBehaviour
{
    private float speed = 1;
    private float width;
    private Vector3 screenPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.75f, 1.25f);
        width = GetComponent<SpriteRenderer>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector2(13, transform.position.y);
    }
}
