using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Curl
    {
        public void IntegrationWithCurl(string parameter)
        {
            try
            {
                //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
                //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).             
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + parameter);
              
                //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
                procStartInfo.CreateNoWindow = true;
                //Esconder la ventana
                procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //Inicializa el proceso
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();              
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Console.WriteLine(e.Message );
            }          
        }
    }
}
