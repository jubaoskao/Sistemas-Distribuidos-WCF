using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AvaliadorExpressoes
{
    public partial class frmAvaliador : Form
    {
        private Hashtable tokens;
        private Calc calculadora;

        public frmAvaliador()
        {
            InitializeComponent();
            calculadora = new Calc();
        }

        private void btnAnalisar_Click(object sender, EventArgs e)
        {
            tokens = new Hashtable();
            bool analise = calculadora.Analisar(txtExpressao.Text);
            if (analise)
            {
                //MessageBox.Show("OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPosFixa.Text = calculadora.Converter(txtExpressao.Text);
            }
            else
            {
                lblPosFixa.Text = string.Empty;
                //MessageBox.Show("Erro na análise", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void PopularGrid(Hashtable hash)
        {
            dtgElementos.Rows.Clear();

            foreach (DictionaryEntry v in hash)
                dtgElementos.Rows.Add(new object[] { v.Key, v.Value });
        }

        private void txtExpressao_TextChanged(object sender, EventArgs e)
        {
            tokens = new Hashtable();
            Hashtable hash = calculadora.ObterVariaveis(txtExpressao.Text);
            PopularGrid(hash);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Hashtable hash = new Hashtable();

            btnAnalisar_Click(null, null);

            foreach (DataGridViewRow item in dtgElementos.Rows)
                hash[item.Cells[0].Value.ToString()] = Convert.ToDouble(item.Cells[1].Value);

            lblResultado.Text = calculadora.Calcular(lblPosFixa.Text, hash).ToString();
        }
    }
}
