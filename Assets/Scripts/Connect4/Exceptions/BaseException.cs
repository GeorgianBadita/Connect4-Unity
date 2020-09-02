using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseException : Exception
{
    /// <summary>
    /// Default constructor
    /// </summary>
    public BaseException() { }

    /// <summary>
    /// Constructor for base exception
    /// </summary>
    /// <param name="error"></param>
    public BaseException(string error): base(error) { }
}
