namespace StudentsXML
{
    using StudentsXML.Models;
    using System.IO;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            //var sb = new StringBuilder();
            var students = GetStudents();
            var serializer = new XmlSerializer(typeof(StudentDto[]), new XmlRootAttribute("students"));

            using (var writer = new StreamWriter("students.xml"))
            {
                serializer.Serialize(writer, students);
            }
            
        }

        private static StudentDto[] GetStudents()
        {
            var firstStudent = new StudentDto()
            {
                Name = "Ivan Ivanov",
                Gender = "Male",
                BirthDate = "1999/12/23",
                PhoneNumber = "0000000000",
                Email = "ivan.ivanov@abb.bg",
                University = "Software University",
                Specialty = "C# Web Developer",
                FacultyNumber = "12345156",
                exams = new ExamDto[]
                {
                    new ExamDto()
                    {
                        Name = "Programming Basics",
                        DateTaken = "2017/12/12",
                        Grade = 6.00d,
                    },

                    new ExamDto()
                    {
                        Name = "Programming Fundamentals",
                        DateTaken = "2018/03/17",
                        Grade = 6.00d,
                    }

                },
            };

            var secondStudent = new StudentDto()
            {
                Name = "Pesho Peshov",
                Gender = "Male",
                BirthDate = "1998/11/04",
                PhoneNumber = "0889346763",
                Email = "Pesho.Peshov@abb.bg",
                University = "Software University",
                Specialty = "Java Web Developer",
                FacultyNumber = "15458990",
                exams = new ExamDto[]
                {
                    new ExamDto()
                    {
                        Name = "Programming Basics",
                        DateTaken = "2017/12/12",
                        Grade = 5.98d,
                    },

                    new ExamDto()
                    {
                        Name = "Programming Fundamentals",
                        DateTaken = "2018/03/17",
                        Grade = 5.12d,
                    }

                },
            };

            return new StudentDto[] { firstStudent, secondStudent };
        }
    }
}
