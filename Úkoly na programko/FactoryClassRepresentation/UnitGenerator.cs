namespace FactoryClassRepresentation;
internal class UnitGenerator
{
    public string Name { get; }
    public List<Employee> Employees { get; } = new List<Employee>();
    public List<UnitGenerator> SubUnits { get; } = new List<UnitGenerator>();
    public bool IsSubDepartment { get; private set; }

    public UnitGenerator(string name, bool isSubDepartment = false)
    {
        Name = name;
        IsSubDepartment = isSubDepartment;
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public void AddSubUnit(UnitGenerator unit)
    {
        SubUnits.Add(unit);
    }

    public void DisplayHierarchy(bool isRoot = true)
    {
        if (isRoot)
        {
            Console.WriteLine($"Firma: {Name}");
        }
        else if (IsSubDepartment)
        {
            Console.WriteLine($"  pododdělení: {Name}");
        }
        else
        {
            Console.WriteLine($"  oddělení: {Name}");
        }

        if (Employees.Any())
        {
            Console.WriteLine($"    zaměstnanci:");
            foreach (var employee in Employees)
            {
                Console.WriteLine($"      - {employee}");
            }
        }

        foreach (var subUnit in SubUnits)
        {
            subUnit.DisplayHierarchy(false);
        }
    }

    public int GetTotalEmployees()
    {
        int count = Employees.Count;
        foreach (var sU in SubUnits)
        {
            count += sU.GetTotalEmployees();
        }
        return count;
    }
    public int GetTotalSalary()
    {
        int totalSalaries = Employees.Sum(e => e.Salary);
        foreach (var sU in SubUnits)
        {
            totalSalaries += sU.GetTotalSalary();
        }
        return totalSalaries;
    }
}
