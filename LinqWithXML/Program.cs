using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXML {
    class Program {
        static void Main(string[] args) {
            string studentsXML = @"<Students>
                                     <Student>
                                        <Name>Peem</Name>
                                        <Age>21</Age>
                                        <University>Cambridge</University>
                                        <AreInYear>2015</AreInYear>            
                                     </Student>
                                     <Student>
                                        <Name>Carol</Name>
                                        <Age>17</Age>
                                        <University>Stanford</University>
                                        <AreInYear>2018</AreInYear>   
                                     </Student><Student>
                                        <Name>Daryl</Name>
                                        <Age>22</Age>
                                        <University>Stanford</University>
                                        <AreInYear>2014</AreInYear>   
                                     </Student>
                                     <Student>
                                        <Name>John</Name>
                                        <Age>20</Age>
                                        <University>Cambridge</University>
                                        <AreInYear>2015</AreInYear>            
                                     </Student>                  
                                   </Students>";
            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               AreInYear = student.Element("AreInYear").Value
                           };
            foreach (var student in students) {
                Console.WriteLine($"Student {student.Name} with Age {student.Age} from University {student.University} Are in year {student.AreInYear}");
            }

            var sortedStudents = from student in students orderby student.Age select student;
            foreach (var student in sortedStudents) {
                Console.WriteLine($"Student {student.Name} with age {student.Age} from University {student.University} Are in year {student.AreInYear}");
            }

            Console.ReadKey();
        }
    }
}
