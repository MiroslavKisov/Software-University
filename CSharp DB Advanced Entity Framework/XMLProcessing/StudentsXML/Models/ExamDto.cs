namespace StudentsXML.Models
{
    using System.Xml.Serialization;

    [XmlType("exams")]
    public class ExamDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("datetaken")]
        public string DateTaken { get; set; }

        [XmlElement("grade")]
        public double Grade { get; set; }
    }
}
