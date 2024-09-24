using App.Gerador.Etiqueta.Classes.Bll;
using App.Gerador.Etiqueta.Classes.Model;
using System;
using System.Windows.Forms;

namespace App.Gerador.Etiqueta.Forms
{
    public partial class FrmEtiqueta : Form
    {
        EtiquetaModeloBo etiquetaModeloBo = new EtiquetaModeloBo();

        private int opcao { get; set; }

        public FrmEtiqueta()
        {
            InitializeComponent();
        }

        private void LimparCampos(Control _control)
        {
            for (int i = 0; i <= _control.Controls.Count - 1; i++)
            {
                if (_control.Controls[i] is TextBoxBase)
                    (_control.Controls[i] as TextBoxBase).Text = "";
                else if (_control.Controls[i] is ListControl)
                    (_control.Controls[i] as ListControl).SelectedIndex = 0;
                else if (_control.Controls[i] is CheckBox)
                    (_control.Controls[i] as CheckBox).Checked = false;
                else if (_control.Controls[i] is DateTimePicker)
                    (_control.Controls[i] as DateTimePicker).Value = DateTime.Now;
                else if (_control.Controls[i] is TextBoxCurrency.TextBoxCurrency)
                    (_control.Controls[i] as TextBoxCurrency.TextBoxCurrency).Text = "0";
                else
                    HabilitarCampos(_control.Controls[i]);
            }
        }
        private void HabilitarCampos(Control _control, bool _status = true)
        {
            for (int i = 0; i <= _control.Controls.Count - 1; i++)
            {
                if (_control.Controls[i] is TextBoxBase)
                    (_control.Controls[i] as TextBoxBase).ReadOnly = !_status;
                else if (_control.Controls[i] is ListControl)
                    (_control.Controls[i] as ListControl).Enabled = _status;
                else if (_control.Controls[i] is CheckBox)
                    (_control.Controls[i] as CheckBox).Enabled = _status;
                else if (_control.Controls[i] is DateTimePicker)
                    (_control.Controls[i] as DateTimePicker).Enabled = _status;
                else if (_control.Controls[i] is TextBoxCurrency.TextBoxCurrency)
                    (_control.Controls[i] as TextBoxCurrency.TextBoxCurrency).ReadOnly = !_status;
                else if (_control.Controls[i] is ButtonBase)
                    (_control.Controls[i] as ButtonBase).Enabled = _status;
                else
                    HabilitarCampos(_control.Controls[i], _status);
            }
        }
        private void ControlarBotoes(bool _status)
        {
            novoButton.Enabled = _status;
            editarButton.Enabled = _status && etiquetaModeloBindingSource.Count > 0;
            excluirButton.Enabled = _status && etiquetaModeloBindingSource.Count > 0;
            gravarButton.Enabled = !_status;
            cancelarButton.Enabled = !_status;

            adicionarCampoButton.Enabled = opcao > 0;
            removerCampoButton.Enabled = opcao > 0;
        }

        private void FrmEtiqueta_Load(object sender, EventArgs e)
        {
            try
            {
                opcao = 0;
                HabilitarCampos(dadosPanel, false);
                LimparCampos(dadosPanel);
                etiquetaModeloBindingSource.DataSource = etiquetaModeloBo.RetornarTodos();
                etiquetaModeloBindingSource.ResetBindings(false);
                ControlarBotoes(true);
                etiquetaDataGridView.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar inicializar a tela.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            try
            {
                opcao = 1;
                HabilitarCampos(dadosPanel);
                ControlarBotoes(false);
                gridGroupBox.Enabled = false;
                etiquetaModeloBindingSource.AddNew();
                idTextBox.ReadOnly = true;
                nomeTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar iniciar um novo registro.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void editarButton_Click(object sender, EventArgs e)
        {
            try
            {
                opcao = 2;
                HabilitarCampos(dadosPanel);
                ControlarBotoes(false);
                gridGroupBox.Enabled = false;
                nomeTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar editar o registro.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void excluirButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (etiquetaModeloBindingSource.Current is EtiquetaModelo obj && obj.Id > 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir o registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (etiquetaModeloBo.Excluir(obj.Id))
                        {
                            etiquetaModeloBindingSource.Remove(obj);
                            etiquetaModeloBindingSource.ResetBindings(false);
                            ControlarBotoes(true);
                            opcao = 0;
                            MessageBox.Show("Registro excluído com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (etiquetaModeloBindingSource.Count > 0)
                                etiquetaDataGridView.Focus();
                        }
                        else
                            MessageBox.Show("Não foi possível excluir o registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir o registro.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gravarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                etiquetaModeloBindingSource.EndEdit();
                if (etiquetaModeloBindingSource.Current is EtiquetaModelo obj)
                {
                    if (etiquetaModeloBo.Validar(obj))
                    {
                        if (etiquetaModeloBo.Salvar(obj))
                        {
                            etiquetaModeloBindingSource.ResetBindings(false);
                            HabilitarCampos(dadosPanel, false);
                            opcao = 0;
                            ControlarBotoes(true);
                            gridGroupBox.Enabled = true;
                            MessageBox.Show("Registro gravado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            etiquetaDataGridView.Focus();
                        }
                        else
                            MessageBox.Show($"Não foi possível grarvar o registro.\r\n\r\n{(string.IsNullOrWhiteSpace(obj.MensagemValidacao) ? "" : obj.MensagemValidacao)}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show(obj.MensagemValidacao, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar gravar o registro.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente cancelar esta operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                LimparCampos(dadosPanel);
                HabilitarCampos(dadosPanel, false);

                etiquetaModeloBindingSource.DataSource = etiquetaModeloBo.RetornarTodos();
                etiquetaModeloBindingSource.ResetBindings(false);

                opcao = 0;
                ControlarBotoes(true);
                gridGroupBox.Enabled = true;
                if (etiquetaModeloBindingSource.Count > 0)
                    etiquetaDataGridView.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar cancelar o processo.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adicionarCampoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (etiquetaModeloBindingSource.Current is EtiquetaModelo obj)
                {
                    if (obj != null)
                    {
                        EtiquetaCampo campo = new EtiquetaCampo() { EtiquetaId = obj.Id };
                        using (FrmEtiquetaCampo frm = new FrmEtiquetaCampo(campo, true))
                        {
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                obj.Campos.Add(campo);
                                camposBindingSource.ResetBindings(false);
                            }
                        }
                        camposBindingSource.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar iniciar um novo registro filho.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void removerCampoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (camposBindingSource.Count <= 0)
                    return;

                if (camposBindingSource.Current is EtiquetaCampo obj)
                {
                    if (MessageBox.Show("Deseja realmente revomer o registro filho selecionado?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        camposBindingSource.Remove(obj);
                        etiquetaModeloBindingSource.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar remover o registro filho.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void etiquetaModeloBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (etiquetaModeloBindingSource == null || etiquetaModeloBindingSource.DataSource == null || etiquetaModeloBindingSource.IsBindingSuspended)
                    return;

                if (etiquetaModeloBindingSource.Current is EtiquetaModelo obj)
                {
                    if (obj != null && obj.Id > 0 && obj.Campos.Count <= 0)
                        etiquetaModeloBo.RetornarCamposPorModelo(obj);
                    camposBindingSource.DataSource = obj;
                    camposBindingSource.ResetBindings(false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar recuperar registro(s) filho(s).\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void camposDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (opcao > 0)
                {
                    if (camposBindingSource.Current is EtiquetaCampo obj)
                    {
                        if (obj != null)
                        {
                            EtiquetaCampo original = obj.ShallowCopy() as EtiquetaCampo;
                            using (FrmEtiquetaCampo frm = new FrmEtiquetaCampo(obj))
                            {
                                frm.ShowDialog();
                                if (frm.DialogResult == DialogResult.Cancel)
                                    obj.RestoreValues(original);
                            }
                            camposBindingSource.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar editar o registro filho.\r\n\r\n{ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}