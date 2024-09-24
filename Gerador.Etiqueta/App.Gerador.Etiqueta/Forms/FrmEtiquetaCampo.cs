using App.Gerador.Etiqueta.Classes.Bll;
using App.Gerador.Etiqueta.Classes.Fixo;
using App.Gerador.Etiqueta.Classes.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace App.Gerador.Etiqueta.Forms
{
    public partial class FrmEtiquetaCampo : Form
    {
        private EtiquetaModeloBo etiquetaModeloBo = new EtiquetaModeloBo();

        private EtiquetaCampo Campo { get; set; }
        private bool IsInserting { get; set; }

        public FrmEtiquetaCampo()
        {
            InitializeComponent();
        }
        public FrmEtiquetaCampo(EtiquetaCampo _obj, bool isInserting = false)
            : this()
        {
            Campo = _obj;
            IsInserting = isInserting;
        }

        private List<Fonte> FontesRetornar()
        {
            List<Fonte> lst = new List<Fonte>();
            InstalledFontCollection fontes = new InstalledFontCollection();
            foreach (FontFamily item in fontes.Families)
            {
                Fonte obj = new Fonte()
                {
                    Descricao = item.Name
                };
                lst.Add(obj);
            }
            return lst;
        }

        private void FrmEtiquetaCampo_Load(object sender, EventArgs e)
        {
            idTextBox.ReadOnly = true;
            etiquetaIdTextBox.ReadOnly = true;

            campoComboBox.DataSource = Enum.GetValues(typeof(CampoEnum));
            campoComboBox.SelectedItem = CampoEnum.Nenhum;

            fonteNomeComboBox.DataSource = FontesRetornar();
            fonteNomeComboBox.DisplayMember = "Descricao";
            fonteNomeComboBox.ValueMember = "Descricao";
            try
            {
                fonteNomeComboBox.SelectedValue = "Arial";
            }
            catch { }

            if (IsInserting)
                etiquetaCampoBindingSource.AddNew();
            else
            {
                etiquetaCampoBindingSource.DataSource = Campo;
                etiquetaCampoBindingSource.ResetBindings(false);
            }
        }

        private void etiquetaCampoBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            e.NewObject = Campo;
        }

        private void gravarButton_Click(object sender, EventArgs e)
        {
            Validate();
            etiquetaCampoBindingSource.EndEdit();
            if (etiquetaCampoBindingSource.Current is EtiquetaCampo obj)
            {
                if (etiquetaModeloBo.ValidarCampo(obj))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show(obj.MensagemValidacao, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar esta operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            DialogResult = DialogResult.Cancel;
        }
    }
}
