using System;
using UnityEngine;

namespace Code.UI
{
    public interface IImageHolder
    {
        public event Action<IImageHolder> Selected;
        public void Deselect();
        public void SetImage(Sprite sprite);
        public Sprite GetImage();
        public void SetParent(Transform parent);
    }
}