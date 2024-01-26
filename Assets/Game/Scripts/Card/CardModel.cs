using System;
using UnityEngine;

namespace Game.Card
{
    [Serializable]
    public class CardModel
    {
        [Range(0, 10)]public float Scale = 1;
    }
}