using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RainbowSchool
{
    public class Teacher
    {
        public string ID;
        public string Name;
        public string Class;
        public string Section;

        public Teacher(string id, string name, string classs, string section)
        {
            this.ID = id;
            this.Name = name;
            this.Class = classs;
            this.Section = section;
        }
        public override string ToString()
        {
            //return "ID: " + this.ID + " Name: " + this.Name + " Class: " + this.Class + " Section: " + this.Section;
            return  this.ID + "-" + this.Name + "-" + this.Class + "-" + this.Section;
        }
    }
    public class FileOperations
    {
        public void ReadData()
        {
            FileStream fs = null;
            StreamReader sr = null;
            //List<Teacher> list = new List<Teacher>();
            string[] Array = null;
            try
            {
                fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();

                while (str != null)
                {
                    Array = str.Split("-");

                    //Console.WriteLine(str);
                    Console.WriteLine("ID: "+ Array[0]+ " Name: " + Array[1]+ " Class: " + Array[2] + " Section: " + Array[3] );
                    str = sr.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
        public void AppendData(Teacher teacher)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(teacher.ToString());
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public void UpdateData(string Id,int choiceUpdate,string NewValue)
        {
            //FileStream fs = null;
            //StreamReader sr = null;

            try
            {
                
                //fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.Open, FileAccess.Read);
                //sr = new StreamReader(fs);

                //sr.BaseStream.Seek(0, SeekOrigin.Begin);
                //string str = sr.ReadLine();
                //while (str != null)
                //{
                //    Console.WriteLine(str);
                //    str = sr.ReadLine();
                //}
                string path = "C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt";
                string[] readText = File.ReadAllLines(path);
                string[] Array = null;
                File.WriteAllText(path, String.Empty);

                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (string s in readText)
                    {
                        if (s.Contains(Id))
                        {
                            Array=s.Split("-");
                            switch(choiceUpdate)
                            {
                                case 1:
                                    Array[1] = NewValue;
                                    break;
                                case 2:
                                    Array[2] = NewValue;
                                    break;
                                case 3:
                                    Array[3]= NewValue;
                                    break;
                            }
                            string upadted = Array[0] + "-" + Array[1] + "-" + Array[2] + "-" + Array[3];
                            writer.WriteLine(upadted);
                        }
                        if (!s.Contains(Id))
                        {
                            writer.WriteLine(s);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //sr.Close();
                //fs.Close();
            }
        }
    }
    class Program2
    {
        static void Main(string[] args)
        {
            int choice = 0;
            int choiceUpdate = 0;
            string ID = "";
            string Name, Class, Section = "";
            FileOperations obj = new FileOperations();
            //Console.ReadKey();

            Console.WriteLine("Please Choose from menu: ");
            Console.WriteLine("1. Insert new teacher");
            Console.WriteLine("2. Upadte current teacher data");
            Console.WriteLine("3. View data");
            Console.WriteLine("4. Exit");
            Console.Write("Your Choice: ");
            choice = int.Parse(Console.ReadLine());
            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter ID: ");
                        ID = Console.ReadLine();
                        Console.WriteLine("Enter Name: ");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter Class: ");
                        Class = Console.ReadLine();
                        Console.WriteLine("Enter Section: ");
                        Section = Console.ReadLine();

                        Teacher teacher = new Teacher(ID, Name, Class, Section);
                        obj.AppendData(teacher);

                        break;
                    case 2:
                        Console.WriteLine("Enter Teacher ID to Update: ");
                        ID = Console.ReadLine();
                        Console.WriteLine("What do you want upadte: ");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Class");
                        Console.WriteLine("3. Section");
                        Console.Write("Your Choice: ");
                        choiceUpdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter New Value: ");
                        string NewValue = Console.ReadLine();
                        obj.UpdateData(ID, choiceUpdate, NewValue);
                        break;
                    case 3:       
                        obj.ReadData();
                        break;
                }
                Console.WriteLine("Please Choose from menu: ");
                Console.WriteLine("1. Insert new teacher");
                Console.WriteLine("2. Upadte current teacher data");
                Console.WriteLine("3. View data");
                Console.WriteLine("4. Exit");
                Console.Write("Your Choice: ");
                choice = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("Hello World!");
        }
    }
}
