using System;
using UnityEngine;

namespace Game.CardModule
{
    [CreateAssetMenu(fileName = "CardModuleConfig", menuName = "Configs/CardModuleConfig")]
    public class CardModuleConfig : ScriptableObject
    {
        [Range(3, 6)] public int CardsNumber;
    }
}