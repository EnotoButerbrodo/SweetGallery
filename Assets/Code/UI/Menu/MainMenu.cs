using System;
using Code.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _galleryButton;

        [Inject] private Game _game;

        private void OnEnable()
        {
            _galleryButton.onClick.AddListener(OnGalleryButton);
        }

        private void OnDisable()
        {
            _galleryButton.onClick.RemoveListener(OnGalleryButton);
            
        }

        private void OnGalleryButton()
        {
            _game.StateMachine.Enter<GalleryMenuState>();
        }
    }
}