using System;

public class Fraction
{
    private int top;
    private int bottom;

    // Default constructor (1/1)
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    // Constructor with one parameter (numerator)
    public Fraction(int numerator)
    {
        top = numerator;
        bottom = 1;
    }

    // Constructor with two parameters (numerator and denominator)
    public Fraction(int numerator, int denominator)
    {
        top = numerator;
        bottom = denominator;
    }

    // Getters and Setters
    public int GetTop()
    {
        return top;
    }

    public void SetTop(int value)
    {
        top = value;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int value)
    {
        bottom = value;
    }

    // Method to return fraction as string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{top}/{bottom}";
    }

    // Method to return decimal value
    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
}
