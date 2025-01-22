namespace FactoryClassRepresentation;

internal class Employee
{
    public string Name { get; }
    public int Salary { get; }


    public Employee(string name, int salary)
    {
        Name =name;
        Salary =salary;
    }

    public override string ToString()
    {
        return $"{Name}: {Salary}";
    }

}