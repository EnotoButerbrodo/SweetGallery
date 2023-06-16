using UnityEngine;

namespace Code.UI.Gallery
{
    public class ImageHolderFactory : MonoBehaviour, IImageHolderFactory
    {
        [SerializeField] private ImageHolder _holderPrefab;

        public IImageHolder Get()
        {
           var holder =  Instantiate(_holderPrefab);
           return holder;
        }
            
    }
}