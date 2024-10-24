using System.ComponentModel.DataAnnotations;

public class Rectangle : Shape
{
    private double _length;
    private double _width;
    
    public Rectangle(string color, double length, double width) : base (color)
    {
        _length = length;
        _width = width;
    }

    // Observe o uso da palavra-chave override aqui.
    public override double GetArea()
    {
        return _length * _width;
    }
}