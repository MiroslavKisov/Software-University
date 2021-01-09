namespace StudentsXML.Models
{
    using System.Xml.Serialization;

    [XmlRoot("student")]
    [XmlType("student")]
    public class StudentDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("gender")]
        public string Gender { get; set; }

        [XmlElement("birthdate")]
        public string BirthDate { get; set; }

        [XmlElement("phonenumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("university")]
        public string University { get; set; }

        [XmlElement("specialty")]
        public string Specialty { get; set; }

        [XmlElement("facultynumber")]
        public string FacultyNumber { get; set; }

        [XmlArrayItem("exam")]
        public ExamDto[] exams { get; set; }
    }
}
