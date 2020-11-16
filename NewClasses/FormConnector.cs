using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpKml.Dom;
using Point = System.Drawing.Point;

namespace MissionPlanner.NewClasses
{
    public class FormConnector
    {
        private Form _mainForm;

        private List<Form> _connectedForms = new List<Form>();

        private Point _mainLocation;

        public FormConnector(Form mainForm)
        {
            this._mainForm = mainForm;
            this._mainLocation = new Point(this._mainForm.Location.X, this._mainForm.Location.Y);
            this._mainForm.LocationChanged += new EventHandler(MainForm_LocationChanged);
            _mainForm.Resize += new EventHandler(MainForm_Resize);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetConnectedFormsSize(_mainForm.WindowState);
        }

        private void SetConnectedFormsSize(FormWindowState windowState)
        {
            foreach (var connectedForm in _connectedForms)
            {
                if (windowState != FormWindowState.Maximized)
                {
                    connectedForm.WindowState = windowState;
                }
                else
                {
                    connectedForm.WindowState = FormWindowState.Normal;
                }
                
                if (windowState != FormWindowState.Minimized && connectedForm is IFormConnectable)
                {
                    ((IFormConnectable) connectedForm).SetFormLocation();
                }
            }
        }
        
        public void ConnectForm(Form form)
        {
            if (!this._connectedForms.Contains(form))
            {
                this._connectedForms.Add(form);
            }
        }

        public void DisconnectForm(Form form)
        {
            if (_connectedForms.Contains(form))
            {
                _connectedForms.Remove(form);
            }
        }

        void MainForm_LocationChanged(object sender, EventArgs e)
        {
            UpdateFormsLocations();
        }

        private void UpdateFormsLocations()
        {
            Point relativeChange = new Point(this._mainForm.Location.X - this._mainLocation.X,
                this._mainForm.Location.Y - this._mainLocation.Y);
            foreach (Form form in this._connectedForms)
            {
                form.Location = new Point(form.Location.X + relativeChange.X, form.Location.Y + relativeChange.Y);
            }

            this._mainLocation = new Point(this._mainForm.Location.X, this._mainForm.Location.Y);
        }
    }
}