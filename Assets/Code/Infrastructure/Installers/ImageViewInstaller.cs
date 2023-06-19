using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ImageViewInstaller : MonoInstaller
    {
        [SerializeField] private ImageHolder _imageHolder;
        public override void InstallBindings()
        {
            BindImageHolder();
        }

        private void BindImageHolder()
        {
            Container
                .Bind<IImageHolder>()
                .FromInstance(_imageHolder)
                .AsSingle();
        }
    }
}