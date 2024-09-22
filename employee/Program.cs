﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public Employee(int id, string name, int age, int salary)
    {
        Id = id;
        Name = name;
        Age = age;
        Salary = salary;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        // Fájl beolvasása
        string[] lines = File.ReadAllLines("tulajdonsagok_100sor.txt");

        foreach (var line in lines)
        {

            string[] adatok = line.Split(';');

            if (adatok.Length != 4)
            {
                Console.WriteLine($"Hibás formátumú sor: {line}");
                continue;
            }

            try
            {
                employees.Add(new Employee(
                    int.Parse(adatok[0]),   // Azonosító
                    adatok[1],              // Név
                    int.Parse(adatok[2]),   // Kor
                    int.Parse(adatok[3])    // Kereset
                ));
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Nem sikerült feldolgozni a sort: {line}. Hiba: {ex.Message}");
            }
        }
        Console.ReadKey();
    }
}