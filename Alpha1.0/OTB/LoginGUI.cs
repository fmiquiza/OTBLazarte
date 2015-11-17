using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace OTB
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument Usuarios = XDocument.Load("C:/Users/Methos/Documents/GitHub/OTBLazarte/Alpha1.0/OTB/Base de Datos/Usuarios.xml");

            var listaUsuarios = from datosUser in Usuarios.Descendants("Usuario")
                                 select new
                                 {
                                     ID = int.Parse(datosUser.Attribute("ID").Value),
                                     USUARIO = datosUser.Element("usuario").Value,
                                     PASSWORD = datosUser.Element("password").Value,
                                     IDROL = datosUser.Element("idrol")
                                 };

            foreach (var item in listaUsuarios)
            {
                if (item.USUARIO.ToString() == textBox1.Text.ToString() && item.PASSWORD.ToString() == textBox2.Text.ToString())
                {
                    LoginGUI logui = new LoginGUI();
                    AdministradorGUI admingui = new AdministradorGUI();
                       
                    this.Hide();
                    admingui.ShowDialog();
                    this.Close(); 
                }
            }
        }
    }
}
