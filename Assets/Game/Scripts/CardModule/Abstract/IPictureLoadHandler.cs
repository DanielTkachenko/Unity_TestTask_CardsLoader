using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.CardModule.Abstract
{
    public interface IPictureLoadHandler
    {
        UniTask<Texture2D> DownloadPictureAsync(string url);
    }
}