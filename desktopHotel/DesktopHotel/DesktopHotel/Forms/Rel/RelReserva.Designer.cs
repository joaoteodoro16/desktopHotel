
namespace DesktopHotel.Forms.Rel
{
    partial class RelReserva
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
            this.reservasBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReservaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReserva = new DesktopHotel.DataSet.DataSetReserva();
            this.reservasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reservasTableAdapter = new DesktopHotel.DataSet.DataSetReservaTableAdapters.reservasTableAdapter();
            this.reservasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reservasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReservaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // reservasBindingSource3
            // 
            this.reservasBindingSource3.DataMember = "reservas";
            this.reservasBindingSource3.DataSource = this.dataSetReservaBindingSource;
            // 
            // dataSetReservaBindingSource
            // 
            this.dataSetReservaBindingSource.DataSource = this.dataSetReserva;
            this.dataSetReservaBindingSource.Position = 0;
            // 
            // dataSetReserva
            // 
            this.dataSetReserva.DataSetName = "DataSetReserva";
            this.dataSetReserva.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reservasBindingSource
            // 
            this.reservasBindingSource.DataMember = "reservas";
            this.reservasBindingSource.DataSource = this.dataSetReservaBindingSource;
            // 
            // reservasTableAdapter
            // 
            this.reservasTableAdapter.ClearBeforeFill = true;
            // 
            // reservasBindingSource1
            // 
            this.reservasBindingSource1.DataMember = "reservas";
            this.reservasBindingSource1.DataSource = this.dataSetReservaBindingSource;
            // 
            // reservasBindingSource2
            // 
            this.reservasBindingSource2.DataMember = "reservas";
            this.reservasBindingSource2.DataSource = this.dataSetReservaBindingSource;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reservasBindingSource3;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DesktopHotel.Relatorio.RelReserva.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RelReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Reservas";
            this.Load += new System.EventHandler(this.RelReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReservaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservasBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataSet.DataSetReserva dataSetReserva;
        private System.Windows.Forms.BindingSource dataSetReservaBindingSource;
        private System.Windows.Forms.BindingSource reservasBindingSource;
        private DataSet.DataSetReservaTableAdapters.reservasTableAdapter reservasTableAdapter;
        private System.Windows.Forms.BindingSource reservasBindingSource1;
        private System.Windows.Forms.BindingSource reservasBindingSource2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reservasBindingSource3;
    }
}