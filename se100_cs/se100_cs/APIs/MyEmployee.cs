﻿using Microsoft.EntityFrameworkCore;
using se100_cs.Model;
using static se100_cs.APIs.MyPosition;

namespace se100_cs.APIs
{
    public class MyEmployee
    {
        public MyEmployee() { }
        public class Employee_DTO_Response
        {
            public long ID { get; set; }
            public string email { get; set; } = "";
            public string fullName { get; set; } = "";
            public string phoneNumber { get; set; } = "";
            public string avatar { get; set; } = "";
            public DateTime birth_day { get; set; } = DateTime.UtcNow;
            public bool gender { get; set; } = true;
            public string cmnd { get; set; } = "";
            public string address { get; set; } = "";
        }
        public List<Employee_DTO_Response> getByDepartmentCode(string departmentCode)
        {
            using (DataContext context = new DataContext())
            {
                SqlDepartment? department = context.departments!.Where(s => s.code == departmentCode && s.isDeleted==false).FirstOrDefault();
                if (department == null)
                {
                    return new List<Employee_DTO_Response>();
                }
                List<SqlEmployee>? list = context.employees!.Include(s => s.department).Where(s => s.isDeleted == false && s.department!.code == departmentCode ).ToList();
                List<Employee_DTO_Response> repsonse = new List<Employee_DTO_Response>();
                if (list.Count > 0)
                {
                    foreach (SqlEmployee employee in list)
                    {
                        Employee_DTO_Response item = new Employee_DTO_Response();
                        item.ID = employee.ID;
                        item.email = employee.email;
                        item.fullName = employee.fullName;
                        item.phoneNumber = employee.phoneNumber;
                        item.avatar = employee.avatar;
                        item.gender = employee.gender;
                        item.cmnd = employee.cmnd;
                        item.address = employee.address;
                        repsonse.Add(item);
                    }
                }
                return repsonse;
            }
        }

        public string getRole(long employee_id)
        {
            using (DataContext context = new DataContext())
            {
                SqlEmployee employee = context.employees!.Where(s => s.ID == employee_id && s.isDeleted == false).FirstOrDefault();
                if (employee == null)
                {
                    return "NotFound";
                }
                return employee.role.ToString();
            }
        }

        public async Task<bool> createNew(string email, string fullName, string phoneNumber, DateTime birth_day, bool  gender, string cmnd, string address,string avatar, string departmentCode)
        {
            using (DataContext context = new DataContext())
            {
                if (string.IsNullOrEmpty(email)  || string.IsNullOrEmpty(departmentCode) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(avatar) || string.IsNullOrEmpty(cmnd))
                {
                    return false;
                }
                SqlDepartment? department = context.departments!.Where(s => s.code == departmentCode).FirstOrDefault();
                if (department == null)
                {
                    return false;
                }
                SqlEmployee? existing = context.employees!.Where(s=>s.email == email).FirstOrDefault();
                if (existing != null)
                {
                    return false;
                }
                SqlEmployee item = new SqlEmployee();
                item.email = email;
                item.password = DataContext.randomString(6);
                item.fullName = fullName;
                item.phoneNumber = phoneNumber;
                item.birth_day = birth_day;
                item.gender = gender;
                item.cmnd = cmnd;
                item.token = DataContext.randomString(8);
                item.avatar = avatar;
                item.address = address;
                item.department = department;
                context.employees!.Add(item);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> updateOne(string email, string fullName, string phoneNumber, DateTime birth_day, bool gender, string cmnd, string address, string avatar, long id)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(avatar) || string.IsNullOrEmpty(cmnd))
            {
                return false;
            }
            using (DataContext context = new DataContext())
            {
                SqlEmployee? employee = context.employees!.Where(s => s.ID == id && s.isDeleted == false).FirstOrDefault();
                if (employee == null)
                {
                    return false;
                }
                else
                {
                    employee.email = email;
                    employee.password = DataContext.randomString(6);
                    employee.fullName = fullName;
                    employee.phoneNumber = phoneNumber;
                    employee.birth_day = birth_day;
                    employee.gender = gender;
                    employee.cmnd = cmnd;
                    employee.avatar = avatar;
                    employee.address = address;
                    await context.SaveChangesAsync();
                }
                return true;
            }
        }
        public async Task<bool> updateRole(string role, long id)
        {
            if (string.IsNullOrEmpty(role))
            {
                return false;
            }
            using (DataContext context = new DataContext())
            {
                SqlEmployee? employee = context.employees!.Where(s => s.ID == id && s.isDeleted == false).FirstOrDefault();
                if (employee == null)
                {
                    return false;
                }
                else
                {
                    if (role == "admin") {
                    employee.role = Role.ADMIN;
                    }
                    else if (role == "director") { employee.role=Role.DIRECTOR; }
                    else if (role == "manager") { employee.role=Role.MANAGER; }
                    else  { employee.role=Role.EMPLOYEE; }
                    await context.SaveChangesAsync();
                }
                return true;
            }
        }
        public async Task<bool> deleteOne(long id)
        {
            using (DataContext context = new DataContext())
            {
                SqlEmployee? employee = context.employees!.Where(s => s.ID == id && s.isDeleted == false).FirstOrDefault();
                if (employee == null)
                {
                    return false;
                }
                else
                {
                    employee.isDeleted = true;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
        }
        public string login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "";
            }
            using (DataContext context = new DataContext())
            {
                SqlEmployee employee = context.employees!.Where(s => s.email == email).FirstOrDefault();
                if (employee == null)
                {
                    return "";
                }
                else
                {
                    if (employee.password != password)
                    {
                        return "";
                    }
                    else
                    {
                        return employee.token;
                    }
                }
            }
            return "";
        }

        public long checkEmployee(string token)
        {
            using (DataContext context = new DataContext())
            {
                SqlEmployee employee = context.employees.Where(s=>s.token == token && s.isDeleted==false).FirstOrDefault();
                if(employee == null)
                {
                    return -1;
                }
                else
                {
                    return employee.ID;
                }
            }
        }

        public int countTotalEmployee()
        {
            int count = 0;
            using(DataContext context = new DataContext())
            {
                count = context.employees!.Where(s=>s.isDeleted==false).Count();
            }
            return count;
        }
        public int countMaleEmployee()
        {
            int count = 0;
            using (DataContext context = new DataContext())
            {
                count = context.employees!.Where(s => s.isDeleted == false&& s.gender==true).Count();
            }
            return count;

        }
        public class Total_Employee
        {
            public int man { get; set; } = 0;
            public int woman { get; set; } = 0;
            public int total { get; set; } = 0;
        }
        public Total_Employee getTotal_Employee()
        {
            int total = countTotalEmployee(); 
            int male = countMaleEmployee();
            Total_Employee today = new Total_Employee();
            today.man = male;
            today.total= total;
            today.woman = total - male;
            return today;
        }
    }
}
