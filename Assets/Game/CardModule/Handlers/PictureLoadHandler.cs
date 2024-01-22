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
        private const string URL = "https://picsum.photos/";
        private const int size = 50;
        private string currentUrl;

        public PictureLoadHandler()
        {
            currentUrl = $"{URL}/{size}";
        }

        public async UniTask<Texture2D> DownloadPictureAsync()
        {
            using var request = UnityWebRequestTexture.GetTexture(currentUrl);

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