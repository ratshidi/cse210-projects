class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        List<Scripture> library = CreateLibrary();

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        int wordsToHide = ChooseDifficulty();

        string input = "";
        while (input != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine().Trim().ToLower();

            if (input != "quit")
            {
                scripture.HideRandomWords(wordsToHide);
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All the words are hidden. Great job!");
        }
    }

    static int ChooseDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Choose a difficulty:");
        Console.WriteLine("1. Easy (hide 2 words at a time)");
        Console.WriteLine("2. Medium (hide 3 words at a time)");
        Console.WriteLine("3. Hard (hide 5 words at a time)");
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            return 2;
        }
        else if (choice == "3")
        {
            return 5;
        }

        return 3;
    }

    static List<Scripture> CreateLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        Reference reference1 = new Reference("John", 3, 16);
        library.Add(new Scripture(reference1,
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        library.Add(new Scripture(reference2,
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

        Reference reference3 = new Reference("2 Nephi", 2, 25);
        library.Add(new Scripture(reference3,
            "Adam fell that men might be; and men are, that they might have joy."));

        return library;
    }
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {

            List<Word> visibleWords = new List<Word>();
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    visibleWords.Add(word);
                }
            }

            if (visibleWords.Count == 0)
            {
                return;
            }

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string text = "";
        foreach (Word word in _words)
        {
            text = text + word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} {text.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}