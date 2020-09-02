class EmptyUndoStackException : BaseException
{
    /// <summary>
    /// Default constructor for empty undo stack exception
    /// </summary>
    public EmptyUndoStackException() : base($"Undo Stack is empty") { }


    /// <summary>
    /// Constructor for empty undo stack exception
    /// </summary>
    /// <param name="error">exception message</param>
    public EmptyUndoStackException(string error) : base(error) { }

}
