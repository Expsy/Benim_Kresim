using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public List<GameObject> hands;
    private int positionIncrement = 27;
    private Vector2 firstHandLocation = Vector2.zero;
    private Vector2 HandLocation;
    public GameObject handParent;
    public int nailCount = 0;

    private void Awake()
    {
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        KidManager.kidManager.PutKidsInOrder();
        InstantiateHands();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CheckIfCleaned()
    {
        if (KidManager.kidManager.currentKid.myKid.dirtyNailCount <= 0)
        {
            KidManager.kidManager.currentKid.myKid.dirty = false;
        }
    }

    void InstantiateHands()
    {
        HandLocation = firstHandLocation;
        foreach (KidObject kid in KidManager.kidManager.kidList)
        {
            int i = Random.Range(0, 2);

            if (i == 0)
            {
                kid.myKid.dirty = false;
                InstantiateCleanHand();
            }
            else if (i == 1)
            {
                kid.myKid.dirty = true;
                kid.myKid.dirtyNailCount = 10;
                InstantiateDirtyHand();
            }

            HandLocation -= new Vector2(positionIncrement, 0);
        }
    }

    private void InstantiateDirtyHand()
    {
        Instantiate(hands[1], HandLocation, Quaternion.identity, handParent.transform);
    }

    private void InstantiateCleanHand()
    {
        Instantiate(hands[0], HandLocation, Quaternion.identity, handParent.transform);
    }
    
    
    IEnumerator MoveHandsCoroutine(){

        float time = 0;
        float duration = 1;
        Vector3 firstPos = handParent.transform.position;
        Vector3 nextPos = firstPos + new Vector3(27, 0, 0);
        while (time < duration)
        {
            handParent.transform.position = Vector3.Lerp(firstPos, nextPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public void MoveHands()
    {
        if (!KidManager.kidManager.IsItLastKid())
        {
            StartCoroutine(MoveHandsCoroutine());
        }
    }
    
}