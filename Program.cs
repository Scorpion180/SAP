using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Etapa1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            ListaVuelos lv = new ListaVuelos();
                using (Stream stream = File.Open("Vuelos.bin", FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    lv = (ListaVuelos)bformatter.Deserialize(stream);
                }
            VentanaPrincipalForm ventanaPrincipal = new VentanaPrincipalForm(lv);
            ventanaPrincipal.ShowDialog();
            File.Delete("Vuelos.bin");
            using (Stream sw = File.Open("Vuelos.bin", FileMode.Create))
               {
                   var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                   bformatter.Serialize(sw, lv);
                   sw.Close();
                }




        }
    }
}
