using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelaFlights
{
    public partial class AppScr : Form
    {
        QuerryProcess querryProcess;
        QueryEnum CurrentQuery;
        private OpenFileDialog openFileDialog1;
        CsvReader CsvFileReader;
        public AppScr()
        {            
            InitializeComponent();
            SetAllControlsFont(this.Controls);
            DisableControls(this.QueryPanel);
            DisableControls(this.InputPanel);
            DisableControls(this.ResultsPanel);
        }

        private void Query_Click(object sender, EventArgs e)
        {
            CurrentQuery = GetQueryEnum(sender);
            querryProcess.StartQuery(CurrentQuery);
            DisableControls(this.QueryPanel);
            EnableControls(this.InputPanel);
            ((Control)sender).Enabled = true;
            DisableInput(CurrentQuery);
        }

        private void DisableInput(QueryEnum query)
        {
            switch(query)
            {
                case QueryEnum.AVG_DEP_DEL:
                    this.CityC.Enabled = false;
                    break;
                case QueryEnum.FARTHEST_DESTINATIONS:
                case QueryEnum.MOST_fLIGHTS:
                    this.CityC.Enabled = false;
                    this.CityB.Enabled = false;
                    break;
                case QueryEnum.SHORTEST_PATH:
                    break;
            }
        }

        private QueryEnum GetQueryEnum(object sender)
        {
            if (((Button)sender).Name == "Q1")
                return QueryEnum.AVG_DEP_DEL;
            if (((Button)sender).Name == "Q2")
                return QueryEnum.MOST_fLIGHTS;
            if (((Button)sender).Name == "Q3")
                return QueryEnum.FARTHEST_DESTINATIONS;
            return QueryEnum.NONE;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackInput_Click(object sender, EventArgs e)
        {
            DisableControls(this.InputPanel);
            EnableControls(this.QueryPanel);
            FileConfirm_Click(sender, e);

        }

        private void ConfirmInput_Click(object sender, EventArgs e)
        {
            string[] input = { this.CityA.Text, this.CityB.Text, this.CityC.Text };
            querryProcess.PerformQuery(input);
            DisableControls(this.InputPanel);
            EnableControls(this.ResultsPanel);
            this.ResultText.Text = querryProcess.GetResults();
        }

        private void BackResults_Click(object sender, EventArgs e)
        {
            DisableControls(this.ResultsPanel);
            EnableControls(this.QueryPanel);
            FileConfirm_Click(sender, e);
        }

        protected void DisableControls(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                ctrl.BackColor = Color.LightGray;
                ctrl.Enabled = false;
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = "";
            }
        }

        protected void EnableControls(Panel panel)
        {
            foreach(Control ctrl in panel.Controls)
            {
                ctrl.BackColor = Color.White;
                ctrl.Enabled = true;
            }
        }
        public void SetAllControlsFont(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                ctrl.Font = new Font("Impact", ctrl.Font.Size + 4);
            }
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string FileName = openFileDialog1.FileName;
                this.FileNameText.Text = FileName;
            }
        }

        private void QueryBack_Click(object sender, EventArgs e)
        {
            if (openFileDialog1 == null)
                return;
            DisableControls(this.QueryPanel);
            EnableControls(this.FilePanel);
        }

        private void FileConfirm_Click(object sender, EventArgs e)
        {
            if (openFileDialog1 == null)
                return;
            DisableControls(this.FilePanel);
            EnableControls(this.QueryPanel);
            querryProcess = new QuerryProcess(openFileDialog1.FileName);
            SetAutoCompleteSource(this.CityA);

        }

        private void SetAutoCompleteSource(TextBox text, bool SrcCity = true)
        {
            text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            string[] array = querryProcess.GetCityArray(SrcCity);
            source.AddRange(array);
            text.AutoCompleteSource = AutoCompleteSource.CustomSource;
            text.AutoCompleteCustomSource = source;
        }

        private void CityB_Click(object sender, EventArgs e)
        {
            if(CurrentQuery == QueryEnum.AVG_DEP_DEL)
                querryProcess.SelectOriginCity(this.CityA.Text);
            SetAutoCompleteSource(this.CityB, false);
        }


    }
}
