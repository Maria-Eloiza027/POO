namespace POO;

public class Cachorro : Animal
{
    public Cachorro(string nome, int idade) : base(nome, idade)
    {
    }

    public override void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez AuAu");
    }
    
}