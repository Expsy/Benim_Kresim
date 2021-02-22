using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{

    public CardScriptableObject cardTemplate;
    private SpriteRenderer myToyImage;
    private Card myCard;
    private SpriteRenderer spriteRenderer;
    private CardManager cardManager;

    public Sprite[] sprites;
    public int cardID;

    public bool faceUp = false;
    public bool clickable = true;


    private void Awake()
    {
        cardManager = CardManager.instance;
        myCard = GetComponent<Card>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cardID = cardTemplate.cardID;
        myToyImage = transform.GetChild(0).GetComponent<SpriteRenderer>();
        myToyImage.sprite = cardTemplate.cardFrontSprite;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (faceUp)
        {
            spriteRenderer.sprite = sprites[0];
            myToyImage.enabled = true;
            clickable = false;
        }
        else
        {
            spriteRenderer.sprite = sprites[1];
            myToyImage.enabled = false;
            clickable = true;
        }
    }

    public void TakePosition(Vector2 gridPos)
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector2((1/(cardManager.gridXSize+1)) * gridPos.x , (1/(cardManager.gridYSize+1))* gridPos.y));
        Vector3 posToMove = new Vector3(pos.x, pos.y, 0);
        transform.DOMove(posToMove, 2, false);
    }

    private void OnMouseDown()
    {
        if (clickable)
        {
            TurnCardUp();
            cardManager.cardSelect(myCard);
        }
    }

    public void TurnCardUp()
    {
        faceUp = true;
    }
    
    public void TurnCardDown()
    {
        faceUp = false;
    }

    public void DelayedTurnCard()
    {
        Invoke(nameof(TurnCardDown), 2);
    }

    public void CancelDelayedTurnCard()
    {
        CancelInvoke(nameof(DelayedTurnCard));
    }
}
