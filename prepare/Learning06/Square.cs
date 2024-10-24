public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base (color)
    {
        _side = side;
    }

    // Observe o uso da palavra-chave override (substituir) aqui

    public override double GetArea()
    {
        return _side * _side;
    }
}