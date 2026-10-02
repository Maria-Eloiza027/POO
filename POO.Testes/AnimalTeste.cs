using Microsoft.Extensions.DependencyModel;

namespace POO.Testes;

[TestClass]
[DoNotParallelize]
public sealed class AnimalTeste
{
    private StringWriter _consoleOutput;
    private TextWriter _originalOutput;
    
    [TestInitialize]
    public void Setup() // setup significa configurar 
    {
        _consoleOutput = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_consoleOutput);
    }

    [TestCleanup]
    public void Cleanup() // que significa limpar
    {
        Console.SetOut(_originalOutput);
        _consoleOutput.Dispose();
    }
    
    
    [TestMethod]
    public void DeveRetornarObjetoCachorro_QuandoNomeEIdadeEstaoCorretos()
    {
        //Arrange
        string nomeEsperada = "Mabel";
        int idadeEsperada = 8;
        
        //Act
        var animal = new Cachorro(nomeEsperada, idadeEsperada);
        
        //Assert
        Assert.AreEqual(nomeEsperada, animal.Nome);
        Assert.AreEqual(idadeEsperada, animal.Idade);
    }
    [TestMethod]
    public void QuandoInvocadoComer_DeveEscreverMensagemPadraoNoConsole()
    {
        // valor atual: _consoleOutput.ToString();
        
        //Arrange - arranjo
        string nome = "Mabel";
        var animal = new Cachorro(nome, 8);
        string mensagemEsperada = ($"{nome} está comendo!{Environment.NewLine}");
        
        //Act - ação
        animal.Comer();
        
        //Assert - afirmação
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaCachorro_DeveFazerAuAu()
    {
        //Arrange
        string nome = "Mabel";
        var animal = new Cachorro(nome, 8);
        string mensagemEsperada = ($"{nome} fez AuAu{Environment.NewLine}");
        
        //Act
        animal.FazerBarulho();
        
        //Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }
    
    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaGato_DeveFazerMiauMiau()
    {
        //Arrange
        string nome = "Mimoso";
        var animal = new Gato(nome, 5);
        string mensagemEsperada = ($"{nome} fez MiauMiau{Environment.NewLine}");
        
        //Act
        animal.FazerBarulho();
        
        //Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaVaca_DeveFazerMuuuu()
    {
        //Arrange
        string nome = "Estrelinha";
        var animal = new Vaca(nome, 3);
        string mensagemEsperada = ($"{nome} fez Muuuu{Environment.NewLine}");
        
        //Act
        animal.FazerBarulho();
        
        //Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }
    
    //Unhappy Tests

    [TestMethod]
    public void QuandoInstanciarComNomeVazio_Sempre_DeveLancarArgumentException()
    {
        // Arrange
        string nomeAnimal = " ";
        
        
        //Act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 12));
        Assert.Contains("O nome não pode estar vazio ou nulo!", excecao.Message);
    }

    [TestMethod]
    public void QuandoInstaciarComNomeNulo_SempreDeveLancarArgumentException()
    {
        // Arrange
        string nomeAnimal = null;


        //Act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 12));
        Assert.Contains("O nome não pode estar vazio ou nulo!", excecao.Message);


    }

    [TestMethod]
    public void QuandoInstanciarComIdadeNegativa_Sempre_DeveLancarArgumentException()
    {
        //Arrange
        int idade = -1;

        //Act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro("Mel", idade));
        Assert.Contains("A idade não pode ser negativa!", excecao.Message);
    }
}