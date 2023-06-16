namespace Code.UI
{
    public class ImageURLBuilder : IImageURLBuilder
    {
        private readonly string _imagesServerURL = @"http://data.ikppbb.com/test-task-unity-data/pics";
        
        public string GetURLForImageNumber(int number)
            => $"{_imagesServerURL}//{number}.jpg";

    }
}