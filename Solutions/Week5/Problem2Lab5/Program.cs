string sentence = "Test new words test duplicates a a A A ha";

var words = sentence.Split();
var wordCount = words.Select(w => w.ToLower()).Distinct().Count();
Console.WriteLine(wordCount);

// PROBLEM 3:
List<char> chars = new List<char>();
Random rand = new Random();

for (int i = 0; i < 30; i++)
{
    chars.Add((char)('a' + rand.Next(26)));
}

// ascending
Console.WriteLine("\nsorted ascending");
var ascending = chars.Order();
foreach (char c in ascending)
{
    Console.Write(c);
}


// descending
Console.WriteLine("\nsorted descending");
var descending = chars.OrderDescending();
foreach (char c in descending)
{
    Console.Write(c);
}

// ascending no dups
Console.WriteLine("\nsorted ascending no duplicates");
var noDups = ascending.Distinct();
foreach (char c in noDups)
{
    Console.Write(c);
}

//PROBLEM4
Console.WriteLine("\nPROBLEM 4:");
int[] nums = new int[100];
for (int i = 0; i < nums.Length; i++)
{
    nums[i] = rand.Next(20, 51);
}

var groupby8 = nums.OrderBy(n => n % 8).GroupBy(n => n % 8)
    .Select(group => new
    {
        Title = $"Remainder of {group.Key}",
        Count = group.Count(),
        Numbers = group
    });

foreach (var group in groupby8)
{
    Console.WriteLine($"Amount of numbers with remainder of {group.Title}: {group.Count}");
    foreach (var num in group.Numbers)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();
}