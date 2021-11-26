
namespace DesktopHotel.Forms
{
    partial class RelQuarto
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
            this.quartosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetQuartoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetQuarto = new DesktopHotel.DataSet.DataSetQuarto();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.quartosTableAdapter = new DesktopHotel.DataSet.DataSetQuartoTableAdapters.quartosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quartosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetQuartoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetQuarto)).BeginInit();
            this.SuspendLayout();
            // 
            // quartosBindingSource
            // 
            this.quartosBindingSource.DataMember = "quartos";
            this.quartosBindingSource.DataSource = this.dataSetQuartoBindingSource;
            // 
            // dataSetQuartoBindingSource
            // 
            this.dataSetQuartoBindingSource.DataSource = this.dataSetQuarto;
            this.dataSetQuartoBindingSource.Position = 0;
            // 
            // dataSetQuarto
            // 
            this.dataSetQuarto.DataSetName = "DataSetQuarto";
            this.dataSetQuarto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.quartosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DesktopHotel.Relatorio.RelQuarto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // quartosTableAdapter
            // 
            this.quartosTableAdapter.ClearBeforeFill = true;
            // 
            // RelQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RelQuarto";
            this.Text = "Relatório Quartos";
            this.Load += new System.EventHandler(this.RelQuarto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quartosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetQuartoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetQuarto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetQuartoBindingSource;
        private DataSet.DataSetQuarto dataSetQuarto;
        private System.Windows.Forms.BindingSource quartosBindingSource;
        private DataSet.DataSetQuartoTableAdapters.quartosTableAdapter quartosTableAdapter;
    }
}