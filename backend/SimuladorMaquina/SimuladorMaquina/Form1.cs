using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorMaquina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            Model1 conexao = new Model1();

            List<Equipamento> equipamentos = conexao.Equipamento.ToList<Equipamento>();
            Random rando = new Random();
            while (true)
            {
                foreach (Equipamento equipamento in equipamentos)
                {
                    Evento evento = new Evento();
                    evento.Equipamento = equipamento;
                    evento.PecasBoas = rando.Next(0, 100)*2;
                    evento.PecasRuins = rando.Next(0, 10);
                    evento.TempoParada = rando.Next(0, 60).ToString();
                    evento.TempoProducao = (60 - Convert.ToInt16(evento.TempoParada)).ToString();

                    conexao.Evento.Add(evento);
                    conexao.SaveChanges();
                }
                Thread.Sleep(1000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model1 conexao = new Model1();
            int id = 0;
            Int32.TryParse(txtIdAlarme.Text, out id);
            if (id > 0)
            {
                Equipamento equipamento = conexao.Equipamento.Where(a => a.Id == id).FirstOrDefault();
                if (equipamento != null)
                {
                    Alarme alarme = new Alarme();
                    alarme.Equipamento = equipamento;
                    alarme.DataAlarme = DateTime.Now;
                    alarme.DescricaoAlarme = "Parada de emergência";
                    equipamento.Alarme.Add(alarme);
                    conexao.SaveChanges();
                    MessageBox.Show("Alarme criado com sucesso!");
                }else
                {
                    MessageBox.Show("Não encontrado nenhum equipamento.");
                }

            }
            else
            {
                MessageBox.Show("Digito o número do equipamento.");


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
