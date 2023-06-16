using System;
using System.Collections;
using Code.Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Code.UI
{
    public class ImageDownloader
    {
        private int _currentImage = 1;
        private IImageURLBuilder _urlBuilder;
        private ICoroutineRunner _coroutineRunner;

        public ImageDownloader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _urlBuilder = new ImageURLBuilder();
        }
        
        public void GetNextImage(Action<Sprite> resultCallback)
        {
            _coroutineRunner.StartCoroutine(GetTexture(resultCallback));
        }
        

        private IEnumerator GetTexture(Action<Sprite> resultCallback)
        {
            string url = _urlBuilder.GetURLForImageNumber(_currentImage++);

            using (UnityWebRequest getTextureRequest = UnityWebRequestTexture.GetTexture(url))
            {
                yield return getTextureRequest.SendWebRequest();

                if (getTextureRequest.result != UnityWebRequest.Result.Success)
                {
                    resultCallback.Invoke(null);
                    yield break;
                }

                Texture2D texture = DownloadHandlerTexture.GetContent(getTextureRequest);

                Vector2 spriteSize = new Vector2(texture.width, texture.height);

                Sprite sprite = Sprite.Create(texture
                    , rect: new Rect(Vector2.zero, spriteSize)
                    , pivot: new Vector2(0.5f, 0.5f));

                resultCallback.Invoke(sprite);
            }
        } 


    }
}