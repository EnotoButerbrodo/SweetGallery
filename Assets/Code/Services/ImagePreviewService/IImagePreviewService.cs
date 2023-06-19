using UnityEngine;

namespace Code.Services.ImagePreviewService
{
    public interface IImagePreviewService
    {
        Sprite ImageToPreview { get; set; }
    }
}