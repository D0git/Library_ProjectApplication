using LibraryProject.Data;
using LibraryProject.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models.Collections
{
    internal class LesEmployees
    {
        private readonly LibraryContext context;

        public LesEmployees(LibraryContext context)
        {
            this.context = context;
        }


        public bool Ajouter_Emp(string nom, string prenom, Status status, string adresse, string email, string phone, string image, DateTime dateNaissance)
        {
            var exist = context.Employees.Any(emp => emp.DateNaissance == dateNaissance && emp.Prenom == prenom && emp.Nom == nom);
            if (!exist)
            {
                Employee employee = new Employee(nom, prenom, status, adresse, email, phone, image, dateNaissance);
                context.Employees.Add(employee);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void RemoveEmployee(int id)
        {
            var emp = from e in context.Employees
                      where e.Id == id
                      select e;
            context.Employees.Remove((Employee)emp);
            context.SaveChanges();
        }

        public HashSet<Employee> RechercheEmployees(string search)
        {
            var employees = context.Employees.Where(emp => emp.Prenom.ToLower().Contains(search.ToLower()) || emp.Nom.ToLower().Contains(search.ToLower()) || emp.Status.ToString().ToLower().Contains(search.ToLower())).ToHashSet();

            return employees;
        }

        public HashSet<Employee> GetEmployees()
        {
            return context.Employees.ToHashSet();
        }

        public Employee GetUnEmployee(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(emp => emp.Id == id);
            return employee;
        }
    }
}