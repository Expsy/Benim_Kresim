using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Card", menuName = "ScriptableObjects/Card", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public Sprite cardFrontSprite;
    public int cardID;

}
