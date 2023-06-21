using System;
using UnityEngine;

namespace Code.Services
{
    public interface IInputService
    {
        public event Action BackButtonPressed;

        public void Enable();
        public void Disable();
    }
}