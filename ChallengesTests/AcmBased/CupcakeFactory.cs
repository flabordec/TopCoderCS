using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCSTest.AcmBased
{
    public class Employee
    {
        public HashSet<Employee> Subordinates { get; }
        public long Multiplier { get; set; }
        public long TotalPaid { get; set; }

        /// <inheritdoc />
        public Employee(int multiplier)
        {
            Multiplier = multiplier;
            TotalPaid = 0;
            Subordinates = new HashSet<Employee>();
        }
    }

    public class CupcakeFactory : IAcmStyle
    {
        public void Solve(StreamReader input, StreamWriter output)
        {
            string[] line;

            line = input.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int s = int.Parse(line[1]);

            int nextId = 1;

            var employees = new Employee[n];
            employees[nextId++] = new Employee(s);

            for (int t = 0; t < n; t++)
            {
                line = input.ReadLine().Split(' ');

                int i = int.Parse(line[0]);
                switch (i)
                {
                    case 1:
                    {
                        // hired -- 1 supervisor
                        int supervisorIx = int.Parse(line[1]);
                        var newEmployee = new Employee(s);
                        employees[supervisorIx].Subordinates.Add(newEmployee);
                        employees[nextId++] = newEmployee;
                        break;
                    }

                    case 2:
                    {
                        // change multiplier -- 2 employee multiplier
                        int employeeIx = int.Parse(line[1]);
                        long multiplier = long.Parse(line[2]);
                        employees[employeeIx].Multiplier = multiplier;
                        break;
                    }

                    case 3:
                    {
                        // pay bonus to employees -- 3 supervisor bonus
                        int employeeIx = int.Parse(line[1]);
                        long bonus = long.Parse(line[2]);
                        
                        var queue = new Queue<Employee>();
                        queue.Enqueue(employees[employeeIx]);
                        while (queue.Any())
                        {
                            Employee curr = queue.Dequeue();
                            long paid = curr.Multiplier * bonus;
                            curr.TotalPaid += paid;
                            foreach (Employee subordinate in curr.Subordinates)
                                queue.Enqueue(subordinate);
                        }
                        break;
                    }

                    case 4:
                    {
                        // query -- 4 employee
                        int employeeIx = int.Parse(line[1]);
                        output.WriteLine(employees[employeeIx].TotalPaid);
                        break;
                    }
                }
            }
        }
    }
}
