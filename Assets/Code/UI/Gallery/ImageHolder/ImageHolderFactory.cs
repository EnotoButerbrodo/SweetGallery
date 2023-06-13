using UnityEngine;

namespace Code.UI.Gallery
{
    public class ImageHolderFactory : MonoBehaviour, IImageHolderFactory
    {
        [SerializeField] private ImageHolder _holderPrefab;
        [SerializeField] private Transform _content;

        public IImageHolder Get()
        {
           var holder =  Object.Instantiate(_holderPrefab);
           holder.SetParent(_content);
           
           return holder;
        }
            
    }
}