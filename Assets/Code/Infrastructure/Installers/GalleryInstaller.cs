using Code.UI.Gallery;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GalleryInstaller : MonoInstaller
    {
        [SerializeField] private ImageHolderFactory _factory;
        public override void InstallBindings()
        {
            BindImageHoldersFactory();
        }

        private void BindImageHoldersFactory()
        {
            Container
                .Bind<IImageHolderFactory>()
                .To<ImageHolderFactory>()
                .FromComponentsInNewPrefab(_factory)
                .AsSingle();

        }
    }
}