namespace FactoryClassRepresentation;

internal class EmpolyeeFactory
{
    private static List<string> Names = new List<string>
{
    "Jan",
    "Tomáš",
    "Anna",
    "Petra",
    "Karel",
    "Lucie",
    "David",
    "Eva",
    "Jiří",
    "Tereza"
};
    private static int[] Salaries = { 40000, 43000, 45000, 47500, 50000, };

    private static Random random = new Random();

    public static Employee CreateRandomEmployee()
    {
        string name = Names[random.Next(Names.Count)];
        int salary = Salaries[random.Next(Salaries.Length)];

        return new Employee(name, salary);
    }

}