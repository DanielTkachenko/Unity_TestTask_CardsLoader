using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.CardModule.Abstract
{
    public interface ICardsFlipHandler
    {
        public Action OnCardsFlipFinished { get; }
        UniTaskVoid Flip(IEnumerable<CardView> list, string url);
    }
}