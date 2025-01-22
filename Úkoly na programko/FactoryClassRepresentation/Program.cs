using FactoryClassRepresentation;

UnitGenerator company = new CompanyBuilder("Zalando")
.AddDepartment("doprava", 5)          
.AddDepartment("účetnictví", 3)
.AddDepartment("marketing", 2)
.AddDepartment("údržba a scaling", 2)
.AddSubDepartment("doprava", "řidiči", 3)
.AddSubDepartment("doprava", "logistika", 3)
.AddSubDepartment("účetnictví", "director", 1)
.AddSubDepartment("účetnictví", "účetní", 5)
.AddSubDepartment("marketing", "managment", 2)
.AddSubDepartment("marketing", "reklamní makléři", 3)
.AddSubDepartment("marketing", "média", 12)
.AddSubDepartment("údržba a scaling", "zprávci stránek", 5)
.AddSubDepartment("údržba a scaling", "developers", 3)
.Build();

company.DisplayHierarchy();
Console.WriteLine($"počet zaměstnanců: {company.GetTotalEmployees()}");
Console.WriteLine($"součet platů: {company.GetTotalSalary()} kč");

