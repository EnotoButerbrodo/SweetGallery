using Code.Infrastructure;
using Code.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class GalleryUIControll : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [Inject] private IInputService _input;
        [Inject] private Game _game;

        private void OnEnable()
        {
            _input.BackButtonPressed += ReturnToGallery;
            _backButton.onClick.AddListener(ReturnToGallery);
        }

        private void OnDisable()
        {
            _input.BackButtonPressed -= ReturnToGallery;
            _backButton.onClick.RemoveListener(ReturnToGallery);
        }

        private void ReturnToGallery()
        {
            _game.StateMachine.Enter<GalleryState>();
        }
    }
}