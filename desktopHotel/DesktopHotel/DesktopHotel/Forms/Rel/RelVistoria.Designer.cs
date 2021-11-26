
namespace DesktopHotel.Forms.Rel
{
    partial class RelVistoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vistoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetVistoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetVistoria = new DesktopHotel.DataSet.DataSetVistoria();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vistoriaTableAdapter = new DesktopHotel.DataSet.DataSetVistoriaTableAdapters.vistoriaTableAdapter();
            this.vistoriaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vistoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVistoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVistoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistoriaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // vistoriaBindingSource
            // 
            this.vistoriaBindingSource.DataMember = "vistoria";
            this.vistoriaBindingSource.DataSource = this.dataSetVistoriaBindingSource;
            // 
            // dataSetVistoriaBindingSource
            // 
            this.dataSetVistoriaBindingSource.DataSource = this.dataSetVistoria;
            this.dataSetVistoriaBindingSource.Position = 0;
            // 
            // dataSetVistoria
            // 
            this.dataSetVistoria.DataSetName = "DataSetVistoria";
            this.dataSetVistoria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vistoriaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DesktopHotel.Relatorio.RelVistoria.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // vistoriaTableAdapter
            // 
            this.vistoriaTableAdapter.ClearBeforeFill = true;
            // 
            // vistoriaBindingSource1
            // 
            this.vistoriaBindingSource1.DataMember = "vistoria";
            this.vistoriaBindingSource1.DataSource = this.dataSetVistoriaBindingSource;
            // 
            // RelVistoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RelVistoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Vistorias";
            this.Load += new System.EventHandler(this.RelVistoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vistoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVistoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVistoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistoriaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetVistoriaBindingSource;
        private DataSet.DataSetVistoria dataSetVistoria;
        private System.Windows.Forms.BindingSource vistoriaBindingSource;
        private DataSet.DataSetVistoriaTableAdapters.vistoriaTableAdapter vistoriaTableAdapter;
        private System.Windows.Forms.BindingSource vistoriaBindingSource1;
    }
}