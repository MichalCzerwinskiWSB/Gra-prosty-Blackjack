using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Card
{
    public string Number { get; }


    public Card(string number)
    {
        Number = number;
        //Console.WriteLine(number);
    }

    public int Value()
    {
        if (int.TryParse(Number, out int val))
            return val;
        else if (Number == "A")
            return 11;
        else
            return 10;
    }

    public override string ToString()
    {
        return $"{Number}";
    }



}
public class Deck
{
    private List<Card> cards;
    public static Random rnd = new Random();


    public Deck()
    {
        int suits = 4;
        string[] numbers = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        cards = new List<Card>();

        for (int i = 0; i < suits; i++)
        foreach (string number in numbers)
            cards.Add(new Card(number));


        Shuffle();


    }
    public void Shuffle()
    {
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            int j = rnd.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }

    }

    public void PrintAllCards()
    {
        foreach (var card in cards)
        {
            Console.WriteLine(card);
        }
    }


}

public class Hand
{

}

public class Player
{

}

public class Dealer
{

}

class Program
{
    static void Main()
    {
        Deck deck = new Deck();
        deck.PrintAllCards();
        


    }
}