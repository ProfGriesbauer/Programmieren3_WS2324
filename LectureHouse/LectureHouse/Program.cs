// See https://aka.ms/new-console-template for more information
LectureHouse.House MyHouse1 = new LectureHouse.House();
LectureHouse.House MyHouse2 = new LectureHouse.House();

MyHouse1.StromAn = true;
Console.WriteLine("MyHouse1 HauptLichtschalter: {0}", MyHouse1.StromAn);
MyHouse1.StromAn = false;
MyHouse1.HeizungAn = true;
Console.WriteLine("MyHouse1 HauptLichtschalter: {0}", MyHouse1.HeizungAn);

Console.WriteLine("Hello, World!");
