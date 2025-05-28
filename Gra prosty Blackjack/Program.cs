using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Card
{
    public string Number { get; }


    public Card(string number)
    {
        Number = number;
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

    public Card Deal()
    {
        Card top = cards[0];
        cards.RemoveAt(0);
        return top;
    }


}

public class Hand
{
    public List<Card> Cards = new List<Card>();

    public void Add(Card card)
    {
        Cards.Add(card);
    }
    public int Value()
    {
        int value = 0;
        int aces = 0;

        foreach(var card in Cards)
        {
            value += card.Value();
            if (card.Number == "A") aces++;
        }

        while (value > 21 && aces > 0)
        {
            value -= 10;
            aces--;
        }

        return value;
    }

    public override string ToString()
    {
        return string.Join(", ", Cards);
    }


}

public class Player
{
    public Hand hand = new Hand();

    public void Play(Deck deck)
    {
        Console.WriteLine($"Twoja wartosc: {hand} (watrosc: {hand.Value()})");
        if (hand.Value() >= 21)
        {
               
        }

        Console.WriteLine("Dobierz karte albo nie dobieraj (zostaw/dobierz)");
        string input = Console.ReadLine().ToLower();
        if (input == "zostaw")
        {
            
        }
        else if(input == "dobierz")
        {
            hand.Add(deck.Deal());
        }
    }

}

class Dealer
{
    public Hand Hand = new Hand();

    public void Play(Deck deck)
    {
        while (Hand.Value() < 17)
        {
            Hand.Add(deck.Deal());
        }
    }
}

class Program
{
    static void Main()
    {
        Deck deck = new Deck();
        Player player = new Player();
        Dealer dealer = new Dealer();

        player.hand.Add(deck.Deal());
        player.hand.Add(deck.Deal());

        dealer.Hand.Add(deck.Deal());
        dealer.Hand.Add(deck.Deal());

        Console.WriteLine("Dealer pokazuje: " + dealer.Hand.Cards[0]);

        player.Play(deck);
        if (player.hand.Value() > 21)
        {
            Console.WriteLine("Przegrales.");
            return;
        }

        dealer.Play(deck);
        Console.WriteLine($"Karty dealera: {dealer.Hand} (value: {dealer.Hand.Value()})");

        if (dealer.Hand.Value() > 21 || player.hand.Value() > dealer.Hand.Value())
            Console.WriteLine("Wygrywasz!");
        else if (player.hand.Value() == dealer.Hand.Value())
            Console.WriteLine("Push.");
        else
            Console.WriteLine("Dealer wygrywa.");



    }
}