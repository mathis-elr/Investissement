using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investissement
{
    public partial class GraphiquesVue : UserControl
    {
        private TransactionController transactionController;
        public GraphiquesVue(TransactionController transactionController)
        {
            this.transactionController = transactionController;

            InitializeComponent();
        }

        private void GraphiquesVue_Load(object sender, EventArgs e)
        {

        }
    }
}
