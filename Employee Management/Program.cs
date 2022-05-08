using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, List<Employee>> myDictionary = employees
                .GroupBy(o => o.Company)
                .ToDictionary(g => g.Key, g => g.ToList());
            var result = new Dictionary<string, int>();

            foreach (var keyValuePair in myDictionary.OrderBy(dic=> dic.Key))
            {
                result.Add(keyValuePair.Key, (int)Math.Round(keyValuePair.Value.Average(emp => emp.Age), MidpointRounding.AwayFromZero));
            }

            return result;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, List<Employee>> myDictionary = employees
                .GroupBy(o => o.Company)
                .ToDictionary(g => g.Key, g => g.ToList());
            var result = new Dictionary<string, int>();

            foreach (var keyValuePair in myDictionary.OrderBy(dic => dic.Key))
            {
                result.Add(keyValuePair.Key, keyValuePair.Value.Count);
            }

            return result;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, List<Employee>> myDictionary = employees
                .GroupBy(o => o.Company)
                .ToDictionary(g => g.Key, g => g.ToList());
            var result = new Dictionary<string, Employee>();

            foreach (var keyValuePair in myDictionary.OrderBy(dic => dic.Key))
            {
                var employee = new Employee();
                var max = 0;
                foreach (var employee1 in keyValuePair.Value)
                {
                    if (employee1.Age > max)
                    {
                        max = employee1.Age;
                        employee = employee1;
                    }
                }
                result.Add(keyValuePair.Key, employee);
            }

            return result;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                Console.WriteLine(str);
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}