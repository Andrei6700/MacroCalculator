    using System;
    using System.Data;
    using System.Windows.Forms;
    using MacroCalculator.Factory_MacroCalculator;

    namespace MacroCalculator.ResultPage
    {
        public partial class ResultPage : Form, IDietPlanPage
        {
            public ResultPage(DataTable results)
            {
                InitializeComponent();
                dataGridView1.DataSource = results;
            }

            public ResultPage(DataTable results, double currentWeight, double targetWeight, int daysNeeded, int monthsNeeded, string cutType)
                : this(results)
            {
                infoLabel.ForeColor = System.Drawing.Color.White;
                infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                infoLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);

                infoLabel.Text =
                    $"Your current weight is {currentWeight} kg.\n" +
                    $"To reach {targetWeight} kg with a {cutType}, it will take you approximately {daysNeeded} days (~{monthsNeeded} months).";

                infoLabel.Visible = true;
            }

            public void ShowPage() // Implementare ShowPage
            {
                this.Show();
            }

            public void HidePage() // Implementare HidePage
            {
                this.Hide();
            }
        }
    }
