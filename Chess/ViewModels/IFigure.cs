using Avalonia.Media.Imaging;

namespace Chess.ViewModels;

public interface IFigure
{
    public bool IsVisible { get; set; }
    
    public Bitmap PathToSprite { get; set; }
    
    public int XCanvasCoordinate { get; set; }
    
    public int YCanvasCoordinate { get; set; }
    
    public int X { get; set; }
    
    public int Y { get; set; }

    public void PrintCoords();

    public bool CheckMove(int newX, int newY);
}