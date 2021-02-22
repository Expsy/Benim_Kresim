using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    
    public float gridXSize;
    public float gridYSize;
    
    public List<Card> prefabList = new List<Card>();
    public List<Vector2> cardPositions = new List<Vector2>();

    public int currentCardCount;

    public Card selectedCard1;
    public Card selectedCard2;

    public static CardManager instance;
    public GameObject cardParent;

    public GameObject statScreen;

    #region Stats

        

    #endregion

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
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePositions();
        InstantiateCards();
        StatScreenCheck();
        

    }

    private void Update()
    {
        
    }

    private void StatScreenCheck()
    {
        currentCardCount = cardParent.transform.childCount;
        if (currentCardCount <= 1)
        {
            statScreen.SetActive(true);
        }
    }

    void InstantiateCards()
    {
        
        Vector3 cameraPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        Vector3 instantiatePos = new Vector3(cameraPos.x, cameraPos.y, 0);

        foreach (Card card in prefabList)
        {
            for (int i = 0; i < 2; i++)
            {
                Card newCard = Instantiate(card, instantiatePos, Quaternion.identity, cardParent.transform);
                int randomPos = Random.Range(0, cardPositions.Count);
                newCard.TakePosition(cardPositions[randomPos]);
                cardPositions.RemoveAt(randomPos);
            }
        }
    }

    private void LateUpdate()
    {
        StatScreenCheck();

    }

    void CreatePositions()
    {
        for (int i = 1; i < gridXSize+1; i++)
        {
            for (int j = 1; j < gridYSize+1; j++)
            {
                cardPositions.Add(new Vector2(i, j));
            }
        }
    }

    public void cardSelect(Card card)
    {
        if (selectedCard1 == null)
        {
            selectedCard1 = card;
        }
        else if (selectedCard1 !=null && selectedCard2 == null)
        {
            selectedCard2 = card;
            cardCheck();
        }
        else if (selectedCard1 != null && selectedCard2 != null)
        {
            CancelInvoke(nameof(RemoveCards));
            ResetCards();
            cardSelect(card);
        }
    }

    public void cardCheck()
    {
        if (selectedCard1.cardID == selectedCard2.cardID)
        {
            // selectedCard1.gameObject.SetActive(false);
            // selectedCard2.gameObject.SetActive(false);
            Destroy(selectedCard1.gameObject);
            Destroy(selectedCard2.gameObject);
            RemoveCards();

        }
        else
        {
            selectedCard1.DelayedTurnCard();
            selectedCard2.DelayedTurnCard();
            Invoke(nameof(RemoveCards), 2);
        }
        
        StatScreenCheck();

    }

    public void ResetCards()
    {
        selectedCard1.CancelDelayedTurnCard();
        selectedCard2.CancelDelayedTurnCard(); 

        selectedCard1.TurnCardDown();
        selectedCard2.TurnCardDown();
        
        RemoveCards();
    }

    public void RemoveCards()
    {
        selectedCard1 = null;
        selectedCard2 = null;
    }
}
