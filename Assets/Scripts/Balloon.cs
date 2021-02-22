using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class Balloon : MonoBehaviour
{
    private float lifeTime;
    private BalloonManager balloonManager;
    private Animator animator;
    private List<float> speedVariants = new List<float>(){1.6f, 1.8f,  2f,  2.2f,  2.4f};

    private float speed;
    private float maxLifetime;
    private float reflexPoint;


    private float initializationTime;
    // Start is called before the first frame update
    void Start()
    {
        InitializeFields();
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = balloonManager.balloonColors[Random.Range(0, balloonManager.balloonColors.Count)];
    }

    private void InitializeFields()
    {
        balloonManager = BalloonManager.instance;
        initializationTime = Time.realtimeSinceStartup;
        animator = GetComponent<Animator>();
        speed = speedVariants[Random.Range(0, speedVariants.Count)];

        switch (speed)
        {
            case 1.6f:
                maxLifetime = 7.29f;
                break;
            case 1.8f:
                maxLifetime = 6.49f;
                break;
            case 2f:
                maxLifetime = 5.83f;
                break;
            case 2.2f:
                maxLifetime = 5.31f;
                break;
            case 2.4f:
                maxLifetime = 4.87f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    private void OnMouseDown()
    {
        balloonManager.GainPoint();
        balloonManager.poppedBalloonsCount += 1;
        Invoke(nameof(DisableCollider), 0.1f);
        animator.SetTrigger("Pop");

    }

    public void Death()
    {
        CalculateLifeTime();
        CalculateReflexPoint();
        Destroy(this.gameObject);
    }

    private void CalculateLifeTime()
    {
        lifeTime = Time.realtimeSinceStartup - initializationTime;
    }

    private void CalculateReflexPoint()
    {
        reflexPoint = Mathf.Abs(maxLifetime - lifeTime) / maxLifetime;
        balloonManager.reflexPointList.Add(reflexPoint);
    }

    void DisableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
