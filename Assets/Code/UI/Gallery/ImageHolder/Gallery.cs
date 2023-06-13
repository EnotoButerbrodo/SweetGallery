using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI.Gallery
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private int _startImagesCount = 4;
        [SerializeField] private ImageHolderFactory _factory;
        
        private List<IImageHolder> _holders = new List<IImageHolder>();

        private void Awake()
        {
            Debug.Log("Gallery");
            CreateStartHolders();
        }

        private void CreateStartHolders()
        {
            for (int i = 0; i < _startImagesCount; i++)
            {
                CreateImageHolder();
            }
        }

        private void CreateImageHolder()
        {
            var newHolder = _factory.Get();
            _holders.Add(newHolder);
        }
        
    }
}