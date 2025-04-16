using Tutorial6.Models;

namespace Tutorial6;

public static class Database
{
    public static List<Test> Tests = new List<Test>()
    {
        new Test() { Id = 1, Name = "Test1" },
        new Test() { Id = 2, Name = "Test2" },
        new Test() { Id = 3, Name = "Test3" }
    };

    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal() { Id = 1, Name = "Burek", category = "kot", weight = 12, color = "brazowy" },
        new Animal() { Id = 2, Name = "Stefan", category = "kot", weight = 7, color = "rudy" },
        new Animal() { Id = 3, Name = "Azor", category = "chomik", weight = 1, color = "mieszany" }
    };

}