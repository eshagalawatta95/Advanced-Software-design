using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinance.Core.Service;
using MyFinance.Entities;

namespace MyFinance.Views.UserControls.Summary
{
    public partial class PredictionUserControl : UserControl
    {
        private IApplicationService _applicationService;
        private BindingList<KeyValuePair<int, string>> _previousData;

        public PredictionUserControl()
        {
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();
        }

        private void PredictionUserControl_Load(object sender, EventArgs e)
        {
            predictDateErrorLabel.Text = "";
            previousDataErrorLabel.Text = "";
            predictDateDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            predictDateDateTimePicker.MinDate = DateTime.Now.Date.AddDays(1);

            _previousData = new BindingList<KeyValuePair<int, string>>(new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "1 Month"),
                new KeyValuePair<int, string>(2, "2 Months"),
                new KeyValuePair<int, string>(3, "3 Months"),
                new KeyValuePair<int, string>(4, "4 Months"),
                new KeyValuePair<int, string>(5, "5 Months"),
                new KeyValuePair<int, string>(6, "6 Months"),
            });

            previousDataComboBox.DataSource = _previousData;
            previousDataComboBox.DisplayMember = "Value";
            previousDataComboBox.ValueMember = "Key";
            previousDataComboBox.SelectedIndex = 2;
        }

        private bool IsValidateForm()
        {
            bool isValid = true;

            DateTime dateTime = predictDateDateTimePicker.Value;

            predictDateErrorLabel.Text = "";
            previousDataErrorLabel.Text = "";
            actionsUserControl.ErrorMessageText = "";

            if (previousDataComboBox.SelectedIndex < 0)
            {
                previousDataErrorLabel.Text = "Previous data is required";
                isValid = false;
            }

            if (dateTime < DateTime.Now)
            {
                predictDateErrorLabel.Text = "Predict date should be a future date";
                isValid = false;
            }

            return isValid;
        }

        public void ClearForm()
        {
            predictDateErrorLabel.Text = "";
            previousDataErrorLabel.Text = "";
            actionsUserControl.ErrorMessageText = "";
            resultGroup.Visible = false;
        }

        private async void actionsUserControl_PredictButtonOnClick(object sender, EventArgs e)
        {
            if (!IsValidateForm())
            {
                return;
            }

            KeyValuePair<int, string> previousDataKeyValuePair = _previousData[previousDataComboBox.SelectedIndex];
            DateTime dateTime = predictDateDateTimePicker.Value;

            if (!_applicationService.IsAvailableEnoughtData(previousDataKeyValuePair.Key))
            {
                DialogResult dr = MessageBox.Show("Predictor method requires more data to work properly. Are you sure to continue anyway?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            previousDataComboBox.Enabled = false;
            predictDateDateTimePicker.Enabled = false;
            actionsUserControl.IsEnabledButtons = false;

            PredictionEntity predictionEntity = await _applicationService.GetPredictionsAsync(previousDataKeyValuePair.Key, dateTime);
            actionsUserControl.ErrorMessageText = predictionEntity.WarningMessage;

            if (predictionEntity.IsPredicted)
            {
                balanceOnIntroLabel.Text = $"Balance on {dateTime.ToString("yyyy-MM-dd")}";
                balanceOnValueLabel.Text = predictionEntity.PredictBalanace.ToString("0.00");
                balanceOnTodayLabel.Text = predictionEntity.TodayBalanace.ToString("0.00");
                avgIncomeLabel.Text = predictionEntity.AverageIncome.ToString("0.00");
                avgExpensesLabel.Text = predictionEntity.AverageExpense.ToString("0.00");

                foreach (DailyBreakDownPredictionEntity dailyBreakDown in predictionEntity.DailyBreakDownPredictions)
                {
                    if (dailyBreakDown.DayOfWeek == DayOfWeek.Monday)
                    {
                        monInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        monOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                    else if (dailyBreakDown.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        tueInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        tueOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                    else if (dailyBreakDown.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        wedInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        wedOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                    else if (dailyBreakDown.DayOfWeek == DayOfWeek.Thursday)
                    {
                        thuInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        thuOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                    else if (dailyBreakDown.DayOfWeek == DayOfWeek.Friday)
                    {
                        friInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        friOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                    else if (dailyBreakDown.DayOfWeek == DayOfWeek.Saturday)
                    {
                        satInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        satOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                    else if (dailyBreakDown.DayOfWeek == DayOfWeek.Sunday)
                    {
                        sunInLabel.Text = dailyBreakDown.AverageIncome.ToString("0.00");
                        sunOutLabel.Text = dailyBreakDown.AverageExpense.ToString("0.00");
                    }
                }
            }
            else
            {
                MessageBox.Show(predictionEntity.WarningMessage, "Prediction failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            resultGroup.Visible = predictionEntity.IsPredicted;
            previousDataComboBox.Enabled = true;
            predictDateDateTimePicker.Enabled = true;
            actionsUserControl.IsEnabledButtons = true;
        }

        private void actionsUserControl_ResetButtonOnClick(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
