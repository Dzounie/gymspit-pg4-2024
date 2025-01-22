namespace FactoryClassRepresentation;

internal class CompanyBuilder
{
    private UnitGenerator MainUnit;

    public CompanyBuilder(string companyName)
    {
        MainUnit = new UnitGenerator(companyName);
    }
    public CompanyBuilder AddDepartment(string depName, int employeesCount)
    {
        var department = new UnitGenerator(depName);
        for (int i = 0; i < employeesCount; i++)
        {
            department.AddEmployee(EmpolyeeFactory.CreateRandomEmployee());
        }
        MainUnit.AddSubUnit(department);
        return this;
    }

    public CompanyBuilder AddSubDepartment(string depParentName, string subDepName, int employeesCount)
    {
        var parent = FindUnitByName(MainUnit, depParentName);
        if (parent != null)
        {
            var subDepartment = new UnitGenerator(subDepName, true);

            var random = new Random();

            var selectedEmployees = parent.Employees
                .OrderBy(e => random.Next())
                .Take(employeesCount)
                .ToList();

            subDepartment.Employees.AddRange(selectedEmployees);
            parent.AddSubUnit(subDepartment);
        }
        return this;
    }

    private UnitGenerator FindUnitByName(UnitGenerator unit, string name)
    {
        if (unit.Name == name) return unit;
        foreach (var sUnit in unit.SubUnits)
        {
            var result = FindUnitByName(sUnit, name);
            if (result != null) return result;
        }
        return null!;
    }

    public UnitGenerator Build()
    {
        return MainUnit;
    }
}