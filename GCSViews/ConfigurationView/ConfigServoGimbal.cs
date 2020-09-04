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
        TextBox[] textBoxes = new TextBox[11];
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
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
            textBoxes[10] = textBox11;
            
            defaultDictInit();
        }
        
        private void deserealaseDict() 
        {
            if (File.Exists(defaultConfig))
            {
                StreamReader stream = new StreamReader(defaultConfig);
                var orgDict = ((item[])serializer.Deserialize(stream))
                       .ToDictionary(i => i.id, i => new servoValue(int.Parse(i.servo) ,int.Parse(i.value)));
                for (int i = 0; i < 11; i++) 
                {
                    servoValue s;
                    Dictionary<string, servoValue> Dict = (Dictionary<string, servoValue>)orgDict;
                    
                    if (Dict.TryGetValue(i.ToString(), out s) )
                    {
                        MainV2.configServo[i] = s; 
                    }
                }
                stream.Close();
            }
        }

        private void updateComboboxes() 
        {
            for (int i = 0; i < 11; i++) 
            {
                comboBox[i].SelectedIndex = MainV2.configServo[i].servo;
                textBoxes[i].Text = MainV2.configServo[i].value.ToString();
            }
        }

        private void serealaseDict()
        {
            StreamWriter stream = new StreamWriter(defaultConfig, false);
            serializer.Serialize(stream,
              MainV2.configServo.Select(kv => new item() { id = kv.Key.ToString(), servo = kv.Value.servo.ToString(), value = kv.Value.value.ToString()}).ToArray());
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
            MainV2.configServo = new Dictionary<int, servoValue>();
            MainV2.configServo[0] = new servoValue(0, 1500);
            MainV2.configServo[1] = new servoValue(0, 1500);
            MainV2.configServo[2] = new servoValue(0, 1500);
            MainV2.configServo[3] = new servoValue(0, 1500);
            MainV2.configServo[4] = new servoValue(0, 1500);
            MainV2.configServo[5] = new servoValue(0, 1500);
            MainV2.configServo[6] = new servoValue(0, 1500);
            MainV2.configServo[7] = new servoValue(0, 1500);
            MainV2.configServo[8] = new servoValue(0, 1500);
            MainV2.configServo[9] = new servoValue(0, 1500);
            MainV2.configServo[10] = new servoValue(0, 1500);
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
                int v = 1500;
                MainV2.configServo[i].servo = comboBox[i].SelectedIndex;
                MainV2.configServo[i].value = int.TryParse(textBoxes[i].Text, out v) ? v : 1500;
            }
            serealaseDict();
        }
    }
}
