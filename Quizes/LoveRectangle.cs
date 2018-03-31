namespace MainDSA.Quizes
{
    public class LoveRectangle
    {
        // Coordinates of bottom left corner
        public int LeftX { get; set; }
        public int BottomY { get; set; }

        // Dimensions
        public int Width { get; set; }
        public int Height { get; set; }

        public LoveRectangle() { }

        public LoveRectangle(int leftX, int bottomY, int width, int height)
        {
            LeftX = leftX;
            BottomY = bottomY;
            Width = width;
            Height = height;
        }
    }
}
