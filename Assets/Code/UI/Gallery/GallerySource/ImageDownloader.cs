using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Code.Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Code.UI
{
    public class ImageDownloader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private Dictionary<string, Coroutine> _loadingOperations = new(); 
        
        public ImageDownloader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void TryGetImage(string url, ImageDownloadResult resultCallback)
        {
            var loadOperation = _coroutineRunner.StartCoroutine(GetTexture(url, resultCallback));
            _loadingOperations.Add(url, loadOperation);
        }

        public void CancelDownloads()
        {
            foreach (var loadingOperation in _loadingOperations)
            {
                _coroutineRunner.StopCoroutine(loadingOperation.Value);
            }
        }
        
        private IEnumerator GetTexture(string url, ImageDownloadResult resultCallback)
        {
            using (UnityWebRequest getTextureRequest = UnityWebRequestTexture.GetTexture(url))
            {
                yield return getTextureRequest.SendWebRequest();

                if (getTextureRequest.result != UnityWebRequest.Result.Success)
                {
                    resultCallback.Invoke(false, url, null);
                    yield break;
                }

                Texture2D texture = DownloadHandlerTexture.GetContent(getTextureRequest);

                Vector2 spriteSize = new Vector2(texture.width, texture.height);
                Sprite sprite = Sprite.Create(texture
                    , rect: new Rect(Vector2.zero, spriteSize)
                    , pivot: new Vector2(0.5f, 0.5f));

                _loadingOperations.Remove(url);
                
                resultCallback.Invoke(true, url, sprite);
            }
        } 


    }
}