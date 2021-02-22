using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class KidBehaviour : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private static readonly int SneezeBegin = Animator.StringToHash("SneezeBegin");
    private bool goingBathroom = false;
    public GameObject popUp;
    public GameObject door;
    private Vector2 initialPos;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EventCheck", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sneeze();
        }
    }

    public void EventCheck()
    {
        if (!goingBathroom)
        {
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                Sneeze();
            }
        }
    }

    private void OnMouseDown()
    {
        popUp.SetActive(true);
    }

    void Sneeze()
    {
        _animator.SetTrigger(SneezeBegin);
        _audioSource.Play();
    }

    public void GoBathroom()
    {
        StartCoroutine(GoBathroomCoroutine());
    }

    IEnumerator GoBathroomCoroutine()
    {
        goingBathroom = true;
        float time = 0;
        float duration = 2;
        initialPos = transform.position;
        Vector2 doorPos = new Vector2(door.transform.position.x, transform.position.y);
        while (time < duration)
        {
            transform.position = Vector2.Lerp(initialPos, doorPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        GetComponent<SpriteRenderer>().enabled = false;
        Invoke("ComeBackFromBathroom", 2);
    }

    void ComeBackFromBathroom()
    {
        StartCoroutine(ComeBackFromBathroomCoroutine());
    }

    IEnumerator ComeBackFromBathroomCoroutine()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        float time = 0;
        float duration = 2;
        Vector2 doorPos = new Vector2(door.transform.position.x, transform.position.y);
        while (time < duration)
        {
            transform.position = Vector2.Lerp(doorPos, initialPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        goingBathroom = false;
    }
}
