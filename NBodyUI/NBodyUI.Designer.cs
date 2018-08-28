namespace NBodyUI
{
    partial class NBodyUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxSolarSystem = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxKineticEnergy = new System.Windows.Forms.TextBox();
            this.labelKineticEnergy = new System.Windows.Forms.Label();
            this.labelPotentialEnergy = new System.Windows.Forms.Label();
            this.textBoxPotentialEnergy = new System.Windows.Forms.TextBox();
            this.labelTotalEnergy = new System.Windows.Forms.Label();
            this.textBoxTotalEnergy = new System.Windows.Forms.TextBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelMoonVelocity = new System.Windows.Forms.Label();
            this.textBoxMoonVelocity = new System.Windows.Forms.TextBox();
            this.groupBoxIntMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonRungeKuttaMethod = new System.Windows.Forms.RadioButton();
            this.radioButtonEulerMethod = new System.Windows.Forms.RadioButton();
            this.radioButtonLeapFrogMethod = new System.Windows.Forms.RadioButton();
            this.labelTimeDuration = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxStopIfEnergy = new System.Windows.Forms.CheckBox();
            this.textBoxTimeStep = new System.Windows.Forms.TextBox();
            this.labelTimeStep = new System.Windows.Forms.Label();
            this.textBoxUpdateInterval = new System.Windows.Forms.TextBox();
            this.labelUpdateInterval = new System.Windows.Forms.Label();
            this.textBoxRunTime = new System.Windows.Forms.TextBox();
            this.labelRunTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowAsteroidOrbits = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCometOrbits = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeComAsterInForce = new System.Windows.Forms.CheckBox();
            this.textBoxNumAsteroids = new System.Windows.Forms.TextBox();
            this.textBoxNumComets = new System.Windows.Forms.TextBox();
            this.checkBoxAsteroid = new System.Windows.Forms.CheckBox();
            this.checkBoxComet = new System.Windows.Forms.CheckBox();
            this.checkBoxJupiter = new System.Windows.Forms.CheckBox();
            this.checkBoxMars = new System.Windows.Forms.CheckBox();
            this.checkBoxEarth = new System.Windows.Forms.CheckBox();
            this.checkBoxVenus = new System.Windows.Forms.CheckBox();
            this.checkBoxMercury = new System.Windows.Forms.CheckBox();
            this.checkBoxSun = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.buttonClearConsole = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolarSystem)).BeginInit();
            this.groupBoxIntMethod.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxSolarSystem
            // 
            this.pictureBoxSolarSystem.BackColor = System.Drawing.Color.Black;
            this.pictureBoxSolarSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSolarSystem.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSolarSystem.Name = "pictureBoxSolarSystem";
            this.pictureBoxSolarSystem.Size = new System.Drawing.Size(591, 622);
            this.pictureBoxSolarSystem.TabIndex = 0;
            this.pictureBoxSolarSystem.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.White;
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(206, 58);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxKineticEnergy
            // 
            this.textBoxKineticEnergy.Location = new System.Drawing.Point(34, 19);
            this.textBoxKineticEnergy.Name = "textBoxKineticEnergy";
            this.textBoxKineticEnergy.Size = new System.Drawing.Size(151, 20);
            this.textBoxKineticEnergy.TabIndex = 2;
            this.textBoxKineticEnergy.Text = "0";
            // 
            // labelKineticEnergy
            // 
            this.labelKineticEnergy.AutoSize = true;
            this.labelKineticEnergy.Location = new System.Drawing.Point(7, 22);
            this.labelKineticEnergy.Name = "labelKineticEnergy";
            this.labelKineticEnergy.Size = new System.Drawing.Size(21, 13);
            this.labelKineticEnergy.TabIndex = 3;
            this.labelKineticEnergy.Text = "KE";
            // 
            // labelPotentialEnergy
            // 
            this.labelPotentialEnergy.AutoSize = true;
            this.labelPotentialEnergy.Location = new System.Drawing.Point(7, 48);
            this.labelPotentialEnergy.Name = "labelPotentialEnergy";
            this.labelPotentialEnergy.Size = new System.Drawing.Size(21, 13);
            this.labelPotentialEnergy.TabIndex = 4;
            this.labelPotentialEnergy.Text = "PE";
            // 
            // textBoxPotentialEnergy
            // 
            this.textBoxPotentialEnergy.Location = new System.Drawing.Point(34, 45);
            this.textBoxPotentialEnergy.Name = "textBoxPotentialEnergy";
            this.textBoxPotentialEnergy.Size = new System.Drawing.Size(151, 20);
            this.textBoxPotentialEnergy.TabIndex = 5;
            this.textBoxPotentialEnergy.Text = "0";
            // 
            // labelTotalEnergy
            // 
            this.labelTotalEnergy.AutoSize = true;
            this.labelTotalEnergy.Location = new System.Drawing.Point(7, 74);
            this.labelTotalEnergy.Name = "labelTotalEnergy";
            this.labelTotalEnergy.Size = new System.Drawing.Size(21, 13);
            this.labelTotalEnergy.TabIndex = 6;
            this.labelTotalEnergy.Text = "TE";
            // 
            // textBoxTotalEnergy
            // 
            this.textBoxTotalEnergy.Location = new System.Drawing.Point(34, 71);
            this.textBoxTotalEnergy.Name = "textBoxTotalEnergy";
            this.textBoxTotalEnergy.Size = new System.Drawing.Size(151, 20);
            this.textBoxTotalEnergy.TabIndex = 7;
            this.textBoxTotalEnergy.Text = "0";
            // 
            // labelMonth
            // 
            this.labelMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(96, 16);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(51, 13);
            this.labelMonth.TabIndex = 8;
            this.labelMonth.Text = "0 Months";
            // 
            // labelYear
            // 
            this.labelYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(11, 16);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(43, 13);
            this.labelYear.TabIndex = 9;
            this.labelYear.Text = "0 Years";
            // 
            // labelMoonVelocity
            // 
            this.labelMoonVelocity.AutoSize = true;
            this.labelMoonVelocity.Location = new System.Drawing.Point(7, 100);
            this.labelMoonVelocity.Name = "labelMoonVelocity";
            this.labelMoonVelocity.Size = new System.Drawing.Size(50, 13);
            this.labelMoonVelocity.TabIndex = 10;
            this.labelMoonVelocity.Text = "Earth Vel";
            // 
            // textBoxMoonVelocity
            // 
            this.textBoxMoonVelocity.Location = new System.Drawing.Point(67, 97);
            this.textBoxMoonVelocity.Name = "textBoxMoonVelocity";
            this.textBoxMoonVelocity.Size = new System.Drawing.Size(118, 20);
            this.textBoxMoonVelocity.TabIndex = 11;
            this.textBoxMoonVelocity.Text = "0";
            // 
            // groupBoxIntMethod
            // 
            this.groupBoxIntMethod.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxIntMethod.Controls.Add(this.radioButtonRungeKuttaMethod);
            this.groupBoxIntMethod.Controls.Add(this.radioButtonEulerMethod);
            this.groupBoxIntMethod.Controls.Add(this.radioButtonLeapFrogMethod);
            this.groupBoxIntMethod.Location = new System.Drawing.Point(12, 76);
            this.groupBoxIntMethod.Name = "groupBoxIntMethod";
            this.groupBoxIntMethod.Size = new System.Drawing.Size(206, 74);
            this.groupBoxIntMethod.TabIndex = 12;
            this.groupBoxIntMethod.TabStop = false;
            this.groupBoxIntMethod.Text = "ODE Integration Method";
            // 
            // radioButtonRungeKuttaMethod
            // 
            this.radioButtonRungeKuttaMethod.AutoSize = true;
            this.radioButtonRungeKuttaMethod.Location = new System.Drawing.Point(10, 43);
            this.radioButtonRungeKuttaMethod.Name = "radioButtonRungeKuttaMethod";
            this.radioButtonRungeKuttaMethod.Size = new System.Drawing.Size(85, 17);
            this.radioButtonRungeKuttaMethod.TabIndex = 3;
            this.radioButtonRungeKuttaMethod.TabStop = true;
            this.radioButtonRungeKuttaMethod.Text = "Runge-Kutta";
            this.radioButtonRungeKuttaMethod.UseVisualStyleBackColor = true;
            this.radioButtonRungeKuttaMethod.CheckedChanged += new System.EventHandler(this.radioButtonRungeKuttaMethod_CheckedChanged);
            // 
            // radioButtonEulerMethod
            // 
            this.radioButtonEulerMethod.AutoSize = true;
            this.radioButtonEulerMethod.Location = new System.Drawing.Point(10, 20);
            this.radioButtonEulerMethod.Name = "radioButtonEulerMethod";
            this.radioButtonEulerMethod.Size = new System.Drawing.Size(49, 17);
            this.radioButtonEulerMethod.TabIndex = 2;
            this.radioButtonEulerMethod.TabStop = true;
            this.radioButtonEulerMethod.Text = "Euler";
            this.radioButtonEulerMethod.UseVisualStyleBackColor = true;
            this.radioButtonEulerMethod.CheckedChanged += new System.EventHandler(this.radioButtonEulerMethod_CheckedChanged);
            // 
            // radioButtonLeapFrogMethod
            // 
            this.radioButtonLeapFrogMethod.AutoSize = true;
            this.radioButtonLeapFrogMethod.Location = new System.Drawing.Point(106, 20);
            this.radioButtonLeapFrogMethod.Name = "radioButtonLeapFrogMethod";
            this.radioButtonLeapFrogMethod.Size = new System.Drawing.Size(73, 17);
            this.radioButtonLeapFrogMethod.TabIndex = 1;
            this.radioButtonLeapFrogMethod.Text = "Leap Frog";
            this.radioButtonLeapFrogMethod.UseVisualStyleBackColor = true;
            // 
            // labelTimeDuration
            // 
            this.labelTimeDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeDuration.AutoSize = true;
            this.labelTimeDuration.Location = new System.Drawing.Point(67, 39);
            this.labelTimeDuration.Name = "labelTimeDuration";
            this.labelTimeDuration.Size = new System.Drawing.Size(13, 13);
            this.labelTimeDuration.TabIndex = 13;
            this.labelTimeDuration.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Duration:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.textBoxMoonVelocity);
            this.groupBox1.Controls.Add(this.labelMoonVelocity);
            this.groupBox1.Controls.Add(this.textBoxKineticEnergy);
            this.groupBox1.Controls.Add(this.labelKineticEnergy);
            this.groupBox1.Controls.Add(this.labelPotentialEnergy);
            this.groupBox1.Controls.Add(this.checkBoxStopIfEnergy);
            this.groupBox1.Controls.Add(this.textBoxPotentialEnergy);
            this.groupBox1.Controls.Add(this.textBoxTotalEnergy);
            this.groupBox1.Controls.Add(this.labelTotalEnergy);
            this.groupBox1.Location = new System.Drawing.Point(12, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 154);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Energy";
            // 
            // checkBoxStopIfEnergy
            // 
            this.checkBoxStopIfEnergy.AutoSize = true;
            this.checkBoxStopIfEnergy.Location = new System.Drawing.Point(10, 123);
            this.checkBoxStopIfEnergy.Name = "checkBoxStopIfEnergy";
            this.checkBoxStopIfEnergy.Size = new System.Drawing.Size(110, 17);
            this.checkBoxStopIfEnergy.TabIndex = 25;
            this.checkBoxStopIfEnergy.Text = "Stop if Energy > 0";
            this.checkBoxStopIfEnergy.UseVisualStyleBackColor = true;
            // 
            // textBoxTimeStep
            // 
            this.textBoxTimeStep.Location = new System.Drawing.Point(99, 23);
            this.textBoxTimeStep.Name = "textBoxTimeStep";
            this.textBoxTimeStep.Size = new System.Drawing.Size(60, 20);
            this.textBoxTimeStep.TabIndex = 17;
            this.textBoxTimeStep.Text = "50";
            // 
            // labelTimeStep
            // 
            this.labelTimeStep.AutoSize = true;
            this.labelTimeStep.Location = new System.Drawing.Point(9, 26);
            this.labelTimeStep.Name = "labelTimeStep";
            this.labelTimeStep.Size = new System.Drawing.Size(79, 13);
            this.labelTimeStep.TabIndex = 18;
            this.labelTimeStep.Text = "Timestep (sec):";
            // 
            // textBoxUpdateInterval
            // 
            this.textBoxUpdateInterval.Location = new System.Drawing.Point(99, 49);
            this.textBoxUpdateInterval.Name = "textBoxUpdateInterval";
            this.textBoxUpdateInterval.Size = new System.Drawing.Size(60, 20);
            this.textBoxUpdateInterval.TabIndex = 19;
            this.textBoxUpdateInterval.Text = "50000";
            // 
            // labelUpdateInterval
            // 
            this.labelUpdateInterval.AutoSize = true;
            this.labelUpdateInterval.Location = new System.Drawing.Point(10, 52);
            this.labelUpdateInterval.Name = "labelUpdateInterval";
            this.labelUpdateInterval.Size = new System.Drawing.Size(83, 13);
            this.labelUpdateInterval.TabIndex = 20;
            this.labelUpdateInterval.Text = "Update Interval:";
            // 
            // textBoxRunTime
            // 
            this.textBoxRunTime.Location = new System.Drawing.Point(99, 76);
            this.textBoxRunTime.Name = "textBoxRunTime";
            this.textBoxRunTime.Size = new System.Drawing.Size(60, 20);
            this.textBoxRunTime.TabIndex = 21;
            // 
            // labelRunTime
            // 
            this.labelRunTime.AutoSize = true;
            this.labelRunTime.Location = new System.Drawing.Point(10, 79);
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(73, 13);
            this.labelRunTime.TabIndex = 22;
            this.labelRunTime.Text = "Runtime (Yrs):";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.checkBoxShowAsteroidOrbits);
            this.groupBox2.Controls.Add(this.checkBoxShowCometOrbits);
            this.groupBox2.Controls.Add(this.checkBoxIncludeComAsterInForce);
            this.groupBox2.Controls.Add(this.textBoxNumAsteroids);
            this.groupBox2.Controls.Add(this.textBoxNumComets);
            this.groupBox2.Controls.Add(this.checkBoxAsteroid);
            this.groupBox2.Controls.Add(this.checkBoxComet);
            this.groupBox2.Controls.Add(this.checkBoxJupiter);
            this.groupBox2.Controls.Add(this.checkBoxMars);
            this.groupBox2.Controls.Add(this.checkBoxEarth);
            this.groupBox2.Controls.Add(this.checkBoxVenus);
            this.groupBox2.Controls.Add(this.checkBoxMercury);
            this.groupBox2.Controls.Add(this.checkBoxSun);
            this.groupBox2.Location = new System.Drawing.Point(224, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 226);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bodies";
            // 
            // checkBoxShowAsteroidOrbits
            // 
            this.checkBoxShowAsteroidOrbits.AutoSize = true;
            this.checkBoxShowAsteroidOrbits.Location = new System.Drawing.Point(10, 185);
            this.checkBoxShowAsteroidOrbits.Name = "checkBoxShowAsteroidOrbits";
            this.checkBoxShowAsteroidOrbits.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowAsteroidOrbits.TabIndex = 12;
            this.checkBoxShowAsteroidOrbits.Text = "Show Asteroid Orbits";
            this.checkBoxShowAsteroidOrbits.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCometOrbits
            // 
            this.checkBoxShowCometOrbits.AutoSize = true;
            this.checkBoxShowCometOrbits.Location = new System.Drawing.Point(10, 161);
            this.checkBoxShowCometOrbits.Name = "checkBoxShowCometOrbits";
            this.checkBoxShowCometOrbits.Size = new System.Drawing.Size(116, 17);
            this.checkBoxShowCometOrbits.TabIndex = 11;
            this.checkBoxShowCometOrbits.Text = "Show Comet Orbits";
            this.checkBoxShowCometOrbits.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeComAsterInForce
            // 
            this.checkBoxIncludeComAsterInForce.AutoSize = true;
            this.checkBoxIncludeComAsterInForce.Location = new System.Drawing.Point(10, 138);
            this.checkBoxIncludeComAsterInForce.Name = "checkBoxIncludeComAsterInForce";
            this.checkBoxIncludeComAsterInForce.Size = new System.Drawing.Size(153, 17);
            this.checkBoxIncludeComAsterInForce.TabIndex = 10;
            this.checkBoxIncludeComAsterInForce.Text = "Include in force calculation";
            this.checkBoxIncludeComAsterInForce.UseVisualStyleBackColor = true;
            // 
            // textBoxNumAsteroids
            // 
            this.textBoxNumAsteroids.Location = new System.Drawing.Point(100, 112);
            this.textBoxNumAsteroids.Name = "textBoxNumAsteroids";
            this.textBoxNumAsteroids.Size = new System.Drawing.Size(85, 20);
            this.textBoxNumAsteroids.TabIndex = 9;
            // 
            // textBoxNumComets
            // 
            this.textBoxNumComets.Location = new System.Drawing.Point(99, 89);
            this.textBoxNumComets.Name = "textBoxNumComets";
            this.textBoxNumComets.Size = new System.Drawing.Size(86, 20);
            this.textBoxNumComets.TabIndex = 8;
            // 
            // checkBoxAsteroid
            // 
            this.checkBoxAsteroid.AutoSize = true;
            this.checkBoxAsteroid.BackColor = System.Drawing.Color.DimGray;
            this.checkBoxAsteroid.ForeColor = System.Drawing.Color.White;
            this.checkBoxAsteroid.Location = new System.Drawing.Point(10, 114);
            this.checkBoxAsteroid.Name = "checkBoxAsteroid";
            this.checkBoxAsteroid.Size = new System.Drawing.Size(64, 17);
            this.checkBoxAsteroid.TabIndex = 7;
            this.checkBoxAsteroid.Text = "Asteroid";
            this.checkBoxAsteroid.UseVisualStyleBackColor = false;
            // 
            // checkBoxComet
            // 
            this.checkBoxComet.AutoSize = true;
            this.checkBoxComet.BackColor = System.Drawing.Color.White;
            this.checkBoxComet.Location = new System.Drawing.Point(10, 91);
            this.checkBoxComet.Name = "checkBoxComet";
            this.checkBoxComet.Size = new System.Drawing.Size(56, 17);
            this.checkBoxComet.TabIndex = 6;
            this.checkBoxComet.Text = "Comet";
            this.checkBoxComet.UseVisualStyleBackColor = false;
            // 
            // checkBoxJupiter
            // 
            this.checkBoxJupiter.AutoSize = true;
            this.checkBoxJupiter.BackColor = System.Drawing.Color.Orange;
            this.checkBoxJupiter.Location = new System.Drawing.Point(100, 68);
            this.checkBoxJupiter.Name = "checkBoxJupiter";
            this.checkBoxJupiter.Size = new System.Drawing.Size(57, 17);
            this.checkBoxJupiter.TabIndex = 5;
            this.checkBoxJupiter.Text = "Jupiter";
            this.checkBoxJupiter.UseVisualStyleBackColor = false;
            // 
            // checkBoxMars
            // 
            this.checkBoxMars.AutoSize = true;
            this.checkBoxMars.BackColor = System.Drawing.Color.OrangeRed;
            this.checkBoxMars.Location = new System.Drawing.Point(100, 45);
            this.checkBoxMars.Name = "checkBoxMars";
            this.checkBoxMars.Size = new System.Drawing.Size(49, 17);
            this.checkBoxMars.TabIndex = 4;
            this.checkBoxMars.Text = "Mars";
            this.checkBoxMars.UseVisualStyleBackColor = false;
            // 
            // checkBoxEarth
            // 
            this.checkBoxEarth.AutoSize = true;
            this.checkBoxEarth.BackColor = System.Drawing.Color.Blue;
            this.checkBoxEarth.ForeColor = System.Drawing.Color.White;
            this.checkBoxEarth.Location = new System.Drawing.Point(100, 20);
            this.checkBoxEarth.Name = "checkBoxEarth";
            this.checkBoxEarth.Size = new System.Drawing.Size(51, 17);
            this.checkBoxEarth.TabIndex = 3;
            this.checkBoxEarth.Text = "Earth";
            this.checkBoxEarth.UseVisualStyleBackColor = false;
            // 
            // checkBoxVenus
            // 
            this.checkBoxVenus.AutoSize = true;
            this.checkBoxVenus.BackColor = System.Drawing.Color.SteelBlue;
            this.checkBoxVenus.ForeColor = System.Drawing.Color.White;
            this.checkBoxVenus.Location = new System.Drawing.Point(10, 68);
            this.checkBoxVenus.Name = "checkBoxVenus";
            this.checkBoxVenus.Size = new System.Drawing.Size(56, 17);
            this.checkBoxVenus.TabIndex = 2;
            this.checkBoxVenus.Text = "Venus";
            this.checkBoxVenus.UseVisualStyleBackColor = false;
            // 
            // checkBoxMercury
            // 
            this.checkBoxMercury.AutoSize = true;
            this.checkBoxMercury.BackColor = System.Drawing.Color.DarkGray;
            this.checkBoxMercury.Location = new System.Drawing.Point(10, 44);
            this.checkBoxMercury.Name = "checkBoxMercury";
            this.checkBoxMercury.Size = new System.Drawing.Size(64, 17);
            this.checkBoxMercury.TabIndex = 1;
            this.checkBoxMercury.Text = "Mercury";
            this.checkBoxMercury.UseVisualStyleBackColor = false;
            // 
            // checkBoxSun
            // 
            this.checkBoxSun.AutoSize = true;
            this.checkBoxSun.BackColor = System.Drawing.Color.Yellow;
            this.checkBoxSun.Location = new System.Drawing.Point(10, 20);
            this.checkBoxSun.Name = "checkBoxSun";
            this.checkBoxSun.Size = new System.Drawing.Size(45, 17);
            this.checkBoxSun.TabIndex = 0;
            this.checkBoxSun.Text = "Sun";
            this.checkBoxSun.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.labelTimeStep);
            this.groupBox3.Controls.Add(this.textBoxTimeStep);
            this.groupBox3.Controls.Add(this.labelRunTime);
            this.groupBox3.Controls.Add(this.textBoxUpdateInterval);
            this.groupBox3.Controls.Add(this.textBoxRunTime);
            this.groupBox3.Controls.Add(this.labelUpdateInterval);
            this.groupBox3.Location = new System.Drawing.Point(12, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 109);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input Parameters";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxConsole.Location = new System.Drawing.Point(13, 432);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(417, 180);
            this.textBoxConsole.TabIndex = 26;
            // 
            // buttonClearConsole
            // 
            this.buttonClearConsole.Location = new System.Drawing.Point(224, 403);
            this.buttonClearConsole.Name = "buttonClearConsole";
            this.buttonClearConsole.Size = new System.Drawing.Size(75, 23);
            this.buttonClearConsole.TabIndex = 27;
            this.buttonClearConsole.Text = "Clear";
            this.buttonClearConsole.UseVisualStyleBackColor = true;
            this.buttonClearConsole.Click += new System.EventHandler(this.buttonClearConsole_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel1.Controls.Add(this.buttonClearConsole);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxIntMethod);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxConsole);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxSolarSystem);
            this.splitContainer1.Size = new System.Drawing.Size(1033, 622);
            this.splitContainer1.SplitterDistance = 438;
            this.splitContainer1.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.labelTimeDuration);
            this.groupBox4.Controls.Add(this.labelMonth);
            this.groupBox4.Controls.Add(this.labelYear);
            this.groupBox4.Location = new System.Drawing.Point(224, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 66);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            // 
            // NBodyUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 622);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NBodyUI";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolarSystem)).EndInit();
            this.groupBoxIntMethod.ResumeLayout(false);
            this.groupBoxIntMethod.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSolarSystem;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxKineticEnergy;
        private System.Windows.Forms.Label labelKineticEnergy;
        private System.Windows.Forms.Label labelPotentialEnergy;
        private System.Windows.Forms.TextBox textBoxPotentialEnergy;
        private System.Windows.Forms.Label labelTotalEnergy;
        private System.Windows.Forms.TextBox textBoxTotalEnergy;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelMoonVelocity;
        private System.Windows.Forms.TextBox textBoxMoonVelocity;
        private System.Windows.Forms.GroupBox groupBoxIntMethod;
        private System.Windows.Forms.RadioButton radioButtonLeapFrogMethod;
        private System.Windows.Forms.Label labelTimeDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTimeStep;
        private System.Windows.Forms.Label labelTimeStep;
        private System.Windows.Forms.TextBox textBoxUpdateInterval;
        private System.Windows.Forms.Label labelUpdateInterval;
        private System.Windows.Forms.TextBox textBoxRunTime;
        private System.Windows.Forms.Label labelRunTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxSun;
        private System.Windows.Forms.CheckBox checkBoxAsteroid;
        private System.Windows.Forms.CheckBox checkBoxComet;
        private System.Windows.Forms.CheckBox checkBoxJupiter;
        private System.Windows.Forms.CheckBox checkBoxMars;
        private System.Windows.Forms.CheckBox checkBoxEarth;
        private System.Windows.Forms.CheckBox checkBoxVenus;
        private System.Windows.Forms.CheckBox checkBoxMercury;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxStopIfEnergy;
        private System.Windows.Forms.TextBox textBoxNumAsteroids;
        private System.Windows.Forms.TextBox textBoxNumComets;
        private System.Windows.Forms.RadioButton radioButtonEulerMethod;
        private System.Windows.Forms.RadioButton radioButtonRungeKuttaMethod;
        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.Button buttonClearConsole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxIncludeComAsterInForce;
        private System.Windows.Forms.CheckBox checkBoxShowCometOrbits;
        private System.Windows.Forms.CheckBox checkBoxShowAsteroidOrbits;
    }
}

