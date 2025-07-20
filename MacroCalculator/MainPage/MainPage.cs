using System;
using System.Windows.Forms;
using MacroCalculator.Factory_MacroCalculator;

namespace MacroCalculator.MainPage
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnBulk_Click(object sender, EventArgs e)
        {
            var factory = new BulkPlanFactory();
            IDietPlanPage bulkPage = factory.CreatePage();
            bulkPage.ShowPage();
            this.Hide();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            var factory = new CutPlanFactory();
            IDietPlanPage cutPage = factory.CreatePage();
            cutPage.ShowPage();
            this.Hide();
        }

        private void btnMaintain_Click(object sender, EventArgs e)
        {
            var factory = new MaintainPlanFactory();
            IDietPlanPage maintainPage = factory.CreatePage();
            maintainPage.ShowPage();
            this.Hide();
        }
    }
}