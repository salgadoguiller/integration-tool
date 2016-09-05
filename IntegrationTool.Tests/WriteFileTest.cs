using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  NUnit.Framework;
using IntegrationTool.Controllers;

namespace IntegrationTool.Tests
{
    [TestFixture]
    class WriteFileTest
    {            
        [TestCase("external_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "BIO652001|BIO652001|Microbiology|201206|t||201206_COURSES", @"C:\Users\cturcios\Desktop\COURSES.txt")]
        [TestCase("external_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "CHE101M|CHE101M|General Chemistry 2 Master|201206|t||201206_COURSES", @"C:\Users\cturcios\Desktop\COURSES.txt")]
        [TestCase("external_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "HIS100001|HIS100001|Western Civilization 1|201206|t||201206_COURSES", @"C:\Users\cturcios\Desktop\COURSES.txt")]
        [TestCase("external_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "CHE101001|CHE101001|General Chemistry 2 001|201206|t|CHE101M|201206_COURSES", @"C:\Users\cturcios\Desktop\COURSES.txt")]
        [TestCase("external_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "CHE101002|CHE101002|General Chemistry 2 002|201206|t|CHE101M|201206_COURSES", @"C:\Users\cturcios\Desktop\COURSES.txt")]       
        public void WriteInFile(string headers, string resultQuery,string location)
        {           
            WriteFileController file = new WriteFileController();
            file.writeFileByString(headers, resultQuery,location);
        }

       
        [TestCase("external_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "CHE101002|CHE101002|General Chemistry 2 002|201206|t|CHE101M|201206_COURSES", @"C:\Users\cturcios\Desktop","COURSES")]
        public void WriteInFile2(string headers, string resultQuery, string location,string nameIntegration)
        {
            WriteFileController file = new WriteFileController();
            file.writeFileByString2(headers, resultQuery, location,nameIntegration);
        }

        [Test]
        public void writeFileinExcel()
        {
            WriteFileController file = new WriteFileController();
            file.writeIntegrationinExcel("external_course_key|course_id|course_name|term_key|duration|master_course_key|new_data_source_key", "CHE101002|CHE101002|General Chemistry 2 002|201206|t|CHE101M|201206_COURSES", @"C:\Users\cturcios\Desktop", "COURSES");
        }

       
    }
}
