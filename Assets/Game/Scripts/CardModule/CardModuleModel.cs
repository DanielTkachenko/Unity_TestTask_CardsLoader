using System;
using UnityEngine;

namespace Game.CardModule
{
    [Serializable]
    public class CardModuleModel
    {
        [Range(3, 6)] public int CardsNumber = 3;
        public string PicturesURL;
    }
}