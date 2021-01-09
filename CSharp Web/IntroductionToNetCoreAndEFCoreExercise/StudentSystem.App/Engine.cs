namespace StudentSystem.App
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;

    public class Engine
    {
        private StudentSystemContext db;
        private const int numberOfStudentItems = 20;
        private const int numberOfHomeworkItems = 33;
        private const int numberOfResourceItems = 33;
        private const int numberOfCourseItems = 8;
        private const int numberOfLicenseItems = 100;

        public Engine(StudentSystemContext db)
        {
            this.db = db;
        }

        public void SeedData()
        {
            var students = new List<Student>();

            string[] studentNames = { "Pesho", "Gosho", "John", "Steve", "Mikey", "Dave", "Stephanie", "Jenna", "Mila", "Dillan", "Fredy", "Xaero", "Kim", "Jill", "Claire", "Chris", "Albert", "Walter", "Fiona", "Hughie" };

            string[] phoneNumbers = { "43657883", "893451346", "12342135578", "08958473525", "1535778894", "516217247", "5782362626", "0545627672", "14753685685", "2372482538", "36483583232", "35462572272", "2547237272546746", "563474573788", "1454613717", "74859432463", "5634683568358", "567372672373", "563478356835", "7347364733" };

            string[] registrationDates = { "12/03/1967", "14/07/1997", "11/05/2011", "31/03/2013", "22/06/2009", "14/03/2009", "01/09/1999", "17/11/2016", "15/10/1995", "03/03/2007", "30/12/2017", "22/07/2015", "12/03/2007", "15/08/2002", "13/04/2006", "19/09/2007", "16/05/1999", "15/03/2007", "12/03/2007", "02/01/2016" };

            string[] birthDays = { "15/08/1998", "06/07/1987", null, "12/12/1998", null, null, "19/09/1992", "16/07/1995", null, "01/07/1993", null, null, "13/03/1989", null, "12/03/1986", null, "30/04/1999", "11/12/1994", null, null };

            for (int i = 0; i < numberOfStudentItems; i++)
            {
                var student = new Student
                {
                    Name = studentNames[i],
                    PhoneNumber = phoneNumbers[i],
                    RegistrationDate = DateTime.ParseExact(registrationDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                };

                if (birthDays[i] == null)
                {
                    student.Birthday = null;
                }
                else
                {
                    student.Birthday = DateTime.ParseExact(birthDays[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                if (IsValid(student))
                {
                    students.Add(student);
                }
            }

            var courses = new List<Course>();

            string[] coursesNames = { "Math", "Physics", "Geography", "C# Web Development", "Java", "Introduction to BlockChain", "Self Defence", "Astrology" };

            string[] descriptions = { "Learning new calculus skills", "Dive into the depths of quantum mechanics", "Learning your positon on the globe :)", "The course will provide you with the skillset to build websites from scratch", "Java for dummies", "Become a blockchain god", "Learn how to defend yourself and your family", "Become a astrology master in no time" };

            string[] startDates = { "15/10/1995", "03/03/2007", "30/12/2017", "22/07/2015", "19/09/2007", "16/05/1999", "15/03/2007", "12/03/2007" };

            string[] endDates = { "15/12/1995", "03/05/2007", "02/03/2018", "22/09/2015", "19/11/2007", "16/07/1999", "15/05/2007", "12/05/2007" };

            decimal[] prices = { 999.99m, 123.56m, 450.99m, 1199.99m, 390.00m, 250.00m, 125.49m, 1200.00m };

            for (int i = 0; i < numberOfCourseItems; i++)
            {
                var course = new Course
                {
                    Name = coursesNames[i],
                    Description = descriptions[i],
                    StartDate = DateTime.ParseExact(startDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(endDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Price = prices[i],
                };

                if (IsValid(course))
                {
                    courses.Add(course);
                }
            }

            db.Courses.AddRange(courses);
            db.Students.AddRange(students);
            db.SaveChanges();

            var studentsCourses = new List<StudentCourse>();

            var studentsCoursesIds = new List<List<int>>
            {
               new List<int>{1, 1}, new List<int>{1, 2}, new List<int>{1, 3}, new List<int>{2, 5}, new List<int>{2, 7},
               new List<int>{2, 10}, new List<int>{2, 19}, new List<int>{3, 20}, new List<int>{3, 17}, new List<int>{3, 12},
               new List<int>{3, 15}, new List<int>{3, 11}, new List<int>{4, 7}, new List<int>{4, 6}, new List<int>{4, 1},
               new List<int>{5, 8}, new List<int>{5, 13}, new List<int>{5, 3}, new List<int>{5, 14}, new List<int>{5, 9},
               new List<int>{6, 18}, new List<int>{6, 11}, new List<int>{6, 10}, new List<int>{6, 13}, new List<int>{7, 20},
               new List<int>{7, 19}, new List<int>{7, 16}, new List<int>{7, 8}, new List<int>{7, 1}, new List<int>{7, 2},
               new List<int>{7, 3}, new List<int>{8, 1}, new List<int>{8, 16}, new List<int>{8, 19}, new List<int>{8, 18},
               new List<int>{8, 17}, new List<int>{8, 12}, new List<int>{8, 9}, new List<int>{8, 10}, new List<int>{8, 11},
               new List<int>{8, 3}, new List<int>{2, 4},
            };

            foreach (var ids in studentsCoursesIds)
            {
                var studentCourse = new StudentCourse
                {
                    StudentId = ids[1],
                    CourseId = ids[0],
                };

                studentsCourses.Add(studentCourse);
            }

            db.StudentsCourses.AddRange(studentsCourses);
            db.SaveChanges();

            var homeworks = new List<Homework>();

            var random = new Random();

            string[] submissionDates = { "18/01/2007", "18/10/2007", "11/07/2008", "21/10/2008", "11/07/2009", "25/07/2009", "22/08/2009", "07/01/2010", "07/03/2011", "02/08/2011", "08/02/2013", "26/04/2013", "26/03/2014", "24/04/2014", "25/04/2014", "17/07/2014", "28/07/2014", "22/11/2014", "23/08/2015", "17/03/2016", "12/06/2016", "15/12/2016", "26/08/2018", "03/10/2018", "25/12/2018", "11/03/2008", "03/05/2008", "03/01/2009", "10/03/2009", "10/07/2010", "20/06/2014", "15/08/2017", "31/12/2017" };

            //Randomly generated from a online generator
            string[] homeworkContent = { "He said he was not there yesterday; however, many people saw him there.", "I am happy to take your donation; any amount will be greatly appreciated.", "I will never be this young again. Ever.Oh damn… I just got older.", "The clock within this blog and the clock on my laptop are 1 hour different from each other.", "Abstraction is often one floor above you.", "I think I will buy the red car, or I will lease the blue one.", "I am counting my calories, yet I really want dessert.", "What was the person thinking when they discovered cow’s milk was fine for human consumption… and why did they do it in the first place!?", "How was the math test?", "We have a lot of rain in June.", "Sixty - Four comes asking for bread.", "She only paints with bold colors; she does not like pastels.", "Is it free?", "Everyone was busy, so I went to the movie alone.", "This is a Japanese doll.", "He turned in the research paper on Friday; otherwise, he would have not passed the class.", "The river stole the gods.", "Hurry!", "I want to buy a onesie… but know it won’t suit me.", "The book is in front of the table.", "The lake is a long way from here.", "Lets all be unique together until we realise we are all the same.", "The body may perhaps compensates for the loss of a true metaphysics.", "We need to rent a room for our party.", "He told us a very exciting adventure story.", "He ran out of money, so he had to stop playing poker.", "Sometimes, all you need to do is completely make an ass of yourself and laugh it off to realise that life isn’t so bad after all.", "The stranger officiates the meal.", "The memory we used to share is no longer coherent.", "There were white out conditions in the town; subsequently, the roads were impassable.", "Joe made the sugar cookies; Susan decorated them.", "Tom got a small piece of pie.", "The shooter says goodbye to his love." };

            string[] contentTypes = { "Application", "Pdf", "Zip" };

            for (int i = 0; i < numberOfHomeworkItems; i++)
            {
                var homework = new Homework
                {
                    Content = homeworkContent[i],
                    ContentType = (ContentType)Enum.Parse(typeof(ContentType), contentTypes[random.Next(0, 3)], true),
                    SubmissionDate = DateTime.ParseExact(submissionDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CourseId = random.Next(1, numberOfCourseItems + 1),
                    StudentId = random.Next(1, numberOfStudentItems + 1)
                };

                if (IsValid(homework))
                {
                    homeworks.Add(homework);
                }
            }

            var resources = new List<Resource>();

            //Randomly generated from a online generator
            string[] resourceNames = { "afford", "tame", "slow", "attempt", "juggle", "rail", "secret", "transport", "flippant", "dusty", "petite", "money", "afterthought", "grip", "grate", "hammer", "connection", "keen", "button", "rub", "anger", "pizzas", "straight", "successful", "tasteless", "explain", "hum", "kitty", "ball", "applaud", "baseball", "puffy", "wall" };

            //Randomly generated from a online generator
            string[] resoureURLs = { "http://www.example.edu/behavior.html", "http://www.example.com/", "https://example.com/argument.php", "https://example.com/", "https://example.com/advertisement", "http://www.example.com/#blade", "http://www.example.com/", "https://www.example.com/?ants=birthday&badge=addition#brick", "https://berry.example.com/", "https://www.example.com/approval/boat?aunt=bear", "http://example.com/", "https://www.example.org/afternoon/basin.htm", "http://www.example.com/", "http://bee.example.com/", "http://www.example.com/beginner", "http://behavior.example.com/beef", "http://www.example.com/?brother=birth#bottle", "http://www.example.com/?blade=brick", "https://approval.example.com/animal.html?bait=bait", "http://example.com/?brick=account", "http://www.example.com/", "http://example.com/achiever.php#amount", "http://www.example.com/board/blood.php", "https://www.example.org/baseball/border.html", "http://www.example.net/alarm/animal.php", "http://example.com/", "http://example.com/beef#breath", "http://www.example.com/", "https://example.org/", "http://www.example.com/", "https://birth.example.com/", "http://www.example.com/", "https://example.com/bell/animal" };

            string[] resourceTypes = { "Video", "Presentation", "Document", "Other" };

            for (int i = 0; i < numberOfResourceItems; i++)
            {
                var resource = new Resource
                {
                    Name = resourceNames[i],
                    ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType), resourceTypes[random.Next(1, 4)], true),
                    URL = resoureURLs[i],
                    CourseId = random.Next(1, numberOfCourseItems + 1),
                };

                if (IsValid(resource))
                {
                    resources.Add(resource);
                }
            }

            db.Homeworks.AddRange(homeworks);
            db.Resources.AddRange(resources);
            db.SaveChanges();

            var licenses = new List<License>();

            string[] licenseNames = { "WQKMXn4F", "cdk4ECg8", "sZ5N78pH", "fEv5enrr", "5De3eamF", "cMn6eHap", "RM6eWCph", "r9tSc7DX", "n3VoACHv", "8A9JzE5M", "WDCajA4n", "3Gkfqr2b", "R7hnfude", "CYEfQsSC", "SZFykbif", "aw8Gnc59", "8EVuTCKa", "5Po7wSSf", "YDaZfufP", "JHciEdzg", "oLtJQhQC", "vGqpp53Q", "ed2AoxhU", "7GjJzxgX", "hrkAsroi", "6nwNEEGZ", "uYUHo54P", "AbxLMV5s", "NNsZk5HB", "oCByNNVi", "sUbV8pZg", "84Hmbvvm", "6hyPY9Uc", "RT4UQshG", "ADQLak5B", "BQRPgYwM", "mRiPeHEN", "4VyzMF88", "5c3ns9R3", "TpqkdG2M", "8teskdmo", "aLnf6rgo", "bfQwugbT", "BUrmSjud", "hb7cMuSF", "tig4nupP", "u9sxMd25", "MPSwipFr", "NSpxUvWZ", "YcoRDzeu", "tWhWEQ2o", "q8rnVPpZ", "eubqgLkF", "fHojUi5S", "NcwqAt9a", "Zhm9nG99", "n8L7dvLi", "x7THCUUP", "ufnBXx43", "m6R4vJo6", "ZpYtsp9T", "9yT6w463", "BvJhvkev", "Zv8VVkdU", "yeHPyopw", "9mBP8Zgk", "7acbWbph", "wajzvgrp", "n4euRBY9", "Ni3hJZrP", "bB95sh92", "kWiTHMjj", "Xm2HizVT", "iBSUYwQz", "dCedBumC", "DCWriCXh", "uEcs2p2N", "LRLP2kPQ", "imaNQFaK", "JZWtZq7W", "TnSu552P", "9gaqYrkK", "Suzyo82G", "gUrmJcQN", "od8yqpqm", "Bcdou8m4", "keUF9HSj", "YaMKALHY", "Kygp6Ztb", "zwPHjvBy", "WvykP9qH", "e3D4Z2Hp", "WKqCzWUP", "UB33AsFp", "9NZJuycR", "e4jeKKcE", "P454a4dk", "HQ26pyyv", "iLdkXFzw", "xUwKVDaq", };

            for (int i = 0; i < numberOfLicenseItems; i++)
            {
                var license = new License
                {
                    Name = licenseNames[i],
                    ResourceId = random.Next(1, numberOfResourceItems + 1),
                };

                if (IsValid(license))
                {
                    licenses.Add(license);
                }
            }

            db.Licenses.AddRange(licenses);
            db.SaveChanges();
        }

        public void ListAllStudentsAndTheirHomeWorkSubmissions()
        {
            var studentsAndHomeworks = db.Students
                                         .Select(e => new
                                         {
                                             StudentName = e.Name,
                                             Homeworks = e.HomeworkSubmissions
                                                          .Select(z => new
                                                          {
                                                              HomeworkContent = z.Content,
                                                              HomeworkContentType = z.ContentType,
                                                          })
                                                          .ToList(),
                                         })
                                         .ToList();

            foreach (var student in studentsAndHomeworks)
            {
                Console.WriteLine($"Student Name: {student.StudentName}");
                Console.WriteLine("--Homeworks:");
                foreach (var homehork in student.Homeworks)
                {
                    Console.WriteLine($"-----Content: {homehork.HomeworkContent}");
                    Console.WriteLine($"-----Content Type: {homehork.HomeworkContentType}");
                    Console.WriteLine();
                }
            }
        }

        public void ListAllCoursesWithTheirCorrespondingResources()
        {
            var coursesAndResources = db.Courses
                                        .Select(e => new
                                        {
                                            CourseName = e.Name,
                                            CourseDescription = e.Description,
                                            CourseStartDate = e.StartDate,
                                            CourseEndDate = e.EndDate,
                                            CourseResources = e.Resources
                                                               .Select(z => new
                                                               {
                                                                   ResourceName = z.Name,
                                                                   Type = z.ResourceType,
                                                                   ResourceURL = z.URL,
                                                               })
                                                               .ToList(),
                                        })
                                        .OrderBy(e => e.CourseStartDate)
                                        .ThenByDescending(e => e.CourseEndDate)
                                        .ToList();

            foreach (var course in coursesAndResources)
            {
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine("--Resources: ");
                foreach (var resource in course.CourseResources)
                {
                    Console.WriteLine($"-----Resource Name: {resource.ResourceName}");
                    Console.WriteLine($"-----Resource Type: {resource.Type}");
                    Console.WriteLine($"-----Resource URL: {resource.ResourceURL}");
                    Console.WriteLine();
                }
            }
        }

        public void ListAllCoursesWithMoreThanFourResources()
        {
            var courses = db.Courses
                            .Where(e => e.Resources.Count > 4)
                            .Select(e => new
                            {
                                CourseName = e.Name,
                                ResourceCount = e.Resources.Count,
                                CourseStartDate = e.StartDate,
                            })
                            .OrderByDescending(e => e.ResourceCount)
                            .ThenByDescending(e => e.CourseStartDate)
                            .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.CourseName} Resource count: {course.ResourceCount}");
                Console.WriteLine();
            }
        }

        public void ListAllCoursesWhichWereActiveOnaGivenDate()
        {
            var dateAsString = "04/04/2007";

            var date = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var courses = db.Courses
                            .Where(e => e.StartDate <= date && e.EndDate >= date)
                            .Select(e => new
                            {
                                CourseName = e.Name,
                                CourseStartDate = e.StartDate,
                                CourseEndDate = e.EndDate,
                                Duration = (e.EndDate - e.StartDate).Days,
                                StudentsEnrolled = e.Students.Count
                            })
                            .OrderByDescending(e => e.StudentsEnrolled)
                            .ThenByDescending(e => e.Duration)
                            .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine($"--Start Date: {course.CourseStartDate}");
                Console.WriteLine($"--End Date: {course.CourseEndDate}");
                Console.WriteLine($"--Duration: {course.Duration} days");
                Console.WriteLine($"--Students Enrolled: {course.StudentsEnrolled}");
                Console.WriteLine();
            }
        }

        public void CalculateNumberOfCoursesAndTheirPrice()
        {
            var students = db.Students
                             .Select(e => new
                             {
                                 StudentName = e.Name,
                                 NumberOfCourses = e.Courses.Count,
                                 TotalPrice = e.Courses.Sum(z => z.Course.Price),
                                 AveragePrice = e.Courses.Average(z => z.Course.Price),
                             })
                             .OrderByDescending(e => e.TotalPrice)
                             .ThenByDescending(e => e.NumberOfCourses)
                             .ThenBy(e => e.StudentName)
                             .ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.StudentName}");
                Console.WriteLine($"--Number Of Courses: {student.NumberOfCourses}");
                Console.WriteLine($"--Total Price: {student.TotalPrice:F2} BGN");
                Console.WriteLine($"--Average Price : {student.AveragePrice:F2} BGN");
                Console.WriteLine();
            }
        }

        public void ListAllCoursesWithTheirCorrespondingResourcesAndLicenses()
        {
            var courses = db.Courses
                            .Select(e => new
                            {
                                CourseName = e.Name,
                                ResourceCount = e.Resources.Count,
                                CourseResources = e.Resources.Select(z => new
                                {
                                    ResourceName = z.Name,
                                    LicenseCount = z.Licences.Count,
                                    ResourceLicenses = z.Licences.Select(r => new
                                    {
                                        LicenseName = r.Name,
                                    })
                                    .ToList(),
                                })
                                .OrderByDescending(z => z.LicenseCount)
                                .ThenBy(z => z.ResourceName)
                                .ToList(),
                            })
                            .OrderByDescending(e => e.ResourceCount)
                            .ThenBy(e => e.CourseName)
                            .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine("-Resources:");
                Console.WriteLine();

                foreach (var resource in  course.CourseResources)
                {
                    Console.WriteLine($"--Resource Name: {resource.ResourceName}");
                    Console.WriteLine("---Licenses:");
                    Console.WriteLine();

                    foreach (var license in resource.ResourceLicenses)
                    {
                        Console.WriteLine($"-----License Name: {license.LicenseName}");
                    }

                    Console.WriteLine();
                }
            }
        }

        public void ListAllStudentsWithTheirCoursesResourcesAndLicenses()
        {
            var students = db.Students
                             .Select(e => new
                             {
                                 StudentName = e.Name,
                                 CoursesCount = e.Courses.Count,
                                 ResourcesCount = e.Courses.Sum(z => z.Course.Resources.Count),
                                 LicencesCount = e.Courses.Sum(z => z.Course.Resources.Sum(a => a.Licences.Count)),
                             })
                             .OrderByDescending(e => e.CoursesCount)
                             .ThenByDescending(e => e.ResourcesCount)
                             .ThenBy(e => e.StudentName)
                             .ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.StudentName}");
                Console.WriteLine($"--Courses Count: {student.CoursesCount}");
                Console.WriteLine($"--Resouces Count: {student.ResourcesCount}");
                Console.WriteLine($"--Licenses Count: {student.LicencesCount}");
                Console.WriteLine();
            }
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);

            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
