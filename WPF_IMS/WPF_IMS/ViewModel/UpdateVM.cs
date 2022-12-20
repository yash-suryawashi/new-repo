using Interface_Lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WPF_IMS.Command;

namespace WPF_IMS.ViewModel
{
    public class UpdateVM : ViewModelBase
    {
        string multipleSelections, name, user, project;

        public Action CloseAction { get; set; }

        public UpdateCommand _updateCommand { get; set; }
        public UpdateCommand _update_selectionChanged{ get; set; }


        private string instrumentNameUpdate;
        public string InstrumentNameUpdate
        {
            get { return instrumentNameUpdate; }
            set 
            { 
                instrumentNameUpdate = value; 
                OnPropertyChanged(nameof(InstrumentNameUpdate));
            }
        }

        private int instrumentUserUpdate_index;
        public int InstrumentUserUpdate_index
        {
            get { return instrumentUserUpdate_index; }
            set 
            { 
                instrumentUserUpdate_index = value;
                OnPropertyChanged(nameof(InstrumentUserUpdate_index));
            }
        }

        private string instrumentUserUpdate_value;
        public string InstrumentUserUpdate_value
        {
            get { return instrumentUserUpdate_value; }
            set 
            { 
                instrumentUserUpdate_value = value;
                OnPropertyChanged(nameof(InstrumentUserUpdate_value));
            }
        }

        private int instrumentProjectsUpdate_index;
        public int InstrumentProjectsUpdate_index
        {
            get { return instrumentProjectsUpdate_index; }
            set 
            { 
                instrumentProjectsUpdate_index = value;
                OnPropertyChanged(nameof(InstrumentProjectsUpdate_index));
            }
        }

        private int lbInstrument_Index;
        public int LBInstrument_Index
        {
            get { return lbInstrument_Index; }
            set
            {
                lbInstrument_Index = value;
                OnPropertyChanged(nameof(LBInstrument_Index));
            }
        }

        private Instruments selectedInstrumentForUpdate;
        public Instruments SelectedInstrumentForUpdate
        {
            get { return selectedInstrumentForUpdate; }
            set
            {
                selectedInstrumentForUpdate = value;
                OnPropertyChanged(nameof(SelectedInstrumentForUpdate));
            }
        }

        private List<string> lbProjectsUpdate_itemsSource;
        public List<string> LBProjectsUpdate_itemsSource
        {
            get { return lbProjectsUpdate_itemsSource; }
            set 
            { 
                lbProjectsUpdate_itemsSource = value;
                OnPropertyChanged(nameof(LBProjectsUpdate_itemsSource));
            }
        }

        public void update(object u)
        {
            if(LBInstrument_Index != -1)
            {
                var collection = u as ICollection;
                List<string> selections = collection.Cast<string>().ToList();

                name = InstrumentNameUpdate;
                if(name == "")
                {
                    name = SelectedInstrumentForUpdate.Name;
                }
                user = InstrumentUserUpdate_value;

                if (InstrumentProjectsUpdate_index != -1)
                {
                    foreach (var item in selections)
                    {
                        multipleSelections += (multipleSelections == "" ? "" : " ") + item;
                    }
                    project = multipleSelections.ToString();
                }
                else
                {
                    project = "";
                    MessageBox.Show("Please select at least one project");
                }

                if(name != "" && user != null && project != "")
                {
                    Instruments objToBeUpdated = SelectedInstrumentForUpdate;
                    string instrToUpdate = objToBeUpdated.Name;

                    Instruments updateInstrument = new Instruments
                    {
                        Name = name,
                        User = user,
                        Project = project
                    };

                    i.updateInstrument(instrToUpdate, updateInstrument);
                    LBInstrument_Index = -1;
                    InstrumentNameUpdate = string.Empty;
                    InstrumentUserUpdate_index = -1;
                    InstrumentProjectsUpdate_index = -1;
                }
                else
                {
                    LBInstrument_Index = -1;
                    InstrumentNameUpdate = string.Empty;
                    InstrumentUserUpdate_index = -1;
                    InstrumentProjectsUpdate_index = -1;
                }
                CloseAction();
            }
            else
            {
                MessageBox.Show("Please select an instrument to update");
            }
        }

        public UpdateVM()
        {
            LBInstrument_Index = -1;
            InstrumentNameUpdate = string.Empty;
            InstrumentUserUpdate_index = -1;
            InstrumentProjectsUpdate_index = -1;
            _updateCommand = new UpdateCommand(this);
        }
    }
}