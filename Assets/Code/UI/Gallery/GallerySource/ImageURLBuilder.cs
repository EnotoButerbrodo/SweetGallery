namespace Code.UI
{
    public class ImageURLBuilder : IImageURLBuilder
    {
        private readonly string _imagesServerURL;

        public ImageURLBuilder(string imagesServerURL)
        {
            _imagesServerURL = imagesServerURL;
        }

        public string GetURLForImageNumber(int number)
            => $"{_imagesServerURL}//{number}.jpg";

    }
}