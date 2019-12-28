using System;

namespace ElementsTree
{
    /// <summary>
    /// Представляет ошибки, возникающие во время работы с деревьями.
    /// </summary>
    public class TreeException : Exception
    {
        public TreeException(string message) : base(message) { }
    }
}
