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
    public partial class PatrimoineVue : UserControl
    {
        private TransactionController transactionController;
        public PatrimoineVue(TransactionController transactionController)
        {
            this.transactionController = transactionController;

            InitializeComponent();
        }

        private void PatrimoineVue_Load(object sender, EventArgs e)
        {

        }
    }
}
