using System;
using UnityEngine;

namespace Game.Card
{
    [Serializable]
    public class CardAnimationModel
    {
        [Range(0, 5)] public float FlipAnimationDuration = 1f;
    }
}