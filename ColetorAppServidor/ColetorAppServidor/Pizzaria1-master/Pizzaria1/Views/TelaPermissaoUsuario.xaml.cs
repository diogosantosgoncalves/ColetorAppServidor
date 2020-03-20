using ColetorAppServidor.Models;
using ColetorAppServidor.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ColetorAppServidor.Views
{
    /// <summary>
    /// Interação lógica para PagePermissaoUsuario.xam
    /// </summary>
    public partial class TelaPermissaoUsuario : Window
    {
        ServicesDBSetorUsuario servicesDBSetorUsuario = new ServicesDBSetorUsuario();
        SetorUsuario setorUsuario = new SetorUsuario();
        public TelaPermissaoUsuario()
        {
            InitializeComponent();
        }
        public TelaPermissaoUsuario(int codigo)
        {
            InitializeComponent();
            setorUsuario = servicesDBSetorUsuario.Busca_Setor(codigo);
            txt_CodigoUsuario.Text = setorUsuario.setorusuario_id.ToString();
            txt_NomeUsuario.Text = setorUsuario.Usuario.usu_nome;
        }
    }
}
