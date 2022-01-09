using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinance.Entities;
using MyFinance.Enums;
using MyFinance.Core.Service;

namespace MyFinance.Views.UserControls.Task.ManageTaskUserControl
{
    public partial class ManageTaskUserControl : UserControl
    {
        private OneTimeTasks _onetimetaskEntity;
        private ScheduledTasks _schtaskEntity;
        private Action<ContentItemEnum> _changeContentMainFormAction;
        private IApplicationService _applicationService;
        ApplicationErrorLog applicationErrorLog = new ApplicationErrorLog();

        public ManageTaskUserControl(Action<ContentItemEnum> changeContentMainFormAction)
        {
            _changeContentMainFormAction = changeContentMainFormAction;
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
            _onetimetaskEntity = null;
            InitializeComponent();
            comboBoxRepeat.DataSource = Enum.GetValues(typeof(ContentRepeatItemEnum));
            taskTypeComboBox.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
            comboBoxRepeat.SelectedIndex = 1;
            dateTimePickerTo.MinDate = DateTime.Today.AddDays(1);
            dateTimePickerForm.MinDate = DateTime.Today;
            dateTimePickerEffective.MinDate = DateTime.Today.AddDays(1);
            referenceNumberPanel.Visible = false;
        }

        public ManageTaskUserControl(Action<ContentItemEnum> changeContent, OneTimeTasks transactionEntity, ScheduledTasks schtrans) : this(changeContent)
        {
            _onetimetaskEntity = transactionEntity;
            if(schtrans != null)
            _schtaskEntity = schtrans;
        }

        private void SetTaskEntity(OneTimeTasks onetimetaskEntity = null)
        {
            try
            {
                _onetimetaskEntity = onetimetaskEntity ?? new OneTimeTasks()
                {
                    Duration = 0D,
                    ReferenceNumber = "",
                    Comments = "",
                };

                if (_onetimetaskEntity.Id == 0)
                {
                    referenceNumberPanel.Visible = false;
                }
                else
                {
                    referenceNumberPanel.Visible = true;
                    referenceNumberTextBox.Text = _onetimetaskEntity.ReferenceNumber;
                }

                durationErrorLabel.Text = "";
                amountNumericUpDown.Text = _onetimetaskEntity.Duration.ToString();
                taskTypeComboBox.SelectedIndex = _onetimetaskEntity.Type;
                remarksTextBox.Text = _onetimetaskEntity.Comments;
                dateTimePickerEffective.Value = _onetimetaskEntity.Effectivedate;
                remarksTextBox.Text = _onetimetaskEntity.Comments;
                remarksErrorLabel.Text = "";
                comboBoxType.Enabled = false;
                dateTimePickerForm.Enabled = true;
            }
            catch (Exception k)
            {
                applicationErrorLog.ErrorLog("Task", "setting one time tasks to UI", k.ToString());
            }
        }

        private void SetScheduleTaskEntity(ScheduledTasks schEntity = null)
        {
            try
            {
                _schtaskEntity = schEntity ?? new ScheduledTasks()
                {
                    Duration = 0D,
                    ReferenceNumber = "",
                    Comments = "",
                };

                if (_schtaskEntity.Id == 0)
                {
                    referenceNumberPanel.Visible = false;
                    taskTypeComboBox.SelectedIndex = -1;
                }
                else
                {
                    comboBoxType.SelectedIndex = 1;
                    comboBoxType.Enabled = false;
                    referenceNumberPanel.Visible = true;
                    referenceNumberTextBox.Text = _schtaskEntity.ReferenceNumber;
                }

                durationErrorLabel.Text = "";
                remarksTextBox.Text = _schtaskEntity.Comments;
                remarksErrorLabel.Text = "";
                amountNumericUpDown.Text = _schtaskEntity.Duration.ToString();
                taskTypeComboBox.SelectedIndex = _schtaskEntity.Type;
                dateTimePickerEffective.Value = _schtaskEntity.Effectivedate;
                comboBoxType.Enabled = true;

                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
                DateTime dtTemp = DateTime.Now;

                comboBoxRepeat.SelectedText = _schtaskEntity.RepeatType;
                dateTimePickerForm.Value = DateTime.Today.AddDays(1);
                dateTimePickerTo.Value = (DateTime)_schtaskEntity.EndDateTime;
                dateTimePickerForm.Enabled = false;
                dateTimePickerForm.Value = _schtaskEntity.Effectivedate;
            }
            catch (Exception k)
            {
                applicationErrorLog.ErrorLog("Task", "setting scheduled tasks to UI", k.ToString());
            }
        }
        
        private void contentHeaderUserControl_BackButtonOnClick(object sender, EventArgs e)
        {
            _changeContentMainFormAction(ContentItemEnum.Task);
        }

        private void ManageTaskUserControl_Load(object sender, EventArgs e)
        {

            if (_onetimetaskEntity != null)
            SetTaskEntity(_onetimetaskEntity);
            if(_schtaskEntity != null)
            SetScheduleTaskEntity(_schtaskEntity);

            int Consider_Val = 0;
            if (_onetimetaskEntity != null) Consider_Val = _onetimetaskEntity.Id;
            else if (_schtaskEntity != null) Consider_Val = _schtaskEntity.Id;

                if (Consider_Val == 0)
                {
                    actionsUserControl.DeleteButtonVisible = false;
                    actionsUserControl.ResetButtonVisible = true;
                    contentHeaderUserControl.MainTitle = "Add Tasks";
                }
                else
                {
                    actionsUserControl.DeleteButtonVisible = true;
                    actionsUserControl.ResetButtonVisible = false;
                    contentHeaderUserControl.MainTitle = "Update Task";
                }
        }

        private bool IsFormDataValid()
        {
            bool isValid = true;
            if (_onetimetaskEntity != null) {
                int id = _onetimetaskEntity.Id; }
                 else if (_schtaskEntity != null){    
                 int id = _schtaskEntity.Id; }

            string remarks = remarksTextBox.Text;
            string amount = amountNumericUpDown.Text;
            double amountDouble;

            if (string.IsNullOrWhiteSpace(remarks))
            {
                isValid = false;
                remarksErrorLabel.Text = "Remark is required";
            }
            else
            {
                remarksErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(amount))
            {
                isValid = false;
                durationErrorLabel.Text = "Duration is required";
            }
            else if (!double.TryParse(amount, out amountDouble))
            {
                isValid = false;
                durationErrorLabel.Text = "Duration need to be numeric";
            }
            else if (amountDouble <= 0)
            {
                isValid = false;
                durationErrorLabel.Text = "Duration should greater than zero";
            }
            else
            {
                durationErrorLabel.Text = "";
            }
           
                DateTime dtCheck = DateTime.Now;
                string SelectedType = this.comboBoxRepeat.GetItemText(this.comboBoxRepeat.SelectedItem).Trim();
                if (SelectedType == ContentRepeatItemEnum.Daily.ToString())
                    dtCheck = dateTimePickerForm.Value.AddDays(1);
                else if (SelectedType == ContentRepeatItemEnum.Weekly.ToString())
                    dtCheck = dateTimePickerForm.Value.AddDays(7);
                else if (SelectedType == ContentRepeatItemEnum.Monthly.ToString())
                    dtCheck = dateTimePickerForm.Value.AddDays(30);
                else
                    dtCheck = dateTimePickerForm.Value.AddYears(1);
                if (dtCheck > dateTimePickerTo.Value)
                {
                    isValid = false;
                    labelInvalidDate.Text = "Enter valid End Date";
                }
                else
                {
                    labelInvalidDate.Text = "";
                }
           

            return isValid;
        }

        private async void actionsUserControl_SaveButtonOnClick(object sender, EventArgs e)
        {
            if (IsFormDataValid())
            {
                tableLayoutPanel.Enabled = false;
                actionsUserControl.IsEnabledButtons = false;
                int id = 0;

                if (_onetimetaskEntity != null)
                {
                     id = _onetimetaskEntity.Id;
                }
                else if (_schtaskEntity != null)
                {
                     id = _schtaskEntity.Id;
                }
                string remarks = remarksTextBox.Text;
                int taskId =comboBoxType.SelectedIndex;
                double duration = double.Parse(amountNumericUpDown.Text);
                DateTime Effectivedate = dateTimePickerEffective.Value;

                if (taskId == 0) {

                    //single time tasks
                    OneTimeTasks taskEntity = new OneTimeTasks()
                    {
                        Id = id,
                        Duration = duration,
                        Comments = remarks,
                        Effectivedate = Effectivedate,
                        IsDelete = false,
                        Type = taskTypeComboBox.SelectedIndex,
                        CreatedDateTime = DateTime.Now
                    };

                    if (id == 0)
                    {
                        await _applicationService.InsertTaskAsync(taskEntity, true);
                    }
                    else
                    {
                        await _applicationService.UpdateTaskAsync(taskEntity);
                    }

                }

                else
                {
                    //Scheduled tasks

                    DateTime dtNextDate = DateTime.Now;
                    string SelectedType = this.comboBoxRepeat.GetItemText(this.comboBoxRepeat.SelectedItem).Trim();
                   
                    if (SelectedType== ContentRepeatItemEnum.Daily.ToString())
                        dtNextDate = dateTimePickerForm.Value.AddDays(1);
                    else if(SelectedType == ContentRepeatItemEnum.Weekly.ToString())
                        dtNextDate = dateTimePickerForm.Value.AddDays(7);
                    else if (SelectedType == ContentRepeatItemEnum.Monthly.ToString())
                        dtNextDate = dateTimePickerForm.Value.AddDays(30);
                    else
                        dtNextDate = dateTimePickerForm.Value.AddYears(1);

                    ScheduledTasks taskSheduledEntity = new ScheduledTasks()
                    {
                        Id = id,
                        Duration = duration,
                        Comments = remarks,
                        Effectivedate = Effectivedate,
                        IsDelete = false,
                        Type = comboBoxType.SelectedIndex,
                        CreatedDateTime = DateTime.Now,
                        RepeatType = SelectedType,
                        StartDateTime = dateTimePickerForm.Value,
                        EndDateTime= dateTimePickerTo.Value,       
                        IsActive = checkBoxActive.Checked,

                    };

                    if (id == 0)
                    {
                        await _applicationService.InsertSheduledTasktAsync(taskSheduledEntity);
                    }
                    else
                    {
                        await _applicationService.UpdateSheduledTaskListAsync(taskSheduledEntity);
                    }
                }

           
                _changeContentMainFormAction(ContentItemEnum.Task);
            }
        }

        private async void actionsUserControl_DeleteButtonOnClick(object sender, EventArgs e)
        {
            int id = 0;

            if (_onetimetaskEntity != null)
            {
                 id = _onetimetaskEntity.Id;
            }
            else if (_schtaskEntity != null)
            {
                 id = _schtaskEntity.Id;
            }

            if (id > 0)
            {
                tableLayoutPanel.Enabled = false;
                actionsUserControl.IsEnabledButtons = false;

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this Task?", "Confrimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (_onetimetaskEntity != null)
                    {
                        await _applicationService.DeleteTaskAsync(_onetimetaskEntity.Id);
                    }
                    else if (_schtaskEntity != null)
                    {
                        await _applicationService.DeleteSheduledTaskAsync(_schtaskEntity.Id);
                    }
                
                    _changeContentMainFormAction(ContentItemEnum.Task);
                }

                tableLayoutPanel.Enabled = true;
                actionsUserControl.IsEnabledButtons = true;
            }
        }

        private void actionsUserControl_ResetButtonOnClick(object sender, EventArgs e)
        {
                 SetTaskEntity();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxType.SelectedIndex == 1) {
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
            }
            else
            {
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                comboBoxRepeat.SelectedIndex = 2;
                dateTimePickerTo.MinDate = DateTime.Today.AddDays(2);
                dateTimePickerForm.MinDate = DateTime.Today.AddDays(1);

            }
        }

        private void dateTimePickerEffective_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerForm.Value = dateTimePickerEffective.Value;
        }
    }
}

