using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace Chess.ViewModels;

public abstract class Figure: ReactiveObject
{
    public Figure(int x, int y, int tileSize, string pathToSprite)
    {
        X = x;
        Y= y;
        XCanvasCoordinate = x * tileSize + tileSize / 4;
        YCanvasCoordinate = y * tileSize + tileSize / 4;
        PathToSprite = new Bitmap(
            AssetLoader.Open(new Uri(pathToSprite)));
        
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
    
    
    private int _xCanvasCoordinate = 0;
    public int XCanvasCoordinate
    {
        get
        {
            return _xCanvasCoordinate;
        }
        private set
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
        private set
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
        private set
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
        private set
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

    public abstract bool CheckMove(int newX, int newY);
    
    public void PrintCoords()
    {
        Console.WriteLine($"X: {X}, Y: {Y}  normal:  X: {(X - ChessBoardViewModel.TileSize / 4) / ChessBoardViewModel.TileSize}  Y: {(Y - ChessBoardViewModel.TileSize / 4) / ChessBoardViewModel.TileSize}");
    }
}