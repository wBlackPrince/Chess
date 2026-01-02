using System;

namespace Chess.ViewModels;

public class Pawn: Figure
{
    public const string SpritePath = "avares://Chess/Assets/images/pawn_white.png";
    
    public Pawn(int x, int y, int tileSize) : base(x, y, tileSize, SpritePath)
    {
    }

    public override bool CheckMove(int newX, int newY)
    {
        return ((Y - 1) == newY && ((X - 1) == newX || (X + 1) == newX || X == newX));
    }
}