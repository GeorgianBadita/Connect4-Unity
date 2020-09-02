using System;

public class EndGameCoordintaes
{

    private int startX;
    private int startY;
    private int stopX;
    private int stopY;

    /// <summary>
    /// End game coordinates constructor
    /// </summary>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="stopX"></param>
    /// <param name="stopY"></param>
    public EndGameCoordintaes(int startX, int stopX, int startY, int stopY)
    {
        this.startX = startX;
        this.startY = startY;
        this.stopX = stopX;
        this.stopY = stopY;
    }

    public int GetStartX()
    {
        return startX;
    }

    public int GetStartY()
    {
        return startY;
    }

    public int GetStopX()
    {
        return stopX;
    }

    public int GetStopY()
    {
        return stopY;
    }

    public override string ToString()
    {
        return startX + " " + stopX + " " + startY + " " + stopY;
    }
}