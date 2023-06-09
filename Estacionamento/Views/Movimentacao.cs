using System;
using System.Windows.Forms;

namespace Views {
    
    public class Movimentacao {
        
        public static void ListarMovimentacoes() {
            Form movimentacoes = new Form();
            movimentacoes.Text = "Movimentacoes de Veículos";
            movimentacoes.Size = new System.Drawing.Size(700, 500);
            movimentacoes.StartPosition = FormStartPosition.CenterScreen;
            movimentacoes.FormBorderStyle = FormBorderStyle.FixedSingle;
            movimentacoes.MaximizeBox = false;
            movimentacoes.MinimizeBox = false;
            movimentacoes.BackColor = Color.BlueViolet;

            ListView listaMovimentacao = new ListView();
            listaMovimentacao.Size = new System.Drawing.Size(665, 400);
            listaMovimentacao.Location = new System.Drawing.Point(10, 10);
            listaMovimentacao.View = View.Details;
            listaMovimentacao.Columns.Add("Id", 100);
            listaMovimentacao.Columns.Add("Id Estacionamento", 150);
            listaMovimentacao.Columns.Add("Data Entrada", 210);
            listaMovimentacao.Columns.Add("Data Saída", 201);
            listaMovimentacao.FullRowSelect = true;
            listaMovimentacao.GridLines = true;

            List<Models.Movimentacao> movimentacoesList = (List<Models.Movimentacao>)Controllers.Movimentacao.BuscarMovimentacaos();
            foreach (Models.Movimentacao veiculo in movimentacoesList) {
                ListViewItem item = new ListViewItem(veiculo.Id.ToString());
                item.SubItems.Add(veiculo.IdEstacionamento.ToString());
                item.SubItems.Add(veiculo.DataEntrada.ToString());
                item.SubItems.Add(veiculo.DataSaida.ToString());
                listaMovimentacao.Items.Add(item);
            }

            Button btnAdicionar = new Button();
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.Top = 420;
            btnAdicionar.Left = 10;
            btnAdicionar.Font = new Font(btnAdicionar.Font.FontFamily, 18);
            btnAdicionar.BackColor = Color.White;
            btnAdicionar.ForeColor = Color.BlueViolet;
            btnAdicionar.Size = new System.Drawing.Size(150, 35);
            btnAdicionar.Click += (sender, e) => {
                //movimentacoes.Close();
                //movimentacoes.Dispose();
                CriarMovimentacao();
            };
            
            
            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Top = 420;
            btnEdit.Left = 181;
            btnEdit.Font = new Font(btnEdit.Font.FontFamily, 18);
            btnEdit.BackColor = Color.White;
            btnEdit.ForeColor = Color.BlueViolet;
            btnEdit.Size = new System.Drawing.Size(150, 35);
            btnEdit.Click += (sender, e) => {
                string id = listaMovimentacao.SelectedItems[0].Text;
                movimentacoes.Close();
                movimentacoes.Dispose();
                AlterarMovimentacao(Int32.Parse(id));
                movimentacoes.Close();
            };


            Button BtnRemove = new Button();
            BtnRemove.Text = "Remove";
            BtnRemove.Top = 420;
            BtnRemove.Left = 352;
            BtnRemove.Font = new Font(BtnRemove.Font.FontFamily, 18);
            BtnRemove.BackColor = Color.White;
            BtnRemove.ForeColor = Color.BlueViolet;
            BtnRemove.Size = new System.Drawing.Size(150, 35);
            BtnRemove.Click += (sender, e) => {
                string id = listaMovimentacao.SelectedItems[0].Text;
                ExcluirMovimentacao(Int32.Parse(id));
                movimentacoes.Dispose();
                movimentacoes.Close();
            };

            Button BtnVoltar = new Button();
            BtnVoltar.Text = "Voltar";
            BtnVoltar.Top = 420;
            BtnVoltar.Left = 523;
            BtnVoltar.Font = new Font(BtnVoltar.Font.FontFamily, 18);
            BtnVoltar.BackColor = Color.White;
            BtnVoltar.ForeColor = Color.BlueViolet;
            BtnVoltar.Size = new System.Drawing.Size(150, 35);
            BtnVoltar.Click += (sender, e) => {
                movimentacoes.Hide();
                movimentacoes.Close();
                movimentacoes.Dispose();
            };

            movimentacoes.Controls.Add(listaMovimentacao);
            movimentacoes.Controls.Add(btnAdicionar);
            movimentacoes.Controls.Add(btnEdit);
            movimentacoes.Controls.Add(BtnRemove);
            movimentacoes.Controls.Add(BtnVoltar);
            movimentacoes.ShowDialog();
        } 

          public static void CriarMovimentacao() {
            Form adicionarMovimentacao = new Form();
            adicionarMovimentacao.Text = "Adicionar Movimentacao de veículo";
            adicionarMovimentacao.Size = new System.Drawing.Size(600, 450);
            adicionarMovimentacao.StartPosition = FormStartPosition.CenterScreen;
            adicionarMovimentacao.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionarMovimentacao.MaximizeBox = false;
            adicionarMovimentacao.MinimizeBox = false;
            adicionarMovimentacao.BackColor = Color.BlueViolet;

            Label lblId= new Label();
            lblId.Text = "Id:";
            lblId.Top = 25;
            lblId.Left = 10;
            lblId.ForeColor = Color.White;
            lblId.Font = new Font(lblId.Font.FontFamily, 18);
            lblId.Size = new System.Drawing.Size(250, 50);

            TextBox txtId = new TextBox();
            txtId.Top = 32;
            txtId.Left = 270;
            txtId.BackColor = Color.LightGray;
            txtId.Size = new System.Drawing.Size(300, 35);

            Label lblIdEstacionamento = new Label();
            lblIdEstacionamento.Text = "Id Estacionamento:";
            lblIdEstacionamento.Top = 70;
            lblIdEstacionamento.Left = 10;
            lblIdEstacionamento.ForeColor = Color.White;
            lblIdEstacionamento.Font = new Font(lblIdEstacionamento.Font.FontFamily, 18);
            lblIdEstacionamento.Size = new System.Drawing.Size(250, 35);

            TextBox txtIdEstacionamento = new TextBox();
            txtIdEstacionamento.Top = 77;
            txtIdEstacionamento.Left = 270;
            txtIdEstacionamento.BackColor = Color.LightGray;
            txtIdEstacionamento.Size = new System.Drawing.Size(300, 35);

            Label lblDataEntrada = new Label();
            lblDataEntrada.Text = "Data Entrada:";
            lblDataEntrada.Top = 115;
            lblDataEntrada.Left = 10;
            lblDataEntrada.ForeColor = Color.White;
            lblDataEntrada.Font = new Font(lblDataEntrada.Font.FontFamily, 18);
            lblDataEntrada.Size = new System.Drawing.Size(250, 35);

            TextBox txtDataEntrada = new TextBox();
            txtDataEntrada.Top = 122;
            txtDataEntrada.Left = 270;
            txtDataEntrada.BackColor = Color.LightGray;
            txtDataEntrada.Size = new System.Drawing.Size(300, 35);

            Label lblDataSaida = new Label();
            lblDataSaida.Text = "Data Saída:";
            lblDataSaida.Top = 160;
            lblDataSaida.Left = 10;
            lblDataSaida.ForeColor = Color.White;
            lblDataSaida.Font = new Font(lblDataSaida.Font.FontFamily, 18);
            lblDataSaida.Size = new System.Drawing.Size(250, 35);

            TextBox txtDataSaida = new TextBox();
            txtDataSaida.Top = 167;
            txtDataSaida.Left = 270;
            txtDataSaida.BackColor = Color.LightGray;
            txtDataSaida.Size = new System.Drawing.Size(300, 35);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 330;
            btnSalvar.Left = 70;
            btnSalvar.BackColor = Color.White;
            btnSalvar.ForeColor = Color.BlueViolet;
            btnSalvar.Font = new Font(btnSalvar.Font.FontFamily, 18);
            btnSalvar.Size = new System.Drawing.Size(150, 35);
            btnSalvar.Click += (sender, e) => {
                try
                {
                    Controllers.Movimentacao.CriarMovimentacao(int.Parse(txtId.Text), int.Parse(txtIdEstacionamento.Text), txtDataEntrada.Text, txtDataSaida.Text);
                    adicionarMovimentacao.Hide();
                    adicionarMovimentacao.Close();
                    adicionarMovimentacao.Dispose();
                    ListarMovimentacoes();
                }
                catch (Exception err)
                {
                    MessageBox.Show($"Erro ao adicionar produto: {err.Message}");
                }
                finally 
                {
                    adicionarMovimentacao.Hide();
                    adicionarMovimentacao.Close();
                    adicionarMovimentacao.Dispose();
                    ListarMovimentacoes();                    
                }
                               
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 330;
            btnCancelar.Left = 360;
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.BlueViolet;
            btnCancelar.Font = new Font(btnCancelar.Font.FontFamily, 18);
            btnCancelar.Size = new System.Drawing.Size(150, 35);
            btnCancelar.Click += (sender, e) => {
                adicionarMovimentacao.Close();
            };

            adicionarMovimentacao.Controls.Add(lblId);
            adicionarMovimentacao.Controls.Add(txtId);
            adicionarMovimentacao.Controls.Add(lblIdEstacionamento);
            adicionarMovimentacao.Controls.Add(txtIdEstacionamento);
            adicionarMovimentacao.Controls.Add(lblDataEntrada);
            adicionarMovimentacao.Controls.Add(txtDataEntrada);
            adicionarMovimentacao.Controls.Add(lblDataSaida);
            adicionarMovimentacao.Controls.Add(txtDataSaida);
            adicionarMovimentacao.Controls.Add(btnSalvar);
            adicionarMovimentacao.Controls.Add(btnCancelar);
            adicionarMovimentacao.ShowDialog();
        }


        public static void AlterarMovimentacao(int id) {
            Models.Movimentacao veiculo = Controllers.Movimentacao.BuscarMovimentacao(id);
            Form editar = new Form();
            editar.Text = "Editar Movimentacao de veículo";
            editar.Size = new System.Drawing.Size(600, 450);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;
            editar.BackColor = Color.BlueViolet;

            Label lblId= new Label();
            lblId.Text = "Id:";
            lblId.Top = 25;
            lblId.Left = 10;
            lblId.ForeColor = Color.White;
            lblId.Font = new Font(lblId.Font.FontFamily, 18);
            lblId.Size = new System.Drawing.Size(130, 35);

            TextBox txtId = new TextBox();
            txtId.Top = 32;
            txtId.Left = 140;
            txtId.BackColor = Color.LightGray;
            txtId.Size = new System.Drawing.Size(230, 35);
            txtId.Text = veiculo.Id.ToString();
            txtId.ReadOnly = true;
            txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;

            Label lblIdEstacionamento = new Label();
            lblIdEstacionamento.Text = "Id Estacionamento:";
            lblIdEstacionamento.Top = 60;
            lblIdEstacionamento.Left = 10;
            lblIdEstacionamento.ForeColor = Color.White;
            lblIdEstacionamento.Font = new Font(lblIdEstacionamento.Font.FontFamily, 18);
            lblIdEstacionamento.Size = new System.Drawing.Size(130, 35);

            TextBox txtIdEstacionamento = new TextBox();
            txtIdEstacionamento.Top = 67;
            txtIdEstacionamento.Left = 140;
            txtIdEstacionamento.BackColor = Color.LightGray;
            txtIdEstacionamento.Size = new System.Drawing.Size(230, 35);

            Label lblDataEntrada = new Label();
            lblDataEntrada.Text = "Data Entrada:";
            lblDataEntrada.Top = 85;
            lblDataEntrada.Left = 10;
            lblDataEntrada.ForeColor = Color.White;
            lblDataEntrada.Font = new Font(lblDataEntrada.Font.FontFamily, 18);
            lblDataEntrada.Size = new System.Drawing.Size(130, 35);

            TextBox txtDataEntrada = new TextBox();
            txtDataEntrada.Top = 92;
            txtDataEntrada.Left = 140;
            txtDataEntrada.BackColor = Color.LightGray;
            txtDataEntrada.Size = new System.Drawing.Size(230, 35);

            Label lblDataSaida = new Label();
            lblDataSaida.Text = "Data Saída:";
            lblDataSaida.Top = 120;
            lblDataSaida.Left = 10;
            lblDataSaida.ForeColor = Color.White;
            lblDataSaida.Font = new Font(lblDataSaida.Font.FontFamily, 18);
            lblDataSaida.Size = new System.Drawing.Size(130, 35);

            TextBox txtDataSaida = new TextBox();
            txtDataSaida.Top = 127;
            txtDataSaida.Left = 140;
            txtDataSaida.BackColor = Color.LightGray;
            txtDataSaida.Size = new System.Drawing.Size(230, 35);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 330;
            btnSalvar.Left = 70;
            btnSalvar.BackColor = Color.White;
            btnSalvar.ForeColor = Color.BlueViolet;
            btnSalvar.Font = new Font(btnSalvar.Font.FontFamily, 18);
            btnSalvar.Size = new System.Drawing.Size(150, 35);
            btnSalvar.Click += (sender, e) => {
                Controllers.Movimentacao.AlterarMovimentacao(int.Parse(txtId.Text), int.Parse(txtIdEstacionamento.Text), txtDataEntrada.Text, txtDataSaida.Text);
                editar.Hide();
                editar.Close();
                editar.Dispose();
                ListarMovimentacoes();
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 330;
            btnCancelar.Left = 360;
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.BlueViolet;
            btnCancelar.Font = new Font(btnCancelar.Font.FontFamily, 18);
            btnCancelar.Size = new System.Drawing.Size(150, 35);
            btnCancelar.Click += (sender, e) => {
                editar.Close();
                editar.Dispose();
            };

            editar.Controls.Add(lblId);
            editar.Controls.Add(txtId);
            editar.Controls.Add(lblIdEstacionamento);
            editar.Controls.Add(txtIdEstacionamento);
            editar.Controls.Add(lblDataEntrada);
            editar.Controls.Add(txtDataEntrada);
            editar.Controls.Add(lblDataSaida);
            editar.Controls.Add(txtDataSaida);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnCancelar);
            editar.ShowDialog();
    }


    public static void ExcluirMovimentacao(int id) {

        Form remove = new Form();
        remove.Text = "Remover";
        remove.Size = new System.Drawing.Size(188, 83);
        remove.StartPosition = FormStartPosition.CenterScreen;
        remove.FormBorderStyle = FormBorderStyle.FixedSingle;
        remove.MaximizeBox = false;
        remove.MinimizeBox = false;

        Button sim = new Button();
        sim.Text = "Sim";
        sim.Top = 10;
        sim.Left = 10;
        sim.Size = new System.Drawing.Size(70, 25);
        sim.Click += (sender, e) => {
            Controllers.Movimentacao.ExcluirMovimentacao(id);
            remove.Close();
            remove.Dispose();
            ListarMovimentacoes();          
        };

        Button nao = new Button();
        nao.Text = "Não";
        nao.Top = 10;
        nao.Left = 90;
        nao.Size = new System.Drawing.Size(70, 25);
        nao.Click += (sender, e) => {
            remove.Hide();
            remove.Close();
            remove.Dispose();
            ListarMovimentacoes();
        };

        remove.Controls.Add(sim);
        remove.Controls.Add(nao);   
        remove.ShowDialog();
        }
    }
}