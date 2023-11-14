// See https://aka.ms/new-console-template for more information
using LectureHouse;

LectureHouse.House MyHouse1 = new LectureHouse.House(45.0f);
LectureHouse.House MyHouse2 = new LectureHouse.House();

MyHouse1.StromAn = true;
Console.WriteLine("MyHouse1 HauptLichtschalter: {0}", MyHouse1.StromAn);
MyHouse1.StromAn = false;
MyHouse1.HeizungAn = true;
Console.WriteLine("MyHouse1 HauptLichtschalter: {0}", MyHouse1.HeizungAn);

MyHouse1.Room0Anmachen();
Console.WriteLine(MyHouse1.Serialize());
MyHouse1.Deserialize(MyHouse1.Serialize());
