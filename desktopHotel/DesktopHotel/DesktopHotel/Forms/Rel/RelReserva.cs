﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Forms.Rel
{
    public partial class RelReserva : Form
    {
        public RelReserva()
        {
            InitializeComponent();
        }

        private void RelReserva_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetReserva.reservas'. Você pode movê-la ou removê-la conforme necessário.
            this.reservasTableAdapter.Fill(this.dataSetReserva.reservas);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
