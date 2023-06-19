using UnityEngine;

namespace Code.Services.ImagePreviewService
{
    public class ImagePreviewService : IImagePreviewService
    {
       public Sprite ImageToPreview { get; set; }
    }
}