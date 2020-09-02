class InvalidColumnException: BaseException
{
    /// <summary>
    /// Default constructor for invalid column exception
    /// </summary>
    public InvalidColumnException(): base($"Column must be a number between {0} and {BoardUtils.NUM_COLS-1}") { }


    /// <summary>
    /// Constructor for invalid column exception
    /// </summary>
    /// <param name="error">exception message</param>
    public InvalidColumnException(string error) : base(error) { }

}

