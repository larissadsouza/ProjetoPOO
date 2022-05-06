using n2.Veículos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n2
{
    public partial class Form1 : Form
    {
        public List<Marca> marcas = new List<Marca>();
        public List<Modelo> modelos = new List<Modelo>();
        public List<Veiculo> lista = new List<Veiculo>();
        public Veiculo pesquisado = null;
        public Form1()
        {
            InitializeComponent();

        }

        public void AtualizaModelos()
        {
            lbModelos.Items.Clear();
            foreach (Modelo model in modelos)
            {
                lbModelos.Items.Add(model.Codigo + " - " + model.Descricao + " - " + model.Marca.Descricao);
            }
        }
        public void AtualizaMarcas()
        {
            lbMarcas.Items.Clear();
            foreach(Marca marc in marcas)
            {
                lbMarcas.Items.Add(marc.Codigo + " - " + marc.Descricao);
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            try
            {
                Marca m = new Marca();
                m.Codigo = Convert.ToInt32(ndCodMarca.Value);
                m.Descricao = txtDescMarca.Text;

                foreach (Marca marca in marcas)
                {
                    if (marca.Codigo == ndCodMarca.Value)
                    {
                        MessageBox.Show("Código já cadastrado");
                        return;
                    }
                    if (marca.Descricao.ToUpper() == txtDescMarca.Text.ToUpper())
                    {
                        MessageBox.Show("Marca já cadastrada");
                        return;
                    }

                }
                marcas.Add(m);
                AtualizaMarcas();

                txtDescMarca.Clear();
                MessageBox.Show("Cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo m = new Modelo();
                m.Codigo = Convert.ToInt32(ndCodModel.Value);
                m.Descricao = txtDescModel.Text;

                if (lbMarcas.Items.Count == 0 || lbMarcas.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione a marca correspondente primeiro!");
                    return;
                }
                foreach (Modelo mod in modelos)
                {
                    if (mod.Codigo == ndCodModel.Value)
                    {
                        MessageBox.Show("Código já cadastrado");
                        return;
                    }
                    if (mod.Descricao.ToUpper() == txtDescModel.Text.ToUpper())
                    {
                        MessageBox.Show("Modelo já cadastrado");
                        return;
                    }

                }
                foreach (string marca in lbMarcas.SelectedItems)
                {
                    string codigoMarca = marca.Split('-')[0].Trim();
                    m.Marca = marcas.Find(c => c.Codigo == Convert.ToInt32(codigoMarca));
                }
                modelos.Add(m);
                AtualizaModelos();
                txtDescModel.Clear();
                MessageBox.Show("Cadastrado com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }



        private void C_EscreverNaTela(object sender, Veículos.DispararEventArgs e)
        {
            txtResumao.Text += Environment.NewLine + e.FraseEvento;
        }


        public void InstanciaMarca()
        {
            Marca m = new Marca();
            m.Codigo = 1;
            m.Descricao = "Marca Top";
        }

        private void btnTotaldePedagio_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            txtResumao.Text = Convert.ToString(Pedagio.ValorTotalRecebido);
        }

        private void btnAcionarLimpador_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            if (lista.Count == 0)
            {
                MessageBox.Show("Não há veículos cadastrados");
                return;
            }
            bool acao = false;
            foreach (Veiculo v in lista)
            {
                if (v is IVeiculosComParabrisa)
                {
                    if (v is Carro)
                    {
                        (v as Carro).limpador = true;
                        txtResumao.Text += Environment.NewLine + "Veículo " + v.Identificacao + " acionou o limpador";
                    }
                    if (v is Caminhao)
                    {
                        (v as Caminhao).limpador = true;
                        txtResumao.Text += Environment.NewLine + "Veículo " + v.Identificacao + " acionou o limpador";
                    }
                    if (v is Onibus)
                    {
                        (v as Onibus).limpador = true;
                        txtResumao.Text += Environment.NewLine + "Veículo " + v.Identificacao + " acionou o limpador";
                    }
                    if (v is Aviao)
                    {
                        (v as Aviao).limpador = true;
                        txtResumao.Text += Environment.NewLine + "Veículo " + v.Identificacao + " acionou o limpador";
                    }
                    if (v is Trem)
                    {
                        (v as Trem).limpador = true;
                        txtResumao.Text += Environment.NewLine + "Veículo " + v.Identificacao + " acionou o limpador";
                    }

                    acao = true;
                }
            }
            if (acao == false)
            {
                MessageBox.Show("Não haviam veículos com parabrisa cadastrados");
            }

        }


        private void btnAtracarcomTodos_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            if (lista.Count == 0)
            {
                MessageBox.Show("Não há veículos cadastrados");
                return;
            }
            bool acao = false;
            foreach (Veiculo v in lista)
            {
                if (v is INavios)
                {
                    (v as INavios).Atracar();
                    acao = true;
                }
            }
            if (acao == false)
            {
                MessageBox.Show("Não haviam navios cadastradas");
            }

        }

        private void btnAtacarcomTodos_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            if (lista.Count == 0)
            {
                MessageBox.Show("Não há veículos cadastrados");
                return;
            }
            bool acao = false;
            foreach (Veiculo v in lista)
            {
                if (v is IGuerra)
                {
                    (v as IGuerra).Atacar();
                    acao = true;
                }
            }
            if (acao == false)
            {
                MessageBox.Show("Não haviam veículos de guerra cadastradas");
            }

        }

        private void btnEmpinarcomTodos_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            if (lista.Count == 0)
            {
                MessageBox.Show("Não há veículos cadastrados");
                return;

            }
            bool acao = false;
            foreach (Veiculo v in lista)
            {
                if (v is Moto)
                {
                    (v as Moto).Empinar();
                    acao = true;
                }
            }
            if (acao == false)
            {
                MessageBox.Show("Não haviam motos cadastradas");
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            string descricao = "";
            foreach (Veiculo v in lista)
            {
                descricao += v.ToString() + Environment.NewLine;

            }
            txtResumao.Text = descricao;
        }


        private void btnCriarAviao_Click(object sender, EventArgs e)
        {
            try
            {
                Aviao a = new Aviao();
                a.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    a.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }

                if ((rbLimpadorAviao.Checked ? true : false))
                    a.LigaDesligaLimpador();
                a.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                a.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == a.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(a);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarTrem_Click(object sender, EventArgs e)
        {
            try
            {
                Trem t = new Trem();
                t.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    t.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }
                t.QuantidadeDeVagoes = Convert.ToInt32(ndQtddeVagoes.Value);
                if ((rbLimpadorTrem.Checked ? true : false))
                    t.LigaDesligaLimpador();
                t.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                t.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == t.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(t);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarAGuerra_Click(object sender, EventArgs e)
        {
            try
            {
                AviaodeGuerra av = new AviaodeGuerra();
                av.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    av.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }

                av.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                av.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == av.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(av);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarNavio_Click(object sender, EventArgs e)
        {
            try
            {
                Navio n = new Navio();
                n.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    n.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }

                n.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                n.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == n.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(n);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarNGuerra_Click(object sender, EventArgs e)
        {
            try
            {
                NaviodeGuerra na = new NaviodeGuerra();
                na.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    na.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }

                na.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                na.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == na.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(na);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
        }

        private void btnCriarCar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Carro c = new Carro();
                c.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    c.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }
                c.Quantidadeportas = Convert.ToInt32(ndQtdPortas.Value);
                if ((rbLimpador.Checked ? true : false))
                    c.LigaDesligaLimpador();
                c.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                c.EscreverNaTela += C_EscreverNaTela;

                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == c.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(c);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarOnibus_Click_1(object sender, EventArgs e)
        {
            try
            {
                Onibus o = new Onibus();
                o.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    o.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }

                if ((rbLimpadorOnibus.Checked ? true : false))
                    o.LigaDesligaLimpador();

                o.Leito = ((rbLeito.Checked ? true : false));
                o.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                o.Quantidadedeeixos = Convert.ToInt32(ndQtdEixosOnibus.Value);
                o.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == o.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(o);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarMoto_Click_1(object sender, EventArgs e)
        {
            try
            {
                Moto m = new Moto();
                m.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    m.Modeloveiculo = modelos.Find(k => k.Codigo == Convert.ToInt32(codigoModel));
                }

                m.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                m.EscreverNaTela += C_EscreverNaTela;
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == m.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(m);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCriarCaminhao_Click_1(object sender, EventArgs e)
        {
            try
            {
                Caminhao c = new Caminhao();
                c.Identificacao = txtIdentificacao.Text;

                if (lbModelos.Items.Count == 0 || lbModelos.SelectedIndex == -1)
                {
                    MessageBox.Show("Cadastre/Selecione o modelo primeiro!");
                    return;
                }
                foreach (string modelo in lbModelos.SelectedItems)
                {
                    string codigoModel = modelo.Split('-')[0].Trim();
                    c.Modeloveiculo = modelos.Find(m => m.Codigo == Convert.ToInt32(codigoModel));
                }

                if ((rbLimpadorCaminhao.Checked ? true : false))
                    c.LigaDesligaLimpador();
                c.Capacidadepassageiros = Convert.ToInt32(ndNumPassageiro.Value);
                c.EscreverNaTela += C_EscreverNaTela;
                c.Pesocarregado = Convert.ToInt32(ndPesoCarregado.Value);
                c.Quantidadedeeixos = Convert.ToInt32(ndQtddeEixos.Value);
                c.Capacidadepeso = Convert.ToInt32(ndCapacidadeMaxima);
                foreach (Veiculo v in lista)
                {
                    if (v.Identificacao == c.Identificacao)
                    {
                        MessageBox.Show("Veículo já cadastrado");
                        return;
                    }

                }
                lista.Add(c);
                txtIdentificacao.Clear();

                MessageBox.Show("Criado!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            pesquisado = lista.Find(v => v.Identificacao.Trim().ToUpper().Equals(txtPesquisa.Text.Trim().ToUpper()));

            if (pesquisado == null)
                MessageBox.Show("Não encontrado!");
            else
            {
                txtPesquisado.Clear();
                txtPesquisado.Text = pesquisado.ToString();
            }
        }
        public void AtualizaVeiculo()
        {
            txtPesquisado.Text = pesquisado.ToString();
        }

        private void btnCarregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (pesquisado == null)
                {
                    MessageBox.Show("Pesquise um veículo primeiro!");
                    return;
                }
                if (ndPeso.Value == 0)
                {
                    MessageBox.Show("Preencha um peso a ser carregado");
                    return;
                }

                if (pesquisado is Caminhao)
                {
                    (pesquisado as Caminhao).Carregarpeso(Convert.ToDouble(ndPeso.Text));
                    AtualizaVeiculo();
                }
                else
                    MessageBox.Show("Não é um caminhão");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnDescarregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (pesquisado == null)
                {
                    MessageBox.Show("Pesquise um veículo primeiro!");
                    return;
                }

                if (pesquisado is Caminhao)
                {
                    (pesquisado as Caminhao).Descarregar();
                    AtualizaVeiculo();
                }

                else
                    MessageBox.Show("Não é um caminhão");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAtacar_Click_1(object sender, EventArgs e)
        {
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is IGuerra)
                (pesquisado as IGuerra).Atacar();
            else
                MessageBox.Show("Não é um veículo de guerra");
        }


        private void btnEjetar_Click_1(object sender, EventArgs e)
        {
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is AviaodeGuerra)
                (pesquisado as AviaodeGuerra).Ejetar();
            else
                MessageBox.Show("Não é um avião de guerra");
        }

        private void btnAtracar_Click_1(object sender, EventArgs e)
        {
            txtResumao.Clear();
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is INavios)
                (pesquisado as INavios).Atracar();
            else
                MessageBox.Show("Não é um navio");
        }

        private void btnAcelera_Click_1(object sender, EventArgs e)
        {
            txtResumao.Clear();
            try
            {
                if (pesquisado == null)
                {
                    MessageBox.Show("Pesquise um veículo primeiro!");
                    return;
                }
                pesquisado.Acelerar();
                AtualizaVeiculo();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnDesacelera_Click_1(object sender, EventArgs e)
        {
            txtResumao.Clear();
            try
            {
                if (pesquisado == null)
                {
                    MessageBox.Show("Pesquise um veículo primeiro!");
                    return;
                }
                pesquisado.Desacelerar();
                AtualizaVeiculo();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnDecolar_Click_1(object sender, EventArgs e)
        {
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is IAviões)
                (pesquisado as IAviões).Decolar();
            else
                MessageBox.Show("Não é um avião");
        }

        private void btnPedagio_Click_1(object sender, EventArgs e)
        {
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is IVeiculosPagamPedagio)
                Pedagio.Receber(pesquisado);
            else
                MessageBox.Show("Não é um veículo que paga pedágio");
        }

        private void btnLimpador_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (pesquisado == null)
                {
                    MessageBox.Show("Pesquise um veículo primeiro!");
                    return;
                }

                if (pesquisado is IVeiculosComParabrisa)
                    (pesquisado as IVeiculosComParabrisa).LigaDesligaLimpador();
                else
                    MessageBox.Show("Veículo não possui limpador");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnEmpinar_Click_1(object sender, EventArgs e)
        {

            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is Moto)
                (pesquisado as Moto).Empinar();
            else
                MessageBox.Show("Não é uma moto");
        }

        private void btnArremeter_Click_1(object sender, EventArgs e)
        {
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is IAviões)
                (pesquisado as IAviões).Arremeter();
            else
                MessageBox.Show("Não é um avião");
        }

        private void btnPagarPedagio_Click(object sender, EventArgs e)
        {
            txtResumao.Clear();
            if (lista.Count == 0)
            {
                MessageBox.Show("Não há veículos cadastrados");
                return;
            }
            bool acao = false;
            foreach (Veiculo v in lista)
            {
                if (v is IVeiculosPagamPedagio)
                {
                    Pedagio.Receber(v);
                    acao = true;
                }
                if (acao == false)
                    MessageBox.Show("Não haviam veículos que pagam pedágio cadastrados");
            }
        }

        private void btnPousar_Click_1(object sender, EventArgs e)
        {
            if (pesquisado == null)
            {
                MessageBox.Show("Pesquise um veículo primeiro!");
                return;
            }

            if (pesquisado is IAviões)
                (pesquisado as IAviões).Pousar();
            else
                MessageBox.Show("Não é um avião");
        }

        private void btnInstanciar_Click(object sender, EventArgs e)
        {
            btnInstanciar.Enabled = false;
            {
                Marca ma = new Marca();
                ma.Codigo = 1;
                ma.Descricao = "VW";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo m = new Modelo();
                m.Codigo = 1;
                m.Descricao = "Gol";
                m.Marca = marcas[0];
                modelos.Add(m);

                Carro c = new Carro();
                c.Identificacao = "Carro";
                c.Modeloveiculo = modelos[0];
                c.Quantidadeportas = 4;
                c.limpador = true;
                c.Capacidadepassageiros = 5;
                c.EscreverNaTela += C_EscreverNaTela;
                lista.Add(c);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 2;
                ma.Descricao = "Mercedes-Benz";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo m = new Modelo();
                m.Codigo = 2;
                m.Descricao = "Actros";
                m.Marca = marcas[1];
                modelos.Add(m);

                Caminhao c = new Caminhao();
                c.Identificacao = "Caminhao";
                c.Modeloveiculo = modelos[1];
                c.limpador = true;
                c.Pesocarregado = 100;
                c.Quantidadedeeixos = 2;
                c.Capacidadepassageiros = 3;
                c.Capacidadepeso = 500;
                c.EscreverNaTela += C_EscreverNaTela;
                lista.Add(c);
            }
            {

                Modelo m = new Modelo();
                m.Codigo = 3;
                m.Descricao = "OF 1721";
                m.Marca = marcas[1];
                modelos.Add(m);

                Onibus o = new Onibus();
                o.Identificacao = "Onibus";
                o.modeloveiculo = modelos[2];
                o.limpador = false;
                o.Leito = true;
                o.Quantidadedeeixos = 2;
                o.Capacidadepassageiros = 30;
                o.EscreverNaTela += C_EscreverNaTela;
                lista.Add(o);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 3;
                ma.Descricao = "Honda";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo mo = new Modelo();
                mo.Codigo = 4;
                mo.Descricao = "CG 150";
                mo.Marca = marcas[2];
                modelos.Add(mo);

                Moto m = new Moto();
                m.Identificacao = "Moto";
                m.Modeloveiculo = modelos[3];
                m.Capacidadepassageiros = 2;
                m.EscreverNaTela += C_EscreverNaTela;
                lista.Add(m);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 4;
                ma.Descricao = "Airbus";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo mo = new Modelo();
                mo.Codigo = 5;
                mo.Descricao = "A 380";
                mo.Marca = marcas[3];
                modelos.Add(mo);

                Aviao a = new Aviao();
                a.Identificacao = "Aviao";
                a.Modeloveiculo = modelos[4];
                a.Capacidadepassageiros = 500;
                a.limpador = true;
                a.EscreverNaTela += C_EscreverNaTela;
                lista.Add(a);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 5;
                ma.Descricao = "North American Aviation";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo mo = new Modelo();
                mo.Codigo = 6;
                mo.Descricao = "P-51 Mustang";
                mo.Marca = marcas[4];
                modelos.Add(mo);

                AviaodeGuerra av = new AviaodeGuerra();
                av.Identificacao = "Aviao de Guerra";
                av.Modeloveiculo = modelos[5];
                av.Capacidadepassageiros = 1;
                av.EscreverNaTela += C_EscreverNaTela;
                lista.Add(av);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 6;
                ma.Descricao = "Hyundai Rotem";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo mo = new Modelo();
                mo.Codigo = 7;
                mo.Descricao = "TUE";
                mo.Marca = marcas[5];
                modelos.Add(mo);

                Trem t = new Trem();
                t.Identificacao = "Trem";
                t.Modeloveiculo = modelos[6];
                t.Capacidadepassageiros = 250;
                t.QuantidadeDeVagoes = 3;
                t.limpador = true;
                t.EscreverNaTela += C_EscreverNaTela;
                lista.Add(t);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 7;
                ma.Descricao = "STX Europe";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo mo = new Modelo();
                mo.Codigo = 8;
                mo.Descricao = "Oasis of the Seas";
                mo.Marca = marcas[6];
                modelos.Add(mo);

                Navio n = new Navio();
                n.Identificacao = "Navio";
                n.Modeloveiculo = modelos[7];
                n.Capacidadepassageiros = 6296;
                n.EscreverNaTela += C_EscreverNaTela;
                lista.Add(n);
            }
            {
                Marca ma = new Marca();
                ma.Codigo = 8;
                ma.Descricao = "Blohm & Voss";
                marcas.Add(ma);
                lbMarcas.Items.Add(ma.Codigo + " - " + ma.Descricao);

                Modelo mo = new Modelo();
                mo.Codigo = 9;
                mo.Descricao = "Bismarck";
                mo.Marca = marcas[7];
                modelos.Add(mo);

                NaviodeGuerra nv = new NaviodeGuerra();
                nv.Identificacao = "Navio de Guerra";
                nv.Modeloveiculo = modelos[8];
                nv.Capacidadepassageiros = 2200;
                nv.EscreverNaTela += C_EscreverNaTela;
                lista.Add(nv);

                MessageBox.Show("Feito!");
                btnExibir.PerformClick();
                AtualizaModelos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string descricao = "";
            if (File.Exists("dados.txt"))
            {
                File.Delete("dados.txt");
            }
            foreach (Veiculo v in lista)
            {
                descricao += v.Identificacao + "|" +
                    v.Modeloveiculo.Codigo + "-" + v.Modeloveiculo.Descricao + "|"
                    + v.Modeloveiculo.Marca.Codigo + "-" + v.Modeloveiculo.Marca.Descricao + "|" +
                    v.Capacidadepassageiros + "|" + v.Velocidadeatual + "|";

                if (v is Carro)
                {
                    descricao += "Carro" + "|" + (v as Carro).Quantidadeportas + "|" + (v as Carro).limpador + Environment.NewLine;
                }
                if (v is Caminhao)
                {
                    descricao += "Caminhao" + "|" + (v as Caminhao).limpador + "|" + (v as Caminhao).Pesocarregado + "|" + (v as Caminhao).Capacidadepeso + "|"
                         + (v as Caminhao).Quantidadedeeixos + Environment.NewLine;
                }
                if (v is Onibus)
                {
                    descricao += "Onibus" + "|" + (v as Onibus).limpador + "|" + (v as Onibus).Quantidadedeeixos + "|" + (v as Onibus).leito + Environment.NewLine;
                }
                if (v is Moto)
                {
                    descricao += "Moto" + Environment.NewLine;
                }
                if (v is Aviao)
                {
                    descricao += "Aviao" + "|" + (v as Aviao).limpador + Environment.NewLine;
                }
                if (v is AviaodeGuerra)
                {
                    descricao += "Aviao de Guerra" + Environment.NewLine;
                }
                if (v is Trem)
                {
                    descricao += "Trem" + "|" + (v as Trem).QuantidadeDeVagoes + "|" + (v as Trem).limpador + Environment.NewLine;
                }
                if (v is Navio)
                {
                    descricao += "Navio" + Environment.NewLine;
                }
                if (v is NaviodeGuerra)
                {
                    descricao += "Navio de Guerra" + Environment.NewLine;
                }
            }

            if (File.Exists("dados.txt"))
            {
                File.Delete("dados.txt");
            }

            File.WriteAllText("dados.txt", descricao);
            MessageBox.Show("Salvo!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("dados.txt"))
            {
                string[] linhas = File.ReadAllLines("dados.txt");
               
                foreach (string linha in linhas)
                {
                    string[] dadoslinha = linha.Split('|');

                    if (dadoslinha[5] == "Carro")
                    {
                        Carro c = new Carro();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        c.Quantidadeportas = int.Parse(dadoslinha[6]);
                        c.limpador = Convert.ToBoolean(dadoslinha[7]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Caminhao")
                    {
                        Caminhao c = new Caminhao();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        c.limpador = Convert.ToBoolean(dadoslinha[6]);
                        c.Pesocarregado = int.Parse(dadoslinha[7]);
                        c.Capacidadepeso = int.Parse(dadoslinha[8]);
                        c.Quantidadedeeixos = int.Parse(dadoslinha[9]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Onibus")
                    {
                        Onibus c = new Onibus();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        c.limpador = Convert.ToBoolean(dadoslinha[6]);
                        c.Quantidadedeeixos = int.Parse(dadoslinha[7]);
                        c.Leito = Convert.ToBoolean(dadoslinha[8]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Moto")
                    {
                        Moto c = new Moto();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Aviao")
                    {
                        Aviao c = new Aviao();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        c.limpador = Convert.ToBoolean(dadoslinha[6]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Aviao de Guerra")
                    {
                        AviaodeGuerra c = new AviaodeGuerra();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Trem")
                    {
                        Trem c = new Trem();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        c.Capacidadepassageiros = int.Parse(dadoslinha[3]);
                        c.Velocidadeatual = int.Parse(dadoslinha[4]);
                        c.QuantidadeDeVagoes = int.Parse(dadoslinha[6]);
                        c.limpador = Convert.ToBoolean(dadoslinha[7]);
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Navio")
                    {
                        Navio c = new Navio();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        lista.Add(c);
                    }
                    if (dadoslinha[5] == "Navio de Guerra")
                    {
                        NaviodeGuerra c = new NaviodeGuerra();
                        c.Identificacao = dadoslinha[0];
                        string[] modelo = dadoslinha[1].Trim().Split('-');
                        string[] marca = dadoslinha[2].Trim().Split('-');
                        Marca ma = new Marca();
                        Modelo m = new Modelo();
                        Marca auxi = marcas.Find(aux => aux.Codigo == int.Parse(marca[0]));
                        if (auxi == null)
                        {
                            ma.Codigo = int.Parse(marca[0]);
                            ma.Descricao = marca[1];
                            marcas.Add(ma);
                        }
                        else
                        {
                            ma = auxi;
                        }
                        Modelo auxil = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        if (auxil == null)
                        {
                            m.Codigo = int.Parse(modelo[0]);
                            m.Descricao = modelo[1];
                            m.Marca = ma;
                            modelos.Add(m);
                        }
                        else
                        {
                            m = auxil;
                        }
                        c.Modeloveiculo = modelos.Find(aux => aux.Codigo == int.Parse(modelo[0]));
                        lista.Add(c);
                    }
                    

                }

                MessageBox.Show("Recuperado com sucesso");
                AtualizaModelos();
                AtualizaMarcas();
            }
            else
            {
                MessageBox.Show("Não há registros para se recuperar");
            }
        }
    }
}
