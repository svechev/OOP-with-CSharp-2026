using Problem1;

Time time1 = new Time()
{
    Hour = 1,
    Minute = 2,
    Second = 3,
};
Time time2 = new Time(10, 0, 20);

Console.WriteLine(time2);

Account account = new(DateTime.Now, 100, 0.01, "100") {
    Id = "101"
};

Console.WriteLine(account);
