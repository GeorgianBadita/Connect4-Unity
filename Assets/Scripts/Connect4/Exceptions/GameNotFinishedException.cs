class GameNotFinishedException : BaseException
{
    /// <summary>
    /// Default constructor for column game not finished exception
    /// </summary>
    public GameNotFinishedException() : base($"Game is not finished!") { }


    /// <summary>
    /// Constructor for game not finished exception
    /// </summary>
    /// <param name="error">exception message</param>
    public GameNotFinishedException(string error) : base(error) { }

}

