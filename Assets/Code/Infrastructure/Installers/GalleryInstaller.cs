using Code.Services;
using Code.UI;
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
            BindImageDownloader();
        }

        private void BindImageDownloader()
        {
            var imageDownloader = new ImageDownloader(Container.Resolve<ICoroutineRunner>());
            Container
                .Bind<ImageDownloader>()
                .FromInstance(imageDownloader)
                .AsSingle();
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