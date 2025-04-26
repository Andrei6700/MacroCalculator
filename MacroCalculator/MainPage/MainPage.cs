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
            var bulkPage = DietPlanFactory.CreateDietPlan("Bulk");
            bulkPage.ShowPage();
            this.Hide();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            var cutPage = DietPlanFactory.CreateDietPlan("Cut");
            cutPage.ShowPage();
            this.Hide();
        }

        private void btnMaintain_Click(object sender, EventArgs e)
        {
            var maintainPage = DietPlanFactory.CreateDietPlan("Maintain");
            maintainPage.ShowPage();
            this.Hide();
        }
    }
}