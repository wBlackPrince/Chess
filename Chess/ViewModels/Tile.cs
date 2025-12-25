using Avalonia.Media;

namespace Chess.ViewModels;

public class Tile
{
    public int X { get; set; }
    
    public int Y { get; set; }
    
    public Brush Color { get; set; }
    
    public int Size { get; set; }


    public Tile(Brush color, int x, int y, int size)
    {
        Color = color;
        X = x;
        Y = y;
        Size = size;
    }
}