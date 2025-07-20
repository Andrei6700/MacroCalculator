using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MacroCalculator.Factory_MacroCalculator;
using MacroCalculator.Interfaces;
using MacroCalculator.Logic;

namespace MacroCalculator.CutPage
{
    public partial class CutPage : Form, IDietPlanPage
    {
        public CutPage()
        {
            InitializeComponent();
            sexComboBox.Items.AddRange(new object[] { "Male", "Female" });
            sexComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            activityComboBox.Items.AddRange(new object[]
            {
                "Sedentary (1.2)",
                "Lightly active (1.375)",
                "Moderately active (1.55)",
                "Very active (1.725)",
                "Extremely active (1.9)"
            });
            activityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            cutComboBox.Items.AddRange(new object[] { "Lean Cut (-300 kcal)", "Aggressive Cut (-600 kcal)" });
            cutComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void ShowPage()
        {
            this.Show();
        }

        public void HidePage()
        {
            this.Hide();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ageTextBox.Text, out int age) ||
                sexComboBox.SelectedItem == null ||
                !double.TryParse(weightTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double weight) ||
                !double.TryParse(heightTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double height) ||
                activityComboBox.SelectedItem == null ||
                cutComboBox.SelectedItem == null ||
                !double.TryParse(targetTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double target))
            {
                MessageBox.Show("Invalid field ! Add numbers instead of text !!", "Error 404",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sex
            string sex = sexComboBox.SelectedItem.ToString();

            // Activity factor
            string act = activityComboBox.SelectedItem.ToString();
            string actVal = act.Substring(act.IndexOf('(') + 1).TrimEnd(')');
            actVal = actVal.Replace(',', '.');
            double activityFactor = double.Parse(actVal, CultureInfo.InvariantCulture);

            // Calorie deficit
            int deficit = cutComboBox.SelectedItem.ToString().Contains("300") ? 300 : 600;
            string cutType = cutComboBox.SelectedItem.ToString();

            // BMR calculation
            double bmr = 10 * weight + 6.25 * height - 5 * age + (sex == "Male" ? 5 : -161);

            // Calculating calories
            ICalorieCalculator calorieCalculator = new CutCaloriesCalculator();
            double totalCalories = calorieCalculator.CalculateCalories(bmr, activityFactor, deficit);

            // Macro
            double carbsGrams = (totalCalories * 0.5) / 4;
            double proteinGrams = weight * 3; // 3g protein per kg
            double fatGrams = (totalCalories * 0.25) / 9;
            double fiberGrams = totalCalories / 1000 * 14;

            // Check if target weight is valid
            if (target >= weight)
            {
                MessageBox.Show("Target weight must be less than current weight for a cut!", "Error 404",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double weightDiff = weight - target; // kg to lose
            double dailyDeficit = deficit; // kcal per day
            double daysNeeded = (weightDiff * 7700) / dailyDeficit; // 7700 kcal = 1 kg
            if (daysNeeded < 0) daysNeeded = 0;

            int days = (int)Math.Ceiling(daysNeeded);
            int weeks = days / 7;
            int months = weeks / 4;

            var table = new DataTable();
            table.Columns.Add("Macro", typeof(string));
            table.Columns.Add("Value per gram", typeof(string));

            table.Rows.Add("Total calories", $"{(int)Math.Round(totalCalories)} kcal");
            table.Rows.Add("Carbs", ((int)Math.Round(carbsGrams)).ToString());
            table.Rows.Add("Protein", ((int)Math.Round(proteinGrams)).ToString());
            table.Rows.Add("Fats", ((int)Math.Round(fatGrams)).ToString());
            table.Rows.Add("Fiber", ((int)Math.Round(fiberGrams)).ToString());

            var resultPage = new MacroCalculator.ResultPage.ResultPage(table, weight, target, days, months, cutType);
            resultPage.Show();
            this.Hide();
        }
    }
}
