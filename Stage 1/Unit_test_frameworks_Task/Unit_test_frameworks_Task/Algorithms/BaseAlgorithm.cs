using System;

public abstract class BaseAlgorithm
{
    protected char[] _input;

    public BaseAlgorithm(string input)
    {
        _input = input.ToCharArray();
    }

    public virtual string Execute()
    {
        throw new NotImplementedException();
    }

    public virtual bool AreEqual(char symbol1, char symbol2)
    {
        throw new NotImplementedException();
    }
}