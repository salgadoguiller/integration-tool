using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IntegrationToolService
{
    public partial class IntegrationTool : ServiceBase
    {
        public IntegrationTool()
        {
            InitializeComponent();
          
        }
      
        protected override void OnStart(string[] args)
        {
            var timer = new Timer { AutoReset = true, Interval = 60000 };
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        protected override void OnStop()
        {

        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteFile writeFile = new WriteFile();
            writeFile.writeFileByString2("ğçşüexternal_course_key|course_id|course_name|term_keyñá|duration|master_course_key|new_data_source_key", "CHE101002|CHE101002|General Chemistry 2 002|201206|t|CHE101M|201206_COURSES", @"C:\Users\cturcios\Desktop", "COURSES");
            writeFile.writeIntegrationinExcel("iÝğçşüexternal_course_key|course_id|course_name|term_key|duration|master_course_key|new_data_source_key", "CHE101002|CHE101002|General Chemistry 2 002|201206|t|CHE101M|201206_COURSES", @"C:\Users\cturcios\Desktop", "COURSES");
           /* var processes = Process.GetProcessesByName("firefox");

            foreach (var process in processes)
            {
                process.CloseMainWindow();

                if (!process.HasExited)
                {
                    process.Kill();
                    process.Close();
                }
            }*/
        }
    }
}
