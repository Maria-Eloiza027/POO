namespace POO;

public class Gato : Animal
{
    public Gato(string nome, int idade) : base(nome, idade)
    {
    }

    public override void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez MiauMiau");
    }
}