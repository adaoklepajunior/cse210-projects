public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    //Porque não faz sentido definir um corpo padrão para este método na
    //classe base, em vez de fazer uma função "virtual" aqui assim:
    //
    // public virtual double GetArea()
    // {
    //    return 0;
    // }
    //
    // Em vez disso, podemos declarar a função como uma função "abstrata". Isso significa
    // que é uma função virtual vazia que deve ser implementada ou "preenchida" por
    // qualquer classe que herda de Shape. Então, qualquer classe que possua um método abstrato
    // também deve ser declarado como abstrato.

    public abstract double GetArea();
}