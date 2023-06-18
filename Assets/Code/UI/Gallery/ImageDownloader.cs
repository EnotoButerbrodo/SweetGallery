using System;
using System.Collections;
using System.Net;
using Code.Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Code.UI
{
    public class ImageDownloader
    {
        private readonly IImageURLBuilder _urlBuilder;
        private readonly ICoroutineRunner _coroutineRunner;

        public ImageDownloader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _urlBuilder = new ImageURLBuilder();
        }

        public void TryGetImage(int imageNumber, ImageDownloadResult resultCallback)
        {
            _coroutineRunner.StartCoroutine(GetTexture(imageNumber, resultCallback));
        }
        
        private IEnumerator GetTexture(int imageNumber, ImageDownloadResult resultCallback)
        {
            string url = _urlBuilder.GetURLForImageNumber(imageNumber);

            using (UnityWebRequest getTextureRequest = UnityWebRequestTexture.GetTexture(url))
            {
                yield return getTextureRequest.SendWebRequest();

                if (getTextureRequest.result != UnityWebRequest.Result.Success)
                {
                    resultCallback.Invoke(false, imageNumber, null);
                    yield break;
                }

                Texture2D texture = DownloadHandlerTexture.GetContent(getTextureRequest);

                Vector2 spriteSize = new Vector2(texture.width, texture.height);
                Sprite sprite = Sprite.Create(texture
                    , rect: new Rect(Vector2.zero, spriteSize)
                    , pivot: new Vector2(0.5f, 0.5f));
                
                resultCallback.Invoke(true, imageNumber, sprite);
            }
        } 


    }
}