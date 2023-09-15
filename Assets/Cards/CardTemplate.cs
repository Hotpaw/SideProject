using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Card", order = 1)]
public class CardTemplate : ScriptableObject
{
    public string cardname;
    public string cardDescription;
    public Image cardImage;

    public CardData cardEffect;
}
