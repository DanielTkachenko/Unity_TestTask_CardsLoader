using System;
using UnityEngine;

namespace Game.Card
{
    [CreateAssetMenu(fileName = "CardConfig", menuName = "Configs/CardConfig")]
    public class CardConfig : ScriptableObject
    {
        public CardModel Model => model;
        
        [SerializeField] private CardModel model;
    }
    
    [Serializable]
    public class CardModel
    {
        [Range(0, 10)]public float Scale = 1;
    }
}