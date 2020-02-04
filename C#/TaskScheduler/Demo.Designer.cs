namespace TaskScheduler
{
    partial class Demo
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownDaily = new System.Windows.Forms.NumericUpDown();
            this.labelDailyEvery = new System.Windows.Forms.Label();
            this.labelDailyDay = new System.Windows.Forms.Label();
            this.checkedListBoxWeeklyDays = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyMonths = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyDays = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyWeekNumber = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMonthlyWeekDay = new System.Windows.Forms.CheckedListBox();
            this.tabControlMode = new System.Windows.Forms.TabControl();
            this.tabPageOneTimeOnly = new System.Windows.Forms.TabPage();
            this.checkBoxOneTimeOnlyActive = new System.Windows.Forms.CheckBox();
            this.labelOneTimeOnlyDay = new System.Windows.Forms.Label();
            this.dateTimePickerOneTimeOnlyDay = new System.Windows.Forms.DateTimePicker();
            this.tabPageDaily = new System.Windows.Forms.TabPage();
            this.tabPageWeekly = new System.Windows.Forms.TabPage();
            this.labelWeeklyDays = new System.Windows.Forms.Label();
            this.tabPageMonthly = new System.Windows.Forms.TabPage();
            this.tabControlMonthlyMode = new System.Windows.Forms.TabControl();
            this.tabPageMonthlyDayOfMonth = new System.Windows.Forms.TabPage();
            this.tabPageMonthlyWeekDay = new System.Windows.Forms.TabPage();
            this.labelMonthlyMonth = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonCreateTrigger = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextTrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonShowAllTrigger = new System.Windows.Forms.Button();
            this.dateTimePickerTriggerTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.buttonToXML = new System.Windows.Forms.Button();
            this.textBoxlabelOneTimeOnlyTag = new System.Windows.Forms.TextBox();
            this.labelOneTimeOnlyTag = new System.Windows.Forms.Label();
            this.buttonFromXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaily)).BeginInit();
            this.tabControlMode.SuspendLayout();
            this.tabPageOneTimeOnly.SuspendLayout();
            this.tabPageDaily.SuspendLayout();
            this.tabPageWeekly.SuspendLayout();
            this.tabPageMonthly.SuspendLayout();
            this.tabControlMonthlyMode.SuspendLayout();
            this.tabPageMonthlyDayOfMonth.SuspendLayout();
            this.tabPageMonthlyWeekDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownDaily
            // 
            this.numericUpDownDaily.Location = new System.Drawing.Point(60, 18);
            this.numericUpDownDaily.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownDaily.Name = "numericUpDownDaily";
            this.numericUpDownDaily.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownDaily.TabIndex = 3;
            // 
            // labelDailyEvery
            // 
            this.labelDailyEvery.AutoSize = true;
            this.labelDailyEvery.Location = new System.Drawing.Point(20, 20);
            this.labelDailyEvery.Name = "labelDailyEvery";
            this.labelDailyEvery.Size = new System.Drawing.Size(34, 13);
            this.labelDailyEvery.TabIndex = 4;
            this.labelDailyEvery.Text = "Every";
            // 
            // labelDailyDay
            // 
            this.labelDailyDay.AutoSize = true;
            this.labelDailyDay.Location = new System.Drawing.Point(115, 20);
            this.labelDailyDay.Name = "labelDailyDay";
            this.labelDailyDay.Size = new System.Drawing.Size(24, 13);
            this.labelDailyDay.TabIndex = 5;
            this.labelDailyDay.Text = "day";
            // 
            // checkedListBoxWeeklyDays
            // 
            this.checkedListBoxWeeklyDays.FormattingEnabled = true;
            this.checkedListBoxWeeklyDays.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.checkedListBoxWeeklyDays.Location = new System.Drawing.Point(60, 20);
            this.checkedListBoxWeeklyDays.Name = "checkedListBoxWeeklyDays";
            this.checkedListBoxWeeklyDays.Size = new System.Drawing.Size(104, 109);
            this.checkedListBoxWeeklyDays.TabIndex = 27;
            // 
            // checkedListBoxMonthlyMonths
            // 
            this.checkedListBoxMonthlyMonths.FormattingEnabled = true;
            this.checkedListBoxMonthlyMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.checkedListBoxMonthlyMonths.Location = new System.Drawing.Point(60, 20);
            this.checkedListBoxMonthlyMonths.Name = "checkedListBoxMonthlyMonths";
            this.checkedListBoxMonthlyMonths.Size = new System.Drawing.Size(120, 109);
            this.checkedListBoxMonthlyMonths.TabIndex = 28;
            // 
            // checkedListBoxMonthlyDays
            // 
            this.checkedListBoxMonthlyDays.FormattingEnabled = true;
            this.checkedListBoxMonthlyDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "Last Day"});
            this.checkedListBoxMonthlyDays.Location = new System.Drawing.Point(8, 8);
            this.checkedListBoxMonthlyDays.Name = "checkedListBoxMonthlyDays";
            this.checkedListBoxMonthlyDays.Size = new System.Drawing.Size(229, 109);
            this.checkedListBoxMonthlyDays.TabIndex = 29;
            // 
            // checkedListBoxMonthlyWeekNumber
            // 
            this.checkedListBoxMonthlyWeekNumber.FormattingEnabled = true;
            this.checkedListBoxMonthlyWeekNumber.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.checkedListBoxMonthlyWeekNumber.Location = new System.Drawing.Point(8, 8);
            this.checkedListBoxMonthlyWeekNumber.Name = "checkedListBoxMonthlyWeekNumber";
            this.checkedListBoxMonthlyWeekNumber.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxMonthlyWeekNumber.TabIndex = 33;
            // 
            // checkedListBoxMonthlyWeekDay
            // 
            this.checkedListBoxMonthlyWeekDay.FormattingEnabled = true;
            this.checkedListBoxMonthlyWeekDay.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.checkedListBoxMonthlyWeekDay.Location = new System.Drawing.Point(132, 8);
            this.checkedListBoxMonthlyWeekDay.Name = "checkedListBoxMonthlyWeekDay";
            this.checkedListBoxMonthlyWeekDay.Size = new System.Drawing.Size(104, 109);
            this.checkedListBoxMonthlyWeekDay.TabIndex = 34;
            // 
            // tabControlMode
            // 
            this.tabControlMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMode.Controls.Add(this.tabPageOneTimeOnly);
            this.tabControlMode.Controls.Add(this.tabPageDaily);
            this.tabControlMode.Controls.Add(this.tabPageWeekly);
            this.tabControlMode.Controls.Add(this.tabPageMonthly);
            this.tabControlMode.Location = new System.Drawing.Point(16, 125);
            this.tabControlMode.Name = "tabControlMode";
            this.tabControlMode.SelectedIndex = 0;
            this.tabControlMode.Size = new System.Drawing.Size(833, 206);
            this.tabControlMode.TabIndex = 35;
            // 
            // tabPageOneTimeOnly
            // 
            this.tabPageOneTimeOnly.Controls.Add(this.checkBoxOneTimeOnlyActive);
            this.tabPageOneTimeOnly.Controls.Add(this.labelOneTimeOnlyDay);
            this.tabPageOneTimeOnly.Controls.Add(this.dateTimePickerOneTimeOnlyDay);
            this.tabPageOneTimeOnly.Location = new System.Drawing.Point(4, 22);
            this.tabPageOneTimeOnly.Name = "tabPageOneTimeOnly";
            this.tabPageOneTimeOnly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOneTimeOnly.Size = new System.Drawing.Size(825, 180);
            this.tabPageOneTimeOnly.TabIndex = 0;
            this.tabPageOneTimeOnly.Tag = "1";
            this.tabPageOneTimeOnly.Text = "One time only";
            this.tabPageOneTimeOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxOneTimeOnlyActive
            // 
            this.checkBoxOneTimeOnlyActive.AutoSize = true;
            this.checkBoxOneTimeOnlyActive.Location = new System.Drawing.Point(20, 20);
            this.checkBoxOneTimeOnlyActive.Name = "checkBoxOneTimeOnlyActive";
            this.checkBoxOneTimeOnlyActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxOneTimeOnlyActive.TabIndex = 3;
            this.checkBoxOneTimeOnlyActive.Text = "Active";
            this.checkBoxOneTimeOnlyActive.UseVisualStyleBackColor = true;
            // 
            // labelOneTimeOnlyDay
            // 
            this.labelOneTimeOnlyDay.AutoSize = true;
            this.labelOneTimeOnlyDay.Location = new System.Drawing.Point(18, 53);
            this.labelOneTimeOnlyDay.Name = "labelOneTimeOnlyDay";
            this.labelOneTimeOnlyDay.Size = new System.Drawing.Size(29, 13);
            this.labelOneTimeOnlyDay.TabIndex = 2;
            this.labelOneTimeOnlyDay.Text = "Day:";
            // 
            // dateTimePickerOneTimeOnlyDay
            // 
            this.dateTimePickerOneTimeOnlyDay.Location = new System.Drawing.Point(53, 47);
            this.dateTimePickerOneTimeOnlyDay.Name = "dateTimePickerOneTimeOnlyDay";
            this.dateTimePickerOneTimeOnlyDay.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerOneTimeOnlyDay.TabIndex = 1;
            // 
            // tabPageDaily
            // 
            this.tabPageDaily.Controls.Add(this.numericUpDownDaily);
            this.tabPageDaily.Controls.Add(this.labelDailyEvery);
            this.tabPageDaily.Controls.Add(this.labelDailyDay);
            this.tabPageDaily.Location = new System.Drawing.Point(4, 22);
            this.tabPageDaily.Name = "tabPageDaily";
            this.tabPageDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDaily.Size = new System.Drawing.Size(825, 180);
            this.tabPageDaily.TabIndex = 1;
            this.tabPageDaily.Tag = "2";
            this.tabPageDaily.Text = "Daily";
            this.tabPageDaily.UseVisualStyleBackColor = true;
            // 
            // tabPageWeekly
            // 
            this.tabPageWeekly.Controls.Add(this.labelWeeklyDays);
            this.tabPageWeekly.Controls.Add(this.checkedListBoxWeeklyDays);
            this.tabPageWeekly.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeekly.Name = "tabPageWeekly";
            this.tabPageWeekly.Size = new System.Drawing.Size(825, 180);
            this.tabPageWeekly.TabIndex = 3;
            this.tabPageWeekly.Tag = "3";
            this.tabPageWeekly.Text = "Weekly";
            this.tabPageWeekly.UseVisualStyleBackColor = true;
            // 
            // labelWeeklyDays
            // 
            this.labelWeeklyDays.AutoSize = true;
            this.labelWeeklyDays.Location = new System.Drawing.Point(20, 20);
            this.labelWeeklyDays.Name = "labelWeeklyDays";
            this.labelWeeklyDays.Size = new System.Drawing.Size(34, 13);
            this.labelWeeklyDays.TabIndex = 28;
            this.labelWeeklyDays.Text = "Days:";
            // 
            // tabPageMonthly
            // 
            this.tabPageMonthly.Controls.Add(this.tabControlMonthlyMode);
            this.tabPageMonthly.Controls.Add(this.labelMonthlyMonth);
            this.tabPageMonthly.Controls.Add(this.checkedListBoxMonthlyMonths);
            this.tabPageMonthly.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthly.Name = "tabPageMonthly";
            this.tabPageMonthly.Size = new System.Drawing.Size(825, 180);
            this.tabPageMonthly.TabIndex = 2;
            this.tabPageMonthly.Text = "Monthly";
            this.tabPageMonthly.UseVisualStyleBackColor = true;
            // 
            // tabControlMonthlyMode
            // 
            this.tabControlMonthlyMode.Controls.Add(this.tabPageMonthlyDayOfMonth);
            this.tabControlMonthlyMode.Controls.Add(this.tabPageMonthlyWeekDay);
            this.tabControlMonthlyMode.Location = new System.Drawing.Point(186, 20);
            this.tabControlMonthlyMode.Name = "tabControlMonthlyMode";
            this.tabControlMonthlyMode.SelectedIndex = 0;
            this.tabControlMonthlyMode.Size = new System.Drawing.Size(251, 154);
            this.tabControlMonthlyMode.TabIndex = 30;
            // 
            // tabPageMonthlyDayOfMonth
            // 
            this.tabPageMonthlyDayOfMonth.Controls.Add(this.checkedListBoxMonthlyDays);
            this.tabPageMonthlyDayOfMonth.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthlyDayOfMonth.Name = "tabPageMonthlyDayOfMonth";
            this.tabPageMonthlyDayOfMonth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonthlyDayOfMonth.Size = new System.Drawing.Size(243, 128);
            this.tabPageMonthlyDayOfMonth.TabIndex = 0;
            this.tabPageMonthlyDayOfMonth.Text = "Day of Month";
            this.tabPageMonthlyDayOfMonth.UseVisualStyleBackColor = true;
            // 
            // tabPageMonthlyWeekDay
            // 
            this.tabPageMonthlyWeekDay.Controls.Add(this.checkedListBoxMonthlyWeekNumber);
            this.tabPageMonthlyWeekDay.Controls.Add(this.checkedListBoxMonthlyWeekDay);
            this.tabPageMonthlyWeekDay.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthlyWeekDay.Name = "tabPageMonthlyWeekDay";
            this.tabPageMonthlyWeekDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonthlyWeekDay.Size = new System.Drawing.Size(243, 128);
            this.tabPageMonthlyWeekDay.TabIndex = 1;
            this.tabPageMonthlyWeekDay.Text = "Weekday";
            this.tabPageMonthlyWeekDay.UseVisualStyleBackColor = true;
            // 
            // labelMonthlyMonth
            // 
            this.labelMonthlyMonth.AutoSize = true;
            this.labelMonthlyMonth.Location = new System.Drawing.Point(20, 20);
            this.labelMonthlyMonth.Name = "labelMonthlyMonth";
            this.labelMonthlyMonth.Size = new System.Drawing.Size(40, 13);
            this.labelMonthlyMonth.TabIndex = 29;
            this.labelMonthlyMonth.Text = "Month:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(13, 15);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(32, 13);
            this.labelStartDate.TabIndex = 36;
            this.labelStartDate.Text = "Start:";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(61, 12);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 37;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(61, 38);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 39;
            this.dateTimePickerEndDate.Value = new System.DateTime(2010, 7, 12, 17, 25, 0, 0);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(13, 41);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(29, 13);
            this.labelEndDate.TabIndex = 38;
            this.labelEndDate.Text = "End:";
            // 
            // buttonCreateTrigger
            // 
            this.buttonCreateTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateTrigger.Location = new System.Drawing.Point(715, 337);
            this.buttonCreateTrigger.Name = "buttonCreateTrigger";
            this.buttonCreateTrigger.Size = new System.Drawing.Size(130, 23);
            this.buttonCreateTrigger.TabIndex = 40;
            this.buttonCreateTrigger.Text = "Create Trigger Item";
            this.buttonCreateTrigger.UseVisualStyleBackColor = true;
            this.buttonCreateTrigger.Click += new System.EventHandler(this.buttonCreateTrigger_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(715, 366);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(130, 23);
            this.buttonReset.TabIndex = 41;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // listViewItems
            // 
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.NextTrigger});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.Location = new System.Drawing.Point(16, 347);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(671, 115);
            this.listViewItems.TabIndex = 46;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item";
            this.ItemName.Width = 150;
            // 
            // NextTrigger
            // 
            this.NextTrigger.Text = "Next Trigger";
            this.NextTrigger.Width = 150;
            // 
            // buttonShowAllTrigger
            // 
            this.buttonShowAllTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowAllTrigger.Location = new System.Drawing.Point(715, 395);
            this.buttonShowAllTrigger.Name = "buttonShowAllTrigger";
            this.buttonShowAllTrigger.Size = new System.Drawing.Size(130, 23);
            this.buttonShowAllTrigger.TabIndex = 47;
            this.buttonShowAllTrigger.Text = "Show Day-List";
            this.buttonShowAllTrigger.UseVisualStyleBackColor = true;
            this.buttonShowAllTrigger.Click += new System.EventHandler(this.buttonShowAllTrigger_Click);
            // 
            // dateTimePickerTriggerTime
            // 
            this.dateTimePickerTriggerTime.CustomFormat = "";
            this.dateTimePickerTriggerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTriggerTime.Location = new System.Drawing.Point(61, 64);
            this.dateTimePickerTriggerTime.Name = "dateTimePickerTriggerTime";
            this.dateTimePickerTriggerTime.ShowUpDown = true;
            this.dateTimePickerTriggerTime.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerTriggerTime.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Time:";
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.Location = new System.Drawing.Point(715, 487);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxEnabled.TabIndex = 50;
            this.checkBoxEnabled.Text = "Enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.checkBoxEnabled_CheckedChanged);
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEvents.Location = new System.Drawing.Point(16, 468);
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.Size = new System.Drawing.Size(671, 117);
            this.textBoxEvents.TabIndex = 51;
            this.textBoxEvents.WordWrap = false;
            // 
            // buttonToXML
            // 
            this.buttonToXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToXML.Location = new System.Drawing.Point(548, 408);
            this.buttonToXML.Name = "buttonToXML";
            this.buttonToXML.Size = new System.Drawing.Size(130, 23);
            this.buttonToXML.TabIndex = 52;
            this.buttonToXML.Text = "ToXML";
            this.buttonToXML.UseVisualStyleBackColor = true;
            this.buttonToXML.Click += new System.EventHandler(this.buttonToXML_Click);
            // 
            // textBoxlabelOneTimeOnlyTag
            // 
            this.textBoxlabelOneTimeOnlyTag.Location = new System.Drawing.Point(63, 88);
            this.textBoxlabelOneTimeOnlyTag.Name = "textBoxlabelOneTimeOnlyTag";
            this.textBoxlabelOneTimeOnlyTag.Size = new System.Drawing.Size(152, 20);
            this.textBoxlabelOneTimeOnlyTag.TabIndex = 54;
            this.textBoxlabelOneTimeOnlyTag.Text = "New Item";
            // 
            // labelOneTimeOnlyTag
            // 
            this.labelOneTimeOnlyTag.AutoSize = true;
            this.labelOneTimeOnlyTag.Location = new System.Drawing.Point(13, 91);
            this.labelOneTimeOnlyTag.Name = "labelOneTimeOnlyTag";
            this.labelOneTimeOnlyTag.Size = new System.Drawing.Size(29, 13);
            this.labelOneTimeOnlyTag.TabIndex = 53;
            this.labelOneTimeOnlyTag.Text = "Tag:";
            // 
            // buttonFromXML
            // 
            this.buttonFromXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFromXML.Location = new System.Drawing.Point(548, 437);
            this.buttonFromXML.Name = "buttonFromXML";
            this.buttonFromXML.Size = new System.Drawing.Size(130, 23);
            this.buttonFromXML.TabIndex = 55;
            this.buttonFromXML.Text = "FromXML";
            this.buttonFromXML.UseVisualStyleBackColor = true;
            this.buttonFromXML.Click += new System.EventHandler(this.buttonFromXML_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 597);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.buttonFromXML);
            this.Controls.Add(this.textBoxlabelOneTimeOnlyTag);
            this.Controls.Add(this.labelOneTimeOnlyTag);
            this.Controls.Add(this.buttonToXML);
            this.Controls.Add(this.textBoxEvents);
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerTriggerTime);
            this.Controls.Add(this.buttonShowAllTrigger);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonCreateTrigger);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.tabControlMode);
            this.Name = "Demo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Scheduler Demo";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaily)).EndInit();
            this.tabControlMode.ResumeLayout(false);
            this.tabPageOneTimeOnly.ResumeLayout(false);
            this.tabPageOneTimeOnly.PerformLayout();
            this.tabPageDaily.ResumeLayout(false);
            this.tabPageDaily.PerformLayout();
            this.tabPageWeekly.ResumeLayout(false);
            this.tabPageWeekly.PerformLayout();
            this.tabPageMonthly.ResumeLayout(false);
            this.tabPageMonthly.PerformLayout();
            this.tabControlMonthlyMode.ResumeLayout(false);
            this.tabPageMonthlyDayOfMonth.ResumeLayout(false);
            this.tabPageMonthlyWeekDay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownDaily;
        private System.Windows.Forms.Label labelDailyEvery;
        private System.Windows.Forms.Label labelDailyDay;
        private System.Windows.Forms.CheckedListBox checkedListBoxWeeklyDays;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyMonths;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyDays;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyWeekNumber;
        private System.Windows.Forms.CheckedListBox checkedListBoxMonthlyWeekDay;
        private System.Windows.Forms.TabControl tabControlMode;
        private System.Windows.Forms.TabPage tabPageOneTimeOnly;
        private System.Windows.Forms.TabPage tabPageDaily;
        private System.Windows.Forms.TabPage tabPageMonthly;
        private System.Windows.Forms.Label labelOneTimeOnlyDay;
        private System.Windows.Forms.TabPage tabPageWeekly;
        private System.Windows.Forms.Label labelWeeklyDays;
        private System.Windows.Forms.Label labelMonthlyMonth;
        private System.Windows.Forms.TabControl tabControlMonthlyMode;
        private System.Windows.Forms.TabPage tabPageMonthlyDayOfMonth;
        private System.Windows.Forms.TabPage tabPageMonthlyWeekDay;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonCreateTrigger;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader NextTrigger;
        private System.Windows.Forms.Button buttonShowAllTrigger;
        private System.Windows.Forms.DateTimePicker dateTimePickerTriggerTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.Button buttonToXML;
        private System.Windows.Forms.TextBox textBoxlabelOneTimeOnlyTag;
        private System.Windows.Forms.Label labelOneTimeOnlyTag;
        private System.Windows.Forms.CheckBox checkBoxOneTimeOnlyActive;
        private System.Windows.Forms.Button buttonFromXML;
        private System.Windows.Forms.DateTimePicker dateTimePickerOneTimeOnlyDay;

    }
}

