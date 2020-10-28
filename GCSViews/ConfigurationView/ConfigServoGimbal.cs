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
        int[] blackList = new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10, 12 };
        Dictionary<string, int> servoDict;
        ComboBox [] comboBox = new ComboBox[11];
        TextBox[] textBoxes = new TextBox[11];
        TextBox[] textBoxesForDefault = new TextBox[11];
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
            textBoxesForDefault[10] = textBox12; 
            textBoxesForDefault[9] = textBox13; 
            textBoxesForDefault[8] = textBox14; 
            textBoxesForDefault[7] = textBox15; 
            textBoxesForDefault[6] = textBox16; 
            textBoxesForDefault[5] = textBox17; 
            textBoxesForDefault[4] = textBox18; 
            textBoxesForDefault[3] = textBox19; 
            textBoxesForDefault[2] = textBox20; 
            textBoxesForDefault[1] = textBox21; 
            textBoxesForDefault[0] = textBox22;
            defaultDictInit();
            initServoDict();
        }


        private void initServoDict() 
        {
            servoDict = new Dictionary<string, int>();
            for (int i = 1; i < 16; i++)
            {
                if (!blackList.Contains(i))
                {
                    servoDict.Add("Servo " + (i + 1).ToString(),i);
                }
            }
        }
        private void deserealaseDict() 
        {
            if (File.Exists(MainV2.defaultConfig))
            {
                try
                {
                    StreamReader stream = new StreamReader(MainV2.defaultConfig);
                    var orgDict = ((item[]) serializer.Deserialize(stream))
                        .ToDictionary(i => i.id,
                            i => new servoValue(int.Parse(i.servo), int.Parse(i.value), int.Parse(i.defaultValue)));
                    for (int i = 0; i < 11; i++)
                    {
                        servoValue s;
                        Dictionary<string, servoValue> Dict = (Dictionary<string, servoValue>) orgDict;

                        if (Dict.TryGetValue(i.ToString(), out s))
                        {
                            MainV2.configServo[i] = s;
                        }
                    }

                    stream.Close();
                }
                catch (Exception e)
                {
                }
            }
        }

        private void checkForDisabledServos()
        {
            //int[] blackList = new int[] {1, 2, 3, 4, 6,7,8,9, 10, 12};
            for (int k = 0; k < 11; k++)
            {
                if (blackList.Contains(comboBox[k].SelectedIndex))
                {
                    comboBox[k].SelectedIndex = 0;
                }
            }
        }

        private void updateComboboxes() 
        {
            for (int i = 0; i < 11; i++) 
            {
                comboBox[i].SelectedIndex = MainV2.configServo[i].servo;
                textBoxes[i].Text = MainV2.configServo[i].value.ToString();
                textBoxesForDefault[i].Text = MainV2.configServo[i].defaultValue.ToString();
            }
        }

        private void serealaseDict()
        {
            StreamWriter stream = new StreamWriter(MainV2.defaultConfig, false);
            serializer.Serialize(stream,
              MainV2.configServo.Select(kv => new item() { id = kv.Key.ToString(), servo = kv.Value.servo.ToString(), value = kv.Value.value.ToString(), defaultValue = kv.Value.defaultValue.ToString()}).ToArray());
            stream.Close();
        }

        private void defaultDictInit()
        {
            for (int k = 0; k < 11; k++) 
            {
                comboBox[k].Items.Add("-");
                for (int i = 1; i < 16; i++) 
                {
                    if (!blackList.Contains(i))
                    {
                        comboBox[k].Items.Add("Servo " + (i + 1).ToString());
                    }
                }
            }
            MainV2.configServo = new Dictionary<int, servoValue>();
            MainV2.configServo[0] = new servoValue(0, 1500, 1500);
            MainV2.configServo[1] = new servoValue(0, 1500, 1500);
            MainV2.configServo[2] = new servoValue(0, 1500, 1500);
            MainV2.configServo[3] = new servoValue(0, 1500, 1500);
            MainV2.configServo[4] = new servoValue(0, 1500, 1500);
            MainV2.configServo[5] = new servoValue(0, 1500, 1500);
            MainV2.configServo[6] = new servoValue(0, 1500, 1500);
            MainV2.configServo[7] = new servoValue(0, 1500, 1500);
            MainV2.configServo[8] = new servoValue(0, 1500, 1500);
            MainV2.configServo[9] = new servoValue(0, 1500, 1500);
            MainV2.configServo[10] = new servoValue(0, 1500, 1500);
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
                MainV2.configServo[i].servo = getInt(comboBox[i].SelectedText);
                MainV2.configServo[i].value = int.TryParse(textBoxes[i].Text, out v) ? v : 1500;
                MainV2.configServo[i].defaultValue = int.TryParse(textBoxesForDefault[i].Text, out v) ? v : 1500;                
            }
            serealaseDict();
        }

        private int getInt(string s) 
        {
            int result = 0;
            servoDict.TryGetValue(s, out result);
            return result;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkForDisabledServos();
        }
    }
}
