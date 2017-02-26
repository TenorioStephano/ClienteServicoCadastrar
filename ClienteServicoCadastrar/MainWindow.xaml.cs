using System;
using System.Windows;


namespace ClienteServicoCadastrar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        WSCadastrar.CrudServiceSoapClient ws = new WSCadastrar.CrudServiceSoapClient();

        private void btnSair_Click(object sender,RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnConsultar_Click(object sender,RoutedEventArgs e)
        {
            //ws.Consultar(txtId.Text);
            if(!txtId.Text.Equals(""))
            {
                var resposta = ws.Consultar(Int32.Parse(txtId.Text));
                if(resposta.Id == 0)
                {
                    ShowMessage("Código inválido!");
                    LimpaCampos();
                }
                else
                {
                    txtId.Text = resposta.Id.ToString();
                    txtEndereco.Text = resposta.Endereco;
                    txtNome.Text = resposta.Nome;
                    txtTelefone.Text = resposta.Telefone;
                }

            }
            else
            {
                ShowMessage("Por favor digite um código!");
            }
           
        }

        private void btnExcluir_Click(object sender,RoutedEventArgs e)
        {
            if(!txtId.Text.Equals(""))
            {
                ShowMessage(ws.Excluir(Int32.Parse(txtId.Text)));
                LimpaCampos();
            }
            else
            {
                ShowMessage("Por favor digite um código!");
            }
    
        }

        private void btnCadastrar_Click(object sender,RoutedEventArgs e)
        {
            if(!txtNome.Text.Equals("") && !txtTelefone.Text.Equals("") && !txtEndereco.Text.Equals(""))
            {
                ShowMessage(ws.Cadastrar(txtNome.Text,txtTelefone.Text,txtEndereco.Text));
                LimpaCampos();
            }else
            {
                ShowMessage("Os campos Nome, Telefone e Endereço são obrigatórios");
            }
            
        }

        public void LimpaCampos()
        {
            txtId.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void btnAlterar_Click(object sender,RoutedEventArgs e)
        {
            if(!txtNome.Text.Equals("") && !txtTelefone.Text.Equals("") && !txtEndereco.Text.Equals(""))
            {
                ShowMessage(ws.Alterar(Int32.Parse(txtId.Text),txtNome.Text,txtTelefone.Text,txtEndereco.Text));
                //LimpaCampos();
            }
            else
            {
                ShowMessage("Os campos Código, Nome, Telefone e Endereço são obrigatórios");
            }
            
        }
    }
}
