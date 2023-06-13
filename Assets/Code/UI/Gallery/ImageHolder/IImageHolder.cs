﻿using System;
using UnityEngine;

namespace Code.UI.Gallery
{
    public interface IImageHolder
    {
        public event Action<IImageHolder> Selected;
        public event Action<IImageHolder> Deselected;
        
        public void SetImage(Sprite sprite);
        public void SetParent(Transform parent);
    }
}