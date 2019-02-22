using System;

namespace Building_blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Block b = new Block(new int[] { 2, 2, 2 });
            Console.WriteLine(b.GetSurfaceArea());
            Console.ReadKey();
        }
    }

    class Block
    {
        static int Width { get; set; }
        static int Length { get; set; }
        static int Height { get; set; }

        public Block(int[] arguments) {
            Width = arguments[0];
            Length = arguments[1];
            Height = arguments[2];
        }

        public int GetWidth() { return Width; }
        public int GetLength() { return Length; }
        public int GetHeight() { return Height; }
        public int GetVolume() { return Width * Length * Height; }
        public int GetSurfaceArea() { return 2*(Width*Length + Length*Height + Height*Width); }
    }
}
