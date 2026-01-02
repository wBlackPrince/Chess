using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace Chess.ViewModels;

public class Pawn: ReactiveObject, IFigure
{
    public Pawn(int x, int y, int tileSize)
    {
        X = x;
        Y= y;
        XCanvasCoordinate = x * tileSize + tileSize / 4;
        YCanvasCoordinate = y * tileSize + tileSize / 4;
        PathToSprite = new Bitmap(
            AssetLoader.Open(new Uri(
                "avares://Chess/Assets/images/pawn_white.png"
            )));
        
        this
            .WhenAnyValue(p => p.IsVisible)
            .Subscribe(p => this.RaisePropertyChanged(nameof(IsVisible)));
        
        this
            .WhenAnyValue(p => p.X)
            .Subscribe(p => this.RaisePropertyChanged(nameof(X)));
        
        this
            .WhenAnyValue(p => p.Y)
            .Subscribe(p => this.RaisePropertyChanged(nameof(Y)));
        
        this
            .WhenAnyValue(p => p.PathToSprite)
            .Subscribe(p => this.RaisePropertyChanged(nameof(PathToSprite)));
    }


    public bool CheckMove(int newX, int newY)
    {
        bool a = (Y - 1) == newY;
        Console.WriteLine($"a: {a}");
        bool b = ((X - 1) == newX || (X + 1) == newX || X == newX);
        Console.WriteLine($"b: {b}");

        return ((Y - 1) == newY && ((X - 1) == newX || (X + 1) == newX || X == newX));
    }
    
    
    
    private int _xCanvasCoordinate = 0;
    public int XCanvasCoordinate
    {
        get
        {
            return _xCanvasCoordinate;
        }
        set
        {
            _xCanvasCoordinate = value;
            this.RaiseAndSetIfChanged(ref _xCanvasCoordinate, value);
        }
    }
    
    
    private int _yCanvasCoordinate = 0;
    public int YCanvasCoordinate
    {
        get
        {
            return _yCanvasCoordinate;
        }
        set
        {
            _yCanvasCoordinate = value;
            this.RaiseAndSetIfChanged(ref _yCanvasCoordinate, value);
        }
    }
    
    
    
    private int _x = 0;
    public int X
    {
        get
        {
            return _x;
        }
        set
        {
            _x = value;
            this.RaiseAndSetIfChanged(ref _x, value);
        }
    }

    
    private int _y = 0;
    public int Y
    {
        get
        {
            return _y;
        }
        set
        {
            _y = value;
            this.RaiseAndSetIfChanged(ref _y, value);
        }
    }


    private bool _isVisible = true;
    public bool IsVisible
    {
        get
        {
            return _isVisible;
        }
        set
        {
            _isVisible = value;
            this.RaiseAndSetIfChanged(ref _isVisible, value);
        }
    }
    
    
    private Bitmap _pathToSprite;

    public Bitmap PathToSprite
    {
        get
        {
            return _pathToSprite;
        }
        set
        {
            _pathToSprite = value;
            this.RaiseAndSetIfChanged(ref _pathToSprite, value);
        }
    }

    public void PrintCoords()
    {
        Console.WriteLine($"X: {X}, Y: {Y}  normal:  X: {(X - ChessBoardViewModel.TileSize / 4) / ChessBoardViewModel.TileSize}  Y: {(Y - ChessBoardViewModel.TileSize / 4) / ChessBoardViewModel.TileSize}");
    }
}