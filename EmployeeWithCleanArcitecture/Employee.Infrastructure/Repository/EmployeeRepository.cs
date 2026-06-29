using Employee.Application.Interfaces;
using Employee.Domain;
using Employee.Infrastructure.Context;
using System;
using System.Collections.Generic;

namespace Employee.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<employee>, IEmployeeRepository
    {
        private readonly EmployeeDbContext context;

        public EmployeeRepository(EmployeeDbContext context) : base(context)
            {
            this.context = context;
        }

        int IEmployeeRepository.ADD(employee employee)
        {
            throw new NotImplementedException();
        }

        int IEmployeeRepository.Delete(employee employee)
        {
            throw new NotImplementedException();
        }

        employee IEmployeeRepository.get(int? id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<employee> IEmployeeRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        int IEmployeeRepository.Update(employee employee)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Employee>> GetEmployeesbyDeptName(string deptName)
        //{
        //    throw new NotImplementedException();
        //}
    }
    
}
