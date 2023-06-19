﻿namespace Code.Services.UIService
{
    public interface IUIFactory
    {
        public LoadingScreen GetLoadingScreen();
        public ImagePreviewScreen GetImagePreviewScreen();
    }
}