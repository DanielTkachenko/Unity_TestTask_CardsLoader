using System;
using Cysharp.Threading.Tasks;
using Game.CardModule.Abstract;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.CardModule.Handlers
{
    public class PictureLoadHandler : IPictureLoadHandler
    {
        public Action<Texture2D> OnPictureLoadedEvent;

        public async UniTask<Texture2D> DownloadPictureAsync(string url)
        {
            using var request = UnityWebRequestTexture.GetTexture(url);

            try
            {
                await request.SendWebRequest();
            }
            catch (Exception e)
            {
                Debug.Log("Picture load failed");
            }
            
            var result = request.result == UnityWebRequest.Result.Success
                ? DownloadHandlerTexture.GetContent(request)
                : null;
            
            OnPictureLoadedEvent?.Invoke(result);

            return result;
        }
    }
}