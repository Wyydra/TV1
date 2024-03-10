using MorpionApp;

namespace MorpionAppTest;

public class Morpion_verifVictoire{
  [Fact]
  public void VerifVictoire_FullRow_ReturnTrue()
  {
    char[,] grid = {
        {'X', 'X', 'X'},
        {'O', 'O', ' '},
        {' ', ' ', ' '}
    };

    var morpion = new Morpion();
    morpion.grille = grid;
    bool result = morpion.verifVictoire('X');

    Assert.True(result);
  }
  [Fact]
  public void VerifVictoire_FulColl_ReturnTrue()
  {
    char[,] grid = {
        {'X', 'O', ' '},
        {'X', 'O', ' '},
        {'X', ' ', ' '}
    };

    var morpion = new Morpion();
    morpion.grille = grid;
    bool result = morpion.verifVictoire('X');

    Assert.True(result);
  }
  [Fact]
  public void VerifVictoire_FullDiag_ReturnTrue()
  {
    char[,] grid = {
        {'X', 'O', ' '},
        {'O', 'X', ' '},
        {' ', ' ', 'X'}
    };

    var morpion = new Morpion();
    morpion.grille = grid;
    bool result = morpion.verifVictoire('X');

    Assert.True(result);
  }
  [Fact]
  public void VerifVictoire_NoFull_ReturnFalse()
  {
    char[,] grid = {
        {'X', 'O', ' '},
        {'O', 'X', ' '},
        {' ', ' ', 'O'}
    };

    var morpion = new Morpion();
    morpion.grille = grid;
    bool result = morpion.verifVictoire('X');

    Assert.False(result);
  }
  [Fact]
  public void VerifVictoire_GridEmpty_ReturnFalse()
  {
    char[,] emptyGrid = {
        {' ', ' ', ' '},
        {' ', ' ', ' '},
        {' ', ' ', ' '}
    };

    var morpion = new Morpion();
    morpion.grille = emptyGrid;
    bool result = morpion.verifVictoire('X');

    Assert.False(result);
  }
  [Fact]
  public void VerifVictoire_GridFull_ReturnFalse()
  {
    char[,] fullGrid = {
        {'X', 'O', 'X'},
        {'O', 'X', 'O'},
        {'X', 'O', 'X'}
    };

    var morpion = new Morpion();
    morpion.grille = fullGrid;
    bool result = morpion.verifVictoire('X');

    Assert.False(result);
  }
}

public class Morpion_verifEgalite
{
    [Fact]
    public void VerifEgalite_GridFull_ReturnTrue()
    {
        char[,] fullGrid = {
            {'X', 'O', 'X'},
            {'O', 'X', 'O'},
            {'X', 'O', 'X'}
        };

        var morpion = new Morpion();
        morpion.grille = fullGrid;
        bool result = morpion.verifEgalite();

        Assert.True(result);
    }

    [Fact]
    public void VerifEgalite_PartiallyFull_ReturnFalse()
    {
        char[,] notFullGrid = {
            {'X', 'O', ' '},
            {' ', 'X', 'O'},
            {'X', 'O', 'X'}
        };

        var morpion = new Morpion();
        morpion.grille = notFullGrid;
        bool result = morpion.verifEgalite();

        Assert.False(result);
    }

    [Fact]
    public void VerifEgalite_GridEmpty_ReturnFalse()
    {
        // Arrange
        char[,] emptyGrid = {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };

        // Act
        var morpion = new Morpion();
        morpion.grille = emptyGrid;
        bool result = morpion.verifEgalite();

        // Assert
        Assert.False(result);
    }



    // Ajoutez d'autres tests pour d'autres scénarios pertinents ici...
}
