using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Botanik
{
    public partial class Botanik : Form
    {
        public Botanik()
        {
            InitializeComponent();
            List<DataGridView> Tabs = new List<DataGridView>();
            Tabs.Add(dataGridView2);
            Tabs.Add(dataGridView3);
            foreach(DataGridView i in Tabs)
            {
                i.Columns.Add("_Name", "Название растения");
                i.Columns.Add("_Type", "Тип растения");
                i.Columns.Add("_Empl", "Служащий");
                i.Columns.Add("_Date", "Дата посадки");
                i.Columns.Add("_Time", "Время полива");
                i.Columns.Add("_Amount", "Кол-во поливов");
                i.Columns.Add("_Litr", "Кол-во литров");
            }
            dataGridView4.Columns.Add("_Name", "Название растения");
            dataGridView4.Columns.Add("_Time", "Время полива");
            dataGridView4.Columns.Add("_Amount", "Кол-во поливов");
            dataGridView4.Columns.Add("_Litr", "Кол-во литров");
        }

        // Работа со справочником

        void UpdateBase()
        {
            comboBoxEmpl.Items.Clear();
            comboBoxType.Items.Clear();
            foreach(string i in Database.FIO)
            {
                comboBoxEmpl.Items.Add(i);
            }
            foreach(string i in Database.Type)
            {
                comboBoxType.Items.Add(i);
            }
        }

        private void buttonAddEmpl_Click(object sender, EventArgs e)
        {
            Database.FIO.Add(textBoxFIO.Text);
            Database.Phone.Add(textBoxPhone.Text);
            UpdateBase();
            DirUpdate();
        }

        private void AddType_Click(object sender, EventArgs e)
        {
            Database.Type.Add(textBoxPlantType.Text);
            UpdateBase();
            DirUpdate();
        }

        void DirUpdate()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            switch (tabControl2.SelectedIndex)
            {
                case 0: // Тип растения
                    dataGridView1.Columns.Add("_Type", "Тип растения");
                    foreach (string i in Database.Type)
                    {
                        dataGridView1.Rows.Add(i);
                    }
                    break;
                case 1: // Служащие
                    dataGridView1.Columns.Add("_FIO", "ФИО");
                    dataGridView1.Columns.Add("_Phone", "Телефон");
                    for (int i = 0; i < Database.FIO.Count; i++)
                    {
                        dataGridView1.Rows.Add(
                            Database.FIO[i], 
                            Database.Phone[i]);
                    }
                    break;
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBase();
            DirUpdate();
        }

        // Работа с главной базой

        private void buttonAddMain_Click(object sender, EventArgs e)
        {
            // Название/Тип (справочник)/Служащий (справочник)/Дата посадки (datePicker)/Время полива/Кол-во поливов/Литры воды
            dataGridView2.Rows.Add(
                textBoxPlantName.Text, 
                comboBoxType.SelectedItem.ToString(), 
                comboBoxEmpl.SelectedItem.ToString(), 
                dateTimePickerDatePlant.Value.ToString(), 
                textBoxPlantTime.Text, 
                textBoxWaterAmount.Text, 
                textBoxWaterLitres.Text);
            Database.PName.Add(textBoxPlantName.Text);
            Database.PTime.Add(textBoxPlantTime.Text);
            Database.PWatr.Add(textBoxWaterAmount.Text);
            Database.PLitr.Add(textBoxWaterLitres.Text);
            UpdatePlantsCombo();
        }

        // Работа с отчетом

        void UpdatePlantsCombo()
        {
            comboBoxPlantList.Items.Clear();
            for(int i = 0; i < Database.PName.Count; i++)
            {
                comboBoxPlantList.Items.Add(Database.PName[i]);
            }
        }

        private void buttonRep1_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            foreach(DataGridViewRow i in dataGridView2.Rows)
            {
                if (Convert.ToDateTime(i.Cells[3].Value) >= dateTimePickerFrom.Value && Convert.ToDateTime(i.Cells[3].Value) <= dateTimePickerTo.Value)
                {
                    dataGridView3.Rows.Add(
                        i.Cells[0].Value, 
                        i.Cells[1].Value, 
                        i.Cells[2].Value, 
                        i.Cells[3].Value, 
                        i.Cells[4].Value, 
                        i.Cells[5].Value, 
                        i.Cells[6].Value);
                }
            }
        }

        private void buttonWatering_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            for(int i = 0; i < Database.PName.Count; i++ )
            {
                if(comboBoxPlantList.SelectedItem.ToString() == Database.PName[i])
                {
                    dataGridView4.Rows.Add(
                        Database.PName[i],
                        Database.PTime[i],
                        Database.PWatr[i],
                        Database.PLitr[i]);
                }
            }
        }
    }
}
