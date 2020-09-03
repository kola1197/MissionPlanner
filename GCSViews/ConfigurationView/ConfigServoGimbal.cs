using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static MissionPlanner.MainV2;
using System.IO;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigServoGimbal : UserControl
    {
        ComboBox [] comboBox = new ComboBox[11];
        string defaultConfig = "servoConfig.txt";
        XmlSerializer serializer = new XmlSerializer(typeof(item[]),
                                 new XmlRootAttribute() { ElementName = "items" });
        public ConfigServoGimbal()
        {
            InitializeComponent();
            comboBox[0] = comboBox1;
            comboBox[1] = comboBox2;
            comboBox[2] = comboBox3;
            comboBox[3] = comboBox4;
            comboBox[4] = comboBox5;
            comboBox[5] = comboBox6;
            comboBox[6] = comboBox7;
            comboBox[7] = comboBox8;
            comboBox[8] = comboBox9;
            comboBox[9] = comboBox10;
            comboBox[10] = comboBox11;
            defaultDictInit();
        }
        
        private void deserealaseDict() 
        {
            if (File.Exists(defaultConfig))
            {
                StreamReader stream = new StreamReader(defaultConfig);
                var orgDict = ((item[])serializer.Deserialize(stream))
                       .ToDictionary(i => i.id, i => i.value);
                for (int i = 0; i < 11; i++) 
                {
                    int v;
                    string s;
                    Dictionary<string, string> Dict = (Dictionary<string, string>)orgDict;
                    
                    if (Dict.TryGetValue(i.ToString(), out s) )
                    {
                        if (int.TryParse(s, out v))
                        {
                            MainV2.configServo[i] = v; 
                        }
                    }
                }
                stream.Close();
            }

        }

        private void updateComboboxes() 
        {
            for (int i = 0; i < 11; i++) 
            {
                comboBox[i].SelectedIndex = MainV2.configServo[i];
            }
        }

        private void serealaseDict()
        {
            StreamWriter stream = new StreamWriter(defaultConfig, false);
            serializer.Serialize(stream,
              MainV2.configServo.Select(kv => new item() { id = kv.Key.ToString(), value = kv.Value.ToString()}).ToArray());
            stream.Close();
        }

        private void defaultDictInit()
        {
            for (int k = 0; k < 11; k++) 
            {
                comboBox[k].Items.Add("-");
                for (int i = 0; i < 16; i++) 
                {
                    comboBox[k].Items.Add("Servo " + (i+1).ToString());
                }
            }
            MainV2.configServo = new Dictionary<int, int>();
            MainV2.configServo[0] = 0;
            MainV2.configServo[1] = 0;
            MainV2.configServo[2] = 0;
            MainV2.configServo[3] = 0;
            MainV2.configServo[4] = 0;
            MainV2.configServo[5] = 0;
            MainV2.configServo[6] = 0;
            MainV2.configServo[7] = 0;
            MainV2.configServo[8] = 0;
            MainV2.configServo[9] = 0;
            MainV2.configServo[10] = 0;
            deserealaseDict();
            updateComboboxes();

        }

        public void loadConfig() 
        {
            defaultDictInit();

        }

        private void saveButton_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 11; i++) 
            {
                MainV2.configServo[i] = comboBox[i].SelectedIndex;
            }
            serealaseDict();
        }
    }
}
