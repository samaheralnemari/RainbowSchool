//using System;
//using System.Collections;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace RainbowSchool
//{
//    [Serializable]
//    public class Teacher
//    {
//        public int ID;
//        public string Name;
//        public string Class;
//        public string Section;

//        public Teacher(int id, string name, string classs, string section)
//        {
//            this.ID = id;
//            this.Name = name;
//            this.Class = classs;
//            this.Section = section;
//        }
//        public override string ToString()
//        {
//            return "ID: "+ this.ID + " Name: "+ this.Name + " Class: "+ this.Class + " Section: "+ this.Section;

//        }


//    }
//    public class SerializationDeserialization
//    {
//        public void Serialize(Teacher teacher)
//        {
//            FileStream fs = null;
//            try
//            {
//                ArrayList list = new ArrayList();
//                list.Add(teacher);
//                fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.Append);
//                BinaryFormatter formatter = new BinaryFormatter();
//                formatter.Serialize(fs, list);
//            }
//            catch (IOException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                fs.Close();
//            }

//        }
//        public void Deserialize()
//        {
//            FileStream fs = null;
//            try
//            {
//                fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.OpenOrCreate);
//                BinaryFormatter formatter = new BinaryFormatter();

//                ArrayList list = formatter.Deserialize(fs) as ArrayList;
//                foreach (Teacher teacher in list)
//                {
//                    Console.WriteLine("ID: {0}, Name: {1}, Class: {2}, Section: {3}", teacher.ID, teacher.Name, teacher.Class, teacher.Section);
//                }
//            }
//            catch (IOException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                fs.Close();
//            }
//        }
//        public void DeserializeSearch(int ID)
//        {
//            FileStream fs = null;
//            try
//            {
//                fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.OpenOrCreate);
//                BinaryFormatter formatter = new BinaryFormatter();

//                ArrayList list = formatter.Deserialize(fs) as ArrayList;
//                if (list != null)
//                {
//                    var teacher = list.Contains(ID);
//                    Console.WriteLine(teacher);
//                }
//                else
//                {
//                    Console.WriteLine("Empty File");
//                }
//            }
//            catch (IOException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                fs.Close();
//            }
//        }
//        public void DeserializeUpdate(int ID)
//        {
//            FileStream fs = null;
//            try
//            {
//                fs = new FileStream("C:\\Users\\samah\\Desktop\\مسار مطور (.NET)\\Teacher.txt", FileMode.OpenOrCreate);
//                BinaryFormatter formatter = new BinaryFormatter();

//                ArrayList list = formatter.Deserialize(fs) as ArrayList;
//                var teacher = list.Contains(ID);
//                Console.WriteLine(teacher);
//            }
//            catch (IOException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                fs.Close();
//            }
//        }

//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int choice=0;
//            int ID = 0;
//            string Name, Class, Section = "";
//            SerializationDeserialization obj = null;

//            Console.WriteLine("Please Choose from menu: ");
//            Console.WriteLine("1. Insert new teacher");
//            Console.WriteLine("2. Upadte current teacher data");
//            Console.WriteLine("3. View any teacher data");
//            Console.WriteLine("4. Exit");
//            Console.Write("Your Choice: ");
//            choice = int.Parse(Console.ReadLine());           
//            while (choice!=4)
//            {
//                switch(choice)
//                {
//                    case 1:
//                        Console.WriteLine("Enter ID: ");
//                        ID = int.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter Name: ");
//                        Name = Console.ReadLine();
//                        Console.WriteLine("Enter Class: ");
//                        Class = Console.ReadLine();
//                        Console.WriteLine("Enter Section: ");
//                        Section = Console.ReadLine();
//                        obj = new SerializationDeserialization();
//                        Teacher teacher = new Teacher(ID, Name, Class, Section);
//                        obj.Serialize(teacher);
//                        break;
//                    case 2:
//                        Console.WriteLine("Enter Teacher ID to Update: ");
//                        ID = int.Parse(Console.ReadLine());
//                        obj = new SerializationDeserialization();
//                        obj.DeserializeUpdate(ID);
//                        break;
//                    case 3:
//                        Console.WriteLine("Enter Teacher ID: ");
//                        ID = int.Parse(Console.ReadLine());
//                        obj = new SerializationDeserialization();
//                        //obj.DeserializeSearch(ID);
//                        obj.Deserialize();
//                        break;
//                }
//                Console.WriteLine("Please Choose from menu: ");
//                Console.WriteLine("1. Insert new data");
//                Console.WriteLine("2. Upadte current data");
//                Console.WriteLine("3. View any data");
//                Console.WriteLine("4. Exit");
//                choice = int.Parse(Console.ReadLine());
//            }

            
//            Console.WriteLine("Hello World!");
//        }
//    }
//}
