namespace POO;

class Program
{
    static void Main(string[] args)
    {
        //criar arrays

        Animal[] animais =
        [

            new Cachorro("Mabel", 8),

            new Gato("Mimoso", 5),

            new Vaca("Estrelinha", 3)

        ];

        foreach (Animal animalAtual in animais)
        {

            animalAtual.Comer();
            animalAtual.FazerBarulho();

        }
    }
}