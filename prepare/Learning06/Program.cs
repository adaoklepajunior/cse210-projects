using System;

class Program
{
    static void Main(string[] args)
    {
        // Observe que a lista é uma lista de objetos "Shape". Isso significa que
        // você pode colocar qualquer objeto Shape lá e também qualquer objeto onde
        //a classe herda de Shape.

        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 5, 4);
        shapes.Add(s2);

        Circle s3 = new Circle("Grey", 10);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            // Observe que todas as formas possuem um método GetColor da classe base.
            string color = s.GetColor();

            // Observe que todas as formas possuem um método GetArea, mas o comportamento é
            // diferente para cada tipo de forma.
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}