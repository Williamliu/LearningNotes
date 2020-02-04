//******************************************************************************
// Product-Name: TaskScheduler - Demo
// -----------------------------------------------------------------------------
// Version:      1.0
// Release Date: 19.07.2009
// -----------------------------------------------------------------------------
// Autor:        Lothar Perr
// EMail:        lothar.perr@call-data.de
// Homepage:     www.call-data.de
// -----------------------------------------------------------------------------
// License:      CPOL (Code Project Open License)
// -----------------------------------------------------------------------------
// THE SOFTWARE AND THE ACCOMPANYING FILES ARE DISTRIBUTED 
// "AS IS" AND WITHOUT ANY WARRANTIES WHETHER EXPRESSED OR IMPLIED. 
// NO REPONSIBILITIES FOR POSSIBLE DAMAGES OR EVEN FUNCTIONALITY CAN BE TAKEN. 
// THE USER MUST ASSUME THE ENTIRE RISK OF USING THIS SOFTWARE.
//******************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskScheduler
{
    public partial class Demo : Form
    {
        private TaskScheduler _taskScheduler;
        public Demo()
        {
            InitializeComponent();
            _taskScheduler = new TaskScheduler();
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today.AddYears(1);
        }

        private void UpdateTaskList()
        {
            listViewItems.Items.Clear();
            foreach (TaskScheduler.TriggerItem item in _taskScheduler.TriggerItems)
            {
                ListViewItem listItem = listViewItems.Items.Add(item.Tag.ToString());
                listItem.Tag = item;
                DateTime nextDate = item.GetNextTriggerTime();
                if (nextDate != DateTime.MaxValue)
                    listItem.SubItems.Add(nextDate.ToString());
                else
                    listItem.SubItems.Add("Never");
            }
        }

        private void CreateSchedulerItem()
        {
            TaskScheduler.TriggerItem triggerItem = new TaskScheduler.TriggerItem();
            triggerItem.Tag = textBoxlabelOneTimeOnlyTag.Text;
            triggerItem.StartDate = dateTimePickerStartDate.Value;
            triggerItem.EndDate = dateTimePickerEndDate.Value;
            triggerItem.TriggerTime = dateTimePickerTriggerTime.Value;
            triggerItem.OnTrigger += new TaskScheduler.TriggerItem.OnTriggerEventHandler(triggerItem_OnTrigger); // And the trigger-Event :)

            // Set OneTimeOnly - Active and Date
            triggerItem.TriggerSettings.OneTimeOnly.Active = checkBoxOneTimeOnlyActive.Checked;
            triggerItem.TriggerSettings.OneTimeOnly.Date = dateTimePickerOneTimeOnlyDay.Value.Date;

            // Set the interval for daily trigger
            triggerItem.TriggerSettings.Daily.Interval = (ushort)numericUpDownDaily.Value;

            // Set the active days for weekly trigger
            for (byte day = 0; day < 7; day++) // Set the active Days
                triggerItem.TriggerSettings.Weekly.DaysOfWeek[day] = checkedListBoxWeeklyDays.GetItemChecked(day);

            // Set the active months for monthly trigger
            for (byte month = 0; month < 12; month++)
                triggerItem.TriggerSettings.Monthly.Month[month] = checkedListBoxMonthlyMonths.GetItemChecked(month);

            // Set active Days (0..30 = Days, 31=last Day) for monthly trigger
            for (byte day = 0; day < 32; day++)
                triggerItem.TriggerSettings.Monthly.DaysOfMonth[day] = checkedListBoxMonthlyDays.GetItemChecked(day);

            // Set the active weekNumber and DayOfWeek for monthly trigger
            // f.e. the first monday, or the last friday...
            for (byte weekNumber = 0; weekNumber < 5; weekNumber++) // 0..4: first, second, third, fourth or last week
                triggerItem.TriggerSettings.Monthly.WeekDay.WeekNumber[weekNumber] = checkedListBoxMonthlyWeekNumber.GetItemChecked(weekNumber);
            for (byte day = 0; day < 7; day++)
                triggerItem.TriggerSettings.Monthly.WeekDay.DayOfWeek[day] = checkedListBoxMonthlyWeekDay.GetItemChecked(day);

            triggerItem.Enabled = true; // Set the Item-Active - State
            _taskScheduler.AddTrigger(triggerItem); // Add the trigger to List
            _taskScheduler.Enabled = checkBoxEnabled.Checked; // Start the Scheduler
            UpdateTaskList();
        }

        private void ShowAllTriggerDates()
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                TaskScheduler.TriggerItem item = (TaskScheduler.TriggerItem)listViewItems.SelectedItems[0].Tag;
                Form form = new Form();
                ListView listView = new ListView();
                listView.FullRowSelect = true;

                form.Text = "Full list for Task: "+item.Tag.ToString();
                form.Width = 400;
                form.Height = 450;

                listView.Parent = form;
                listView.Dock = DockStyle.Fill;
                listView.View = View.Details;
                listView.Columns.Add("Date", 200);

                DateTime date = dateTimePickerStartDate.Value.Date;
                while (date <= dateTimePickerEndDate.Value.Date)
                {
                    if (item.CheckDate(date)) // probe this date
                        listView.Items.Add(date.ToLongDateString());
                    date = date.AddDays(1);
                }
                form.Show();
            }
            else
                MessageBox.Show("Please select a trigger!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToXML()
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                TaskScheduler.TriggerItem item = (TaskScheduler.TriggerItem)listViewItems.SelectedItems[0].Tag;
                textBoxEvents.Clear();
                textBoxEvents.AppendText(item.ToXML()); // Save the configuration to XML
            }
            else
                MessageBox.Show("Please select a trigger!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void triggerItem_OnTrigger(object sender, TaskScheduler.OnTriggerEventArgs e)
        {
            textBoxEvents.AppendText(e.TriggerDate.ToString() + ": " + e.Item.Tag + ", next trigger: "+e.Item.GetNextTriggerTime().DayOfWeek.ToString()+", " + e.Item.GetNextTriggerTime().ToString()+"\r\n");
            UpdateTaskList();
        }

        private void buttonCreateTrigger_Click(object sender, EventArgs e)
        {
            CreateSchedulerItem();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _taskScheduler.Enabled = false;
            _taskScheduler.TriggerItems.Clear();
            UpdateTaskList();
            textBoxEvents.Clear();
        }

        private void buttonShowAllTrigger_Click(object sender, EventArgs e)
        {
            ShowAllTriggerDates();
        }

        private void buttonToXML_Click(object sender, EventArgs e)
        {
            ExportToXML(); // Use the static method TaskScheduler.TriggerItem.FromXML to load a TriggerItem
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _taskScheduler.Enabled = checkBoxEnabled.Checked;
        }

        private void buttonFromXML_Click(object sender, EventArgs e)
        {
            try
            {
                TaskScheduler.TriggerItem newItem = TaskScheduler.TriggerItem.FromXML(textBoxEvents.Text);
                newItem.Enabled = true; // Enable Item here if you like 
                _taskScheduler.AddTrigger(newItem); // Trigger hinzufügen
                UpdateTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing XML: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}