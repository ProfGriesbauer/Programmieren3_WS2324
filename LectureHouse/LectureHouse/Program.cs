// See https://aka.ms/new-console-template for more information
LectureHouse.House MyHouse1 = new LectureHouse.House();
LectureHouse.House MyHouse2 = new LectureHouse.House();

MyHouse1.SetHauptLichtschalter(true);
Console.WriteLine("MyHouse1 HauptLichtschalter: {0}", MyHouse1.GetHauptLichtschalter());
MyHouse1.AllesAus();
Console.WriteLine("MyHouse1 HauptLichtschalter: {0}", MyHouse1.HauptLichtschalter);

Console.WriteLine("Hello, World!");
