using Employee.Domain;


namespace Employee.Application.Interfaces
{
    public interface IEmployeeRepository
    {
       
        employee get(int? id);

        IEnumerable<employee> GetAll();
        int Update(employee employee);
        int ADD(employee  employee);
        int Delete(employee employee);

    }
}
