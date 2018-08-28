/*
 * Copyright  (C) 2011 Jeff Balsley. All Rights Reserved
 * 
 * @File:
 * 
 * @Author: Jeff Balsley
 * @Date: 1/20/2011
 * @Version: 0.9
 * 
 * @TODOs
 * ===============================================================================
 *  - Create some enums.
 *  - Create object bitmask.
 *  - Create method to read in UI user input instead of doing so inline in c-tor.
 *  - Rewrite RandDouble2. DONE
 *  - Rewrite RandDouble() to take 2 params. DONE
 *  - Finish Runge-Kutta integration method.
 *  - Finish Euler Method. DONE
 *  - Create stuct to hold pixel diameters of objects
 *  
 * 
 * 
 * @Revision History
 * 
 * Date         Author          Comment
 * ================================================================================
 * 1/20/2011    Jeff            - Created this file
 * 2/07/2011    Jeff            - Wrote RandDouble3() that takes 2 input params
 * 2/10/2011    Jeff            - Finished Euler method
 * 
 * 
 * 
 *  
 *  Objects    Time for 1 yr
 * ----------------------------
 *      25      1 min
 *      50      2 min
 *     100      5 min 30 seconds
 *     125      8 min
 *     150     11 min
 *     200     16 min
 *     300     32 min
 *     500      1 hr 19 min
 *
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NBodyLib;
using System.Diagnostics;

namespace NBodyUI
{
    public partial class NBodyUI : Form
    {
        public double h;  // TIME_STEP used in numerical integration methods
        public double h0;   // initial h
        public long timeStepCounter;

        const ushort AU_PIXELS = 75;
        const ushort SUN_SIZE = 17; // diameter of sun in pixels
        const ushort EARTH_SIZE = 9; // diameter of Earth in pixels
        const ushort MOON_SIZE = 5; // diameter of Moon in pixels
        const ushort MERCURY_SIZE = 5;
        const ushort VENUS_SIZE = 9;
        const ushort MARS_SIZE = 7;
        const ushort JUPITER_SIZE = 11;
        const ushort DEFAULT_SIZE = 3; // diameter of default body
        const ushort COMET_SIZE = 2;    // comets 
        const ushort ASTEROID_SIZE = 2;    //  Asteroids

        public long UPDATE_INTERVAL = 10000;
        public short NumberComets = 1;
        public short NumberAsteroids = 1;
        double RunTime = 1;             // by default, run time is 1 year

        const string AsteroidName = "Asteroid";
        const string CometName = "Comet";

        //
        // Seed random num generator
        //
        public static Random ranObj = new Random();


        //
        // Initialize physical constants in  meters, kilograms, and seconds (mks)
        //
        PhysicalConstants Constants = new PhysicalConstants("mks");

        public NBodyUI()
        {
            InitializeComponent();

            //
            //
            //
            InitializeUI();

            splitContainer1.SplitterDistance = 442;
            //splitContainer1.Panel1.
            
        }

        /// <summary>
        /// This method initialized all the UI input parameters for a default simulation.
        /// The user is free to change these defaults before beginning their simulation.
        /// </summary>
        public void InitializeUI()
        {
            //
            // By default, use LeapFrog integration method
            //
            radioButtonLeapFrogMethod.Checked = true;

            //
            // By default, include all objects in sumulation
            //
            checkBoxSun.Checked = true;
            checkBoxMercury.Checked = false;
            checkBoxVenus.Checked = false;
            checkBoxEarth.Checked = false;
            checkBoxMars.Checked = false;
            checkBoxJupiter.Checked = true;
            checkBoxComet.Checked = true;
            checkBoxAsteroid.Checked = false;

            //
            // Set default number of comets and asteroids
            //
            textBoxNumComets.Text = "5";
            textBoxNumAsteroids.Text = "5";

            //
            // By default run parameters
            //
            textBoxTimeStep.Text = "50";
            textBoxUpdateInterval.Text = "50000";
            textBoxRunTime.Text = "2.5";
            checkBoxStopIfEnergy.Checked = true;

            //
            // Draw coordinate system
            //
            DrawCoordinateSystem(Color.Gray);

            return;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ErasePictureBox();
            //DrawCoordinateSystem(Color.DimGray);

            DateTime start = DateTime.Now;

            try
            {
                h = Convert.ToDouble(textBoxTimeStep.Text);
                h0 = h;
                UPDATE_INTERVAL = Convert.ToInt64(textBoxUpdateInterval.Text);
                RunTime = Convert.ToDouble(textBoxRunTime.Text);
                NumberComets = Convert.ToInt16(textBoxNumComets.Text);
                NumberAsteroids = Convert.ToInt16(textBoxNumAsteroids.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(
                    ex.Message, //"Input string is not a sequence of digits.", 
                    "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }


            if (radioButtonEulerMethod.Checked)
            {
                StartSimulationEuler(start);
            }
            else if (radioButtonLeapFrogMethod.Checked)
            {
                StartSimulationLeapFrog(start);
            }
            labelTimeDuration.Text = CalculateTimeDuration(start, DateTime.Now);

        }

        /// <summary>
        /// This method begins a simulation using the Euler method to integrate the equations a motion.  
        /// It is currently unsupported.
        /// </summary>
        public void StartSimulationEuler(DateTime start)
        {
            EnergyStruct Energy = new EnergyStruct(0,0,0);
            List<Body> Bodies = new List<Body>();

            InitializeBodies(Bodies);
            double t0 = 0;
            double t;

            for (t = t0 + h; t < RunTime * Constants.SECONDS_PER_YEAR; t += h)
            {
                CalculateForces(Bodies);

                if (Math.Round(t, 1) % UPDATE_INTERVAL == 0)
                {
                    UpdateUI(Bodies, t, ref Energy, start);
                }

                //
                // Update positions and velocities
                //
                foreach (Body b in Bodies)
                {
                    UpdateVelocity(b);
                    UpdatePosition(b);

                }

                //
                // Break if Total Energy > 0, ie Moon escapes
                //
                if (Energy.Total > 0)
                {
                    MessageBox.Show(
                        "The Moon has escaped!", 
                        "Error", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    break;
                }

            }
        } // End Start Simulation

        /// <summary>
        /// This method begins a simulation using the LeapFrog  method to integrate the equations a motion.  
        /// </summary>
        /// <param name="start">A DateTime object to mark the start time of the simulation.</param>
        public void StartSimulationLeapFrog(DateTime start)
        {
            EnergyStruct Energy = new EnergyStruct(0,0,0);

            List<Body> Bodies = new List<Body>();

            InitializeBodies(Bodies);

            double t0 = 0;
            double t;
            double remainder = 0;
            double remainderOld = 0;

            for (t = t0 + h; t < RunTime * Constants.SECONDS_PER_YEAR; t += h)
            {
                CalculateForces(Bodies);

                remainder = Math.Round(t, 1) % UPDATE_INTERVAL;

                if (remainder < remainderOld)
                {
                    UpdateUI(Bodies, t, ref Energy, start);
                }

                //
                // Update positions and velocities
                //
                foreach (Body b in Bodies)
                {
                    // Don't update Sun
                    if (!String.Equals(b.Name, "Sun", StringComparison.OrdinalIgnoreCase))
                        UpdateLeapFrog2d(b);
                }

                //
                // Break if Total Energy > 0, ie Moon escapes
                //
                if (Energy.Total > 0 && checkBoxStopIfEnergy.Checked)
                {
                    MessageBox.Show(
                        "Total energy > 0!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    break;
                }

                remainderOld = remainder;
            }
            UpdateUI(Bodies, t, ref Energy, start);

        } // End StartSimulationLeapFrog()

        /// <summary>
        /// Calculates the gravitational force between two bodies.  It will set the force properties, 
        /// Fx and Fy, in the Body objects.
        /// </summary>
        /// <param name="b1">Body object number 1.</param>
        /// <param name="b2">Body object number 2.</param>
        public void CalculateForce(Body b1, Body b2)
        {
            double angle;
            angle = Math.Atan2(Math.Abs(b2.X - b1.X), Math.Abs(b2.Y - b1.Y)); // calculate angle in radians
            double TotalForce = CalculateTotalForce(b1, b2);
            //
            // _    G (m1 * m2)  ^
            // F = ------------- r
            //           r^2
            //
            //         _
            // ^       r
            // r =  -------
            //        |r|
            //

            // Force in X-dir
            if (b2.X == b1.X)
            {
                b1.Fx = 0;
                b2.Fx = 0;
            }
            else
            {
                //b1.Fx = Constants.GRAVITATIONAL_CONSTANT * (b2.X - b1.X) * (b1.Mass * b2.Mass) /
                //         Math.Pow(Math.Abs(b2.X - b1.X), 3);
                b1.Fx = TotalForce * Math.Sin(angle);

                if (b1.X > b2.X)
                {
                    b1.Fx = -b1.Fx;
                }

                b2.Fx = -b1.Fx;
            }

            // force in Y-dir
            if (b2.Y == b1.Y)
            {
                b1.Fy = 0;
                b2.Fy = 0;
            }
            else
            {
                //b1.Fy = Constants.GRAVITATIONAL_CONSTANT * (b2.Y - b1.Y) * (b1.Mass * b2.Mass) /
                //         Math.Pow(Math.Abs(b2.Y - b1.Y), 3);
                b1.Fy = TotalForce * Math.Cos(angle);
                if (b1.Y > b2.Y)
                {
                    b1.Fy = -b1.Fy;
                }

                b2.Fy = -b1.Fy;
            }
        }

        //
        // Calculates magnitude (always returns positive number) of force between two bodies.  
        //
        public double CalculateTotalForce(Body b1, Body b2)
        {
            double totalForce;

            // total force
            //
            //      G (m1 * m2)
            // F = ------------
            //           r^2
            //
            totalForce = Constants.GRAVITATIONAL_CONSTANT * (b1.Mass * b2.Mass) /
                 (Math.Pow(b1.X - b2.X, 2) + Math.Pow(b1.Y - b2.Y, 2));

            Debug.Assert(totalForce >= 0, "Magnitude of gravitational force should be >= 0.");

            return totalForce;
        }

        /// <summary>
        /// Calculates the gravitational forces between each object in the List of bodies.
        /// </summary>
        /// <param name="Bodies">List of Body objects.</param>
        public void CalculateForces(List<Body> Bodies)
        {
            // first, Zero forces for each iteration
            foreach (Body b in Bodies)
            {
                b.Fx = 0;
                b.Fy = 0;
            }

            // now, sum up forces
            for (int i = 0; i < Bodies.Count; ++i)
            {
                for (int j = i + 1; j < Bodies.Count; ++j)
                {
                    //
                    // If both bodies are either a comet or an asteroid, check if checkBoxIncludeComAsterInForce
                    // checkbox is checked.  If not, leave these interactions out of the force calculation for
                    // performance reasons
                    //
                    if (((Bodies[i].Name == CometName || Bodies[i].Name == AsteroidName) &&
                        (Bodies[j].Name == CometName || Bodies[j].Name == AsteroidName)) && !checkBoxIncludeComAsterInForce.Checked)
                    {
                        continue;
                    }
                    else
                    {
                        SumForces(Bodies[i], Bodies[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the gravitational force between two bodies and adds the force to the preexisting Fx and Fy properties.
        /// </summary>
        /// <param name="b1">Body 1</param>
        /// <param name="b2">Body 2</param>
        public void SumForces(Body b1, Body b2)
        {
            double ForceInXDir = 0;
            double ForceInYDir = 0;

            //
            // TODO: check that we don't assert if b2.Y - b1.Y = 0
            //
            double angle = Math.Atan2(Math.Abs(b2.X - b1.X), Math.Abs(b2.Y - b1.Y)); // calculate angle in radians
            double TotalForce = CalculateTotalForce(b1, b2);
            Debug.Assert(TotalForce >= 0, "The magnitude of the gravitation force is < 0.");

            // Force in X-dir
            if (b2.X == b1.X)
            {
                ForceInXDir = 0;
            }
            else
            {
                ForceInXDir = TotalForce * Math.Sin(angle);
            }

            // force in Y-dir
            if (b2.Y == b1.Y)
            {
                ForceInYDir = 0;
            }
            else
            {
                ForceInYDir = TotalForce * Math.Cos(angle);
            }

            //
            // Add these forces to the current forces on the two bodies
            // TODO: b1.Fx -= ForceInXDir
            if (b1.X > b2.X)
            {
                b1.Fx = b1.Fx - ForceInXDir;
                b2.Fx = b2.Fx + ForceInXDir;
            }
            else
            {
                b1.Fx = b1.Fx + ForceInXDir;
                b2.Fx = b2.Fx - ForceInXDir;
            }

            if (b1.Y > b2.Y)
            {
                b1.Fy = b1.Fy - ForceInYDir;
                b2.Fy = b2.Fy + ForceInYDir;
            }
            else
            {
                b1.Fy = b1.Fy + ForceInYDir;
                b2.Fy = b2.Fy - ForceInYDir;
            }

        }

        /// <summary>
        /// Calculates the total energy of the system using kinetic energy and potential energy.
        /// </summary>
        /// <param name="Bodies">List of Body objects.</param>
        /// <param name="Energy">EnergyStruct structure.</param>
        /// <returns>Total energy (KE + PE)</returns>
        public double TotalEnergy(List<Body> Bodies, ref EnergyStruct Energy)
        {
            Energy.Kinetic = 0;
            Energy.Potential = 0;
            //
            //         1            
            //  KE =  --- m V^2
            //         2
            //
            foreach (Body b in Bodies)
            {
                Energy.Kinetic = Energy.Kinetic + .5 * b.Mass * (Math.Pow(b.Vx, 2) + Math.Pow(b.Vy, 2));
            }

            //
            //           Mm
            // PE = -G -----
            //           r
            //
            Energy.Potential = CalculatePotentialEnergy(Bodies);

            Energy.Total = Energy.Kinetic + Energy.Potential;

            return Energy.Total;
        }

        /// <summary>
        /// Calculates the total energy of two object using kinetic energy and potential energy.
        /// </summary>
        /// <param name="b1">Body 1.</param>
        /// <param name="b2">Body 2</param>
        /// <param name="Energy">EnergyStruct structure.</param>
        /// <returns>Total energy (KE + PE)</returns>
        public double TotalEnergy(Body b1, Body b2, ref EnergyStruct Energy)
        {
            //
            //         1            
            //  KE =  --- m V^2
            //         2
            //
            Energy.Kinetic = .5 * b1.Mass * (Math.Pow(b1.Vx, 2) + Math.Pow(b1.Vy, 2));
            Energy.Kinetic = Energy.Kinetic + .5 * b2.Mass * (Math.Pow(b2.Vx, 2) + Math.Pow(b2.Vy, 2));

            //
            //           Mm
            // PE = -G -----
            //           r
            //
            Energy.Potential = -(Constants.GRAVITATIONAL_CONSTANT * b1.Mass * b2.Mass) /
                           CalculateDistanceBetween(b1, b2);

            Energy.Total = Energy.Kinetic + Energy.Potential;

            return Energy.Total;
        }

        /// <summary>
        /// Calculates the potential energy of the system.
        /// </summary>
        /// <param name="Bodies">List of Body objects included in the system.</param>
        /// <returns>Potential energy</returns>
        public double CalculatePotentialEnergy(List<Body> Bodies)
        {
            int count = 0;
            double PE = 0;

            for (int i = 0; i < Bodies.Count; ++i)
            {
                for (int j = i + 1; j < Bodies.Count; ++j)
                {
                    PE = PE -(Constants.GRAVITATIONAL_CONSTANT * Bodies[i].Mass * Bodies[j].Mass) /
                           CalculateDistanceBetween(Bodies[i], Bodies[j]);
                    count++;
                    // TODO: Add PE calulation to Bodies[i].PotentialEnergy;
                }
            }

            Debug.Assert(PE < 0, "Potential Energy is > 0.");
            //Debug.Assert(count == );
            // Put an assert for # times we should cycle through loop
            //textBoxConsole.AppendText(String.Format("{0}\r\n", PE.ToString()));

            return PE;
        }

        public void CalculatePEforEachBody(List<Body> Bodies)
        {
            double PE = 0;  // Potential Energy of a selected body

            //
            // Loop though each body in the List and calculate it's PE in the system
            //
            for (int i = 0; i < Bodies.Count; ++i)
            {
                for (int j = 0; j < Bodies.Count; ++j)
                {
                    //
                    // Can't compare a body with itself
                    //
                    if (i == j)
                        continue;

                    PE -= (Constants.GRAVITATIONAL_CONSTANT * Bodies[i].Mass * Bodies[j].Mass) /
                           CalculateDistanceBetween(Bodies[i], Bodies[j]);

                }

                //
                // After summing all bodies j that contribute to the PE of body i, set the 
                // PE in the Body object of i
                //
                Bodies[i].PotentialEnergy = PE;
            }

            double totalPE= 0;
            foreach (Body b in Bodies)
            {
                textBoxConsole.AppendText(String.Format("\r\n{0}\r\n", b.Name));
                textBoxConsole.AppendText(String.Format("PE: {0}", b.PotentialEnergy));
                textBoxConsole.AppendText(String.Format(" KE: {0}\r\n", b.KE()));
                textBoxConsole.AppendText(String.Format("Total: {0}\r\n", b.KE() + b.PotentialEnergy));
                totalPE += b.PotentialEnergy;
            }
            textBoxConsole.AppendText(String.Format("Total PE: {0}", totalPE.ToString()));



            return;
        }

        public int JeffPolynomials(int i)
        {
            int total = 0;

            if (i == 2)
                return 1;
            else
                total = total + JeffPolynomials(i - 1);

            return total;
        }

        /// <summary>
        /// Calculates distance between two objects in meters.
        /// </summary>
        /// <param name="b1">Body 1</param>
        /// <param name="b2">Body 2</param>
        /// <returns>Distance in meters</returns>
        public double CalculateDistanceBetween(Body b1, Body b2)
        {
            double distance = Math.Sqrt(Math.Pow(b1.X - b2.X, 2) + Math.Pow(b1.Y - b2.Y, 2));

            Debug.Assert(distance > 0, "Distance between two objects must be > 0.");
            return distance;
        }

        /// <summary>
        /// This will update the velocity of a Body.  Used for Euler method
        /// </summary>
        /// <param name="b1">The Body Object to update the velocity.</param>
        public void UpdateVelocity(Body b1)
        {
            //
            // v(t) = v0 + (F/m * t)
            //
            // Make sure to calculate force for this timestep first
            b1.Vx = b1.Vx + (b1.Fx / b1.Mass) * h;
            b1.Vy = b1.Vy + (b1.Fy / b1.Mass) * h;
            return;
        }

        /// <summary>
        /// This will update the position of a Body. Used in Euler method
        /// </summary>
        /// <param name="b1">Update the positoin of this Body.</param>
        public void UpdatePosition(Body b1)
        {
            //
            // x(t) = x0 + v0*t + (.5)*(F/m)*t^2
            //

            // Make sure to calculate force first for this timestep
            b1.X = b1.X +
                   b1.Vx * h +
                   .5 * (b1.Fx / b1.Mass) * Math.Pow(h, 2);

            b1.Y = b1.Y +
                   b1.Vy * h +
                   .5 * (b1.Fy / b1.Mass) * Math.Pow(h, 2);

            return;
        }

        /// <summary>
        /// Calculates magnitude of the velocity of one body object.
        /// </summary>
        /// <param name="b1">Body object to find velocity of.</param>
        /// <returns>speed in m/s</returns>
        public double CalculateVelocity(Body b1)
        {
            double speed = Math.Sqrt(Math.Pow(b1.Vx, 2) + Math.Pow(b1.Vy, 2));

            Debug.Assert(speed >= 0, "Magnitude of velocity must be >= 0");

            return speed;
        }

        //
        // This takes a Body object and updates the x & y positions and velocities
        // The forces must first be updated with the CalculateForce() function in the Body object 
        // prior to calling this function.
        //
        public void UpdateLeapFrog2d(Body myBody)
        {
            double initialVelocity = myBody.TotalVelocity();

            double x_new, vx_new, x_half;
            double y_new, vy_new, y_half;

            x_half = myBody.X + .5 * h * der_x(myBody.Vx);
            vx_new = myBody.Vx + h * der_vx(myBody);
            x_new = x_half + .5 * h * der_x(vx_new);

            //textBoxConsole.AppendText(String.Format("{0}: Vx {1}%\r\n", myBody.Name, 100 * h * der_vx(myBody) / myBody.Vx));

            y_half = myBody.Y + .5 * h * der_y(myBody.Vy);
            vy_new = myBody.Vy + h * der_vy(myBody);
            y_new = y_half + .5 * h * der_y(vy_new);

            //textBoxConsole.AppendText(String.Format("{0}: Vy {1}%\r\n", myBody.Name, 100 * h * der_vy(myBody) / myBody.Vy));

            // find change in angle
            double initAngle = (180.0 / Math.PI) * Math.Atan2(Math.Abs(myBody.Vx), Math.Abs(myBody.Vy));
            double finalAngle = (180.0 / Math.PI) * Math.Atan2(Math.Abs(vx_new), Math.Abs(vy_new));
            double angleChange = Math.Abs(finalAngle - initAngle);

            if (angleChange > .01) // > .01 degree
            {
                //textBoxConsole.AppendText(String.Format("Change in Angle: {0} degrees\r\n", angleChange));
                h /= 10;
                textBoxTimeStep.Text = String.Format("{0}", h);
                timeStepCounter = 0;
                //Debug.Assert(false);
            }
            else
            {
                timeStepCounter++;
            }

            myBody.X = x_new;
            myBody.Vx = vx_new;
            myBody.Y = y_new;
            myBody.Vy = vy_new;

            if (Double.IsNaN(myBody.X) || Double.IsNaN(myBody.Y))
                Debug.Assert(false ,"After Updateing positions, NaN");

            double endVelocity = myBody.TotalVelocity();
            double velocityChangePercent = (100 * Math.Abs(endVelocity - initialVelocity)) / initialVelocity;
            if (velocityChangePercent > .01)
            {
                //textBoxConsole.AppendText(String.Format("{0} end vel is {1}% of init vel.\r\n\r\n",
                //                    myBody.Name, (100 * Math.Abs(endVelocity - initialVelocity)) / initialVelocity));
                h /= 10;
                textBoxTimeStep.Text = String.Format("{0}", h);
                timeStepCounter = 0;
                //Debug.Assert(false);
            }
            else
            {
                timeStepCounter++;
            }

            if ( (h < h0) && (timeStepCounter > 1000000) ) // if our timestep is less than the initial timestep
            {
                h *= 10;
                //h = 50;
                textBoxTimeStep.Text = String.Format("{0}", h);
                //textBoxConsole.AppendText(String.Format("Upping h to {0}\r\n", h));
            }

        }

        /// <summary>
        /// This method will convert the length in meters to pixels to be used in the picture box window.
        /// </summary>
        /// <param name="Meters">meters</param>
        /// <returns>Integer number of pixels</returns>
        public int ConvertMetersToPixels(double Meters)
        {
            if (Double.IsNaN(Meters))
                MessageBox.Show("Oops!, Meters is NaN: " + Meters);

            // pixels / meter
            double ConvFactor = AU_PIXELS / Constants.ASTRONOMICAL_UNIT;

            double NumPixels = ConvFactor * Meters;

            bool what = true;
            what = (Meters == Double.NaN);
            if (Double.IsNaN(Meters))
                MessageBox.Show("Oops! NaN");
            //
            // Round to nearest Pixel
            //
                
            // TODO can overflow int; maybe make it a long.
            return Convert.ToInt32(NumPixels);
        }

        public void ErasePictureBox()
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            g.Clear(Color.Black);
            g.Dispose();
        }

        public void DrawSun(int x, int y, Color bodyColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(bodyColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - SUN_SIZE/2;
            myPoint.Y = myPoint.Y - SUN_SIZE/2;

            Rectangle rect = new Rectangle(myPoint, new Size(SUN_SIZE, SUN_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        public void DrawEarth(int x, int y, Color EarthColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(EarthColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - EARTH_SIZE / 2;
            myPoint.Y = myPoint.Y - EARTH_SIZE / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(EARTH_SIZE, EARTH_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        public void DrawMoon(int x, int y, Color MoonColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(MoonColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - MOON_SIZE / 2;
            myPoint.Y = myPoint.Y - MOON_SIZE / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(MOON_SIZE, MOON_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        public void DrawMercury(int x, int y, Color bodyColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(bodyColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - MERCURY_SIZE / 2;
            myPoint.Y = myPoint.Y - MERCURY_SIZE / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(MERCURY_SIZE, MERCURY_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        public void DrawVenus(int x, int y, Color bodyColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(bodyColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - VENUS_SIZE / 2;
            myPoint.Y = myPoint.Y - VENUS_SIZE / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(VENUS_SIZE, VENUS_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        public void DrawMars(int x, int y, Color bodyColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(bodyColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - MARS_SIZE / 2;
            myPoint.Y = myPoint.Y - MARS_SIZE / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(MARS_SIZE, MARS_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }


        public void DrawDefault(int x, int y, Color DefaultColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(DefaultColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - DEFAULT_SIZE / 2;
            myPoint.Y = myPoint.Y - DEFAULT_SIZE / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(DEFAULT_SIZE, DEFAULT_SIZE));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        /// <summary>
        /// Draws a square representing the celestial object in the picture window.
        /// </summary>
        /// <param name="x">X position in pixels</param>
        /// <param name="y">Y position in pixels</param>
        /// <param name="DefaultColor">Color of object to use in pen</param>
        /// <param name="bodySize">Diameter of object in pixels</param>
        public void DrawCircularBody(int x, int y, Color DefaultColor, int bodySize)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(DefaultColor);
            //Pen myPen = new Pen(DefaultColor, 10);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - bodySize / 2;
            myPoint.Y = myPoint.Y - bodySize / 2;

            //Rectangle rect = new Rectangle(myPoint, new Size(bodySize, bodySize));
            //g.FillRectangle(brush, rect);

            g.FillEllipse(brush, 
                Convert.ToInt16(myPoint.X), 
                Convert.ToInt16(myPoint.Y), 
                Convert.ToInt16(bodySize), 
                Convert.ToInt16(bodySize));

            g.Dispose();
        }

        /// <summary>
        /// Draws a square representing the celestial object in the picture window.
        /// </summary>
        /// <param name="x">X position in pixels</param>
        /// <param name="y">Y position in pixels</param>
        /// <param name="DefaultColor">Color of object to use in pen</param>
        /// <param name="bodySize">Diameter of object in pixels</param>
        public void DrawSquareBody(int x, int y, Color DefaultColor, int bodySize)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(DefaultColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - bodySize / 2;
            myPoint.Y = myPoint.Y - bodySize / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(bodySize, bodySize));
            g.FillRectangle(brush, rect);

            g.Dispose();
        }

        public void DrawComet(int x, int y, Color DefaultColor, int bodySize)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            SolidBrush brush = new SolidBrush(DefaultColor);

            Point myPoint = new Point(ConvertXCor(x), ConvertYCor(y));
            myPoint.X = myPoint.X - bodySize / 2;
            myPoint.Y = myPoint.Y - bodySize / 2;

            Rectangle rect = new Rectangle(myPoint, new Size(bodySize, bodySize));
            g.FillRectangle(brush, rect);

            //Pen myPen = new Pen(Color.LightGray, 1);
            //Point point1 = new Point(ConvertXCor(x), ConvertYCor(y));
            //Point point2 = new Point(ConvertXCor(Math.Round(0.1 * x, 1)), ConvertYCor(Math.Round(0.1 * y,1)));
            //g.DrawLine(myPen, point1, point2);

            g.Dispose();
        }

        /*public void DrawCometTail(Color tailColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            Pen myPen = new Pen(tailColor, 1);

            Point point1 = new Point(ConvertXCor(x), ConvertYCor(y));
            Point point2 = new Point(ConvertXCor(x+10), ConvertYCor(y+10));
            g.DrawLine(myPen, point1, point2);

            g.Dispose();
        }*/


        public void EraseBodies(Body Earth, Body Moon)
        {
            DrawEarth(ConvertMetersToPixels(Earth.X), ConvertMetersToPixels(Earth.Y), Color.White);
            DrawMoon(ConvertMetersToPixels(Moon.X), ConvertMetersToPixels(Moon.Y), Color.White);
        }

        /// <summary>
        /// Draws the x-y coordinate system in the picture window.
        /// </summary>
        /// <param name="coordColor">Color of axis</param>
        public void DrawCoordinateSystem(Color coordColor)
        {
            Graphics g = Graphics.FromHwnd(pictureBoxSolarSystem.Handle);
            Pen myPen = new Pen(coordColor, 1);

            Point point1 = new Point(ConvertXCor(0), ConvertYCor(-pictureBoxSolarSystem.Size.Height / 2));
            Point point2 = new Point(ConvertXCor(0), ConvertYCor(pictureBoxSolarSystem.Size.Height / 2));
            g.DrawLine(myPen, point1, point2);

            Point point3 = new Point(ConvertXCor(-pictureBoxSolarSystem.Size.Width / 2), ConvertYCor(0));
            Point point4 = new Point(ConvertXCor(pictureBoxSolarSystem.Size.Width / 2), ConvertYCor(0));
            g.DrawLine(myPen, point3, point4);

            g.Dispose();
        }

        public int ConvertXCor(int x)
        {
            return ( x + (pictureBoxSolarSystem.Size.Width / 2) );
        }

        public int ConvertYCor(int y)
        {
            return (pictureBoxSolarSystem.Size.Height / 2) - y;
        }

        public void UpdateLabels(ref EnergyStruct Energy, double t, DateTime start)
        {
            textBoxKineticEnergy.Text = String.Format("{0:e5} Joules", Energy.Kinetic);
            textBoxPotentialEnergy.Text = String.Format("{0:e5} Joules", Energy.Potential);
            textBoxTotalEnergy.Text = String.Format("{0:e5} Joules" ,Energy.Total);
            //textBoxMoonVelocity.Text = String.Format("{0:f2} m/s", CalculateVelocity(b1) );

            //
            // If t (in seconds) are too large ( > ~60 years) can overflow Int32.
            //
            labelYear.Text = String.Format("Years: {0}", Convert.ToInt64(t) / Constants.SECONDS_PER_YEAR);
            labelMonth.Text = String.Format("Months: {0}",
                (Convert.ToInt64(t) % Constants.SECONDS_PER_YEAR) / Constants.SECONDS_PER_MONTH);

            labelTimeDuration.Text = CalculateTimeDuration(start, DateTime.Now);
        }

        public void UpdateUI(Body Earth, Body Moon, double t, ref EnergyStruct Energy)
        {
            DrawEarth(ConvertMetersToPixels(Earth.LastPrintedX), ConvertMetersToPixels(Earth.LastPrintedY), Color.Black);
            DrawMoon(ConvertMetersToPixels(Moon.LastPrintedX), ConvertMetersToPixels(Moon.LastPrintedY), Color.Black);
            //ErasePictureBox();
            DrawCoordinateSystem(Color.Gray);
            DrawEarth(ConvertMetersToPixels(Earth.X), ConvertMetersToPixels(Earth.Y), Color.Blue);
            DrawMoon(ConvertMetersToPixels(Moon.X), ConvertMetersToPixels(Moon.Y), Color.Gray);

            Earth.LastPrintedX = Earth.X;
            Earth.LastPrintedY = Earth.Y;
            Moon.LastPrintedX = Moon.X;
            Moon.LastPrintedY = Moon.Y;

            TotalEnergy(Earth, Moon, ref Energy);
            UpdateLabels(ref Energy, t, DateTime.Now);

            Application.DoEvents();
        }

        /// <summary>
        /// Will erase the old body by drawing a black version of the object over its last position.  
        /// It will then redraw the object in its new location.
        /// </summary>
        /// <param name="Bodies">List of bodies in the system.</param>
        /// <param name="t">Time</param>
        /// <param name="Energy">EnergyStruct object.</param>
        /// <param name="start">start time</param>
        public void UpdateUI(List<Body> Bodies, double t, ref EnergyStruct Energy, DateTime start)
        {
            //
            // First, paint over the old location of the bodies
            //
            foreach (Body b in Bodies)
            {
                switch (b.Name)
                {
                    case "Earth":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, EARTH_SIZE);
                        break;

                    case "Moon":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, MOON_SIZE);
                        break;

                    case "Mercury":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, MERCURY_SIZE);
                        break;

                    case "Venus":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, VENUS_SIZE);
                        break;

                    case "Mars":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, MARS_SIZE);
                        break;

                    case "Sun":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, SUN_SIZE);
                        break;

                    case "Jupiter":
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, JUPITER_SIZE);
                        break;

                    case CometName:
                        if (!checkBoxShowCometOrbits.Checked)
                        {
                            DrawComet(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, COMET_SIZE);
                        }
                        break;

                    case AsteroidName:
                        if (!checkBoxShowAsteroidOrbits.Checked)
                        {
                            DrawSquareBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, ASTEROID_SIZE);
                        }
                        break;

                    default:
                        DrawCircularBody(ConvertMetersToPixels(b.LastPrintedX), ConvertMetersToPixels(b.LastPrintedY), Color.Black, DEFAULT_SIZE);
                        break;
                }

            }
                
            //ErasePictureBox();

            //DrawCoordinateSystem(Color.Gray);

            foreach (Body b in Bodies)
            {
                switch (b.Name)
                {
                    case "Earth":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.Blue, EARTH_SIZE);
                        break;

                    case "Moon":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.Gray, MOON_SIZE);
                        break;

                    case "Mercury":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.DarkGray, MERCURY_SIZE);
                        break;

                    case "Venus":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.SteelBlue, VENUS_SIZE);
                        break;

                    case "Mars":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.OrangeRed, MARS_SIZE);
                        break;

                    case "Sun":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.Yellow, SUN_SIZE);
                        break;

                    case "Jupiter":
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.Orange, JUPITER_SIZE);
                        break;

                    case CometName:
                        DrawComet(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.White, COMET_SIZE);
                        break;

                    case AsteroidName:
                        DrawSquareBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.DimGray, ASTEROID_SIZE);
                        break;

                    default:
                        DrawCircularBody(ConvertMetersToPixels(b.X), ConvertMetersToPixels(b.Y), Color.Green, DEFAULT_SIZE);
                        break;
                }

                b.LastPrintedX = b.X;
                b.LastPrintedY = b.Y;
            }

            TotalEnergy(Bodies, ref Energy);
            UpdateLabels(ref Energy, t, start);

            Application.DoEvents();
        }

        // Derivative of x position for leapfrog
        public double der_x(double vx)
        {
            return vx;
        }

        // derivative of y position for leapfrog
        public double der_y(double vy)
        {
            return vy;
        }

        // derivative of Vx for leapfrog
        public double der_vx(Body Ball)
        {
            return Ball.Fx / Ball.Mass;
        }

        // derivative of Vy for leapfrop
        public double der_vy(Body Ball)
        {
            return Ball.Fy / Ball.Mass;
        }

        public string CalculateTimeDuration(DateTime start, DateTime end)
        {
            TimeSpan duration = end - start;

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Time: {0} hr; {1} min; {2} sec",
                duration.Hours, duration.Minutes, duration.Seconds);

            return sb.ToString();
        }

        public void InitializeBodies(List<Body> Bodies)
        {

            if (checkBoxSun.Checked)
                Bodies.Add(new Body(Constants.MASS_SUN, 0, 0, 0, 0, "Sun"));

            if (checkBoxMercury.Checked)
                Bodies.Add(new Body(Constants.MASS_MERCURY, Constants.MERCURY_ORBIT, 0, 0, Constants.MERCURY_ORBIT_SPEED, "Mercury"));

            if (checkBoxVenus.Checked)
                Bodies.Add(new Body(Constants.MASS_VENUS, Constants.VENUS_ORBIT, 0, 0, Constants.VENUS_ORBIT_SPEED, "Venus"));

            if (checkBoxEarth.Checked)
                Bodies.Add(new Body(Constants.MASS_EARTH, Constants.AU, 0, 0, Constants.EARTH_ORBIT_SPEED, "Earth"));

            if (checkBoxMars.Checked)
                Bodies.Add(new Body(Constants.MASS_MARS, Constants.MARS_ORBIT, 0, 0, Constants.MARS_ORBIT_SPEED, "Mars"));

            if (checkBoxJupiter.Checked)
                Bodies.Add(new Body(Constants.MASS_JUPITER, Constants.JUPITER_ORBIT, 0, 0, Constants.JUPITER_ORBIT_SPEED, "Jupiter"));

            foreach (Body b in Bodies)
                textBoxConsole.AppendText(String.Format("{0}: L = {1}\r\n", b.Name, b.AngularMomentum()));
            //
            // Add comets to solar system
            //
            
            //textBoxConsole.AppendText(String.Format("(Math.Pow(1-e, .5)) = {0}", (Math.Pow(1 - e, .5))));

            double x;
            double y;
            double e;

            double r, angle;

            if (checkBoxComet.Checked)
            {
                for (int i = 0; i < NumberComets; ++i)
                {
                    //
                    // choose a random location for a comet, between 3 and 6 AU
                    // choose a typical eccentricity
                    //
                    /*x = RandBool() * RandDouble(3, 6) * Constants.ASTRONOMICAL_UNIT;
                    y = RandBool() * RandDouble(3, 6) * Constants.ASTRONOMICAL_UNIT;*/
                    e = RandDouble(0.7, 0.9);
                    r = RandDouble(3, 6) * Constants.ASTRONOMICAL_UNIT;
                    angle = RandDouble(0, Math.PI / 2.0); // random angle between 0 and PI/2
                    x = RandBool() * r * Math.Cos(angle);
                    y = RandBool() * r * Math.Sin(angle);



                    Bodies.Add(new Body(RandDouble() * Constants.MASS_HALLEYS_COMET,
                                    x,
                                    y,
                                    -EllipseVelocityAtAphelionX(x, y, e),
                                    EllipseVelocityAtAphelionY(x, y, e),
                                    CometName));

                    if (GravitationallyBound(Bodies[Bodies.Count - 1].Mass,
                                    Bodies[Bodies.Count - 1].TotalVelocity(),
                                    Bodies[Bodies.Count - 1].DistanceFromSun()) > 0)
                    {
                        textBoxConsole.AppendText(String.Format("{0} is bound. L = {1}\r\n",
                                                    CometName, Bodies[Bodies.Count - 1].AngularMomentum()));
                    }
                    else
                    {
                        textBoxConsole.AppendText(String.Format("{0} is NOT bound. L = {1}\r\n",
                                                    CometName, Bodies[Bodies.Count - 1].AngularMomentum()));
                        Bodies.RemoveAt(Bodies.Count - 1);
                        i--;
                    }
                }
            }

            //
            // Add Asteroids to solar system.  Typical ecentricities of Asteroids
            // are around 0.07 but range up to 0.4 see http://en.wikipedia.org/wiki/Asteroid_belt
            //
            if (checkBoxAsteroid.Checked)
            {
                for (int i = 0; i < NumberAsteroids; ++i)
                {
                    //x = RandBool() * RandDouble(1.8, 3) * Constants.ASTRONOMICAL_UNIT;
                    //y = RandBool() * RandDouble(1.8, 3) * Constants.ASTRONOMICAL_UNIT;
                    e = RandDouble(0.03, 0.1);
                    r = RandDouble(2.0, 3.3) * Constants.ASTRONOMICAL_UNIT;
                    angle = RandDouble(0, Math.PI / 2.0); // random angle between 0 and PI/2
                    x = RandBool() * r * Math.Cos(angle);
                    y = RandBool() * r * Math.Sin(angle);

                    Bodies.Add(new Body(RandDouble() * Constants.MASS_HALLEYS_COMET,
                                    x,
                                    y,
                                    -EllipseVelocityAtAphelionX(x, y, e),
                                    EllipseVelocityAtAphelionY(x, y, e),
                                    AsteroidName));

                    if (GravitationallyBound(Bodies[Bodies.Count - 1].Mass,
                                    Bodies[Bodies.Count - 1].TotalVelocity(),
                                    Bodies[Bodies.Count - 1].DistanceFromSun()) > 0)
                    {
                        textBoxConsole.AppendText(String.Format("{0} is bound. L = {1}\r\n",
                                                    AsteroidName, Bodies[Bodies.Count - 1].AngularMomentum()));
                    }
                    else
                    {
                        textBoxConsole.AppendText(String.Format("{0} is NOT bound. L = {1}\r\n",
                                                    AsteroidName, Bodies[Bodies.Count - 1].AngularMomentum()));
                        Bodies.RemoveAt(Bodies.Count - 1);
                        i--;
                    }
                }
            }

        }

        // return rand double between 0.0 and 1.0
        // TODO: have method take 2 parames, min and max with 0 and 1 as defaults
        public double RandDouble()
        {
            double ranDouble = ranObj.NextDouble();
            return ranDouble;
        }

        public double RandDouble(double d1, double d2)
        {
            //Debug.Assert(d2 > d1, "Bad Parameters, d2 must be > d1");
            double ranDouble = ranObj.NextDouble();

            double range = d2 - d1;
            double returnValue = range * ranDouble + d1;

            return returnValue;
        }
        public int RandInt(int minValue, int maxValue)
        {
            int randInt = ranObj.Next(minValue, maxValue);
            return randInt;
        }

        public int RandBool()
        {
            if (ranObj.NextDouble() < .5)
                return -1;
            else
                return 1;
        }

        private void radioButtonEulerMethod_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioButtonEulerMethod.Checked == true)
            {
                MessageBox.Show(
                    "Not Implemented",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            radioButtonLeapFrogMethod.Checked = true;*/
        }

        private void radioButtonRungeKuttaMethod_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRungeKuttaMethod.Checked == true)
            {
                MessageBox.Show(
                    "Not Implemented",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            radioButtonLeapFrogMethod.Checked = true;
        }

        private void buttonClearConsole_Click(object sender, EventArgs e)
        {
            textBoxConsole.Clear();
        }

        public double GravitationallyBound(double mass, double velocity, double orbitRadius)
        {
            double returnValue = 0;

            double KE = .5 * mass * Math.Pow(velocity, 2);
            double PE = - (Constants.GRAVITATIONAL_CONSTANT * Constants.MASS_SUN * mass) / orbitRadius;

            if (KE == Math.Abs(PE)) // velocity == escape velocity
            {
                returnValue = 0;
            }
            else if (KE < Math.Abs(PE)) // gravitationally bound
            {
                returnValue = 1;
            }
            else if(KE > Math.Abs(PE)) // velocity > escape velosity, object will escape
            {
                returnValue = -1;
            }

            return returnValue;
        }

        public double GravitationallyBound(Body b)
        {
            double returnValue = 0;

            double KE = .5 * b.Mass * Math.Pow(b.TotalVelocity(), 2);
            double PE = -(Constants.GRAVITATIONAL_CONSTANT * Constants.MASS_SUN * b.Mass) / b.DistanceFromSun();

            if (KE == Math.Abs(PE)) // velocity == escape velocity
            {
                returnValue = 0;
            }
            else if (KE < Math.Abs(PE)) // gravitationally bound
            {
                returnValue = 1;
            }
            else if (KE > Math.Abs(PE)) // velocity > escape velosity, object will escape
            {
                returnValue = -1;
            }

            return returnValue;
        }

        public double EllipseVelocityAtAphelionX(double X, double Y, double e)
        {
            double r = Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2), 0.5);
            double V = Math.Pow(Constants.GRAVITATIONAL_CONSTANT*Constants.MASS_SUN / r, 0.5);
            double angle = Math.Atan2(Y,X);
            double Vx = V * Math.Pow(1-e, 0.5) * Math.Sin(angle);
            double Vy = V * Math.Pow(1-e, 0.5) * Math.Cos(angle);
            return Vx;
        }
        public double EllipseVelocityAtAphelionY(double X, double Y, double e)
        {
            double r = Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2), 0.5);
            double V = Math.Pow(Constants.GRAVITATIONAL_CONSTANT * Constants.MASS_SUN / r, 0.5);
            double angle = Math.Atan2(Y, X);
            double Vx = V * Math.Pow(1 - e, 0.5) * Math.Sin(angle);
            double Vy = V * Math.Pow(1 - e, 0.5) * Math.Cos(angle);
            return Vy;
        }





    } // end Partial Class Form

    

}
