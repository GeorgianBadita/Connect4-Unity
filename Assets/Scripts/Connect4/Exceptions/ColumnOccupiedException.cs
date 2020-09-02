class ColumnOccupiedException : BaseException
{
    /// <summary>
    /// Default constructor for column occupied exception
    /// </summary>
    public ColumnOccupiedException() : base($"Column is already full") { }


    /// <summary>
    /// Constructor for column occupied exception
    /// </summary>
    /// <param name="error">exception message</param>
    public ColumnOccupiedException(string error) : base(error) { }

}

