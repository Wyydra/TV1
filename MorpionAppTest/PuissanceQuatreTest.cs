using MorpionApp;

namespace MorpionAppTest;

public class PuissanceQuatre_verifVictoire
{
    [Fact]
    public void verifVictoire_Horizontal_ReturnsTrue()
    {
        char[,] grille = {
            { 'X', 'X', 'X', 'X', 'O', 'O', 'O' },
            { 'O', 'O', 'O', 'O', 'X', 'X', 'X' },
            { 'O', 'O', 'O', 'O', 'X', 'X', 'X' },
            { 'O', 'O', 'O', 'O', 'X', 'X', 'X' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        var result = pq.verifVictoire('X');

        Assert.True(result);
    }
    [Fact]
    public void verifVictoire_Vertical_ReturnsTrue()
    {
        char[,] grille = {
            { 'X', 'O', 'O', 'O', 'O', 'O', 'O' },
            { 'X', 'O', 'O', 'O', 'O', 'O', 'O' },
            { 'X', 'O', 'O', 'O', 'O', 'O', 'O' },
            { 'X', 'O', 'O', 'O', 'O', 'O', 'O' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        bool result = pq.verifVictoire('X');

        Assert.True(result);
    }
    [Fact]
    public void verifVictoire_Diagonal_ReturnsTrue()
    {
        char[,] grille = {
            { 'X', 'O', 'O', 'X', 'O', 'O', 'O' },
            { 'O', 'X', 'O', 'O', 'X', 'X', 'O' },
            { 'O', 'O', 'X', 'O', 'O', 'O', 'X' },
            { 'O', 'O', 'O', 'X', 'O', 'O', 'O' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        bool result = pq.verifVictoire('X');

        Assert.True(result);
    }
    [Fact]
    public void verifVictoire_DiagonalInverse_ReturnsTrue()
    {
        char[,] grille = {
            { 'O', 'O', 'O', 'X', 'O', 'O', 'O' },
            { 'O', 'O', 'X', 'O', 'O', 'X', 'O' },
            { 'O', 'X', 'X', 'O', 'X', 'O', 'O' },
            { 'X', 'O', 'O', 'O', 'X', 'O', 'X' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        bool result = pq.verifVictoire('X');

        Assert.True(result);
    }
    [Fact]
    public void verifVictoire_Equality_ReturnsFalse()
    {
        char[,] grille = {
            { 'O', 'O', 'O', 'X', 'O', 'O', 'X' },
            { 'O', 'O', 'X', 'O', 'X', 'O', 'O' },
            { 'O', 'O', 'X', 'O', 'O', 'X', 'O' },
            { 'X', 'O', 'O', 'O', 'X', 'O', 'O' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        bool result = pq.verifVictoire('X');

        Assert.False(result);
    }
    [Fact]
    public void verifVictoire_Empty_ReturnFalse()
    {
        char[,] grille = {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;
        
        bool result = pq.verifVictoire('X');
        
        Assert.False(result);
    }
}

public class PuissanceQuatre_verifEgalite
{
    [Fact]
    public void verifEgalite_ReturnsTrue()
    {
        char[,] grille = {
            { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
            { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
            { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
            { 'O', 'X', 'O', 'X', 'O', 'X', 'O' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        bool result = pq.verifEgalite();

        Assert.True(result);
    }
    [Fact]
    public void verifEgalite_Empty_ReturnsTrue()
    {
        char[,] grille = {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;
    
        bool result = pq.verifEgalite();
    
        Assert.True(result);
    }
    [Fact]
    public void verifEgalite_ReturnsFalse()
    {
        char[,] grille = {
            { 'X', 'X', 'X', 'X', 'X', 'O', 'X' },
            { 'X', 'X', 'X', 'O', 'X', 'O', 'X' },
            { 'X', 'O', 'X', 'O', 'X', 'O', 'X' },
            { 'O', 'X', 'O', 'X', 'O', 'X', 'O' }
        };
        var pq = new PuissanceQuatre();
        pq.grille = grille;

        bool result = pq.verifEgalite();

        Assert.False(result);
    }
}