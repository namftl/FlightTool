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
        QuerryProcess QuerryProcess;
        QuerryEnum CurrentQuerry;
        private OpenFileDialog FileDialog;
        bool FileOk;
        bool SrcChanged;
        /// <summary>
        /// disable all elements in form except the 'select file' option
        /// </summary>
        public AppScr()
        {            
            InitializeComponent();
            FileOk = false;
            SetAllControlsFont(this.Controls);
            DisableControls(this.QuerryPanel);
            DisableControls(this.InputPanel);
            DisableControls(this.ResultsPanel);
        }

        /// <summary>
        /// opens a file browse dialog and saves the filename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            FileDialog = new OpenFileDialog();
            FileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            // Show the dialog and get result.
            DialogResult result = FileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string FileName = FileDialog.FileName;
                this.FileNameText.Text = FileName;
                FileOk = true;
            }
            else
            {
                FileOk = false;
                this.FileNameText.Text = "";
            }
        }

        /// <summary>
        /// confirms chosen file, freeze select file option, unfreeze query selection and pass filename to 
        /// querry process to start data fetch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileConfirm_Click(object sender, EventArgs e)
        {
            if ((FileDialog == null)||(this.FileNameText.Text != FileDialog.FileName)||(!FileOk))
                return;
            DisableControls(this.FilePanel);
            EnableControls(this.QuerryPanel);
            QuerryProcess = new QuerryProcess(FileDialog.FileName);
        }

        /// <summary>
        /// freeze querry selection, unfreeze file selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryBack_Click(object sender, EventArgs e)
        {
            if (FileDialog == null)
                return;
            DisableControls(this.QuerryPanel);
            EnableControls(this.FilePanel);
        }
        /// <summary>
        /// save querry type, fill first input textbox with source cities, pass querry type to querryprocess
        /// freeze query selection and unfreeze input section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Query_Click(object sender, EventArgs e)
        {
            CurrentQuerry = GetQuerryEnum(sender);
            SetAutoCompleteSource(this.CityA);
            QuerryProcess.StartQuery(CurrentQuerry);
            DisableControls(this.QuerryPanel);
            EnableControls(this.InputPanel);
            ((Control)sender).Enabled = true;
            DisableInput(CurrentQuerry);
            SrcChanged = false;
        }

        /// <summary>
        /// freeze input section, unfreeze querry section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackInput_Click(object sender, EventArgs e)
        {
            DisableControls(this.InputPanel);
            EnableControls(this.QuerryPanel);
            FileConfirm_Click(sender, e);

        }
        /// <summary>
        /// create a new autocomplete list when modifying this box (only once)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityA_ClickOrText(object sender, EventArgs e)
        {
            if (SrcChanged == false)
            {
                QuerryProcess.ResetResults();
                SetAutoCompleteSource(this.CityA);
                SrcChanged = true;
            }
        }

        /// <summary>
        /// if querry depends on two city inputs - filter results according to first city
        /// the set sources for input, reset results if srcChanged,
        /// change bool srcChanged to reset sources if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityB_Click(object sender, EventArgs e)
        {
            if (CurrentQuerry == QuerryEnum.AVG_DEP_DEL)
            {
                if (SrcChanged)
                {
                    SrcChanged = false;
                    QuerryProcess.SelectOriginCity(this.CityA.Text);
                    this.CityB.Text = "";
                }
            }
            SetAutoCompleteSource(this.CityB, false);
        }
        
        /// <summary>
        /// pass input to querry process and perform querry, handle missing input,
        /// freeze input section, unfreeze result section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmInput_Click(object sender, EventArgs e)
        {
            string[] input = { this.CityA.Text, this.CityB.Text};
            this.ResultText.Font = new Font("Impact", 14, FontStyle.Italic);
            if (input[0].Length == 0)
                this.ResultText.Text = "Missing Source input";
            else if ((CurrentQuerry == QuerryEnum.AVG_DEP_DEL) && (input[1].Length == 0))
                this.ResultText.Text = "Missing Destination input";
            else
            {
                if (QuerryProcess.PerformQuery(input))
                    this.ResultText.Text = QuerryProcess.GetResults();
                else
                    this.ResultText.Text = "Querry not found, Please try again";
            }
            DisableControls(this.InputPanel);
            EnableControls(this.ResultsPanel);
        }

        /// <summary>
        /// freeze results, unfreeze querry section, reset data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackResults_Click(object sender, EventArgs e)
        {
            DisableControls(this.ResultsPanel);
            EnableControls(this.QuerryPanel);
            QuerryProcess.ResetResults();
        }


        /// <summary>
        /// determine querry type according to button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private QuerryEnum GetQuerryEnum(object sender)
        {
            if (((Button)sender).Name == "Q1")
                return QuerryEnum.AVG_DEP_DEL;
            if (((Button)sender).Name == "Q2")
                return QuerryEnum.MOST_fLIGHTS;
            if (((Button)sender).Name == "Q3")
                return QuerryEnum.FARTHEST_DESTINATIONS;
            return QuerryEnum.NONE;
        }

        /// <summary>
        /// disables input text boxes that querry doesnt require
        /// </summary>
        /// <param name="querry"></param>
        private void DisableInput(QuerryEnum querry)
        {
            switch(querry)
            {
                case QuerryEnum.AVG_DEP_DEL:
                    break;
                case QuerryEnum.FARTHEST_DESTINATIONS:
                case QuerryEnum.MOST_fLIGHTS:
                    this.CityB.Enabled = false;
                    break;
            }
        }        

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// disables all controls in given panel
        /// </summary>
        /// <param name="panel"></param>
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

        /// <summary>
        /// enable all controls in given panel
        /// </summary>
        /// <param name="panel"></param>
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
        
        /// <summary>
        /// set automplete source for given text box according to source city or destination
        /// </summary>
        /// <param name="text"></param>
        /// <param name="SrcCity"></param>
        private void SetAutoCompleteSource(TextBox text, bool SrcCity = true)
        {
            text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            string[] array = QuerryProcess.GetCityArray(SrcCity);
            source.AddRange(array);
            text.AutoCompleteSource = AutoCompleteSource.CustomSource;
            text.AutoCompleteCustomSource = source;
        }

    }
}
