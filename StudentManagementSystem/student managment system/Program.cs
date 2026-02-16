using System;
using System.Collections.Generic;

namespace StudentSystem
{



    class Program
    {
        static List<Student> students = new List<Student>();
        public static void Main(string[] args)
        {
            bool exit = false;

            Console.WriteLine("hello in my application");
            Console.WriteLine("*****************");
            while (!exit)
            {
                Console.WriteLine("choose number to continue");
                Console.WriteLine("1 Add Student");
                Console.WriteLine("2 Delete Studente");
                Console.WriteLine("3 Show Students");
                Console.WriteLine("4 Update Student");
                Console.WriteLine("5 Average Grade");
                Console.WriteLine("6 Exit");


                Console.WriteLine("*****************");

                Console.Write("enter your choice: ");
                int choice=0;
                try
                {
                     choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid choice");
                }

                switch (choice)
                    {

                        case 1:
                            AddStudent();
                            break;
                        case 2:
                        DeleteStudent();
                            break;
                        case 3:
                            ShowStudents();
                        break;
                        case 4:
                        UpdateStudent();
                            break;
                        case 5:
                        AverageGrade();
                            break;
                        case 6:
                            exit = true;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("error happened or invalid choice! try again!!!");
                            break;


                    }
                
                             

            }
        }



        public static void AddStudent()
        {
            try
            {

                Console.WriteLine("Please enter student Id");
                int studentid = int.Parse(Console.ReadLine());


                bool exists = students.Exists(s => s.Id == studentid);
                if (exists)
                {
                    Console.WriteLine($"the student with id {studentid} is already exist");
                    return;
                }

                Console.WriteLine("Please enter student name");
                string studentname = Console.ReadLine();




                Console.WriteLine("Please enter student grade");
                double studentgrade = double.Parse(Console.ReadLine());

                Student student = new Student();
                student.Id = studentid;
                student.Name = studentname;
                student.Grade = studentgrade;

                students.Add(student);
                Console.WriteLine("*********************");
                Console.WriteLine("Student added successfully");
                Console.WriteLine("*********************");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter the correct data types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error ocuured {0}", ex.Message);
            }
        }
        public static void DeleteStudent()
        {
            
            if (students.Count == 0)
            {
                Console.WriteLine("no students here, please add student and try again, thanks");
                return;
            }
            else
            {
                Console.WriteLine("the students is:");
                foreach (Student st in students)
                {
                    
                    Console.WriteLine("*********************");
                    Console.WriteLine($"Id: {st.Id} , Name: {st.Name} , Grade: {st.Grade}");
                    Console.WriteLine("*********************");
                    
                }
            }

            Console.WriteLine("enter the id of the student that you need delete");
            int id = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {

                students.Remove(student);
                Console.WriteLine($"the student with id : {id} is deleted successfully");

            }
            else
            {
                Console.WriteLine($"the student with id : {id} is not exist");
            }
        }
        public static void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("no students here, please add student and try again,thanks");
            }
            else
            {
                foreach (Student st in students)
                {
                    Console.WriteLine("*********************");
                    Console.WriteLine($"Id: {st.Id}, Name: {st.Name}, Grade: {st.Grade}");
                    Console.WriteLine("*********************");
                }
            }
        }
        public static void AverageGrade()
        {
            if(students.Count == 0)
            {
                Console.WriteLine("no students here, please add student and try again, thanks");

            }
            else
            {
                double count = students.Count;
                double sum = 0;
                foreach (Student st in students)
                {
                    sum += st.Grade;
                }
                double avg= sum / count;
                Console.WriteLine($" The sum is: {sum} the total count is: {count} The average grade of all students is: {Math.Round(avg,2)}");
            }

             
        }
        public static void UpdateStudent()
        {
            Console.WriteLine("enter the id of the student that you need update");
            int id = int.Parse(Console.ReadLine());
            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("enter the new name of the student");
                string newname = Console.ReadLine();
                Console.WriteLine("enter the new Grade of the student");
                double newgrade =double.Parse(Console.ReadLine());

                student.Name = newname;
                student.Grade = newgrade;
                Console.WriteLine("Student updated successfully");


            }
            else
            {
                Console.WriteLine($"the student with id : {id} is not exist");
            }
        }

    

      
    }


    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
    }


}

