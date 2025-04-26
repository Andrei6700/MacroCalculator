using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MacroCalculator.Factory_MacroCalculator;
using MacroCalculator.Interfaces;
using MacroCalculator.Logic;

namespace MacroCalculator.BulkPage
{
    public partial class BulkPage : Form, IDietPlanPage
    {
        public BulkPage()
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

            bulkComboBox.Items.AddRange(new object[] { "Lean Bulk (+250 kcal)", "Dirty Bulk (+500 kcal)" });
            bulkComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
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
                bulkComboBox.SelectedItem == null)
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

            // Caloric surplus
            int surplus = bulkComboBox.SelectedItem.ToString().Contains("250") ? 250 : 500;

            // Mifflin-St Jeor formula for BMR
            double bmr = 10 * weight + 6.25 * height - 5 * age + (sex == "Male" ? 5 : -161);

            // Calculating calories
            ICalorieCalculator calorieCalculator = new BulkCaloriesCalculator();
            double totalCalories = calorieCalculator.CalculateCalories(bmr, activityFactor, surplus);

            // Macro
            double carbsGrams = (totalCalories * 0.5) / 4;
            double proteinGrams = weight * 2.2;
            double fatGrams = (totalCalories * 0.25) / 9;
            double fiberGrams = totalCalories / 1000 * 14;

            var table = new DataTable();
            table.Columns.Add("Macro", typeof(string));
            table.Columns.Add("Value per gram", typeof(string));

            table.Rows.Add("Total calories", $"{(int)Math.Round(totalCalories)} kcal");
            table.Rows.Add("Carbs", ((int)Math.Round(carbsGrams)).ToString());
            table.Rows.Add("Protein", ((int)Math.Round(proteinGrams)).ToString());
            table.Rows.Add("Fats", ((int)Math.Round(fatGrams)).ToString());
            table.Rows.Add("Fiber", ((int)Math.Round(fiberGrams)).ToString());

            var resultPage = new MacroCalculator.ResultPage.ResultPage(table);
            resultPage.Show();
            this.Hide();
        }
    }
}
