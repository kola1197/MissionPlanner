#if !LIB
extern alias Drawing;
using AltitudeAngelWings;
using MissionPlanner.Utilities.AltitudeAngel;
#endif
using GMap.NET.WindowsForms;
using log4net;
using MissionPlanner.ArduPilot;
using MissionPlanner.Comms;
using MissionPlanner.Controls;
using MissionPlanner.GCSViews.ConfigurationView;
using MissionPlanner.Log;
using MissionPlanner.Maps;
using MissionPlanner.Utilities;
using MissionPlanner.Utilities.AltitudeAngel;
using MissionPlanner.Warnings;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.ArduPilot.Mavlink;
using MissionPlanner.Utilities.HW;
using Transitions;
using AltitudeAngelWings;
using MissionPlanner.NewForms;
using GMap.NET.MapProviders;
using Flurl.Util;
using BrightIdeasSoftware;
using GMap.NET;
using Microsoft.Win32;
using MissionPlanner.Controls.BackstageView;
using MissionPlanner.Controls.PreFlight;
using MissionPlanner.GCSViews;
using MissionPlanner;
using Org.BouncyCastle.Asn1.Cms;
using MissionPlanner.Plugin;
using MissionPlanner.Properties;
using Capture = WebCamService.Capture;
using Help = MissionPlanner.GCSViews.Help;
using System.Xml.Serialization;
using System.Windows.Input;
using GMap.NET.WindowsForms.Markers;
using IronPython.Modules;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.NewClasses;
using Microsoft.Win32;

namespace MissionPlanner
{
    public partial class MainV2 : Form
    {
        public static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static menuicons displayicons; //do not initialize to allow update of custom icons


        public abstract class menuicons
        {
            public abstract Image fd { get; }
            public abstract Image fp { get; }
            public abstract Image initsetup { get; }
            public abstract Image config_tuning { get; }
            public abstract Image sim { get; }
            public abstract Image terminal { get; }
            public abstract Image help { get; }
            public abstract Image donate { get; }
            public abstract Image connect { get; }
            public abstract Image disconnect { get; }
            public abstract Image bg { get; }
            public abstract Image wizard { get; }
        }


        public class burntkermitmenuicons : menuicons
        {
            public override Image fd
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_flightdata_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_flightdata_icon.png");
                    else
                        return Resources.light_flightdata_icon;
                }
            }

            public override Image fp
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_flightplan_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_flightplan_icon.png");
                    else
                        return Resources.light_flightplan_icon;
                }
            }

            public override Image initsetup
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_initialsetup_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_initialsetup_icon.png");
                    else
                        return Resources.light_initialsetup_icon;
                }
            }

            public override Image config_tuning
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_tuningconfig_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_tuningconfig_icon.png");
                    else
                        return Resources.light_tuningconfig_icon;
                }
            }

            public override Image sim
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_simulation_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_simulation_icon.png");
                    else
                        return Resources.light_simulation_icon;
                }
            }

            public override Image terminal
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_terminal_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_terminal_icon.png");
                    else
                        return Resources.light_terminal_icon;
                }
            }

            public override Image help
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_help_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_help_icon.png");
                    else
                        return Resources.light_help_icon;
                }
            }

            public override Image donate
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_donate_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_donate_icon.png");
                    else
                        return Resources.donate;
                }
            }

            public override Image connect
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_connect_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_connect_icon.png");
                    else
                        return Resources.light_connect_icon;
                }
            }

            public override Image disconnect
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_disconnect_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_disconnect_icon.png");
                    else
                        return Resources.light_disconnect_icon;
                }
            }

            public override Image bg
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_icon_background.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_icon_background.png");
                    else
                        return Resources.bgdark;
                }
            }

            public override Image wizard
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "light_wizard_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "light_wizard_icon.png");
                    else
                        return Resources.wizardicon;
                }
            }
        }

        public class highcontrastmenuicons : menuicons
        {
            public override Image fd
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_flightdata_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_flightdata_icon.png");
                    else
                        return Resources.dark_flightdata_icon;
                }
            }

            public override Image fp
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_flightplan_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_flightplan_icon.png");
                    else
                        return Resources.dark_flightplan_icon;
                }
            }

            public override Image initsetup
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_initialsetup_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_initialsetup_icon.png");
                    else
                        return Resources.dark_initialsetup_icon;
                }
            }

            public override Image config_tuning
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_tuningconfig_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_tuningconfig_icon.png");
                    else
                        return Resources.dark_tuningconfig_icon;
                }
            }

            public override Image sim
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_simulation_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_simulation_icon.png");
                    else
                        return Resources.dark_simulation_icon;
                }
            }

            public override Image terminal
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_terminal_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_terminal_icon.png");
                    else
                        return Resources.dark_terminal_icon;
                }
            }

            public override Image help
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_help_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_help_icon.png");
                    else
                        return Resources.dark_help_icon;
                }
            }

            public override Image donate
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_donate_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_donate_icon.png");
                    else
                        return Resources.donate;
                }
            }

            public override Image connect
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_connect_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_connect_icon.png");
                    else
                        return Resources.dark_connect_icon;
                }
            }

            public override Image disconnect
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_disconnect_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_disconnect_icon.png");
                    else
                        return Resources.dark_disconnect_icon;
                }
            }

            public override Image bg
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_icon_background.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_icon_background.png");
                    else
                        return null;
                }
            }

            public override Image wizard
            {
                get
                {
                    if (File.Exists(Settings.GetRunningDirectory() + "dark_wizard_icon.png"))
                        return Image.FromFile(Settings.GetRunningDirectory() + "dark_wizard_icon.png");
                    else
                        return Resources.wizardicon;
                }
            }
        }

        public MainSwitcher MyView;

        private static DisplayView _displayConfiguration = File.Exists(DisplayViewExtensions.custompath)
            ? new DisplayView().Custom()
            : new DisplayView().Advanced();

        public static event EventHandler LayoutChanged;

        public static DisplayView DisplayConfiguration
        {
            get { return _displayConfiguration; }
            set
            {
                _displayConfiguration = value;
                Settings.Instance["displayview"] = _displayConfiguration.ConvertToString();
                LayoutChanged?.Invoke(null, EventArgs.Empty);
            }
        }


        public static bool ShowAirports { get; set; }
        public static bool ShowTFR { get; set; }

        private adsb _adsb;

        public bool EnableADSB
        {
            get { return _adsb != null; }
            set
            {
                if (value == true)
                {
                    _adsb = new adsb();

                    if (Settings.Instance["adsbserver"] != null)
                        adsb.server = Settings.Instance["adsbserver"];
                    if (Settings.Instance["adsbport"] != null)
                        adsb.serverport = Int32.Parse(Settings.Instance["adsbport"].ToString());
                }
                else
                {
                    adsb.Stop();
                    _adsb = null;
                }
            }
        }

        //public static event EventHandler LayoutChanged;

        /// <summary>
        /// Active Comport interface
        /// </summary>
        public static MAVLinkInterface comPort
        {
            get { return _comPort; }
            set
            {
                if (_comPort == value)
                    return;
                _comPort = value;
                _comPort.MavChanged -= instance.comPort_MavChanged;
                _comPort.MavChanged += instance.comPort_MavChanged;
                instance.comPort_MavChanged(null, null);
            }
        }

        static MAVLinkInterface _comPort = new MAVLinkInterface();

        /// <summary>
        /// passive comports
        /// </summary>
        public static List<MAVLinkInterface> Comports = new List<MAVLinkInterface>();

        public delegate void WMDeviceChangeEventHandler(WM_DEVICECHANGE_enum cause);

        public event WMDeviceChangeEventHandler DeviceChanged;

        /// <summary>
        /// other planes in the area from adsb
        /// </summary>
        public object adsblock = new object();

        public ConcurrentDictionary<string, adsb.PointLatLngAltHdg> adsbPlanes =
            new ConcurrentDictionary<string, adsb.PointLatLngAltHdg>();

        string titlebar;

        /// <summary>
        /// Comport name
        /// </summary>
        public static string comPortName = "";

        public static int comPortBaud = 115200;

        /// <summary>
        /// mono detection
        /// </summary>
        public static bool MONO = false;

        /// <summary>
        /// speech engine enable
        /// </summary>
        public static bool speechEnable
        {
            get { return speechEngine == null ? false : speechEngine.speechEnable; }
            set
            {
                if (speechEngine != null) speechEngine.speechEnable = value;
            }
        }

        /// <summary>
        /// spech engine static class
        /// </summary>
        public static ISpeech speechEngine { get; set; }

        /// <summary>
        /// joystick static class
        /// </summary>
        public static Joystick.Joystick joystick { get; set; }

        /// <summary>
        /// track last joystick packet sent. used to control rate
        /// </summary>
        DateTime lastjoystick = DateTime.Now;

        /// <summary>
        /// determine if we are running sitl
        /// </summary>
        public static bool sitl
        {
            get
            {
                if (SITL.SITLSEND == null) return false;
                if (SITL.SITLSEND.Client.Connected) return true;
                return false;
            }
        }

        /// <summary>
        /// hud background image grabber from a video stream - not realy that efficent. ie no hardware overlays etc.
        /// </summary>
        public static Capture cam { get; set; }

        /// <summary>
        /// controls the main serial reader thread
        /// </summary>
        bool serialThread = false;

        bool pluginthreadrun = false;

        bool joystickthreadrun = false;

        Thread httpthread;
        Thread joystickthread;
        Thread serialreaderthread;
        Thread pluginthread;

        /// <summary>
        /// track the last heartbeat sent
        /// </summary>
        private DateTime heatbeatSend = DateTime.Now;

        /// <summary>
        /// used to call anything as needed.
        /// </summary>
        public static MainV2 instance = null;


        public static MainSwitcher View;

        /// <summary>
        /// store the time we first connect
        /// </summary>
        DateTime connecttime = DateTime.Now;

        DateTime nodatawarning = DateTime.Now;
        DateTime OpenTime = DateTime.Now;


        DateTime connectButtonUpdate = DateTime.Now;

        /// <summary>
        /// declared here if i want a "single" instance of the form
        /// ie configuration gets reloaded on every click
        /// </summary>
        public FlightData FlightData;

        public FlightPlanner FlightPlanner;
        SITL Simulation;

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// MY NEW FORMS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private DiagnosticForm diagnosticForm;

        public static EngineController engineController;
        private MapChangeForm mapChangeForm;
        private string mapTitleStatus = "";
        int centering = 0; //0 - false, 1 - onse, 2 - always
        public static bool sitlMapChangeSignal = false;

        public static int currentEngineMode = 3;

        public ushort secondTrim = 1500;
        public ushort thirdTrim = 1500;

        public static int loiterRad = -1;

        // public static int maxCapacity = 0;
        // public static int flyTime = 0;
        // public static int butt2RealVoltage = 0;

        public static VibeData vibeData;

        public static Logger logger;

        private Form connectionStatsForm;
        private ConnectionStats _connectionStats;

        public static Dictionary<int, servoValue> configServo = new Dictionary<int, servoValue>();

        public class item
        {
            [XmlAttribute] public string id;
            [XmlAttribute] public string servo;
            [XmlAttribute] public string value;
            [XmlAttribute] public string defaultValue;
        }

        public class servoValue
        {
            public int servo;
            public int value;
            public int defaultValue;

            public servoValue(int _servo, int _value, int _defaultValue)
            {
                servo = _servo;
                value = _value;
                defaultValue = _defaultValue;
            }
        }

        public static string defaultFuelSavePath = Settings.GetUserDataDirectory() + "fuelConfig";
        public static string defaultConfig = Settings.GetUserDataDirectory() + "servoConfig.txt";
        public static string defaultLoggerPath = Settings.GetUserDataDirectory() + "Log";

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

        public XmlSerializer serializer = new XmlSerializer(typeof(item[]),
            new XmlRootAttribute() {ElementName = "items"});

        /// <summary>
        /// This 'Control' is the toolstrip control that holds the comport combo, baudrate combo etc
        /// Otiginally seperate controls, each hosted in a toolstip sqaure, combined into this custom
        /// control for layout reasons.
        /// </summary>
        public static ConnectionControl _connectionControl;

        public static bool TerminalTheming = true;

        /// <summary>
        /// Form for orlan connections
        /// </summary>
        public static ConnectionsForm ConnectionsForm = new ConnectionsForm();

        public static AircraftMenuControl AircraftMenuControl = new AircraftMenuControl();

        public static GaugeHeading GaugeMenuHeading = new GaugeHeading();

        public static RouteAltForm RouteAltForm = new RouteAltForm()
            {Visible = false, StartPosition = FormStartPosition.Manual};

        public static StatusControlPanel StatusControlPanel = new StatusControlPanel();

        public static FormConnector FormConnector;

        /// <summary>
        /// All orlan connections data
        /// </summary>
        public static Dictionary<string, AircraftConnectionInfo> Aircrafts =
            new Dictionary<string, AircraftConnectionInfo>();

        /// <summary>
        /// Antenna connection data
        /// </summary>
        public static AntennaConnectionInfo AntennaConnectionInfo = new AntennaConnectionInfo();

        private DateTime _sitlFuelUpdateTime = DateTime.Now;

        private DateTime _sitlEmulationTime = DateTime.Now;

        private static AircraftConnectionInfo _currentAircraft = null;

        public static AircraftConnectionInfo CurrentAircraft
        {
            get => _currentAircraft;
            set => _currentAircraft = value;
        }

        private static string _currentAircraftNum = null;

        public static string CurrentAircraftNum
        {
            get { return _currentAircraftNum; }
            set
            {
                AircraftMenuControl.updateAllAircraftButtonTexts();

                _currentAircraftNum = value;

                if (value != null)
                {
                    CurrentAircraft = Aircrafts[_currentAircraftNum];
                }
                else
                {
                    CurrentAircraft = null;
                }

                if (_currentAircraftNum != null && ConnectedAircraftExists())
                {
                    ShowConnectionQuality();
                }
            }
        }

        private static MAVLinkInterface _mavlink;
        private static CompositeDisposable _subscriptionsDisposable;

        public static void StopUpdates()
        {
            _subscriptionsDisposable?.Dispose();
        }

        public static void ShowConnectionQuality()
        {
            _subscriptionsDisposable = new CompositeDisposable();

            int currentNum = Int32.Parse(_currentAircraftNum);
            AircraftConnectionInfo currentAircraftInfo = Aircrafts[_currentAircraftNum];
            AircraftMenuControl.aircraftButtonInfo currentMenuButton =
                AircraftMenuControl.aircraftButtons[currentAircraftInfo.MenuNum];
            _mavlink = comPort;

            // var subscriptions = new List<IDisposable>
            // {
            //     // Link quality is a percentage of the number of good packets received
            //     // to the number of packets missed (detected by mavlink seq no.)
            //     // Calculated as an average over the last 3 seconds (non weighted)
            //     // Calculated every second
            //     CombineWithDefault(_mavlink.WhenPacketReceived, _mavlink.WhenPacketLost, Tuple.Create)
            //         .Buffer(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(1))
            //         .Select(CalculateAverage)
            //         .ObserveOn(SynchronizationContext.Current)
            //         .Subscribe(x =>
            //         {
            //             currentMenuButton.Button.Text = currentMenuButton.DefaultText + " | " + x.ToString("00%");
            //             currentConnectionRate = x;
            //         }),
            // };
            //
            // subscriptions.ForEach(d => _subscriptionsDisposable.Add(d));

            // currentMenuButton.Button.Text =
            //     currentMenuButton.DefaultText + " | " + comPort.MAV.cs.linkqualitygcs.ToString() + "%";
        }

        public AircraftConnectionInfo GetCurrentAircraft()
        {
            if (CurrentAircraftNum == null)
            {
                return null;
            }

            return Aircrafts[CurrentAircraftNum];
        }

        private static IObservable<TResult> CombineWithDefault<TSource, TResult>(IObservable<TSource> first,
            Subject<TSource> second, Func<TSource, TSource, TResult> resultSelector)
        {
            return Observable.Defer(() =>
            {
                var foo = new Subject<TResult>();

                first.Select(x => resultSelector(x, default(TSource))).Subscribe(foo);
                second.Select(x => resultSelector(default(TSource), x)).Subscribe(foo);

                return foo;
            });
        }

        private static double CalculateAverage(IList<Tuple<int, int>> xs)
        {
            var packetsReceived = xs.Sum(t => t.Item1);
            var packetsLost = xs.Sum(t => t.Item2);

            return packetsReceived / (packetsReceived + (double) packetsLost);
        }


        public void updateLayout(object sender, EventArgs e)
        {
            MenuSimulation.Visible = DisplayConfiguration.displaySimulation;
            MenuHelp.Visible = DisplayConfiguration.displayHelp;
            BackstageView.Advanced = DisplayConfiguration.isAdvancedMode;

            if (Settings.Instance.GetBoolean("menu_autohide") != DisplayConfiguration.autoHideMenuForce)
            {
                AutoHideMenu(DisplayConfiguration.autoHideMenuForce);
                Settings.Instance["menu_autohide"] = DisplayConfiguration.autoHideMenuForce.ToString();
            }

            autoHideToolStripMenuItem.Visible = !DisplayConfiguration.autoHideMenuForce;

            //Flight data page
            if (MainV2.instance.FlightData != null)
            {
                TabControl t = MainV2.instance.FlightData.tabControlactions;
                if (DisplayConfiguration.displayQuickTab && !t.TabPages.Contains(FlightData.tabQuick))
                {
                    t.TabPages.Add(FlightData.tabQuick);
                }
                else if (!DisplayConfiguration.displayQuickTab && t.TabPages.Contains(FlightData.tabQuick))
                {
                    t.TabPages.Remove(FlightData.tabQuick);
                }

                if (DisplayConfiguration.displayPreFlightTab && !t.TabPages.Contains(FlightData.tabPagePreFlight))
                {
                    t.TabPages.Add(FlightData.tabPagePreFlight);
                }
                else if (!DisplayConfiguration.displayPreFlightTab && t.TabPages.Contains(FlightData.tabPagePreFlight))
                {
                    t.TabPages.Remove(FlightData.tabPagePreFlight);
                }

                if (DisplayConfiguration.displayAdvActionsTab && !t.TabPages.Contains(FlightData.tabActions))
                {
                    t.TabPages.Add(FlightData.tabActions);
                }
                else if (!DisplayConfiguration.displayAdvActionsTab && t.TabPages.Contains(FlightData.tabActions))
                {
                    t.TabPages.Remove(FlightData.tabActions);
                }

                if (DisplayConfiguration.displaySimpleActionsTab && !t.TabPages.Contains(FlightData.tabActionsSimple))
                {
                    t.TabPages.Add(FlightData.tabActionsSimple);
                }
                else if (!DisplayConfiguration.displaySimpleActionsTab &&
                         t.TabPages.Contains(FlightData.tabActionsSimple))
                {
                    t.TabPages.Remove(FlightData.tabActionsSimple);
                }

                if (DisplayConfiguration.displayGaugesTab && !t.TabPages.Contains(FlightData.tabGauges))
                {
                    t.TabPages.Add(FlightData.tabGauges);
                }
                else if (!DisplayConfiguration.displayGaugesTab && t.TabPages.Contains(FlightData.tabGauges))
                {
                    t.TabPages.Remove(FlightData.tabGauges);
                }

                if (DisplayConfiguration.displayStatusTab && !t.TabPages.Contains(FlightData.tabStatus))
                {
                    t.TabPages.Add(FlightData.tabStatus);
                }
                else if (!DisplayConfiguration.displayStatusTab && t.TabPages.Contains(FlightData.tabStatus))
                {
                    t.TabPages.Remove(FlightData.tabStatus);
                }

                if (DisplayConfiguration.displayServoTab && !t.TabPages.Contains(FlightData.tabServo))
                {
                    t.TabPages.Add(FlightData.tabServo);
                }
                else if (!DisplayConfiguration.displayServoTab && t.TabPages.Contains(FlightData.tabServo))
                {
                    t.TabPages.Remove(FlightData.tabServo);
                }

                if (DisplayConfiguration.displayScriptsTab && !t.TabPages.Contains(FlightData.tabScripts))
                {
                    t.TabPages.Add(FlightData.tabScripts);
                }
                else if (!DisplayConfiguration.displayScriptsTab && t.TabPages.Contains(FlightData.tabScripts))
                {
                    t.TabPages.Remove(FlightData.tabScripts);
                }

                if (DisplayConfiguration.displayTelemetryTab && !t.TabPages.Contains(FlightData.tabTLogs))
                {
                    t.TabPages.Add(FlightData.tabTLogs);
                }
                else if (!DisplayConfiguration.displayTelemetryTab && t.TabPages.Contains(FlightData.tabTLogs))
                {
                    t.TabPages.Remove(FlightData.tabTLogs);
                }

                if (DisplayConfiguration.displayDataflashTab && !t.TabPages.Contains(FlightData.tablogbrowse))
                {
                    t.TabPages.Add(FlightData.tablogbrowse);
                }
                else if (!DisplayConfiguration.displayDataflashTab && t.TabPages.Contains(FlightData.tablogbrowse))
                {
                    t.TabPages.Remove(FlightData.tablogbrowse);
                }

                if (DisplayConfiguration.displayMessagesTab && !t.TabPages.Contains(FlightData.tabPagemessages))
                {
                    t.TabPages.Add(FlightData.tabPagemessages);
                }
                else if (!DisplayConfiguration.displayMessagesTab && t.TabPages.Contains(FlightData.tabPagemessages))
                {
                    t.TabPages.Remove(FlightData.tabPagemessages);
                }

                t.SelectedIndex = 0;

                MainV2.instance.FlightData.loadTabControlActions();
            }

            if (MainV2.instance.FlightPlanner != null)
            {
                //hide menu items 
                MainV2.instance.FlightPlanner.updateDisplayView();
            }
        }


        public MainV2()
        {
            log.Info("Mainv2 ctor");

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // create one here - but override on load
            Settings.Instance["guid"] = Guid.NewGuid().ToString();

            // load config
            LoadConfig();

            // force language to be loaded
            L10N.GetConfigLang();

            ShowAirports = true;

            // setup adsb
            adsb.UpdatePlanePosition += adsb_UpdatePlanePosition;

            MAVLinkInterface.UpdateADSBPlanePosition += adsb_UpdatePlanePosition;

            MAVLinkInterface.UpdateADSBCollision += (sender, tuple) =>
            {
                lock (adsblock)
                {
                    if (MainV2.instance.adsbPlanes.ContainsKey(tuple.id))
                    {
                        // update existing
                        ((adsb.PointLatLngAltHdg) instance.adsbPlanes[tuple.id]).ThreatLevel = tuple.threat_level;
                    }
                }
            };

            MAVLinkInterface.gcssysid = (byte) Settings.Instance.GetByte("gcsid", MAVLinkInterface.gcssysid);

            Form splash = Program.Splash;

            splash?.Refresh();

            Application.DoEvents();

            instance = this;
            InitializeComponent();

            //Init Theme table and load BurntKermit as a default
            ThemeManager.thmColor = new ThemeColorTable(); //Init colortable
            ThemeManager.thmColor.InitColors(); //This fills up the table with BurntKermit defaults. 
            ThemeManager.thmColor
                .SetTheme(); //Set the colors, this need to handle the case when not all colors are defined in the theme file


            if (Settings.Instance["theme"] == null) Settings.Instance["theme"] = "BurntKermit.mpsystheme";

            ThemeManager.LoadTheme(Settings.Instance["theme"]);

            ThemeManager.ApplyThemeTo(this);

            MyView = new MainSwitcher(this);

            View = MyView;

            //startup console
            TCPConsole.Write((byte) 'S');

            // define default basestream
            comPort.BaseStream = new SerialPort();
            comPort.BaseStream.BaudRate = 115200;

            _connectionControl = toolStripConnectionControl.ConnectionControl;
            _connectionControl.CMB_baudrate.TextChanged += this.CMB_baudrate_TextChanged;
            _connectionControl.CMB_serialport.SelectedIndexChanged += this.CMB_serialport_SelectedIndexChanged;
            _connectionControl.CMB_serialport.Click += this.CMB_serialport_Click;
            _connectionControl.cmb_sysid.Click += cmb_sysid_Click;

            _connectionControl.ShowLinkStats += (sender, e) => ShowConnectionStatsForm();
            srtm.datadirectory = Settings.GetDataDirectory() +
                                 "srtm";

            var t = Type.GetType("Mono.Runtime");
            MONO = (t != null);

            try
            {
                speechEngine = new Speech();
                MAVLinkInterface.Speech = speechEngine;
                CurrentState.Speech = speechEngine;
            }
            catch
            {
            }

            CustomWarning.defaultsrc = comPort.MAV.cs;
            WarningEngine.Start(speechEnable ? speechEngine : null);
            WarningEngine.WarningMessage += (sender, s) => { MainV2.comPort.MAV.cs.messageHigh = s; };

            // proxy loader - dll load now instead of on config form load
            new Transition(new TransitionType_EaseInEaseOut(2000));

            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Count > 0)
            {
                _connectionControl.CMB_baudrate.SelectedIndex = 8;
                _connectionControl.CMB_serialport.SelectedIndex = 0;
            }
            // ** Done

            splash?.Refresh();
            Application.DoEvents();

            // load last saved connection settings
            string temp = Settings.Instance.ComPort;
            if (!String.IsNullOrEmpty(temp))
            {
                _connectionControl.CMB_serialport.SelectedIndex = _connectionControl.CMB_serialport.FindString(temp);
                if (_connectionControl.CMB_serialport.SelectedIndex == -1)
                {
                    _connectionControl.CMB_serialport.Text = temp; // allows ports that dont exist - yet
                }

                comPort.BaseStream.PortName = temp;
                comPortName = temp;
            }

            string temp2 = Settings.Instance.BaudRate;
            if (!String.IsNullOrEmpty(temp2))
            {
                var idx = _connectionControl.CMB_baudrate.FindString(temp2);
                if (idx == -1)
                {
                    _connectionControl.CMB_baudrate.Text = temp2;
                }
                else
                {
                    _connectionControl.CMB_baudrate.SelectedIndex = idx;
                }

                comPortBaud = Int32.Parse(temp2);
            }

            Tracking.cid = new Guid(Settings.Instance["guid"].ToString());

            if (Settings.Instance.ContainsKey("language") && !String.IsNullOrEmpty(Settings.Instance["language"]))
            {
                changelanguage(CultureInfoEx.GetCultureInfo(Settings.Instance["language"]));
            }

            if (splash != null)
            {
                this.Text = "НПУ"; //splash?.Text;
                titlebar = splash?.Text;
            }

            if (!MONO) // windows only
            {
                if (Settings.Instance["showconsole"] != null && Settings.Instance["showconsole"].ToString() == "True")
                {
                }
                else
                {
                    int win = NativeMethods.FindWindow("ConsoleWindowClass", null);
                    NativeMethods.ShowWindow(win, NativeMethods.SW_HIDE); // hide window
                }

                // prevent system from sleeping while mp open
                var previousExecutionState =
                    NativeMethods.SetThreadExecutionState(
                        NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            }

            ChangeUnits();

            if (Settings.Instance["showairports"] != null)
            {
                MainV2.ShowAirports = Boolean.Parse(Settings.Instance["showairports"]);
            }

            // set default
            ShowTFR = true;
            // load saved
            if (Settings.Instance["showtfr"] != null)
            {
                MainV2.ShowTFR = Settings.Instance.GetBoolean("showtfr", ShowTFR);
            }

            if (Settings.Instance["enableadsb"] != null)
            {
                MainV2.instance.EnableADSB = Settings.Instance.GetBoolean("enableadsb");
            }

            try
            {
                log.Debug(Process.GetCurrentProcess().Modules.ToJSON());
            }
            catch
            {
            }

            try
            {
                log.Info("Create FD");
                FlightData = new FlightData();
                log.Info("Create FP");
                FlightPlanner = new FlightPlanner();
                //Configuration = new GCSViews.ConfigurationView.Setup();
                log.Info("Create SIM");
                Simulation = new SITL();
                //Firmware = new GCSViews.Firmware();
                //Terminal = new GCSViews.Terminal();

                FlightData.Width = MyView.Width;
                FlightPlanner.Width = MyView.Width;
                Simulation.Width = MyView.Width;
            }
            catch (ArgumentException e)
            {
                //http://www.microsoft.com/en-us/download/details.aspx?id=16083
                //System.ArgumentException: Font 'Arial' does not support style 'Regular'.

                log.Fatal(e);
                CustomMessageBox.Show(e.ToString() +
                                      "\n\n Font Issues? Please install this http://www.microsoft.com/en-us/download/details.aspx?id=16083");
                //splash.Close();
                //this.Close();
                Application.Exit();
            }
            catch (Exception e)
            {
                log.Fatal(e);
                CustomMessageBox.Show("A Major error has occured : " + e.ToString());
                Application.Exit();
            }

            //set first instance display configuration
            if (DisplayConfiguration == null)
            {
                DisplayConfiguration = DisplayConfiguration.Advanced();
            }

            // load old config
            if (Settings.Instance["advancedview"] != null)
            {
                if (Settings.Instance.GetBoolean("advancedview") == true)
                {
                    DisplayConfiguration = new DisplayView().Advanced();
                }

                // remove old config
                Settings.Instance.Remove("advancedview");
            } //// load this before the other screens get loaded

            if (Settings.Instance["displayview"] != null)
            {
                try
                {
                    DisplayConfiguration = Settings.Instance.GetDisplayView("displayview");
                }
                catch
                {
                    DisplayConfiguration = DisplayConfiguration.Advanced();
                }
            }

            LayoutChanged += updateLayout;
            LayoutChanged(null, EventArgs.Empty);

            if (Settings.Instance["CHK_GDIPlus"] != null)
                FlightData.myhud.opengl = !Boolean.Parse(Settings.Instance["CHK_GDIPlus"].ToString());

            if (Settings.Instance["CHK_hudshow"] != null)
                FlightData.myhud.hudon = Boolean.Parse(Settings.Instance["CHK_hudshow"].ToString());

            try
            {
                if (Settings.Instance["MainLocX"] != null && Settings.Instance["MainLocY"] != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    Point startpos = new Point(Settings.Instance.GetInt32("MainLocX"),
                        Settings.Instance.GetInt32("MainLocY"));

                    // fix common bug which happens when user removes a monitor, the app shows up
                    // offscreen and it is very hard to move it onscreen.  Also happens with 
                    // remote desktop a lot.  So this only restores position if the position
                    // is visible.
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (s.WorkingArea.Contains(startpos))
                        {
                            this.Location = startpos;
                            break;
                        }
                    }
                }

                if (Settings.Instance["MainMaximised"] != null)
                {
                    this.WindowState =
                        (FormWindowState) Enum.Parse(typeof(FormWindowState), Settings.Instance["MainMaximised"]);
                    // dont allow minimised start state
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Location = new Point(100, 100);
                    }
                }

                if (Settings.Instance["MainHeight"] != null)
                    this.Height = Settings.Instance.GetInt32("MainHeight");
                if (Settings.Instance["MainWidth"] != null)
                    this.Width = Settings.Instance.GetInt32("MainWidth");

                // set presaved default telem rates
                if (Settings.Instance["CMB_rateattitude"] != null)
                    CurrentState.rateattitudebackup = Settings.Instance.GetInt32("CMB_rateattitude");
                if (Settings.Instance["CMB_rateposition"] != null)
                    CurrentState.ratepositionbackup = Settings.Instance.GetInt32("CMB_rateposition");
                if (Settings.Instance["CMB_ratestatus"] != null)
                    CurrentState.ratestatusbackup = Settings.Instance.GetInt32("CMB_ratestatus");
                if (Settings.Instance["CMB_raterc"] != null)
                    CurrentState.ratercbackup = Settings.Instance.GetInt32("CMB_raterc");
                if (Settings.Instance["CMB_ratesensors"] != null)
                    CurrentState.ratesensorsbackup = Settings.Instance.GetInt32("CMB_ratesensors");

                //Load customfield names from config

                for (short i = 0; i < 10; i++)
                {
                    var fieldname = "customfield" + i.ToString();
                    if (Settings.Instance.ContainsKey(fieldname))
                        CurrentState.custom_field_names.Add(fieldname, Settings.Instance[fieldname].ToUpper());
                }

                // make sure rates propogate
                MainV2.comPort.MAV.cs.ResetInternals();

                if (Settings.Instance["speechenable"] != null)
                    MainV2.speechEnable = Settings.Instance.GetBoolean("speechenable");

                if (Settings.Instance["analyticsoptout"] != null)
                    Tracking.OptOut = Settings.Instance.GetBoolean("analyticsoptout");

                try
                {
                    if (Settings.Instance["TXT_homelat"] != null)
                        MainV2.comPort.MAV.cs.PlannedHomeLocation.Lat = Settings.Instance.GetDouble("TXT_homelat");

                    if (Settings.Instance["TXT_homelng"] != null)
                        MainV2.comPort.MAV.cs.PlannedHomeLocation.Lng = Settings.Instance.GetDouble("TXT_homelng");

                    if (Settings.Instance["TXT_homealt"] != null)
                        MainV2.comPort.MAV.cs.PlannedHomeLocation.Alt = Settings.Instance.GetDouble("TXT_homealt");

                    // remove invalid entrys
                    if (Math.Abs(MainV2.comPort.MAV.cs.PlannedHomeLocation.Lat) > 90 ||
                        Math.Abs(MainV2.comPort.MAV.cs.PlannedHomeLocation.Lng) > 180)
                        MainV2.comPort.MAV.cs.PlannedHomeLocation = new PointLatLngAlt();
                }
                catch
                {
                }
            }
            catch
            {
            }

            if (CurrentState.rateattitudebackup == 0) // initilised to 10, configured above from save
            {
                CustomMessageBox.Show(
                    "NOTE: your attitude rate is 0, the hud will not work\nChange in Configuration > Planner > Telemetry Rates");
            }

            // create log dir if it doesnt exist
            try
            {
                if (!Directory.Exists(Settings.Instance.LogDir))
                    Directory.CreateDirectory(Settings.Instance.LogDir);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
#if !NETSTANDARD2_0
#if !NETCOREAPP2_0
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
#endif
#endif

            // make sure new enough .net framework is installed
            if (!MONO)
            {
                RegistryKey installed_versions =
                    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                string[] version_names = installed_versions.GetSubKeyNames();
                //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
                double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1),
                    CultureInfo.InvariantCulture);
                int SP =
                    Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1])
                        .GetValue("SP", 0));

                if (Framework < 4.0)
                {
                    CustomMessageBox.Show("This program requires .NET Framework 4.0. You currently have " + Framework);
                }
            }

            if (Program.IconFile != null)
            {
                //this.Icon = Icon.FromHandle(((Bitmap) Program.IconFile).GetHicon());
            }

            MenuArduPilot.Image = new Bitmap(Resources._0d92fed790a3a70170e61a86db103f399a595c70, (int) (200), 31);
            MenuArduPilot.Width = MenuArduPilot.Image.Width;

            if (Program.Logo2 != null)
                MenuArduPilot.Image = Program.Logo2;

            Application.DoEvents();

            Comports.Add(comPort);

            MainV2.comPort.MavChanged += comPort_MavChanged;

            // save config to test we have write access
            SaveConfig();
            //MyView.ShowScreen("FlightPlanner");

            ///Trying to add connectionControl into toolStripItem
            // ToolStripControlHost connectionControlHost = new ToolStripControlHost(_connectionControl);
            // p1ToolStripMenuItem.DropDownItems.Add(connectionControlHost);

            // p1ToolStripMenuItem.DropDownItems.Add(MenuConnect);
            /*Panel aircraftPanel = new Panel();
            aircraftPanel.Controls.Clear();
            aircraftPanel.Size = new Size(100, 47);
            
            Button testButton = new Button();
            testButton.Size = new Size(50, 47);
            testButton.Text = "Done";
            aircraftPanel.Controls.Add(testButton);*/

            // RouteSlidingScale = new RouteSlidingScale() { Visible = false };

            ToolStripControlHost aircraftControlHost = new ToolStripControlHost(AircraftMenuControl);
            menuStrip1.Items.Add(aircraftControlHost);
            ConnectionsForm.sitlForm = Simulation;

            ToolStripControlHost statusControlHost = new ToolStripControlHost(StatusControlPanel);
            menuStrip1.Items.Add(statusControlHost);

            // ToolStripControlHost headingControlHost = new ToolStripControlHost(GaugeMenuHeading);
            // menuStrip1.Items.Add(headingControlHost);
            mainMenuInit();
            coordinatsControlInit();
            deserealaseDict();
            FormConnector = new FormConnector(this);

            AircraftMenuControl.SwitchOnTimer();

            ConnectionsForm.Init();
            //this.OnClosing += new Ev
            //this.Text = "Мighty Platypus   v0.2";
        }

        private void onClose(CancelEventArgs e)
        {
        }

        private void MakeRightSideMenuTransparent()
        {
            rightSideButtonsMenu.Parent = FlightPlanner.MainMap;
            rightSideButtonsMenu.Location =
                new Point(FlightPlanner.MainMap.Size.Width - rightSideButtonsMenu.Size.Width + 10, 100);
        }

        void cmb_sysid_Click(object sender, EventArgs e)
        {
            MainV2._connectionControl.UpdateSysIDS();
        }

        void comPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainV2.comPort.MAV.sysid);

            HUD.Custom.src = MainV2.comPort.MAV.cs;

            CustomWarning.defaultsrc = MainV2.comPort.MAV.cs;

            CheckListItem.defaultsrc = MainV2.comPort.MAV.cs;

            // when uploading a firmware we dont want to reload this screen.
            if (instance.MyView.current.Control != null &&
                instance.MyView.current.Control.GetType() == typeof(InitialSetup))
            {
                var page = ((InitialSetup) instance.MyView.current.Control).backstageView.SelectedPage;
                if (page != null && page.Text.Contains("Install Firmware"))
                {
                    return;
                }
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker) delegate
                {
                    //enable the payload control page if a mavlink gimbal is detected
                    if (instance.FlightData != null)
                    {
                        instance.FlightData.updatePayloadTabVisible();
                    }

                    instance.MyView.Reload();
                });
            }
            else
            {
                //enable the payload control page if a mavlink gimbal is detected
                if (instance.FlightData != null)
                {
                    instance.FlightData.updatePayloadTabVisible();
                }

                instance.MyView.Reload();
            }
        }
#if !NETSTANDARD2_0
#if !NETCOREAPP2_0
        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            // try prevent crash on resume
            if (e.Mode == PowerModes.Suspend)
            {
                doDisconnect(MainV2.comPort);
            }
        }
#endif
#endif
        private void BGLoadAirports(object nothing)
        {
            // read airport list
            try
            {
                Airports.ReadOurairports(Settings.GetRunningDirectory() +
                                         "airports.csv");

                Airports.checkdups = true;

                //Utilities.Airports.ReadOpenflights(Application.StartupPath + Path.DirectorySeparatorChar + "airports.dat");

                log.Info("Loaded " + Airports.GetAirportCount + " airports");
            }
            catch
            {
            }
        }

        public void switchicons(menuicons icons)
        {
            //Check if we starting 
            if (displayicons != null)
            {
                // dont update if no change
                if (displayicons.GetType() == icons.GetType())
                    return;
            }

            displayicons = icons;

            MainMenu.BackColor = SystemColors.MenuBar;

            MainMenu.BackgroundImage = displayicons.bg;

            MenuFlightData.Image = displayicons.fd;
            MenuFlightPlanner.Image = displayicons.fp;
            MenuInitConfig.Image = displayicons.initsetup;
            MenuSimulation.Image = displayicons.sim;
            MenuConfigTune.Image = displayicons.config_tuning;
            MenuConnect.Image = displayicons.connect;
            MenuHelp.Image = displayicons.help;


            MenuFlightData.ForeColor = ThemeManager.TextColor;
            MenuFlightPlanner.ForeColor = ThemeManager.TextColor;
            MenuInitConfig.ForeColor = ThemeManager.TextColor;
            MenuSimulation.ForeColor = ThemeManager.TextColor;
            MenuConfigTune.ForeColor = ThemeManager.TextColor;
            MenuConnect.ForeColor = ThemeManager.TextColor;
            MenuHelp.ForeColor = ThemeManager.TextColor;
        }

        void coordinatsControlInit()
        {
            coordinatsControl1.timer1.Enabled = true;
            coordinatsControl1.timer1.Tick += Timer1_Tick;
        }

        public static bool ParachuteReleased = false;
        public static int CoordinatsShowMode = 0;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (comPort.MAV.cs.connected && !ParachuteReleased)
            {
                if (comPort.MAV.cs.ch12in > 1800 || comPort.MAV.cs.ch6in > 1800)
                {
                    ParachuteReleased = true;
                    snsControl2.Invoke((MethodInvoker) delegate() { snsControl2.openParachuteForm(); });
                }
            }

            try
            {
                // cheatParachuteLandingTrigger();
            }
            catch (System.Exception eee)
            {
                System.Diagnostics.Debug.WriteLine("Timer error: " + eee.ToString());
            }

            try
            {
                if (StatusControlPanel != null && StatusControlPanel.airspeedDirectionControl2 != null)
                {
                    StatusControlPanel.airspeedDirectionControl2.updateData();
                }

                // Do sitl emulation
                if (_currentAircraftNum != null && Aircrafts[_currentAircraftNum].UsingSitl &&
                    Aircrafts[_currentAircraftNum].Connected)
                {
                    if (StatusControlPanel.SitlEmulation.EngineRunning &&
                        (DateTime.Now - _sitlFuelUpdateTime).TotalSeconds > 1)
                    {
                        StatusControlPanel.SitlEmulation.DoFuelStep();
                        _sitlFuelUpdateTime = DateTime.Now;
                    }

                    int timeSpan = (int) (DateTime.Now - _sitlEmulationTime).TotalMilliseconds;
                    if (timeSpan > 500)
                    {
                        StatusControlPanel.SitlEmulation.DoEmulationStep(timeSpan);
                        _sitlEmulationTime = DateTime.Now;
                    }

                    if (IsSitlLanding &&
                        CurrentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName.Alt) < 1 &&
                        !IsSitlLandComplete)
                    {
                        IsSitlLandComplete = true;
                        StatusControlPanel.SitlEmulation.SetTargetState(SitlState.SitlStateName.LandingEnd);
                    }
                }

                vibeData.update();
                double homedist =
                    FlightPlanner.MainMap.MapProvider.Projection.GetDistance(FlightPlanner.currentMarker.Position,
                        FlightPlanner.pointlist[0]);
                string homedistString = FlightPlanner.FormatDistance(homedist, true);
                string currentMousePosition = "";
                string currentPosition = "";
                double currentMousePositionLat = FlightPlanner.currentMarker.Position.Lat;
                double currentMousePositionLng = FlightPlanner.currentMarker.Position.Lng;
                double currentMousePositionAlt = 20;
                double currentPositionLat = comPort.MAV.cs.lat;
                double currentPositionLng = comPort.MAV.cs.lng;
                double currentPositionAlt = comPort.MAV.cs.alt;
                switch (CoordinatsShowMode)
                {
                    case 0:
                        currentMousePosition = CoordinatsConverter.toWGS_G(currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toWGS_G(currentPositionLat, currentPositionLng,
                            currentPositionAlt);
                        break;
                    case 1:
                        currentMousePosition = CoordinatsConverter.toWGS_GM(currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toWGS_GM(currentPositionLat, currentPositionLng,
                            currentPositionAlt);
                        break;
                    case 2:
                        currentMousePosition = CoordinatsConverter.toWGS_GMS(currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toWGS_GMS(currentPositionLat, currentPositionLng,
                            currentPositionAlt);
                        break;
                    case 3:
                        currentMousePosition = CoordinatsConverter.toSK42_G(currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toSK42_G(currentPositionLat, currentPositionLng,
                            currentPositionAlt);
                        break;
                    case 4:
                        currentMousePosition = CoordinatsConverter.toSK42_GM(currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toSK42_GM(currentPositionLat, currentPositionLng,
                            currentPositionAlt);
                        break;
                    case 5:
                        currentMousePosition = CoordinatsConverter.toSK42_GMS(currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toSK42_GMS(currentPositionLat, currentPositionLng,
                            currentPositionAlt);
                        break;
                    case 6:
                        currentMousePosition = CoordinatsConverter.toRectFromWGSwithFuckingJavaScript(
                            currentMousePositionLat,
                            currentMousePositionLng, currentMousePositionAlt);
                        currentPosition = CoordinatsConverter.toRectFromWGSwithFuckingJavaScript(currentPositionLat,
                            currentPositionLng,
                            currentPositionAlt);
                        break;
                    default:
                        break;
                }

                coordinatsControl1.label1.Text = currentMousePosition;
                coordinatsControl1.label2.Text = homedistString;
                coordinatsControl1.label3.Text = currentPosition;
                //string test1 = FlightPlanner.MainMap.FromLocalToLatLng(FlightPlanner.rulerControl1.Location.X, FlightPlanner.rulerControl1.Location.Y).Lat.ToString() +" " + FlightPlanner.MainMap.FromLocalToLatLng(FlightPlanner.rulerControl1.Location.X, FlightPlanner.rulerControl1.Location.Y).Lng.ToString();
                //string test2 = FlightPlanner.MainMap.FromLocalToLatLng(FlightPlanner.rulerControl1.Location.X + FlightPlanner.rulerControl1.Size.Width, FlightPlanner.rulerControl1.Location.Y).Lat.ToString() + " " + FlightPlanner.MainMap.FromLocalToLatLng(FlightPlanner.rulerControl1.Location.X + FlightPlanner.rulerControl1.Size.Width, FlightPlanner.rulerControl1.Location.Y).Lng.ToString();
                //System.Diagnostics.Debug.WriteLine("TEST RULER: "+test1 + "  - " + test2);
                double distance1 = FlightPlanner.MainMap.MapProvider.Projection.GetDistance(
                    FlightPlanner.MainMap.FromLocalToLatLng(FlightPlanner.rulerControl1.Location.X,
                        FlightPlanner.rulerControl1.Location.Y),
                    FlightPlanner.MainMap.FromLocalToLatLng(
                        FlightPlanner.rulerControl1.Location.X + FlightPlanner.rulerControl1.Size.Width,
                        FlightPlanner.rulerControl1.Location.Y));

                //FlightPlanner.MainMap.MapProvider.Projection.GetDistance(FlightPlanner.currentMarker.Position, FlightPlanner.pointlist[0]);

                FlightPlanner.rulerControl1.recalculate(distance1);

                if (comPort.MAV.cs.connected)
                {
                    double homedistfromplane = FlightPlanner.MainMap.MapProvider.Projection.GetDistance(
                        new PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng), FlightPlanner.pointlist[0]);
                    string homedistfromplaneString = FlightPlanner.FormatDistance(homedistfromplane);
                    FlightPlanner.notificationControl1.label3.Text = homedistfromplaneString;

                    int azimuth = (int) Math.Truncate(FlightPlanner.GetAzimuthAngle(FlightPlanner.pointlist[0],
                        new PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng)));
                    FlightPlanner.notificationControl1.azimuthUav_label.Text = azimuth + "°";
                }
                else
                {
                    FlightPlanner.notificationControl1.label3.Text = "0 м";
                }

                FlightPlanner.notificationControl1.label5.Text =
                    FlightPlanner.FormatDistance(comPort.MAV.cs.wp_dist / 1000.0);
                double lengthCountr = 0;
                for (int i = 0; i < FlightPlanner.Commands.Rows.Count; i++)
                {
                    string s = FlightPlanner.Commands.Rows[i].Cells[FlightPlanner.Dist.Index].Value.ToString();
                    lengthCountr += double.Parse(FlightPlanner.Commands.Rows[i].Cells[FlightPlanner.Dist.Index].Value
                        .ToString());
                }

                FlightPlanner.notificationControl1.label7.Text = FlightPlanner.FormatDistance(lengthCountr / 1000.0);
            }
            catch (System.Exception eee)
            {
                System.Diagnostics.Debug.WriteLine("Timer error: " + eee.ToString());
            }

            try
            {
                snsControl2.setButtonColors();
                if (!FlightPlanner.rulerControl1.timer1.Enabled)
                {
                    FlightPlanner.rulerControl1.timer1.Enabled = true;
                    FlightPlanner.rulerControl1.Parent = FlightPlanner.MainMap;
                }

                if (!FlightPlanner.notificationControl1.timer1.Enabled && !IsSitlLanding && !ParachuteReleased)
                {
                    FlightPlanner.notificationControl1.timer1.Enabled = true;
                    FlightPlanner.notificationControl1.Parent = FlightPlanner.MainMap;
                    FlightPlanner.notificationControl1.BackColor = Color.FromArgb(200, 32, 32, 32);
                }

                if (!FlightPlanner.notificationListControl1.timer1.Enabled)
                {
                    FlightPlanner.notificationListControl1.timer1.Enabled = true;
                    FlightPlanner.notificationListControl1.Parent = FlightPlanner.MainMap;
                    FlightPlanner.notificationListControl1.BackColor = Color.FromArgb(200, 64, 64, 64);
                }

                if (timeControl2.timerControl1.timetButton.BackColor != Color.Transparent)
                {
                    timeControl2.timerControl1.timetButton.BackColor = Color.Transparent;
                }

                if (!timeControl2.timer1.Enabled)
                {
                    timeControl2.timer1.Start();
                }

                if (!FlightPlanner.wpMenu1.timer1.Enabled)
                {
                    FlightPlanner.wpMenu1.timer1.Start();
                }

                if (comPort.MAV.cs.connected && CurrentAircraftNum != null && !Aircrafts[CurrentAircraftNum].inAir)
                {
                    if (comPort.MAV.cs.airspeed > 17.0)
                    {
                        Aircrafts[CurrentAircraftNum].inAir = true;
                        _sitlFuelUpdateTime = DateTime.Now;
                    }
                }

                /*if (ctrlModeActive && ctrlReliasedCounter == -1)
                {
                    secondTrim = MainV2.comPort.GetParam("SERVO4_TRIM");
                    thirdTrim = MainV2.comPort.GetParam("SERVO2_TRIM");
                    MainV2.comPort.setMode("Stabilize");
                    ctrlReliasedCounter = 12;
                    ctrlModeDebuglabel.Visible = true;
                }

                ctrlModeDebuglabel.Visible = true;
                if (ctrlReliasedCounter > 0)
                {
                    ctrlReliasedCounter--;
                    if (ctrlReliasedCounter == 1)
                    {
                        //set AUTO mode
                        MainV2.comPort.setMode("AUTO");
                        System.Diagnostics.Debug.WriteLine("ctrl released!!!");
                        ctrlModeDebuglabel.Visible = false;
                        ctrlReliasedCounter = -1;
                        ctrlModeActive = false;
                    }
                }*/
                if (overrideModeActive || EngineOverrideTestFlag)
                {
                    MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();
                    rc.target_component = comPort.MAV.compid;
                    rc.target_system = comPort.MAV.sysid;
                    rc.chan1_raw = (ushort) overrides[0];
                    rc.chan2_raw = (ushort) overrides[1];
                    rc.chan3_raw = EngineChannelOverride;
                    rc.chan4_raw = (ushort) overrides[3];

                    if ((DateTime.Now - _lastEngineOverrideTime).TotalMilliseconds > 1000)
                    {
                        //Send override for engine for 1 second
                        EngineOverrideTestFlag = false;
                        EngineChannelOverride = (ushort) overrides[2];
                        _lastEngineOverrideTime = DateTime.Now;
                    }
                    
                    System.Diagnostics.Debug.WriteLine("Overrides: " + overrides[0] + " " + overrides[1] + " " +
                                                       overrides[2] + " " + overrides[3] + " ");
                    if (comPort.BaseStream.IsOpen)
                    {
                        if (comPort.BaseStream.BytesToWrite < 50)
                        {
                            //if (sitl)
                            //{
                            //    SITL.rcinput();
                            //}
                            //else
                            //{
                            comPort.sendPacket(rc, rc.target_system, rc.target_component);
                            System.Diagnostics.Debug.WriteLine("rc sent");

                            //}

                            //count++;
                            //lastjoystick = DateTime.Now;
                        }
                    }
                }

                // if (IsEngineOverrideActive || EngineOverrideTestFlag)
                // {
                //     MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();
                //     rc.target_component = comPort.MAV.compid;
                //     rc.target_system = comPort.MAV.sysid;
                //     rc.chan1_raw = (ushort) overrides[0];
                //     rc.chan2_raw = (ushort) overrides[1];
                //     rc.chan3_raw = EngineChannelOverride;
                //     rc.chan4_raw = (ushort) overrides[3];
                //     // System.Diagnostics.Debug.WriteLine("Overrides: " + overrides[0] + " " + overrides[1] + " " +
                //     //                                    overrides[2] + " " + overrides[3] + " ");
                //     EngineOverrideTestFlag = false;
                //     if (comPort.BaseStream.IsOpen)
                //     {
                //         if (comPort.BaseStream.BytesToWrite < 50)
                //         {
                //             //if (sitl)
                //             //{
                //             //    SITL.rcinput();
                //             //}
                //             //else
                //             //{
                //             comPort.sendPacket(rc, rc.target_system, rc.target_component);
                //             // System.Diagnostics.Debug.WriteLine("rc sent");
                //
                //             //}
                //
                //             //count++;
                //             //lastjoystick = DateTime.Now;
                //         }
                //     }
                // }
            }
            catch (System.Exception eee)
            {
                System.Diagnostics.Debug.WriteLine("Timer error: " + eee.ToString());
            }
        }

        public Point GetLowerPanelLocation()
        {
            return panel2.Location;
        }

        public void SubscribeOnWpChange()
        {
            comPort.MAV.cs.WpNoValueChanged += CheckWpChangedToDoParachute;
        }

        public void UnsubscribeOnWpChange()
        {
            comPort.MAV.cs.WpNoValueChanged -= CheckWpChangedToDoParachute;
        }

        private void CheckWpChangedToDoParachute(object sender, ValueChangedEventArgs e)
        {
            cheatParachuteLandingTrigger();
        }

        private bool IsDoParachutePointPassed()
        {
            int doParachuteIndex = 0;
            foreach (DataGridViewRow row in FlightPlanner.Commands.Rows)
            {
                var cmd = (ushort) Enum.Parse(typeof(MAVLink.MAV_CMD),
                    row.Cells[FlightPlanner.Command.Index].Value.ToString(), false);
                if (cmd == (ushort) MAVLink.MAV_CMD.DO_PARACHUTE)
                {
                    doParachuteIndex = row.Index;
                    break;
                }
            }

            if (doParachuteIndex == 0)
            {
                return false;
            }

            return (int) comPort.MAV.cs.wpno >= doParachuteIndex;
        }

        public bool SitlReachedParachutePoint = false;

        private void cheatParachuteLandingTrigger()
        {
            if (comPort.MAV.cs.connected)
            {
                // if ((int) comPort.MAV.cs.wpno + 1 >= FlightPlanner.Commands.Rows.Count)
                // {
                //     return;
                // }

                // bool nextPointIsDoParachute = false;
                // ushort cmd = (ushort) Enum.Parse(typeof(MAVLink.MAV_CMD),
                // FlightPlanner.Commands.Rows[(int) comPort.MAV.cs.wpno].Cells[FlightPlanner.Command.Index].Value
                // .ToString(), false);
                // nextPointIsDoParachute = cmd == (ushort) MAVLink.MAV_CMD.DO_PARACHUTE;

                // if (comPort.MAV.cs.wp_dist < 70 && IsDoParachutePointPassed() && CurrentAircraft.UsingSitl && !_parachutePointReached)
                if (comPort.MAV.cs.wp_dist < 70 && IsDoParachutePointPassed() && CurrentAircraft.UsingSitl &&
                    CurrentAircraft.UsingSitl &&
                    !SitlReachedParachutePoint)
                {
                    // comPort.setMode("LAND");
                    SitlReachedParachutePoint = true;
                    IsSitlLanding = true;
                    FlightPlanner.landPoint = new PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng);
                    snsControl2.Invoke((MethodInvoker) delegate() { snsControl2.openParachuteForm(); });
                }
            }
        }

        public static string FormatDistance(double distInKM, bool toMeterOrFeet)
        {
            string sunits = Settings.Instance["distunits"];
            distances units = distances.Meters;

            if (sunits != null)
                try
                {
                    units = (distances) Enum.Parse(typeof(distances), sunits);
                }
                catch (Exception)
                {
                }

            switch (units)
            {
                case distances.Feet:
                    return toMeterOrFeet
                        ? string.Format((distInKM * 3280.8399).ToString("0.00 ft"))
                        : string.Format((distInKM * 0.621371).ToString("0.0000 miles"));
                case distances.Meters:
                default:
                    return toMeterOrFeet
                        ? string.Format((distInKM * 1000).ToString("0.00 m"))
                        : string.Format(distInKM.ToString("0.0000 km"));
            }
        }

        void mainMenuInit()

        {
            FlightPlanner.mainMenuWidget1.MapChoiseButton.Click += new EventHandler(mapChoiceButtonClick);
            FlightPlanner.mainMenuWidget1.ParamsButton.Click += new EventHandler(paramsButtonClick);
            FlightPlanner.mainMenuWidget1.EKFButton.Click += new EventHandler(diagnosticButtonClick);
            FlightPlanner.mainMenuWidget1.RulerButton.Click += new EventHandler(rulerButtonsClick);
            FlightPlanner.mainMenuWidget1.homeButton.Click += new EventHandler(homeButtonClick);
            FlightPlanner.mainMenuWidget1.centeringButton.MouseDown += new MouseEventHandler(centeringButtonClick);
            FlightPlanner.mainMenuWidget1.ParamsButton.Click += new EventHandler(paramsButtonClick);
            FlightPlanner.mainMenuWidget1.RulerButton.Click += new EventHandler(rulerButtonsClick);
            engineController = new EngineController();
            timer1.Start();
            FlightPlanner.mainMenuWidget1.Parent = FlightPlanner.MainMap;
            //FlightPlanner.mainMenuWidget1.MapChoiseButton.Parent = FlightPlanner.MainMap;
            FlightPlanner.wpMenu1.Parent = FlightPlanner.MainMap;
            MakeRightSideMenuTransparent();
            /*FlightPlanner.wpMenu1.panel1.Parent = FlightPlanner.wpMenu1;
            FlightPlanner.wpMenu1.panel2.Parent = FlightPlanner.wpMenu1;
            FlightPlanner.wpMenu1.panel3.Parent = FlightPlanner.wpMenu1;
            FlightPlanner.wpMenu1.panel4.Parent = FlightPlanner.wpMenu1;
            FlightPlanner.wpMenu1.panel5.Parent = FlightPlanner.wpMenu1;
            FlightPlanner.wpMenu1.panel6.Parent = FlightPlanner.wpMenu1;
            */

            logger = new Logger();
            vibeData = new VibeData();
            Settings.Instance["loadwpsonconnect"] = false.ToString();
            //FlightPlanner.MainMap.OnPositionChanged += new EventHandler(mapChanged);
        }

        public static int selectedItem = 2;

        void mapChoiceButtonClick(object sender, EventArgs e)
        {
            FlightPlanner.mainMenuWidget1.setState(false);
            if (mapChangeForm != null)
            {
                mapChangeForm.Close();
            }

            mapChangeForm = new MapChangeForm();
            mapChangeForm.comboBoxMapType.ValueMember = "Name";

            List<GMapProvider> providers = GMapProviders.List;
            List<GMapProvider> filtredproviders = new List<GMapProvider>();
            int[] providersNumsToCopy = new int[] {11, 12, 13, 16, 17, 18, 19, 64, 65};
            foreach (int i in providersNumsToCopy)
            {
                filtredproviders.Add(providers[i]);
            }

            mapChangeForm.comboBoxMapType.DataSource = filtredproviders.ToArray();

            //mapChangeForm.comboBoxMapType.DataSource = GMapProviders.List.ToArray();
            mapChangeForm.comboBoxMapType.SelectedItem = FlightPlanner.MainMap.MapProvider;
            FlightPlanner.MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;
            FlightPlanner.MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;
            mapChangeForm.chk_grid.CheckedChanged += chk_grid_CheckedChanged;
            mapChangeForm.comboBoxMapType.SelectedValueChanged += comboBoxMapType_SelectedValueChanged;
            mapChangeForm.lbl_status.Text = mapTitleStatus;
            mapChangeForm.comboBoxMapType.SelectedItem = selectedItem;
            mapChangeForm.Show();
        }

        public void chk_grid_CheckedChanged(object sender, EventArgs e)
        {
            FlightPlanner.grid = mapChangeForm.chk_grid.Checked;
        }

        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            //MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = delegate
            {
                mapTitleStatus = "Status: loaded tiles";
                if (mapChangeForm != null)
                {
                    mapChangeForm.lbl_status.Text = mapTitleStatus;
                }

                //panelMenu.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";ti
                //textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}MB of {1:0.00}MB", MainMap.Manager.MemoryCacheSize, MainMap.Manager.MemoryCacheCapacity);
            };
            try
            {
                if (!IsDisposed && IsHandleCreated) BeginInvoke(m);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void MainMap_OnTileLoadStart()
        {
            MethodInvoker m = delegate
            {
                mapTitleStatus = "Status: loading tiles...";
                if (mapChangeForm != null)
                {
                    mapChangeForm.lbl_status.Text = mapTitleStatus;
                }
            };
            try
            {
                if (IsHandleCreated) BeginInvoke(m);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void comboBoxMapType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                // check if we are setting the initial state
                if (FlightPlanner.MainMap.MapProvider != GMapProviders.EmptyProvider &&
                    (GMapProvider) mapChangeForm.comboBoxMapType.SelectedItem == MapboxUser.Instance)
                {
                    var url = Settings.Instance["MapBoxURL", ""];
                    InputBox.Show("Enter MapBox Share URL", "Enter MapBox Share URL", ref url);
                    var match = Regex.Matches(url, @"\/styles\/[^\/]+\/([^\/]+)\/([^\/\.]+).*access_token=([^#&=]+)");
                    if (match != null)
                    {
                        MapboxUser.Instance.UserName = match[0].Groups[1].Value;
                        MapboxUser.Instance.StyleId = match[0].Groups[2].Value;
                        MapboxUser.Instance.MapKey = match[0].Groups[3].Value;
                        Settings.Instance["MapBoxURL"] = url;
                    }
                    else
                    {
                        CustomMessageBox.Show(Strings.InvalidField, Strings.ERROR);
                        return;
                    }
                }

                FlightPlanner.MainMap.MapProvider = (GMapProvider) mapChangeForm.comboBoxMapType.SelectedItem;
                //FlightData.mymap.MapProvider = (GMapProvider)mapChangeForm.comboBoxMapType.SelectedItem;
                Settings.Instance["MapType"] = mapChangeForm.comboBoxMapType.Text;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                CustomMessageBox.Show("Map change failed. try zooming out first.");
            }
        }

        void paramsButtonClick(object sender, EventArgs e)
        {
            MyView.ShowScreen("HWConfig");
        }

        void diagnosticButtonClick(object sender, EventArgs e)
        {
            diagnosticForm = new DiagnosticForm();
            diagnosticForm.myButton1.Click += new EventHandler(firstButtonClick);
            diagnosticForm.Show();
        }

        ////////////////////////////diagnostic form onClick start

        void firstButtonClick(object sender, EventArgs e)
        {
        }


        ////////////////////////////diagnostic form onClick end
        void rulerButtonsClick(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("HERE");
        }

        void homeButtonClick(object sender, EventArgs e)
        {
            // try
            // {
            //     ((Control) sender).Enabled = false;
            //     MainV2.comPort.setMode("RTL");
            // }
            // catch
            // {
            //     CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            // }
            //
            // ((Control) sender).Enabled = true;
            
            FlightPlanner.MainMap.Position =
                new GMap.NET.PointLatLng(FlightPlanner.pointlist[0].Lat, FlightPlanner.pointlist[0].Lng);
        }

        public void setLandWpInSitl()
        {
            DataGridViewRow row =
                (DataGridViewRow) FlightPlanner.Commands.Rows[FlightPlanner.Commands.Rows.Count - 1].Clone();
            row.Cells[FlightPlanner.Command.Index].Value = MAVLink.MAV_CMD.LAND.ToString();
            row.Cells[FlightPlanner.Command.Index + 1].Value = (14).ToString();
            int v = 100;
            row.Cells[FlightPlanner.Lat.Index].Value = FlightPlanner.landPoint.Lat.ToString();
            row.Cells[FlightPlanner.Lon.Index].Value = FlightPlanner.landPoint.Lng.ToString();
            row.Cells[FlightPlanner.Lon.Index + 1].Value = v.ToString();
            FlightPlanner.Commands.Rows.Add(row);
            FlightPlanner.writeKML();
            Thread.Sleep(50);
            FlightPlanner.tryToWriteWP();
            Thread.Sleep(50);
            FlightPlanner.GoToThisPoint(FlightPlanner.Commands.Rows.Count - 1);
            Thread.Sleep(50);
            FlightPlanner.tagForContextMenu = null;
        }

        void centeringButtonClick(object sender, MouseEventArgs e)
        {
            if (!IsSitlLanding)
            {
                FlightPlanner.MainMap.Position = new GMap.NET.PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng);
            }
            else
            {
                FlightPlanner.MainMap.Position =
                    new GMap.NET.PointLatLng(FlightPlanner.landPoint.Lat, FlightPlanner.landPoint.Lng);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (centering != 1)
                {
                    centering = 1;
                    FlightPlanner.mainMenuWidget1.centeringButton.BackColor = Color.Red;
                }
                else
                {
                    centering = 0;
                    FlightPlanner.mainMenuWidget1.centeringButton.BackColor = Color.Transparent;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                centering = 0;
                FlightPlanner.mainMenuWidget1.centeringButton.BackColor = Color.Transparent;
            }
        }

        private void tryToLoadFuelData(int id)
        {
            float[] values = new float[] {0, 0, 0};
            if (File.Exists(MainV2.defaultFuelSavePath + "_" + id.ToString() + ".txt"))
            {
                try
                {
                    StreamReader stream = new StreamReader(MainV2.defaultFuelSavePath + "_" + id.ToString() + ".txt");
                    for (int i = 0; i < 3; i++)
                    {
                        values[i] = float.Parse(stream.ReadLine());
                    }

                    MainV2.CurrentAircraft.MinCapacity =
                        float.Parse(values[0].ToString()); //double.TryParse(minCapacity.Text, out i) ? i : 0;
                    MainV2.CurrentAircraft.MaxCapacity =
                        float.Parse(values[1].ToString()); //double.TryParse(maxСapacity.Text, out i) ? i : 0;
                    MainV2.CurrentAircraft.FuelPerTime =
                        float.Parse(values[1].ToString()); //double.TryParse(flightTimeTBox.Text, out i) ? i : 0;
                    StatusControlPanel.instance.SetFuelPbMinMax();
                }
                catch
                {
                }
            }
        }

        bool soundFlag = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            alarmLabelTextCheck();
            if (centering > 0)
            {
                if (!IsSitlLanding)
                {
                    FlightPlanner.MainMap.Position = new GMap.NET.PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng);
                }
                else
                {
                    FlightPlanner.MainMap.Position =
                        new GMap.NET.PointLatLng(FlightPlanner.landPoint.Lat, FlightPlanner.landPoint.Lng);
                    if (comPort.MAV.cs.wpno != FlightPlanner.landWP)
                    {
                        MainV2.setCurrentWP((ushort) FlightPlanner.landWP);
                    }
                }
            }

            if (comPort.MAV.param.TotalReceived < comPort.MAV.param.TotalReported)
            {
                if (comPort.MAV.param.TotalReported > 0 && comPort.BaseStream.IsOpen)
                    instance.status1.Percent =
                        (comPort.MAV.param.TotalReceived / (double) comPort.MAV.param.TotalReported) * 100.0;
            }

            if (comPort.MAV.param.TotalReceived < comPort.MAV.param.TotalReported)
            {
                soundFlag = true;
                progressBar1.Maximum = progressBar2.Maximum = comPort.MAV.param.TotalReported;
                progressBar1.Value = progressBar2.Value = comPort.MAV.param.TotalReceived;
            }
            else
            {
                if (comPort.MAV.cs.connected)
                {
                    progressBar2.Value = progressBar2.Maximum;
                    progressBar1.Value = progressBar1.Maximum;
                    if (soundFlag)
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                        if (File.Exists("D:\\test.wav"))
                        {
                            player.SoundLocation = "E:\\test.wav";
                            player.Play();
                        }

                        try
                        {
                            MissionPlanner.AircraftConnectionInfo info;
                            if (MainV2.Aircrafts.TryGetValue(MainV2.CurrentAircraftNum, out info))
                            {
                                MissionPlanner.Controls.ConnectionControl.port_sysid port_Sysid =
                                    (MissionPlanner.Controls.ConnectionControl.port_sysid) info.SysId;
                                int id = port_Sysid.sysid;
                                tryToLoadFuelData(id);
                            }

                            soundFlag = !soundFlag;
                        }
                        catch
                        {
                        }

                        //FlightPlanner.getWPFromPlane();
                    }
                }
                else
                {
                    progressBar1.Maximum = 100;
                    progressBar1.Value = 5;
                    progressBar2.Maximum = 100;
                    progressBar2.Value = 5;
                }
            }
            //_aircraftMenuControl.updateCentralButton();

            AircraftMenuControl.updateCentralButton();
            if (FlightPlanner.MainMap.Size.Width != 1920)
            {
                FlightPlanner.MainMap.Size = new Size(1920, FlightPlanner.MainMap.Size.Height);
            }
        }

        public static List<string> notifications = new List<string>();
        public static List<string> warnings = new List<string>();
        private string prevMode = "";

        void alarmLabelTextCheck()
        {
            bool isPlane = _currentAircraftNum != null && Aircrafts[_currentAircraftNum] != null;
            bool isSitl = _currentAircraftNum != null && Aircrafts[_currentAircraftNum] != null &&
                          !Aircrafts[_currentAircraftNum].UsingSitl;
            warnings = new List<string>();
            notifications = new List<string>();
            if (MainV2.comPort.MAV.cs.connected && isPlane)
            {
                if (!MainV2.comPort.MAV.cs.sensors_health.gps && MainV2.comPort.MAV.cs.sensors_enabled.gps &&
                    MainV2.comPort.MAV.cs.sensors_present.gps) //BadGPSHealth
                {
                    warnings.Add("Плохой сигнал GPS");
                }

                if (!MainV2.comPort.MAV.cs.sensors_health.gyro && MainV2.comPort.MAV.cs.sensors_enabled.gyro &&
                    MainV2.comPort.MAV.cs.sensors_present.gyro) //BadGyroHealth
                {
                    warnings.Add("Отказ гироскопов");
                }

                if (!MainV2.comPort.MAV.cs.sensors_health.barometer &&
                    MainV2.comPort.MAV.cs.sensors_enabled.barometer &&
                    MainV2.comPort.MAV.cs.sensors_present.barometer) //BadBaroHealth
                {
                    warnings.Add("Ошибка барометра");
                }

                if (!MainV2.comPort.MAV.cs.sensors_health.ahrs && MainV2.comPort.MAV.cs.sensors_enabled.ahrs &&
                    MainV2.comPort.MAV.cs.sensors_present.ahrs) //BadAHRS
                {
                    warnings.Add("Ошибка ИНС");
                }

                if (!MainV2.comPort.MAV.cs.sensors_health.compass && MainV2.comPort.MAV.cs.sensors_enabled.compass &&
                    MainV2.comPort.MAV.cs.sensors_present.compass)
                {
                    warnings.Add("Отказ компаса");
                }

                if (MainV2.comPort.MAV.cs.ekfcompv > 1)
                {
                    warnings.Add("Рассогласование компаса");
                }

                if (MainV2.comPort.MAV.cs.ekfvelv > 1)
                {
                    warnings.Add("Рассогласование скорости");
                }

                if (MainV2.comPort.MAV.cs.battery_voltage < 11)
                {
                    warnings.Add("Низкое напряжение, отказ генератора");
                }

                if (MainV2.comPort.MAV.cs.rpm2 > 118 && !isSitl || StatusControlPanel.IsSitlConnected() &&
                    _currentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName.Temperature) > 118)
                {
                    warnings.Add("Перегрев двигателя");
                }

                if (MainV2.comPort.MAV.cs.rpm1 > 8600 && !isSitl || StatusControlPanel.IsSitlConnected() &&
                    _currentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName.Rpm) > 8600)
                {
                    warnings.Add("Превышение оборотов двигателя");
                }

                if (StatusControlPanel.IsSitlConnected())
                {
                    if (_currentAircraft.SitlInfo.ParamList.GetParamValue(SitlParam.ParameterName.Rpm) < 3000)
                    {
                        warnings.Add("Двигатель заглох");
                    }
                }
                else
                {
                    if (MainV2.comPort.MAV.cs.rpm1 < 3000 && !isSitl)
                    {
                        warnings.Add("Двигатель заглох");
                    }
                }
                if (prevMode != MainV2.comPort.MAV.cs.mode)
                {
                    prevMode = MainV2.comPort.MAV.cs.mode;
                    currentEngineMode = 3;
                    if (StatusControlPanel != null && StatusControlPanel.EngineControlForm != null)
                    {
                        StatusControlPanel.EngineControlForm.setEngineMode();
                        StatusControlPanel.EngineControlForm.updateButtons(currentEngineMode);
                     }
                }
                if (MainV2.comPort.MAV.cs.mode != "Auto")
                {
                    notifications.Add("Режим изменен на " + MainV2.comPort.MAV.cs.mode);
                }

                try
                {
                    if (comPort.MAV.cs.battery_voltage2 /
                        (CurrentAircraft.MaxCapacity - CurrentAircraft.MinCapacity) <
                        StatusControlPanel._fuelCriticalPercentage / 100 && !StatusControlPanel.IsSitlConnected() ||
                        StatusControlPanel.IsSitlConnected() &&
                        _currentAircraft.Fuel /
                        (CurrentAircraft.MaxCapacity - CurrentAircraft.MinCapacity) <
                        StatusControlPanel._fuelCriticalPercentage / 100) //check in persents
                    {
                        warnings.Add("Малый остаток топлива");
                    }
                }
                catch (Exception e)
                {
                }

                if (ParachuteReleased || StatusControlPanel.IsSitlConnected() && _isSitlLanding)
                {
                    notifications.Add("Парашют выпущен");
                }

                if (comPort.MAV.cs.linkqualitygcs < 45)
                {
                    warnings.Add("Низкий уровень радиосигнала");
                }

                foreach (var v in warnings)
                {
                    logger.write(v);
                }

                foreach (var v in notifications)
                {
                    logger.write(v);
                }

                if (warnings.Count > 0 /*&& MainV2.AircraftInfo[MainV2.CurrentAircraftNum].inAir*/)
                {
                    label1.BackColor = Color.DarkRed;
                    progressBar1.ValueColor = Color.Red;
                    progressBar2.ValueColor = Color.Red;
                    label1.Text = "ОШИБКИ (" + warnings.Count.ToString() + ")";
                    label1.ForeColor = Color.White;
                }
                else
                {
                    if (progressBar1.ValueColor != Color.Lime)
                    {
                        label1.ForeColor = Color.Black;
                        progressBar1.ValueColor = Color.Lime;
                        progressBar2.ValueColor = Color.Lime;
                    }

                    label1.BackColor = Color.Lime;
                    if (notifications.Count == 0)
                    {
                        label1.Text = "";
                    }
                    else
                    {
                        label1.Text =
                            notifications
                                [notifications.Count - 1]; //parachute released is more important message than rtl
                    }
                }
            }
            else
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    warnings.Add("Тест: что-то пошло не так, проверьте, отключен ли дебаг");
                //}
            }
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////
        /// </summary>
        void adsb_UpdatePlanePosition(object sender, adsb.PointLatLngAltHdg adsb)
        {
            //System.Diagnostics.Debug.WriteLine("LOOOOOOOOOOOOOOOp");
            lock (adsblock)
            {
                var id = adsb.Tag;

                if (MainV2.instance.adsbPlanes.ContainsKey(id))
                {
                    // update existing
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Lat = adsb.Lat;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Lng = adsb.Lng;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Alt = adsb.Alt;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Heading = adsb.Heading;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Time = DateTime.Now;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).CallSign = adsb.CallSign;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Squawk = adsb.Squawk;
                    ((adsb.PointLatLngAltHdg) instance.adsbPlanes[id]).Raw = adsb.Raw;

                    if (centering > 0)
                    {
                        FlightPlanner.MainMap.Position =
                            new GMap.NET.PointLatLng(comPort.MAV.cs.lat, comPort.MAV.cs.lng);
                    }
                }
                else
                {
                    // create new plane
                    MainV2.instance.adsbPlanes[id] =
                        new adsb.PointLatLngAltHdg(adsb.Lat, adsb.Lng,
                                adsb.Alt, adsb.Heading, adsb.Speed, id,
                                DateTime.Now)
                            {CallSign = adsb.CallSign, Squawk = adsb.Squawk, Raw = adsb.Raw};
                }

                try
                {
                    // dont rebroadcast something that came from the drone
                    if (sender != null && sender is MAVLinkInterface)
                        return;

                    MAVLink.mavlink_adsb_vehicle_t packet = new MAVLink.mavlink_adsb_vehicle_t();

                    packet.altitude = (int) (MainV2.instance.adsbPlanes[id].Alt * 1000);
                    packet.altitude_type = (byte) MAVLink.ADSB_ALTITUDE_TYPE.GEOMETRIC;
                    packet.callsign = adsb.CallSign.MakeBytes();
                    packet.squawk = adsb.Squawk;
                    packet.emitter_type = (byte) MAVLink.ADSB_EMITTER_TYPE.NO_INFO;
                    packet.heading = (ushort) (MainV2.instance.adsbPlanes[id].Heading * 100);
                    packet.lat = (int) (MainV2.instance.adsbPlanes[id].Lat * 1e7);
                    packet.lon = (int) (MainV2.instance.adsbPlanes[id].Lng * 1e7);
                    packet.ICAO_address = UInt32.Parse(id, NumberStyles.HexNumber);

                    packet.flags = (ushort) (MAVLink.ADSB_FLAGS.VALID_ALTITUDE | MAVLink.ADSB_FLAGS.VALID_COORDS |
                                             MAVLink.ADSB_FLAGS.VALID_HEADING | MAVLink.ADSB_FLAGS.VALID_CALLSIGN);

                    //send to current connected
                    MainV2.comPort.sendPacket(packet, MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid);
                }
                catch
                {
                }
            }
        }


        private void ResetConnectionStats()
        {
            log.Info("Reset connection stats");
            // If the form has been closed, or never shown before, we need do nothing, as 
            // connection stats will be reset when shown
            if (this.connectionStatsForm != null && connectionStatsForm.Visible)
            {
                // else the form is already showing.  reset the stats
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(comPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                ThemeManager.ApplyThemeTo(this.connectionStatsForm);
            }
        }

        private void ShowConnectionStatsForm()
        {
            if (this.connectionStatsForm == null || this.connectionStatsForm.IsDisposed)
            {
                // If the form has been closed, or never shown before, we need all new stuff
                this.connectionStatsForm = new Form
                {
                    Width = 430,
                    Height = 180,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = Strings.LinkStats
                };
                // Change the connection stats control, so that when/if the connection stats form is showing,
                // there will be something to see
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(comPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                this.connectionStatsForm.Width = _connectionStats.Width;
            }

            this.connectionStatsForm.Show();
            ThemeManager.ApplyThemeTo(this.connectionStatsForm);
        }

        private void CMB_serialport_Click(object sender, EventArgs e)
        {
            string oldport = _connectionControl.CMB_serialport.Text;
            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Contains(oldport))
                _connectionControl.CMB_serialport.Text = oldport;
        }

        private void PopulateSerialportList()
        {
            _connectionControl.CMB_serialport.Items.Clear();
            _connectionControl.CMB_serialport.Items.Add("AUTO");
            _connectionControl.CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            _connectionControl.CMB_serialport.Items.Add("TCP");
            _connectionControl.CMB_serialport.Items.Add("UDP");
            _connectionControl.CMB_serialport.Items.Add("UDPCl");
            _connectionControl.CMB_serialport.Items.Add("WS");
        }

        private void MenuFlightData_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightData");
        }

        private void MenuFlightPlanner_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightPlanner");
            //MyView.ShowScreen("FlightPlannerNewWindow");
        }

        public void MenuSetup_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("HWConfig");
            }
            else
            {
                var pw = "";
                if (InputBox.Show("Enter Password", "Please enter your password", ref pw, true) ==
                    DialogResult.OK)
                {
                    bool ans = Password.ValidatePassword(pw);

                    if (ans == false)
                    {
                        CustomMessageBox.Show("Bad Password", "Bad Password");
                    }
                }

                if (Password.VerifyPassword(pw))
                {
                    MyView.ShowScreen("HWConfig");
                }
            }
        }


        public void MenuSimulation_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Simulation");
            Simulation.plane_click();
        }

        private void MenuTuning_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("SWConfig");
            }
            else
            {
                var pw = "";
                if (InputBox.Show("Enter Password", "Please enter your password", ref pw, true) ==
                    DialogResult.OK)
                {
                    bool ans = Password.ValidatePassword(pw);

                    if (ans == false)
                    {
                        CustomMessageBox.Show("Bad Password", "Bad Password");
                    }
                }

                if (Password.VerifyPassword(pw))
                {
                    MyView.ShowScreen("SWConfig");
                }
            }
        }

        private void MenuTerminal_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Terminal");
        }

        public void doDisconnect(MAVLinkInterface comPort)
        {
            log.Info("We are disconnecting");
            try
            {
                if (speechEngine != null) // cancel all pending speech
                    speechEngine.SpeakAsyncCancelAll();

                comPort.BaseStream.DtrEnable = false;
                comPort.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            // now that we have closed the connection, cancel the connection stats
            // so that the 'time connected' etc does not grow, but the user can still
            // look at the now frozen stats on the still open form
            try
            {
                // if terminal is used, then closed using this button.... exception
                if (this.connectionStatsForm != null)
                    ((ConnectionStats) this.connectionStatsForm.Controls[0]).StopUpdates();
            }
            catch
            {
            }

            // refresh config window if needed
            if (MyView.current != null)
            {
                if (MyView.current.Name == "HWConfig")
                    MyView.ShowScreen("HWConfig");
                if (MyView.current.Name == "SWConfig")
                    MyView.ShowScreen("SWConfig");
            }

            try
            {
                ThreadPool.QueueUserWorkItem((WaitCallback) delegate
                    {
                        try
                        {
                            LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                        }
                        catch
                        {
                        }
                    }
                );
            }
            catch
            {
            }

            this.MenuConnect.Image = Resources.light_connect_icon;
        }

        public void doConnect(MAVLinkInterface comPort, string portname, string baud, bool antennaConnecting = false,
            bool getparams = true)
        {
            bool skipconnectcheck = false;
            log.Info("We are connecting to " + portname + " " + baud);
            switch (portname)
            {
                case "preset":
                    skipconnectcheck = true;
                    if (comPort.BaseStream is TcpSerial)
                        _connectionControl.CMB_serialport.Text = "TCP";
                    if (comPort.BaseStream is UdpSerial)
                        _connectionControl.CMB_serialport.Text = "UDP";
                    if (comPort.BaseStream is UdpSerialConnect)
                        _connectionControl.CMB_serialport.Text = "UDPCl";
                    if (comPort.BaseStream is SerialPort)
                    {
                        _connectionControl.CMB_serialport.Text = comPort.BaseStream.PortName;
                        _connectionControl.CMB_baudrate.Text = comPort.BaseStream.BaudRate.ToString();
                    }

                    break;
                case "TCP":
                    comPort.BaseStream = new TcpSerial();
                    _connectionControl.CMB_serialport.Text = "TCP";
                    break;
                case "UDP":
                    comPort.BaseStream = new UdpSerial();
                    _connectionControl.CMB_serialport.Text = "UDP";
                    break;
                case "WS":
                    comPort.BaseStream = new WebSocket();
                    _connectionControl.CMB_serialport.Text = "WS";
                    break;
                case "UDPCl":
                    comPort.BaseStream = new UdpSerialConnect();
                    _connectionControl.CMB_serialport.Text = "UDPCl";
                    break;
                case "AUTO":
                    // do autoscan
                    CommsSerialScan.Scan(true);
                    DateTime deadline = DateTime.Now.AddSeconds(50);
                    while (CommsSerialScan.foundport == false || CommsSerialScan.run == 1)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("wait for port " + CommsSerialScan.foundport + " or " + CommsSerialScan.run);
                        if (DateTime.Now > deadline)
                        {
                            CustomMessageBox.Show(Strings.Timeout);
                            _connectionControl.IsConnected(false);
                            return;
                        }
                    }

                    return;
                default:
                    comPort.BaseStream = new SerialPort();
                    break;
            }

            // Tell the connection UI that we are now connected.
            _connectionControl.IsConnected(true);

            // Here we want to reset the connection stats counter etc.
            this.ResetConnectionStats();

            comPort.MAV.cs.ResetInternals();

            //cleanup any log being played
            comPort.logreadmode = false;
            if (comPort.logplaybackfile != null)
                comPort.logplaybackfile.Close();
            comPort.logplaybackfile = null;

            try
            {
                log.Info("Set Portname");
                // set port, then options
                if (portname.ToLower() != "preset")
                    comPort.BaseStream.PortName = portname;

                log.Info("Set Baudrate");
                try
                {
                    if (baud != "" && baud != "0")
                        comPort.BaseStream.BaudRate = Int32.Parse(baud);
                }
                catch (Exception exp)
                {
                    log.Error(exp);
                }

                // prevent serialreader from doing anything
                comPort.giveComport = true;

                log.Info("About to do dtr if needed");
                // reset on connect logic.
                if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
                {
                    log.Info("set dtr rts to false");
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR();
                }

                comPort.giveComport = false;

                // setup to record new logs
                try
                {
                    Directory.CreateDirectory(Settings.Instance.LogDir);
                    lock (this)
                    {
                        // create log names
                        var dt = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                        var tlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".tlog";
                        var rlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".rlog";

                        // check if this logname already exists
                        int a = 1;
                        while (File.Exists(tlog))
                        {
                            Thread.Sleep(1000);
                            // create new names with a as an index
                            dt = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "-" + a.ToString();
                            tlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".tlog";
                            rlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                   dt + ".rlog";
                        }

                        //open the logs for writing
                        comPort.logfile =
                            new BufferedStream(
                                File.Open(tlog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None));
                        comPort.rawlogfile =
                            new BufferedStream(
                                File.Open(rlog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None));
                        log.Info("creating logfile " + dt + ".tlog");
                    }
                }
                catch (Exception exp2)
                {
                    log.Error(exp2);
                    CustomMessageBox.Show(Strings.Failclog);
                } // soft fail

                // reset connect time - for timeout functions
                connecttime = DateTime.Now;

                // do the connect
                comPort.Open(false, skipconnectcheck);

                if (!comPort.BaseStream.IsOpen)
                {
                    log.Info("comport is closed. existing connect");
                    try
                    {
                        _connectionControl.IsConnected(false);
                        UpdateConnectIcon();
                        comPort.Close();
                    }
                    catch
                    {
                    }

                    return;
                }

                if (getparams)
                {
                    var ftpfile = false;
                    if ((MainV2.comPort.MAV.cs.capabilities & (int) MAVLink.MAV_PROTOCOL_CAPABILITY.FTP) > 0)
                    {
                        var prd = new ProgressReporterDialogue();
                        prd.DoWork += (IProgressReporterDialogue sender) =>
                        {
                            sender.UpdateProgressAndStatus(-1, "Checking for Param MAVFTP");
                            var cancel = new CancellationTokenSource();
                            var paramfileTask = Task.Run<MemoryStream>(() =>
                            {
                                return new MAVFtp(comPort, comPort.MAV.sysid, comPort.MAV.compid).GetFile(
                                    "@PARAM/param.pck", cancel, false, 110);
                            });
                            while (!paramfileTask.IsCompleted)
                            {
                                if (sender.doWorkArgs.CancelRequested)
                                {
                                    cancel.Cancel();
                                    sender.doWorkArgs.CancelAcknowledged = true;
                                }
                            }

                            var paramfile = paramfileTask.Result;
                            if (paramfile != null && paramfile.Length > 0)
                            {
                                var mavlist = parampck.unpack(paramfile.GetBuffer());
                                if (mavlist != null)
                                {
                                    comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param.Clear();
                                    comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param.TotalReported =
                                        mavlist.Count;
                                    comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param.AddRange(mavlist);
                                    var gen = new MAVLink.MavlinkParse();
                                    mavlist.ForEach(a =>
                                    {
                                        comPort.MAVlist[comPort.MAV.sysid, comPort.MAV.compid].param_types[a.Name] =
                                            a.Type;
                                        MainV2.comPort.SaveToTlog(gen.GenerateMAVLinkPacket10(
                                            MAVLink.MAVLINK_MSG_ID.PARAM_VALUE,
                                            new MAVLink.mavlink_param_value_t(a.float_value, (ushort) mavlist.Count, 0,
                                                a.Name.MakeBytesSize(16), (byte) a.Type)));
                                    });

                                    ftpfile = true;
                                    MAVLinkInterface.paramsLoading = false;
                                }
                            }
                        };

                        prd.RunBackgroundOperationAsync();
                    }

                    if (!ftpfile)
                    {
                        // if (Settings.Instance.GetBoolean("Params_BG", false))
                        Task.Run(() => { comPort.getParamList(comPort.MAV.sysid, comPort.MAV.compid); });
                        // else
                        // comPort.getParamList();
                    }
                }

                _connectionControl.UpdateSysIDS();

                // check for newer firmware
                var softwares = Firmware.LoadSoftwares();

                if (softwares.Count > 0)
                {
                    try
                    {
                        string[] fields1 = comPort.MAV.VersionString.Split(' ');

                        foreach (Firmware.software item in softwares)
                        {
                            string[] fields2 = item.name.Split(' ');

                            // check primare firmware type. ie arudplane, arducopter
                            if (fields1[0] == fields2[0])
                            {
                                Version ver1 = VersionDetection.GetVersion(comPort.MAV.VersionString);
                                Version ver2 = VersionDetection.GetVersion(item.name);

                                if (ver2 > ver1)
                                {
                                    // Common.MessageShowAgain(Strings.NewFirmware + "-" + item.name,
                                    //     Strings.NewFirmwareA + item.name + Strings.Pleaseup +
                                    //     "[link;https://discuss.ardupilot.org/tags/stable-release;Release Notes]");
                                    break;
                                }

                                // check the first hit only
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }

                FlightData.CheckBatteryShow();

                // save the baudrate for this port
                Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] =
                    _connectionControl.CMB_baudrate.Text;

                this.Text = titlebar + " " + comPort.MAV.VersionString;

                // refresh config window if needed
                if (MyView.current != null)
                {
                    if (MyView.current.Name == "HWConfig")
                        MyView.ShowScreen("HWConfig");
                    if (MyView.current.Name == "SWConfig")
                        MyView.ShowScreen("SWConfig");
                }

                // load wps on connect option.
                if (Settings.Instance.GetBoolean("loadwpsonconnect") == true)
                {
                    // only do it if we are connected.
                    if (comPort.BaseStream.IsOpen)
                    {
                        MenuFlightPlanner_Click(null, null);
                        FlightPlanner.BUT_read_Click(null, null);
                    }
                }

                // get any rallypoints
                if (MainV2.comPort.MAV.param.ContainsKey("RALLY_TOTAL") &&
                    Int32.Parse(MainV2.comPort.MAV.param["RALLY_TOTAL"].ToString()) > 0)
                {
                    try
                    {
                        FlightPlanner.getRallyPointsToolStripMenuItem_Click(null, null);

                        double maxdist = 0;

                        foreach (var rally in comPort.MAV.rallypoints)
                        {
                            foreach (var rally1 in comPort.MAV.rallypoints)
                            {
                                var pnt1 = new PointLatLngAlt(rally.Value.y / 10000000.0f, rally.Value.x / 10000000.0f);
                                var pnt2 = new PointLatLngAlt(rally1.Value.y / 10000000.0f,
                                    rally1.Value.x / 10000000.0f);

                                var dist = pnt1.GetDistance(pnt2);

                                maxdist = Math.Max(maxdist, dist);
                            }
                        }

                        if (comPort.MAV.param.ContainsKey("RALLY_LIMIT_KM") &&
                            (maxdist / 1000.0) > (float) comPort.MAV.param["RALLY_LIMIT_KM"])
                        {
                            CustomMessageBox.Show(Strings.Warningrallypointdistance + " " +
                                                  (maxdist / 1000.0).ToString("0.00") + " > " +
                                                  (float) comPort.MAV.param["RALLY_LIMIT_KM"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Warn(ex);
                    }
                }

                // get any fences
                if (MainV2.comPort.MAV.param.ContainsKey("FENCE_TOTAL") &&
                    Int32.Parse(MainV2.comPort.MAV.param["FENCE_TOTAL"].ToString()) > 1 &&
                    MainV2.comPort.MAV.param.ContainsKey("FENCE_ACTION"))
                {
                    try
                    {
                        FlightPlanner.GeoFencedownloadToolStripMenuItem_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        log.Warn(ex);
                    }
                }

                //Add HUD custom items source 
                HUD.Custom.src = MainV2.comPort.MAV.cs;

                // set connected icon
                this.MenuConnect.Image = displayicons.disconnect;
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                try
                {
                    _connectionControl.IsConnected(false);
                    UpdateConnectIcon();
                    comPort.Close();
                }
                catch (Exception ex2)
                {
                    log.Warn(ex2);
                }

                CustomMessageBox.Show("Can not establish a connection\n\n" + ex.Message);
                return;
            }
        }

        private void MenuConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            comPort.giveComport = false;

            log.Info("MenuConnect Start");

            // sanity check
            if (comPort.BaseStream.IsOpen && comPort.MAV.cs.groundspeed > 4)
            {
                if ((int) DialogResult.No ==
                    CustomMessageBox.Show(Strings.Stillmoving, Strings.Disconnect, MessageBoxButtons.YesNo))
                {
                    return;
                }
            }

            try
            {
                log.Info("Cleanup last logfiles");
                // cleanup from any previous sessions
                if (comPort.logfile != null)
                    comPort.logfile.Close();

                if (comPort.rawlogfile != null)
                    comPort.rawlogfile.Close();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Strings.ErrorClosingLogFile + ex.Message, Strings.ERROR);
            }

            comPort.logfile = null;
            comPort.rawlogfile = null;

            // decide if this is a connect or disconnect
            if (comPort.BaseStream.IsOpen)
            {
                doDisconnect(comPort);
            }
            else
            {
                doConnect(comPort, _connectionControl.CMB_serialport.Text, _connectionControl.CMB_baudrate.Text);
            }

            _connectionControl.UpdateSysIDS();

            if (comPort.BaseStream.IsOpen)
                loadph_serial();
        }


        public void loadph_serial()
        {
            try
            {
                if (comPort.MAV.SerialString == "")
                    return;

                if (comPort.MAV.SerialString.Contains("CubeBlack") &&
                    !comPort.MAV.SerialString.Contains("CubeBlack+") &&
                    comPort.MAV.param.ContainsKey("INS_ACC3_ID") && comPort.MAV.param["INS_ACC3_ID"].Value == 0 &&
                    comPort.MAV.param.ContainsKey("INS_GYR3_ID") && comPort.MAV.param["INS_GYR3_ID"].Value == 0 &&
                    comPort.MAV.param.ContainsKey("INS_ENABLE_MASK") && comPort.MAV.param["INS_ENABLE_MASK"].Value >= 7)
                {
                    SB.Show("Param Scan");
                }
            }
            catch
            {
            }

            try
            {
                if (comPort.MAV.SerialString == "")
                    return;

                // brd type should be 3
                // devids show which sensor is not detected
                // baro does not list a devid

                //devop read spi lsm9ds0_ext_am 0 0 0x8f 1
                if (comPort.MAV.SerialString.Contains("CubeBlack") && !comPort.MAV.SerialString.Contains("CubeBlack+"))
                {
                    Task.Run(() =>
                    {
                        bool bad1 = false;
                        byte[] data = new byte[0];

                        comPort.device_op(comPort.MAV.sysid, comPort.MAV.compid, out data,
                            MAVLink.DEVICE_OP_BUSTYPE.SPI,
                            "lsm9ds0_ext_g", 0, 0, 0x8f, 1);
                        if (data.Length != 0 && (data[0] != 0xd4 && data[0] != 0xd7))
                            bad1 = true;

                        comPort.device_op(comPort.MAV.sysid, comPort.MAV.compid, out data,
                            MAVLink.DEVICE_OP_BUSTYPE.SPI,
                            "lsm9ds0_ext_am", 0, 0, 0x8f, 1);
                        if (data.Length != 0 && data[0] != 0x49)
                            bad1 = true;

                        if (bad1)
                            this.BeginInvoke(method: (Action) delegate { SB.Show("SPI Scan"); });
                    });
                }
            }
            catch
            {
            }
        }

        private void CMB_serialport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectionControl.CMB_serialport.SelectedItem == _connectionControl.CMB_serialport.Text)
                return;

            comPortName = _connectionControl.CMB_serialport.Text;
            if (comPortName == "UDP" || comPortName == "UDPCl" || comPortName == "TCP" || comPortName == "AUTO")
            {
                _connectionControl.CMB_baudrate.Enabled = false;
            }
            else
            {
                _connectionControl.CMB_baudrate.Enabled = true;
            }

            try
            {
                // check for saved baud rate and restore
                if (Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] != null)
                {
                    _connectionControl.CMB_baudrate.Text =
                        Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"];
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// overriding the OnCLosing is a bit cleaner than handling the event, since it 
        /// is this object.
        /// 
        /// This happens before FormClosed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            CustomMessageBox.DialogResult dialogResult = CustomMessageBox.Show("Выйти из программы?", "НПУ",
                CustomMessageBox.MessageBoxButtons.YesNo,
                CustomMessageBox.MessageBoxIcon.None, "Да", "Нет");
            if (dialogResult == CustomMessageBox.DialogResult.No)
            {
                //do something
                e.Cancel = true;
            }
            else if (dialogResult == CustomMessageBox.DialogResult.Yes)
            {
                base.OnClosing(e);

                log.Info("MainV2_FormClosing");

                log.Info("GMaps write cache");
                // speed up tile saving on exit
                GMaps.Instance.CacheOnIdleRead = false;
                GMaps.Instance.BoostCacheEngine = true;

                Settings.Instance["MainHeight"] = this.Height.ToString();
                Settings.Instance["MainWidth"] = this.Width.ToString();
                Settings.Instance["MainMaximised"] = this.WindowState.ToString();

                Settings.Instance["MainLocX"] = this.Location.X.ToString();
                Settings.Instance["MainLocY"] = this.Location.Y.ToString();

                log.Info("close logs");


#if !LIB
                AltitudeAngel.Dispose();
#endif

                // close bases connection
                try
                {
                    comPort.logreadmode = false;
                    if (comPort.logfile != null)
                        comPort.logfile.Close();

                    if (comPort.rawlogfile != null)
                        comPort.rawlogfile.Close();

                    comPort.logfile = null;
                    comPort.rawlogfile = null;
                }
                catch
                {
                }

                log.Info("close ports");
                // close all connections
                foreach (var port in Comports)
                {
                    try
                    {
                        port.logreadmode = false;
                        if (port.logfile != null)
                            port.logfile.Close();

                        if (port.rawlogfile != null)
                            port.rawlogfile.Close();

                        port.logfile = null;
                        port.rawlogfile = null;
                    }
                    catch
                    {
                    }
                }

                log.Info("stop adsb");
                adsb.Stop();

                log.Info("stop WarningEngine");
                WarningEngine.Stop();

                log.Info("stop GStreamer");
                GStreamer.StopAll();

                log.Info("closing vlcrender");
                try
                {
                    while (vlcrender.store.Count > 0)
                        vlcrender.store[0].Stop();
                }
                catch
                {
                }

                log.Info("closing pluginthread");

                pluginthreadrun = false;

                if (pluginthread != null)
                    pluginthread.Join();

                log.Info("closing serialthread");

                serialThread = false;

                if (serialreaderthread != null)
                    serialreaderthread.Join();

                log.Info("closing joystickthread");

                joystickthreadrun = false;

                if (joystickthread != null)
                    joystickthread.Join();

                log.Info("closing httpthread");

                // if we are waiting on a socket we need to force an abort
                httpserver.Stop();

                log.Info("sorting tlogs");
                try
                {
                    ThreadPool.QueueUserWorkItem((WaitCallback) delegate
                        {
                            try
                            {
                                LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                            }
                            catch
                            {
                            }
                        }
                    );
                }
                catch
                {
                }

                log.Info("closing MyView");

                // close all tabs
                MyView.Dispose();

                log.Info("closing fd");
                try
                {
                    FlightData.Dispose();
                }
                catch
                {
                }

                log.Info("closing fp");
                try
                {
                    FlightPlanner.Dispose();
                }
                catch
                {
                }

                log.Info("closing sim");
                try
                {
                    Simulation.Dispose();
                }
                catch
                {
                }

                try
                {
                    if (comPort.BaseStream.IsOpen)
                        comPort.Close();
                }
                catch
                {
                } // i get alot of these errors, the port is still open, but not valid - user has unpluged usb

                // save config
                SaveConfig();

                Console.WriteLine(httpthread?.IsAlive);
                Console.WriteLine(joystickthread?.IsAlive);
                Console.WriteLine(serialreaderthread?.IsAlive);
                Console.WriteLine(pluginthread?.IsAlive);

                log.Info("MainV2_FormClosing done");

                if (MONO)
                    this.Dispose();
            }
        }


        /// <summary>
        /// this happens after FormClosing...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Console.WriteLine("MainV2_FormClosed");

            if (joystick != null)
            {
                while (!joysendThreadExited)
                    Thread.Sleep(10);

                joystick.Dispose(); //proper clean up of joystick.
            }
        }

        private void LoadConfig()
        {
            try
            {
                log.Info("Loading config");

                Settings.Instance.Load();

                comPortName = Settings.Instance.ComPort;
            }
            catch (Exception ex)
            {
                log.Error("Bad Config File", ex);
            }
        }

        private void SaveConfig()
        {
            try
            {
                log.Info("Saving config");
                Settings.Instance.ComPort = comPortName;

                if (_connectionControl != null)
                    Settings.Instance.BaudRate = _connectionControl.CMB_baudrate.Text;

                Settings.Instance.APMFirmware = MainV2.comPort.MAV.cs.firmware.ToString();

                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// needs to be true by default so that exits properly if no joystick used.
        /// </summary>
        volatile private bool joysendThreadExited = true;

        /// <summary>
        /// thread used to send joystick packets to the MAV
        /// </summary>
        private void joysticksend()
        {
            float rate = 50; // 1000 / 50 = 20 hz
            int count = 0;

            DateTime lastratechange = DateTime.Now;

            joystickthreadrun = true;

            while (joystickthreadrun)
            {
                joysendThreadExited = false;
                //so we know this thread is stil alive.           
                try
                {
                    if (MONO)
                    {
                        log.Error("Mono: closing joystick thread");
                        break;
                    }

                    if (!MONO)
                    {
                        //joystick stuff

                        if (joystick != null && joystick.enabled)
                        {
                            if (!joystick.manual_control)
                            {
                                MAVLink.mavlink_rc_channels_override_t
                                    rc = new MAVLink.mavlink_rc_channels_override_t();

                                rc.target_component = comPort.MAV.compid;
                                rc.target_system = comPort.MAV.sysid;

                                if (joystick.getJoystickAxis(1) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan1_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(2) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan2_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(3) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan3_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(4) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan4_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(5) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan5_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(6) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan6_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(7) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan7_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(8) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan8_raw = UInt16.MaxValue;
                                if (joystick.getJoystickAxis(9) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan9_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(10) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan10_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(11) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan11_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(12) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan12_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(13) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan13_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(14) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan14_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(15) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan15_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(16) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan16_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(17) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan17_raw = (ushort) 0;
                                if (joystick.getJoystickAxis(18) == Joystick.Joystick.joystickaxis.None)
                                    rc.chan18_raw = (ushort) 0;

                                if (joystick.getJoystickAxis(1) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan1_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech1;
                                if (joystick.getJoystickAxis(2) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan2_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech2;
                                if (joystick.getJoystickAxis(3) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan3_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech3;
                                if (joystick.getJoystickAxis(4) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan4_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech4;
                                if (joystick.getJoystickAxis(5) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan5_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech5;
                                if (joystick.getJoystickAxis(6) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan6_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech6;
                                if (joystick.getJoystickAxis(7) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan7_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech7;
                                if (joystick.getJoystickAxis(8) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan8_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech8;
                                if (joystick.getJoystickAxis(9) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan9_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech9;
                                if (joystick.getJoystickAxis(10) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan10_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech10;
                                if (joystick.getJoystickAxis(11) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan11_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech11;
                                if (joystick.getJoystickAxis(12) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan12_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech12;
                                if (joystick.getJoystickAxis(13) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan13_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech13;
                                if (joystick.getJoystickAxis(14) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan14_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech14;
                                if (joystick.getJoystickAxis(15) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan15_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech15;
                                if (joystick.getJoystickAxis(16) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan16_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech16;
                                if (joystick.getJoystickAxis(17) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan17_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech17;
                                if (joystick.getJoystickAxis(18) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan18_raw = (ushort) MainV2.comPort.MAV.cs.rcoverridech18;

                                if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                                {
                                    /*
                                if (MainV2.comPort.MAV.cs.rssi > 0 && MainV2.comPort.MAV.cs.remrssi > 0)
                                {
                                    if (lastratechange.Second != DateTime.Now.Second)
                                    {
                                        if (MainV2.comPort.MAV.cs.txbuffer > 90)
                                        {
                                            if (rate < 20)
                                                rate = 21;
                                            rate--;

                                            if (MainV2.comPort.MAV.cs.linkqualitygcs < 70)
                                                rate = 50;
                                        }
                                        else
                                        {
                                            if (rate > 100)
                                                rate = 100;
                                            rate++;
                                        }

                                        lastratechange = DateTime.Now;
                                    }
                                 
                                }
                                */
                                    //                                Console.WriteLine(DateTime.Now.Millisecond + " {0} {1} {2} {3} {4}", rc.chan1_raw, rc.chan2_raw, rc.chan3_raw, rc.chan4_raw,rate);

                                    //Console.WriteLine("Joystick btw " + comPort.BaseStream.BytesToWrite);

                                    if (!comPort.BaseStream.IsOpen)
                                        continue;

                                    if (comPort.BaseStream.BytesToWrite < 50)
                                    {
                                        if (sitl)
                                        {
                                            SITL.rcinput();
                                        }
                                        else
                                        {
                                            comPort.sendPacket(rc, rc.target_system, rc.target_component);
                                        }

                                        count++;
                                        lastjoystick = DateTime.Now;
                                    }
                                }
                            }
                            else
                            {
                                MAVLink.mavlink_manual_control_t rc = new MAVLink.mavlink_manual_control_t();

                                rc.target = comPort.MAV.compid;

                                if (joystick.getJoystickAxis(1) != Joystick.Joystick.joystickaxis.None)
                                    rc.x = MainV2.comPort.MAV.cs.rcoverridech1;
                                if (joystick.getJoystickAxis(2) != Joystick.Joystick.joystickaxis.None)
                                    rc.y = MainV2.comPort.MAV.cs.rcoverridech2;
                                if (joystick.getJoystickAxis(3) != Joystick.Joystick.joystickaxis.None)
                                    rc.z = MainV2.comPort.MAV.cs.rcoverridech3;
                                if (joystick.getJoystickAxis(4) != Joystick.Joystick.joystickaxis.None)
                                    rc.r = MainV2.comPort.MAV.cs.rcoverridech4;

                                if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                                {
                                    if (!comPort.BaseStream.IsOpen)
                                        continue;

                                    if (comPort.BaseStream.BytesToWrite < 50)
                                    {
                                        if (sitl)
                                        {
                                            SITL.rcinput();
                                        }
                                        else
                                        {
                                            comPort.sendPacket(rc, comPort.MAV.sysid, comPort.MAV.compid);
                                        }

                                        count++;
                                        lastjoystick = DateTime.Now;
                                    }
                                }
                            }
                        }
                    }

                    Thread.Sleep(20);
                }
                catch
                {
                } // cant fall out
            }

            joysendThreadExited = true; //so we know this thread exited.    
        }

        /// <summary>
        /// Used to fix the icon status for unexpected unplugs etc...
        /// </summary>
        private void UpdateConnectIcon()
        {
            if ((DateTime.Now - connectButtonUpdate).Milliseconds > 500)
            {
                //                        Console.WriteLine(DateTime.Now.Millisecond);
                if (comPort.BaseStream.IsOpen)
                {
                    if (this.MenuConnect.Image == null || (string) this.MenuConnect.Image.Tag != "Disconnect")
                    {
                        this.BeginInvoke((MethodInvoker) delegate
                        {
                            this.MenuConnect.Image = displayicons.disconnect;
                            this.MenuConnect.Image.Tag = "Disconnect";
                            this.MenuConnect.Text = Strings.DISCONNECTc;
                            _connectionControl.IsConnected(true);
                        });
                    }
                }
                else
                {
                    if (this.MenuConnect.Image != null && (string) this.MenuConnect.Image.Tag != "Connect")
                    {
                        this.BeginInvoke((MethodInvoker) delegate
                        {
                            this.MenuConnect.Image = displayicons.connect;
                            this.MenuConnect.Image.Tag = "Connect";
                            this.MenuConnect.Text = Strings.CONNECTc;
                            _connectionControl.IsConnected(false);
                            if (_connectionStats != null)
                            {
                                _connectionStats.StopUpdates();
                            }
                        });
                    }

                    if (comPort.logreadmode)
                    {
                        this.BeginInvoke((MethodInvoker) delegate { _connectionControl.IsConnected(true); });
                    }
                }

                connectButtonUpdate = DateTime.Now;
            }
        }

        ManualResetEvent PluginThreadrunner = new ManualResetEvent(false);

        private void PluginThread()
        {
            Hashtable nextrun = new Hashtable();

            pluginthreadrun = true;

            PluginThreadrunner.Reset();

            while (pluginthreadrun)
            {
                try
                {
                    foreach (var plugin in PluginLoader.Plugins.ToArray())
                    {
                        if (!nextrun.ContainsKey(plugin))
                            nextrun[plugin] = DateTime.MinValue;

                        if (DateTime.Now > plugin.NextRun)
                        {
                            // get ms till next run
                            int msnext = (int) (1000 / plugin.loopratehz);
                            // allow the plug to modify this, if needed
                            plugin.NextRun = DateTime.Now.AddMilliseconds(msnext);

                            try
                            {
                                bool ans = plugin.Loop();
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch
                {
                }

                // max rate is 100 hz - prevent massive cpu usage
                Thread.Sleep(10);
            }

            while (PluginLoader.Plugins.Count > 0)
            {
                var plugin = PluginLoader.Plugins[0];
                try
                {
                    plugin.Exit();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }

                PluginLoader.Plugins.Remove(plugin);
            }

            PluginThreadrunner.Set();

            return;
        }

        ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);

        /// <summary>
        /// main serial reader thread
        /// controls
        /// serial reading
        /// link quality stats
        /// speech voltage - custom - alt warning - data lost
        /// heartbeat packet sending
        /// 
        /// and can't fall out
        /// </summary>
        private async void SerialReader()
        {
            if (serialThread == true)
                return;
            serialThread = true;

            SerialThreadrunner.Reset();

            int minbytes = 10;

            int altwarningmax = 0;

            bool armedstatus = false;

            string lastmessagehigh = "";

            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;

            while (serialThread)
            {
                try
                {
                    Thread.Sleep(1); // was 5

                    try
                    {
                        if (ConfigTerminal.comPort is MAVLinkSerialPort)
                        {
                        }
                        else
                        {
                            if (ConfigTerminal.comPort != null && ConfigTerminal.comPort.IsOpen)
                                continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // update connect/disconnect button and info stats
                    try
                    {
                        UpdateConnectIcon();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // 30 seconds interval speech options
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechcustomtime).TotalSeconds > 30 &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (MainV2.speechEngine.IsReady)
                        {
                            if (Settings.Instance.GetBoolean("speechcustomenabled"))
                            {
                                MainV2.speechEngine.SpeakAsync(ArduPilot.Common.speechConversion(comPort.MAV,
                                    "" + Settings.Instance["speechcustom"]));
                            }

                            speechcustomtime = DateTime.Now;
                        }

                        // speech for battery alerts
                        //speechbatteryvolt
                        float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                        float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                        if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                            MainV2.comPort.MAV.cs.battery_voltage <= warnvolt &&
                            MainV2.comPort.MAV.cs.battery_voltage >= 5.0)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync(ArduPilot.Common.speechConversion(comPort.MAV,
                                    "" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (MainV2.comPort.MAV.cs.battery_remaining) < warnpercent &&
                                 MainV2.comPort.MAV.cs.battery_voltage >= 5.0 &&
                                 MainV2.comPort.MAV.cs.battery_remaining != 0.0)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync(
                                    ArduPilot.Common.speechConversion(comPort.MAV,
                                        "" + Settings.Instance["speechbattery"]));
                            }
                        }
                    }

                    // speech for airspeed alerts
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechlowspeedtime).TotalSeconds > 10 &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true &&
                            MainV2.comPort.MAV.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (MainV2.comPort.MAV.cs.airspeed < warnairspeed)
                            {
                                if (MainV2.speechEngine.IsReady)
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(comPort.MAV,
                                            "" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (MainV2.comPort.MAV.cs.groundspeed < warngroundspeed)
                            {
                                if (MainV2.speechEngine.IsReady)
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(comPort.MAV,
                                            "" + Settings.Instance["speechlowgroundspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else
                            {
                                speechlowspeedtime = DateTime.Now;
                            }
                        }
                    }

                    // speech altitude warning - message high warning
                    if (speechEnable && speechEngine != null &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        float warnalt = Single.MaxValue;
                        if (Settings.Instance.ContainsKey("speechaltheight"))
                        {
                            warnalt = Settings.Instance.GetFloat("speechaltheight");
                        }

                        try
                        {
                            altwarningmax = (int) Math.Max(MainV2.comPort.MAV.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true &&
                                MainV2.comPort.MAV.cs.alt != 0.00 &&
                                (MainV2.comPort.MAV.cs.alt <= warnalt) && MainV2.comPort.MAV.cs.armed)
                            {
                                if (altwarningmax > warnalt)
                                {
                                    if (MainV2.speechEngine.IsReady)
                                        MainV2.speechEngine.SpeakAsync(
                                            ArduPilot.Common.speechConversion(comPort.MAV,
                                                "" + Settings.Instance["speechalt"]));
                                }
                            }
                        }
                        catch
                        {
                        } // silent fail


                        try
                        {
                            // say the latest high priority message
                            if (MainV2.speechEngine.IsReady &&
                                lastmessagehigh != MainV2.comPort.MAV.cs.messageHigh &&
                                MainV2.comPort.MAV.cs.messageHigh != null)
                            {
                                if (!MainV2.comPort.MAV.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainV2.speechEngine.SpeakAsync(MainV2.comPort.MAV.cs.messageHigh);
                                    lastmessagehigh = MainV2.comPort.MAV.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // not doing anything
                    if (!MainV2.comPort.logreadmode && !comPort.BaseStream.IsOpen)
                    {
                        altwarningmax = 0;
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - MainV2.comPort.MAV.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            MainV2.comPort.MAV.cs.linkqualitygcs =
                                (ushort) (MainV2.comPort.MAV.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw if there are no other packets are being read
                            FlightData.myhud.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - MainV2.comPort.MAV.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen)
                        && MainV2.comPort.MAV.cs.armed)
                    {
                        if (speechEnable && speechEngine != null)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                               (DateTime.Now - MainV2.comPort.MAV.lastvalidpacket)
                                                               .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != MainV2.comPort.MAV.cs.armed && comPort.BaseStream.IsOpen)
                    {
                        armedstatus = MainV2.comPort.MAV.cs.armed;
                        // status just changed to armed
                        if (MainV2.comPort.MAV.cs.armed == true &&
                            MainV2.comPort.MAV.apname != MAVLink.MAV_AUTOPILOT.INVALID &&
                            MainV2.comPort.MAV.aptype != MAVLink.MAV_TYPE.GIMBAL)
                        {
                            ThreadPool.QueueUserWorkItem(state =>
                            {
                                Thread.CurrentThread.Name = "Arm State change";
                                try
                                {
                                    while (comPort.giveComport == true)
                                        Thread.Sleep(100);

                                    MainV2.comPort.MAV.cs.HomeLocation = new PointLatLngAlt(MainV2.comPort.getWP(0));
                                    if (MyView.current != null && MyView.current.Name == "FlightPlanner")
                                    {
                                        // update home if we are on flight data tab
                                        this.BeginInvoke((Action) delegate { FlightPlanner.updateHome(); });
                                    }
                                }
                                catch
                                {
                                    // dont hang this loop
                                    this.BeginInvoke(
                                        (Action)
                                        delegate
                                        {
                                            CustomMessageBox.Show("Failed to update home location (" +
                                                                  MainV2.comPort.MAV.sysid + ")");
                                        });
                                }
                            });
                        }

                        if (speechEnable && speechEngine != null)
                        {
                            if (Settings.Instance.GetBoolean("speecharmenabled"))
                            {
                                string speech = armedstatus
                                    ? Settings.Instance["speecharm"]
                                    : Settings.Instance["speechdisarm"];
                                if (!String.IsNullOrEmpty(speech))
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(comPort.MAV, speech));
                                }
                            }
                        }
                    }

                    if (comPort.MAV.param.TotalReceived < comPort.MAV.param.TotalReported)
                    {
                        if (comPort.MAV.param.TotalReported > 0 && comPort.BaseStream.IsOpen)
                            instance.status1.Percent =
                                (comPort.MAV.param.TotalReceived / (double) comPort.MAV.param.TotalReported) * 100.0;
                    }

                    // send a hb every seconds from gcs to ap
                    if (heatbeatSend.Second != DateTime.Now.Second)
                    {
                        MAVLink.mavlink_heartbeat_t htb = new MAVLink.mavlink_heartbeat_t()
                        {
                            type = (byte) MAVLink.MAV_TYPE.GCS,
                            autopilot = (byte) MAVLink.MAV_AUTOPILOT.INVALID,
                            mavlink_version = 3 // MAVLink.MAVLINK_VERSION
                        };

                        // enumerate each link
                        foreach (var port in Comports.ToArray())
                        {
                            if (!port.BaseStream.IsOpen)
                                continue;

                            // poll for params at heartbeat interval - primary mav on this port only
                            if (!port.giveComport)
                            {
                                try
                                {
                                    // poll only when not armed
                                    if (!port.MAV.cs.armed)
                                    {
                                        port.getParamPoll();
                                        port.getParamPoll();
                                    }
                                }
                                catch
                                {
                                }
                            }

                            // there are 3 hb types we can send, mavlink1, mavlink2 signed and unsigned
                            bool sentsigned = false;
                            bool sentmavlink1 = false;
                            bool sentmavlink2 = false;

                            // enumerate each mav
                            foreach (var MAV in port.MAVlist)
                            {
                                try
                                {
                                    // poll for version if we dont have it - every mav every port
                                    if (!port.giveComport && MAV.cs.capabilities == 0 &&
                                        (DateTime.Now.Second % 20) == 0 && MAV.cs.version < new Version(0, 1))
                                        port.getVersion(MAV.sysid, MAV.compid, false);

                                    // are we talking to a mavlink2 device
                                    if (MAV.mavlinkv2)
                                    {
                                        // is signing enabled
                                        if (MAV.signing)
                                        {
                                            // check if we have already sent
                                            if (sentsigned)
                                                continue;
                                            sentsigned = true;
                                        }
                                        else
                                        {
                                            // check if we have already sent
                                            if (sentmavlink2)
                                                continue;
                                            sentmavlink2 = true;
                                        }
                                    }
                                    else
                                    {
                                        // check if we have already sent
                                        if (sentmavlink1)
                                            continue;
                                        sentmavlink1 = true;
                                    }

                                    port.sendPacket(htb, MAV.sysid, MAV.compid);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                    // close the bad port
                                    try
                                    {
                                        port.Close();
                                    }
                                    catch
                                    {
                                    }

                                    // refresh the screen if needed
                                    if (port == MainV2.comPort)
                                    {
                                        // refresh config window if needed
                                        if (MyView.current != null)
                                        {
                                            this.BeginInvoke((MethodInvoker) delegate()
                                            {
                                                if (MyView.current.Name == "HWConfig")
                                                    MyView.ShowScreen("HWConfig");
                                                if (MyView.current.Name == "SWConfig")
                                                    MyView.ShowScreen("SWConfig");
                                            });
                                        }
                                    }
                                }
                            }
                        }

                        heatbeatSend = DateTime.Now;
                    }

                    // if not connected or busy, sleep and loop
                    if (!comPort.BaseStream.IsOpen || comPort.giveComport == true)
                    {
                        if (!comPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in Comports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("Main comport shut, swapping to other mav");
                                    comPort = port;
                                    break;
                                }
                            }
                        }

                        Thread.Sleep(100);
                    }

                    // read the interfaces
                    foreach (var port in Comports.ToArray())
                    {
                        if (!port.BaseStream.IsOpen)
                        {
                            // skip primary interface
                            if (port == comPort)
                                continue;

                            // modify array and drop out
                            Comports.Remove(port);
                            port.Dispose();
                            break;
                        }

                        DateTime startread = DateTime.Now;

                        // must be open, we have bytes, we are not yielding the port,
                        // the thread is meant to be running and we only spend 1 seconds max in this read loop
                        while (port.BaseStream.IsOpen && port.BaseStream.BytesToRead > minbytes &&
                               port.giveComport == false && serialThread && startread.AddSeconds(1) > DateTime.Now)
                        {
                            try
                            {
                                await port.readPacketAsync().ConfigureAwait(false);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }

                        // update currentstate of sysids on the port
                        foreach (var MAV in port.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, port, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Tracking.AddException(e);
                    log.Error("Serial Reader fail :" + e.ToString());
                    try
                    {
                        comPort.Close();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }

            Console.WriteLine("SerialReader Done");
            SerialThreadrunner.Set();
        }

        protected override void OnLoad(EventArgs e)
        {
            // check if its defined, and force to show it if not known about
            if (Settings.Instance["menu_autohide"] == null)
            {
                Settings.Instance["menu_autohide"] = "false";
            }

            try
            {
                AutoHideMenu(Settings.Instance.GetBoolean("menu_autohide"));
            }
            catch
            {
            }

            MyView.AddScreen(new MainSwitcher.Screen("FlightData", FlightData, true));
            MyView.AddScreen(new MainSwitcher.Screen("FlightPlanner", FlightPlanner, true));
            MyView.AddScreen(new MainSwitcher.Screen("HWConfig", typeof(InitialSetup), false));
            MyView.AddScreen(new MainSwitcher.Screen("SWConfig", typeof(SoftwareConfig), false));
            MyView.AddScreen(new MainSwitcher.Screen("Simulation", Simulation, true));
            MyView.AddScreen(new MainSwitcher.Screen("Help", typeof(Help), false));

            // hide simulation under mono
            if (Program.MONO)
            {
                MenuSimulation.Visible = false;
            }

            try
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                }
                else
                {
                    log.Info("Load Pluggins");
                    PluginLoader.DisabledPluginNames.Clear();
                    foreach (var s in Settings.Instance.GetList("DisabledPlugins"))
                        PluginLoader.DisabledPluginNames.Add(s);
                    PluginLoader.LoadAll();
                    log.Info("Load Pluggins... Done");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            if (Program.Logo != null && Program.name == "VVVVZ")
            {
                this.PerformLayout();
                MenuFlightPlanner_Click(this, e);
                MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightPlanner));
            }
            else
            {
                this.PerformLayout();
                /*
                log.Info("show FlightData");
                MenuFlightData_Click(this, e);
                log.Info("show FlightData... Done");
                MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightData));
                */
                // MenuFlightData_Click(this, e); 
                MenuFlightPlanner_Click(this, e);
                MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightPlanner));
            }

            // for long running tasks using own threads.
            // for short use threadpool

            this.SuspendLayout();

            // setup http server
            try
            {
                log.Info("start http");
                httpthread = new Thread(new httpserver().listernforclients)
                {
                    Name = "motion jpg stream-network kml",
                    IsBackground = true
                };
                httpthread.Start();
            }
            catch (Exception ex)
            {
                log.Error("Error starting TCP listener thread: ", ex);
                CustomMessageBox.Show(ex.ToString());
            }

            log.Info("start joystick");
            // setup joystick packet sender
            joystickthread = new Thread(new ThreadStart(joysticksend))
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Main joystick sender"
            };
            joystickthread.Start();

            log.Info("start serialreader");
            // setup main serial reader
            serialreaderthread = new Thread(SerialReader)
            {
                IsBackground = true,
                Name = "Main Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            serialreaderthread.Start();

            log.Info("start plugin thread");
            // setup main plugin thread
            pluginthread = new Thread(PluginThread)
            {
                IsBackground = true,
                Name = "plugin runner thread",
                Priority = ThreadPriority.BelowNormal
            };
            pluginthread.Start();


            ThreadPool.QueueUserWorkItem(LoadGDALImages);

            ThreadPool.QueueUserWorkItem(BGLoadAirports);

            ThreadPool.QueueUserWorkItem(BGCreateMaps);

            //ThreadPool.QueueUserWorkItem(BGGetAlmanac);

            ThreadPool.QueueUserWorkItem(BGgetTFR);

            ThreadPool.QueueUserWorkItem(BGNoFly);

            ThreadPool.QueueUserWorkItem(BGGetKIndex);

            // update firmware version list - only once per day
            ThreadPool.QueueUserWorkItem(BGFirmwareCheck);

            log.Info("start AutoConnect");
            AutoConnect.NewMavlinkConnection += (sender, serial) =>
            {
                try
                {
                    log.Info("AutoConnect.NewMavlinkConnection " + serial.PortName);
                    MainV2.instance.BeginInvoke((Action) delegate
                    {
                        if (MainV2.comPort.BaseStream.IsOpen)
                        {
                            var mav = new MAVLinkInterface();
                            mav.BaseStream = serial;
                            MainV2.instance.doConnect(mav, "preset", serial.PortName);

                            MainV2.Comports.Add(mav);
                        }
                        else
                        {
                            MainV2.comPort.BaseStream = serial;
                            MainV2.instance.doConnect(MainV2.comPort, "preset", serial.PortName);
                        }
                    });
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            };
            AutoConnect.NewVideoStream += (sender, gststring) =>
            {
                try
                {
                    log.Info("AutoConnect.NewVideoStream " + gststring);
                    GStreamer.gstlaunch = GStreamer.LookForGstreamer();

                    if (!File.Exists(GStreamer.gstlaunch))
                    {
                        if (CustomMessageBox.Show(
                                "A video stream has been detected, but gstreamer has not been configured/installed.\nDo you want to install/config it now?",
                                "GStreamer", MessageBoxButtons.YesNo) ==
                            (int) DialogResult.Yes)
                        {
                            {
                                ProgressReporterDialogue prd = new ProgressReporterDialogue();
                                ThemeManager.ApplyThemeTo(prd);
                                prd.DoWork += sender2 =>
                                {
                                    GStreamer.DownloadGStreamer(((i, s) =>
                                    {
                                        prd.UpdateProgressAndStatus(i, s);
                                        if (prd.doWorkArgs.CancelRequested) throw new Exception("User Request");
                                    }));
                                };
                                prd.RunBackgroundOperationAsync();

                                GStreamer.gstlaunch = GStreamer.LookForGstreamer();
                            }
                            if (!File.Exists(GStreamer.gstlaunch))
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    GStreamer.StartA(gststring);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            };
            AutoConnect.Start();

            BinaryLog.onFlightMode += (firmware, modeno) =>
            {
                try
                {
                    if (firmware == "")
                        return null;

                    var modes = ArduPilot.Common.getModesList((Firmwares) Enum.Parse(typeof(Firmwares), firmware));
                    string currentmode = null;

                    foreach (var mode in modes)
                    {
                        if (mode.Key == modeno)
                        {
                            currentmode = mode.Value;
                            break;
                        }
                    }

                    return currentmode;
                }
                catch
                {
                    return null;
                }
            };

            GStreamer.onNewImage += (sender, image) =>
            {
                try
                {
                    if (image == null)
                    {
                        FlightData.myhud.bgimage = null;
                        return;
                    }

                    var old = FlightData.myhud.bgimage;
                    FlightData.myhud.bgimage = new Bitmap(image.Width, image.Height, 4 * image.Width,
                        PixelFormat.Format32bppPArgb,
                        image.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888)
                            .Scan0);
                    if (old != null)
                        old.Dispose();
                }
                catch
                {
                }
            };

            vlcrender.onNewImage += (sender, image) =>
            {
                try
                {
                    if (image == null)
                    {
                        FlightData.myhud.bgimage = null;
                        return;
                    }

                    var old = FlightData.myhud.bgimage;
                    FlightData.myhud.bgimage = new Bitmap(image.Width,
                        image.Height,
                        4 * image.Width,
                        PixelFormat.Format32bppPArgb,
                        image.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888).Scan0);
                    if (old != null)
                        old.Dispose();
                }
                catch
                {
                }
            };

            CaptureMJPEG.onNewImage += (sender, image) =>
            {
                try
                {
                    if (image == null)
                    {
                        FlightData.myhud.bgimage = null;
                        return;
                    }

                    var old = FlightData.myhud.bgimage;
                    FlightData.myhud.bgimage = new Bitmap(image.Width, image.Height, 4 * image.Width,
                        PixelFormat.Format32bppPArgb,
                        image.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888).Scan0);
                    if (old != null)
                        old.Dispose();
                }
                catch
                {
                }
            };

            try
            {
                ZeroConf.EnumerateAllServicesFromAllHosts().ContinueWith(a => ZeroConf.ProbeForRTSP());
            }
            catch
            {
            }

            CommsSerialScan.doConnect += port =>
            {
                if (MainV2.instance.InvokeRequired)
                {
                    log.Info("CommsSerialScan.doConnect invoke");
                    MainV2.instance.BeginInvoke(
                        (Action) delegate()
                        {
                            MAVLinkInterface mav = new MAVLinkInterface();
                            mav.BaseStream = port;
                            MainV2.instance.doConnect(mav, "preset", "0");
                            MainV2.Comports.Add(mav);
                        });
                }
                else
                {
                    log.Info("CommsSerialScan.doConnect NO invoke");
                    MAVLinkInterface mav = new MAVLinkInterface();
                    mav.BaseStream = port;
                    MainV2.instance.doConnect(mav, "preset", "0");
                    MainV2.Comports.Add(mav);
                }
            };

            try
            {
                if (!MONO)
                {
#if !LIB

                    log.Info("Load AltitudeAngel");
                    AltitudeAngel.Configure();
                    AltitudeAngel.Initialize();
                    log.Info("Load AltitudeAngel... Done");
#endif
                }
            }
            catch (TypeInitializationException) // windows xp lacking patch level
            {
                //CustomMessageBox.Show("Please update your .net version. kb2468871");
            }
            catch (Exception ex)
            {
                Tracking.AddException(ex);
            }

            this.ResumeLayout();

            Program.Splash?.Close();

            log.Info("appload time");
            Tracking.AddTiming("AppLoad", "Load Time",
                (DateTime.Now - Program.starttime).TotalMilliseconds, "");

            int p = (int) Environment.OSVersion.Platform;
            bool isWin = (p != 4) && (p != 6) && (p != 128);
            bool winXp = isWin && Environment.OSVersion.Version.Major == 5;
            if (winXp)
            {
                Common.MessageShowAgain("Windows XP",
                    "This is the last version that will support Windows XP, please update your OS");

                // invalidate update url
                ConfigurationManager.AppSettings["UpdateLocationVersion"] =
                    "https://firmware.ardupilot.org/MissionPlanner/xp/";
                ConfigurationManager.AppSettings["UpdateLocation"] =
                    "https://firmware.ardupilot.org/MissionPlanner/xp/";
                ConfigurationManager.AppSettings["UpdateLocationMD5"] =
                    "https://firmware.ardupilot.org/MissionPlanner/xp/checksums.txt";
                ConfigurationManager.AppSettings["BetaUpdateLocationVersion"] = "";
            }

            try
            {
                // single update check per day - in a seperate thread
                if (Settings.Instance["update_check"] != DateTime.Now.ToShortDateString())
                {
                    ThreadPool.QueueUserWorkItem(checkupdate);
                    Settings.Instance["update_check"] = DateTime.Now.ToShortDateString();
                }
                else if (Settings.Instance.GetBoolean("beta_updates") == true)
                {
                    Utilities.Update.dobeta = true;
                    ThreadPool.QueueUserWorkItem(checkupdate);
                }
            }
            catch (Exception ex)
            {
                log.Error("Update check failed", ex);
            }

            // play a tlog that was passed to the program/ load a bin log passed
            if (Program.args.Length > 0)
            {
                var cmds = ProcessCommandLine(Program.args);

                if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) && cmds["file"].ToLower().EndsWith(".tlog"))
                {
                    FlightData.LoadLogFile(Program.args[0]);
                    FlightData.BUT_playlog_Click(null, null);
                }
                else if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) &&
                         (cmds["file"].ToLower().EndsWith(".log") || cmds["file"].ToLower().EndsWith(".bin")))
                {
                    LogBrowse logbrowse = new LogBrowse();
                    ThemeManager.ApplyThemeTo(logbrowse);
                    logbrowse.logfilename = Program.args[0];
                    logbrowse.Show(this);
                    logbrowse.BringToFront();
                }

                if (cmds.ContainsKey("script") && File.Exists(cmds["script"]))
                {
                    // invoke for after onload finished
                    this.BeginInvoke((Action) delegate()
                    {
                        try
                        {
                            FlightData.selectedscript = cmds["script"];

                            FlightData.BUT_run_script_Click(null, null);
                        }
                        catch (Exception ex)
                        {
                            CustomMessageBox.Show("Start script failed: " + ex.ToString(), Strings.ERROR);
                        }
                    });
                }

                if (cmds.ContainsKey("joy") && cmds.ContainsKey("type"))
                {
                    if (cmds["type"].ToLower() == "plane")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduPlane;
                    }
                    else if (cmds["type"].ToLower() == "copter")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduCopter2;
                    }
                    else if (cmds["type"].ToLower() == "rover")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduRover;
                    }
                    else if (cmds["type"].ToLower() == "sub")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduSub;
                    }

                    var joy = new Joystick.Joystick(() => MainV2.comPort);

                    if (joy.start(cmds["joy"]))
                    {
                        MainV2.joystick = joy;
                        MainV2.joystick.enabled = true;
                    }
                    else
                    {
                        CustomMessageBox.Show("Failed to start joystick");
                    }
                }

                if (cmds.ContainsKey("rtk"))
                {
                    var inject = new ConfigSerialInjectGPS();
                    if (cmds["rtk"].ToLower().Contains("http"))
                    {
                        inject.CMB_serialport.Text = "NTRIP";
                        var nt = new CommsNTRIP();
                        ConfigSerialInjectGPS.comPort = nt;
                        Task.Run(() =>
                        {
                            try
                            {
                                nt.Open(cmds["rtk"]);
                                nt.lat = MainV2.comPort.MAV.cs.PlannedHomeLocation.Lat;
                                nt.lng = MainV2.comPort.MAV.cs.PlannedHomeLocation.Lng;
                                nt.alt = MainV2.comPort.MAV.cs.PlannedHomeLocation.Alt;
                                this.BeginInvokeIfRequired(() => { inject.DoConnect(); });
                            }
                            catch (Exception ex)
                            {
                                this.BeginInvokeIfRequired(() => { CustomMessageBox.Show(ex.ToString()); });
                            }
                        });
                    }
                }

                if (cmds.ContainsKey("cam"))
                {
                    try
                    {
                        MainV2.cam = new Capture(Int32.Parse(cmds["cam"]), null);

                        MainV2.cam.Start();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(ex.ToString());
                    }
                }

                if (cmds.ContainsKey("gstream"))
                {
                    GStreamer.gstlaunch = GStreamer.LookForGstreamer();

                    if (!File.Exists(GStreamer.gstlaunch))
                    {
                        if (CustomMessageBox.Show(
                                "A video stream has been detected, but gstreamer has not been configured/installed.\nDo you want to install/config it now?",
                                "GStreamer", MessageBoxButtons.YesNo) ==
                            (int) DialogResult.Yes)
                        {
                            GStreamerUI.DownloadGStreamer();
                        }
                    }

                    try
                    {
                        new Thread(delegate()
                            {
                                // 36 retrys
                                for (int i = 0; i < 36; i++)
                                {
                                    try
                                    {
                                        var st = GStreamer.StartA(cmds["gstream"]);
                                        if (st == null)
                                        {
                                            // prevent spam
                                            Thread.Sleep(5000);
                                        }
                                        else
                                        {
                                            while (st.IsAlive)
                                            {
                                                Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                    catch (BadImageFormatException ex)
                                    {
                                        // not running on x64
                                        log.Error(ex);
                                        return;
                                    }
                                    catch (DllNotFoundException ex)
                                    {
                                        // missing or failed download
                                        log.Error(ex);
                                        return;
                                    }
                                }
                            })
                            {IsBackground = true, Name = "Gstreamer cli"}.Start();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }

                if (cmds.ContainsKey("port") && cmds.ContainsKey("baud"))
                {
                    _connectionControl.CMB_serialport.Text = cmds["port"];
                    _connectionControl.CMB_baudrate.Text = cmds["baud"];

                    doConnect(MainV2.comPort, cmds["port"], cmds["baud"]);
                }
            }

            GMapMarkerBase.length = Settings.Instance.GetInt32("GMapMarkerBase_length", 500);
            GMapMarkerBase.DisplayCOG = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayCOG", true);
            GMapMarkerBase.DisplayHeading = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayHeading", true);
            GMapMarkerBase.DisplayNavBearing = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayNavBearing", true);
            GMapMarkerBase.DisplayRadius = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayRadius", true);
            GMapMarkerBase.DisplayTarget = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayTarget", true);
        }

        public void LoadGDALImages(object nothing)
        {
            if (Settings.Instance.ContainsKey("GDALImageDir"))
            {
                try
                {
                    GDAL.GDAL.ScanDirectory(Settings.Instance["GDALImageDir"]);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
        }

        private Dictionary<string, string> ProcessCommandLine(string[] args)
        {
            Dictionary<string, string> cmdargs = new Dictionary<string, string>();
            string cmd = "";
            foreach (var s in args)
            {
                if (s.StartsWith("-") || s.StartsWith("/") || s.StartsWith("--"))
                {
                    cmd = s.TrimStart(new char[] {'-', '/', '-'}).TrimStart(new char[] {'-', '/', '-'});
                    continue;
                }

                if (cmd != "")
                {
                    cmdargs[cmd] = s;
                    log.Info("ProcessCommandLine: " + cmd + " = " + s);
                    cmd = "";
                    continue;
                }

                if (File.Exists(s))
                {
                    // we are not a command, and the file exists.
                    cmdargs["file"] = s;
                    log.Info("ProcessCommandLine: " + "file" + " = " + s);
                    continue;
                }

                log.Info("ProcessCommandLine: UnKnown = " + s);
            }

            return cmdargs;
        }

        private void BGFirmwareCheck(object state)
        {
            try
            {
                if (Settings.Instance["fw_check"] != DateTime.Now.ToShortDateString())
                {
                    var fw = new Firmware();
                    var list = fw.getFWList();
                    if (list.Count > 1)
                        Firmware.SaveSoftwares(new Firmware.optionsObject() {softwares = list});

                    Settings.Instance["fw_check"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGGetKIndex(object state)
        {
            try
            {
                // check the last kindex date
                if (Settings.Instance["kindexdate"] == DateTime.Now.ToShortDateString())
                {
                    KIndex_KIndex(Settings.Instance.GetInt32("kindex"), null);
                }
                else
                {
                    // get a new kindex
                    KIndex.KIndexEvent += KIndex_KIndex;
                    KIndex.GetKIndex();

                    Settings.Instance["kindexdate"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGgetTFR(object state)
        {
            try
            {
                tfr.tfrcache = Settings.GetUserDataDirectory() + "tfr.xml";
                tfr.GetTFRs();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGNoFly(object state)
        {
            try
            {
                NoFly.NoFly.Scan();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        void KIndex_KIndex(object sender, EventArgs e)
        {
            CurrentState.KIndexstatic = (int) sender;
            Settings.Instance["kindex"] = CurrentState.KIndexstatic.ToString();
        }

        private void BGCreateMaps(object state)
        {
            // sort logs
            try
            {
                LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));

                LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.rlog"));
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                // create maps
                LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog", SearchOption.AllDirectories));
                LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.bin", SearchOption.AllDirectories));
                LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.log", SearchOption.AllDirectories));

                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void checkupdate(object stuff)
        {
            /*if (Program.WindowsStoreApp)
                return;

            try
            {
                MissionPlanner.Utilities.Update.CheckForUpdate();
            }
            catch (Exception ex)
            {
                log.Error("Update check failed", ex);
            }*/
        }

        private void MainV2_Resize(object sender, EventArgs e)
        {
            // mono - resize is called before the control is created
            if (MyView != null)
                log.Info("myview width " + MyView.Width + " height " + MyView.Height);

            log.Info("this   width " + this.Width + " height " + this.Height);
            if (FlightPlanner != null)
            {
                MakeRightSideMenuTransparent();
            }

            //rightSideButtonsMenu.Location = new Point(FlightPlanner.MainMap.Size.Width-rightSideButtonsMenu.Size.Width,200);
            //1596; 204
            //FlightPlanner.MainMap.Size = new Size(1920, FlightPlanner.MainMap.Size.Height);
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Help");
        }


        private int ctrlReliasedCounter = -1;
        private bool ctrlModeActive = false;

        /// <summary>
        /// keyboard shortcuts override
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ConfigTerminal.SSHTerminal)
            {
                return false;
            }

            // if (keyData == Keys.F12)
            // {
            //     MenuConnect_Click(null, null);
            //     return true;
            // }
            //
            // if (keyData == Keys.F2)
            // {
            //     MenuFlightData_Click(null, null);
            //     return true;
            // }
            //
            // if (keyData == Keys.F3)
            // {
            //     MenuFlightPlanner_Click(null, null);
            //     return true;
            // }
            //
            // if (keyData == Keys.F4)
            // {
            //     MenuTuning_Click(null, null);
            //     return true;
            // }
            //
            // if (keyData == Keys.F5)
            // {
            //     comPort.getParamList();
            //     MyView.ShowScreen(MyView.current.Name);
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.F)) // temp
            // {
            //     Form frm = new temp();
            //     ThemeManager.ApplyThemeTo(frm);
            //     frm.Show();
            //     return true;
            // }

            /*if (keyData == (Keys.Control | Keys.S)) // screenshot
            {
                ScreenShot();
                return true;
            }*/
            // if (keyData == (Keys.Control | Keys.P))
            // {
            //     new PluginUI().Show();
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.G)) // nmea out
            // {
            //     Form frm = new SerialOutputNMEA();
            //     ThemeManager.ApplyThemeTo(frm);
            //     frm.Show();
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.X))
            // {
            //     new GMAPCache().ShowUserControl();
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.L)) // limits
            // {
            //     new DigitalSkyUI().ShowUserControl();
            //
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.W)) // test ac config
            // {
            //     new PropagationSettings().Show();
            //
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.Z))
            // {
            //     //ScanHW.Scan(comPort);
            //     new Camera().test(MainV2.comPort);
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.T)) // for override connect
            // {
            //     try
            //     {
            //         MainV2.comPort.Open(false);
            //     }
            //     catch (Exception ex)
            //     {
            //         CustomMessageBox.Show(ex.ToString());
            //     }
            //
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.Y)) // for ryan beall and ollyw42
            // {
            //     // write
            //     try
            //     {
            //         MainV2.comPort.doCommand((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
            //             MAVLink.MAV_CMD.PREFLIGHT_STORAGE, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
            //     }
            //     catch
            //     {
            //         CustomMessageBox.Show("Invalid command");
            //         return true;
            //     }
            //
            //     //read
            //     ///////MainV2.comPort.doCommand(MAVLink09.MAV_CMD.PREFLIGHT_STORAGE, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
            //     CustomMessageBox.Show("Done MAV_ACTION_STORAGE_WRITE");
            //     return true;
            // }
            //
            // if (keyData == (Keys.Control | Keys.J))
            // {
            //     new DevopsUI().ShowUserControl();
            //
            //     return true;
            // }

            /* bool manualFlightMode = false;
             int[] overrides = {1500, 1500, 1500, 1500};
 
 
             if (keyData == (Keys.Control | Keys.ControlKey))
             {
                 manualFlightMode = true;
                 //CustomMessageBox.Show("CTRL!!!");
             }
 
             if (keyData == (Keys.Control | Keys.Left))
             {
                 manualFlightMode = true;
                 overrides[3] = (int)(secondTrim*0.85);
             }
 
             if (keyData == (Keys.Control | Keys.Right))
             {
                 manualFlightMode = true;
                 overrides[3] = (int)(secondTrim * 1.15);
             }
 
             if (keyData == (Keys.Control | Keys.Up))
             {
                 manualFlightMode = true;
                 overrides[1] = (int)(thirdTrim * 1.15); ;
             }*/

            //if (keyData == (Keys.Control | Keys.Down))
            //{
            //manualFlightMode = true;
            //overrides[3] = 1300;
            //}

            /*if (keyData == (Keys.Control | Keys.Right | Keys.Up))
            {
                manualFlightMode = true;
                System.Diagnostics.Debug.WriteLine("RIGHT + UP ARROW!!!");
                overrides[2] = 1700;
                overrides[3] = 1700;
            }

            if (keyData == (Keys.Control | Keys.Left | Keys.Down))
            {
                manualFlightMode = true;
                System.Diagnostics.Debug.WriteLine("LEFT + DOWN ARROW!!!");
                overrides[2] = 1300;
                overrides[3] = 1300;
            }

            if (keyData == (Keys.Control | Keys.Right | Keys.Down))
            {
                manualFlightMode = true;
                System.Diagnostics.Debug.WriteLine("RIGHT + DOWN ARROW!!!");
                overrides[2] = 1700;
                overrides[3] = 1300;
            }

            if (keyData == (Keys.Control | Keys.Left | Keys.Up))
            {
                manualFlightMode = true;
                System.Diagnostics.Debug.WriteLine("LEFT + UP ARROW!!!");
                overrides[2] = 1300;
                overrides[3] = 1700;
            }*/
            /*ctrlModeActive = manualFlightMode;
            if (ctrlModeActive && ctrlReliasedCounter != -1)
            {
                ctrlReliasedCounter = 12;
            }*/
            /*
            if (manualFlightMode)
            {
                
                MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();
                rc.target_component = comPort.MAV.compid;
                rc.target_system = comPort.MAV.sysid;
                rc.chan1_raw = Convert.ToUInt16(1500);
                rc.chan2_raw = Convert.ToUInt16(1500);
                rc.chan3_raw = Convert.ToUInt16(1500);
                rc.chan4_raw = Convert.ToUInt16(1500);
                if (overrides[1] != 1500)
                {
                    //MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 2, overrides[1], 0, 0, 0, 0, 0);
                    rc.chan2_raw = Convert.ToUInt16(overrides[1]);
                    
                }
                if (overrides[3] != 1500)
                {
                    //MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 4, overrides[1], 0, 0, 0, 0, 0);
                    rc.chan4_raw = Convert.ToUInt16(overrides[3]);
                }
                //new DevopsUI().ShowUserControl();
                // TODO: add right values
                if (comPort.BaseStream.IsOpen)
                {
                    if (comPort.BaseStream.BytesToWrite < 50)
                    {
                        //if (sitl)
                        //{
                        //    SITL.rcinput();
                        //}
                        //else
                        //{
                        comPort.sendPacket(rc, rc.target_system, rc.target_component);
                        //}

                        //count++;
                        //lastjoystick = DateTime.Now;
                    }
                }

                string debugOverrideInfo = "Output:";

                if (overrides[3] < 1500) 
                {
                    debugOverrideInfo += " ← ";
                }
                if (overrides[1] > 1500)
                {
                    debugOverrideInfo += " ↑ ";
                }
                if (overrides[1] < 1500)
                {
                    debugOverrideInfo += " ↓ ";
                }
                if (overrides[3] > 1500)
                {
                    debugOverrideInfo += " → ";
                }

                ctrlModeDebuglabel.Text = debugOverrideInfo;
                Debug.WriteLine("overrides " + overrides[2] + " " + overrides[3]);
                return true;
            }*/


            if (ProcessCmdKeyCallback != null)
            {
                return ProcessCmdKeyCallback(ref msg, keyData);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        public delegate bool ProcessCmdKeyHandler(ref Message msg, Keys keyData);

        public event ProcessCmdKeyHandler ProcessCmdKeyCallback;

        public void changelanguage(CultureInfo ci)
        {
            log.Info("change lang to " + ci.ToString() + " current " +
                     Thread.CurrentThread.CurrentUICulture.ToString());

            if (ci != null && !Thread.CurrentThread.CurrentUICulture.Equals(ci))
            {
                Thread.CurrentThread.CurrentUICulture = ci;
                Settings.Instance["language"] = ci.Name;
                //System.Threading.Thread.CurrentThread.CurrentCulture = ci;

                HashSet<Control> views = new HashSet<Control> {this, FlightData, FlightPlanner, Simulation};

                foreach (Control view in MyView.Controls)
                    views.Add(view);

                foreach (Control view in views)
                {
                    if (view != null)
                    {
                        ComponentResourceManager rm = new ComponentResourceManager(view.GetType());
                        foreach (Control ctrl in view.Controls)
                        {
                            rm.ApplyResource(ctrl);
                        }

                        rm.ApplyResources(view, "$this");
                    }
                }
            }
        }


        public void ChangeUnits()
        {
            try
            {
                // dist
                if (Settings.Instance["distunits"] != null)
                {
                    switch (
                        (distances) Enum.Parse(typeof(distances), Settings.Instance["distunits"].ToString()))
                    {
                        case distances.Meters:
                            CurrentState.multiplierdist = 1;
                            CurrentState.DistanceUnit = "m";
                            break;
                        case distances.Feet:
                            CurrentState.multiplierdist = 3.2808399f;
                            CurrentState.DistanceUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierdist = 1;
                    CurrentState.DistanceUnit = "m";
                }

                // alt
                if (Settings.Instance["altunits"] != null)
                {
                    switch (
                        (distances) Enum.Parse(typeof(altitudes), Settings.Instance["altunits"].ToString()))
                    {
                        case distances.Meters:
                            CurrentState.multiplieralt = 1;
                            CurrentState.AltUnit = "m";
                            break;
                        case distances.Feet:
                            CurrentState.multiplieralt = 3.2808399f;
                            CurrentState.AltUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplieralt = 1;
                    CurrentState.AltUnit = "m";
                }

                // speed
                if (Settings.Instance["speedunits"] != null)
                {
                    switch ((speeds) Enum.Parse(typeof(speeds), Settings.Instance["speedunits"].ToString()))
                    {
                        case speeds.meters_per_second:
                            CurrentState.multiplierspeed = 1;
                            CurrentState.SpeedUnit = "m/s";
                            break;
                        case speeds.fps:
                            CurrentState.multiplierspeed = 3.2808399f;
                            CurrentState.SpeedUnit = "fps";
                            break;
                        case speeds.kph:
                            CurrentState.multiplierspeed = 3.6f;
                            CurrentState.SpeedUnit = "kph";
                            break;
                        case speeds.mph:
                            CurrentState.multiplierspeed = 2.23693629f;
                            CurrentState.SpeedUnit = "mph";
                            break;
                        case speeds.knots:
                            CurrentState.multiplierspeed = 1.94384449f;
                            CurrentState.SpeedUnit = "kts";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierspeed = 1;
                    CurrentState.SpeedUnit = "m/s";
                }
            }
            catch
            {
            }
        }

        private void CMB_baudrate_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(_connectionControl.CMB_baudrate.Text, out comPortBaud))
            {
                CustomMessageBox.Show(Strings.InvalidBaudRate, Strings.ERROR);
                return;
            }

            var sb = new StringBuilder();
            int baud = 0;
            for (int i = 0; i < _connectionControl.CMB_baudrate.Text.Length; i++)
                if (Char.IsDigit(_connectionControl.CMB_baudrate.Text[i]))
                {
                    sb.Append(_connectionControl.CMB_baudrate.Text[i]);
                    baud = baud * 10 + _connectionControl.CMB_baudrate.Text[i] - '0';
                }

            if (_connectionControl.CMB_baudrate.Text != sb.ToString())
            {
                _connectionControl.CMB_baudrate.Text = sb.ToString();
            }

            try
            {
                if (baud > 0 && comPort.BaseStream.BaudRate != baud)
                    comPort.BaseStream.BaudRate = baud;
            }
            catch (Exception)
            {
            }
        }

        private void MainMenu_MouseLeave(object sender, EventArgs e)
        {
            if (_connectionControl.PointToClient(Control.MousePosition).Y < MainMenu.Height)
                return;

            this.SuspendLayout();

            panel1.Visible = false;

            this.ResumeLayout();
        }

        void menu_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            panel1.Location = new Point(0, 0);
            panel1.Width = menu.Width;
            panel1.BringToFront();
            panel1.Visible = true;
            this.ResumeLayout();
        }

        private void autoHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoHideMenu(autoHideToolStripMenuItem.Checked);

            Settings.Instance["menu_autohide"] = autoHideToolStripMenuItem.Checked.ToString();
        }

        void AutoHideMenu(bool hide)
        {
            autoHideToolStripMenuItem.Checked = hide;

            if (!hide)
            {
                this.SuspendLayout();
                panel1.Dock = DockStyle.Top;
                panel1.SendToBack();
                panel1.Visible = true;
                menu.Visible = false;
                MainMenu.MouseLeave -= MainMenu_MouseLeave;
                panel1.MouseLeave -= MainMenu_MouseLeave;
                toolStripConnectionControl.MouseLeave -= MainMenu_MouseLeave;
                this.ResumeLayout();
            }
            else
            {
                this.SuspendLayout();
                panel1.Dock = DockStyle.None;
                panel1.Visible = false;
                MainMenu.MouseLeave += MainMenu_MouseLeave;
                panel1.MouseLeave += MainMenu_MouseLeave;
                toolStripConnectionControl.MouseLeave += MainMenu_MouseLeave;
                menu.Visible = true;
                menu.SendToBack();
                this.ResumeLayout();
            }
        }

        private ushort[] overrides = new ushort[] {1500, 1500, 1500, 1500};
        private static bool overrideModeActive = false;
        public static bool IsEngineOverrideActive = false;
        public static bool EngineOverrideTestFlag = false;
        public ushort EngineChannelOverride = 1500;
        public static DateTime _lastEngineOverrideTime = DateTime.Now;
        
        private void MainV2_KeyUp(object sender, KeyEventArgs e)
        {
            if (comPort.MAV.cs.connected && CurrentAircraftNum != null && Aircrafts[CurrentAircraftNum].Connected)
            {
                System.Diagnostics.Debug.WriteLine("SMTH is RELEASED");

                Keys keyData = e.KeyData;

                if (keyData == (Keys.ControlKey))
                {
                    logger.write("Ручное управление завершено");
                    System.Diagnostics.Debug.WriteLine("CTRL is RELEASED");
                    overrideModeActive = false;
                    if (comPort.MAV.cs.mode != "Auto")
                    {
                        MainV2.comPort.setMode("AUTO");
                    }
                }

                if (keyData == (Keys.Control | Keys.Left))
                {
                    System.Diagnostics.Debug.WriteLine("LEFT is RELEASED");
                    overrides[3] = 1500;
                }

                if (keyData == (Keys.Control | Keys.Right))
                {
                    System.Diagnostics.Debug.WriteLine("RIGHT is RELEASED");
                    overrides[3] = 1500;
                }

                if (keyData == (Keys.Control | Keys.Down))
                {
                    System.Diagnostics.Debug.WriteLine("UP is RELEASED");
                    overrides[1] = 1500;
                }
            }
        }

        private DateTime _lastFBWBCall = DateTime.Now;
        private void MainV2_KeyDown(object sender, KeyEventArgs e)
        {
            //Message temp = new Message();
            //ProcessCmdKey(ref temp, e.KeyData);
            Console.WriteLine("MainV2_KeyDown " + e.ToString());
            // if (e.KeyCode == Keys.Q)
            // {
            //     MainMenu.Visible = !MainMenu.Visible;
            //     menuStrip1.Visible = !menuStrip1.Visible;
            // }
            //
            // if (e.KeyCode == Keys.S)
            // {
            //     FlightPlanner.instance.MainMap_KeyDown(sender, e);
            // }
            if (comPort.MAV.cs.connected && CurrentAircraftNum != null && Aircrafts[CurrentAircraftNum].Connected)
            {
                Keys keyData = e.KeyData;
                string debugOverrideInfo = "Ручной контроль полета активирован, текущая команда: ";
                if (keyData == (Keys.Control | Keys.ControlKey))
                {
                    if ((DateTime.Now - _lastFBWBCall).TotalMilliseconds > 5000)
                    {
                        secondTrim = (ushort) MainV2.comPort.GetParam("SERVO4_TRIM");
                        thirdTrim = (ushort) MainV2.comPort.GetParam("SERVO2_TRIM");
                        logger.write("Ручное управление активировано");
                        System.Diagnostics.Debug.WriteLine("CRTL is PRESSED");
                        overrideModeActive = true;
                        if (comPort.MAV.cs.mode != "FBWB") //FBWB
                        {
                            MainV2.comPort.setMode("FBWB");
                            _lastFBWBCall = DateTime.Now;
                        }
                    }
                }

                if (keyData == (Keys.Control | Keys.Left))
                {
                    System.Diagnostics.Debug.WriteLine("LEFT is PRESSED");
                    overrides[3] = (ushort) (secondTrim - 0.15 * (secondTrim - 900) - 100);
                    debugOverrideInfo += " ← ";
                }

                if (keyData == (Keys.Control | Keys.Right))
                {
                    System.Diagnostics.Debug.WriteLine("RIGHT is PRESSED");
                    overrides[3] = (ushort) (secondTrim + 0.15 * (secondTrim - 900));
                    debugOverrideInfo += " → ";
                }

                if (keyData == (Keys.Control | Keys.Down))
                {
                    System.Diagnostics.Debug.WriteLine("UP is PRESSED");
                    overrides[1] = (ushort) (thirdTrim + 0.15 * (thirdTrim - 900));
                    debugOverrideInfo += " ↑ ";
                }

                if (overrideModeActive)
                {
                    ctrlModeDebuglabel.Text = debugOverrideInfo;
                }
                else
                {
                    ctrlModeDebuglabel.Text = "";
                }
            }

            //debugOverrideInfo += " ↓ ";       
            //if (e.KeyCode == Keys.G)
            //{
            //    CustomMessageBox.Show(Cursor.Position.ToString());
            //}
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(
                    "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=mich146%40hotmail%2ecom&lc=AU&item_name=Michael%20Oborne&no_note=0&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHostedGuest");
            }
            catch
            {
                CustomMessageBox.Show("Link open failed. check your default webpage association");
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class DEV_BROADCAST_HDR
        {
            internal Int32 dbch_size;
            internal Int32 dbch_devicetype;
            internal Int32 dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_PORT
        {
            public int dbcp_size;
            public int dbcp_devicetype;
            public int dbcp_reserved; // MSDN say "do not use"

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            public byte[] dbcp_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_DEVICEINTERFACE
        {
            public Int32 dbcc_size;
            public Int32 dbcc_devicetype;
            public Int32 dbcc_reserved;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
            internal Byte[]
                dbcc_classguid;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            internal Byte[] dbcc_name;
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CREATE:
                    try
                    {
                        DEV_BROADCAST_DEVICEINTERFACE devBroadcastDeviceInterface = new DEV_BROADCAST_DEVICEINTERFACE();
                        IntPtr devBroadcastDeviceInterfaceBuffer;
                        IntPtr deviceNotificationHandle = IntPtr.Zero;
                        Int32 size = 0;

                        // frmMy is the form that will receive device-change messages.


                        size = Marshal.SizeOf(devBroadcastDeviceInterface);
                        devBroadcastDeviceInterface.dbcc_size = size;
                        devBroadcastDeviceInterface.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
                        devBroadcastDeviceInterface.dbcc_reserved = 0;
                        devBroadcastDeviceInterface.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE.ToByteArray();
                        devBroadcastDeviceInterfaceBuffer = Marshal.AllocHGlobal(size);
                        Marshal.StructureToPtr(devBroadcastDeviceInterface, devBroadcastDeviceInterfaceBuffer, true);


                        deviceNotificationHandle = NativeMethods.RegisterDeviceNotification(this.Handle,
                            devBroadcastDeviceInterfaceBuffer, DEVICE_NOTIFY_WINDOW_HANDLE);
                    }
                    catch
                    {
                    }

                    break;

                case WM_DEVICECHANGE:
                    // The WParam value identifies what is occurring.
                    WM_DEVICECHANGE_enum n = (WM_DEVICECHANGE_enum) m.WParam;
                    var l = m.LParam;
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVEPENDING)
                    {
                        Console.WriteLine("DBT_DEVICEREMOVEPENDING");
                    }

                    if (n == WM_DEVICECHANGE_enum.DBT_DEVNODES_CHANGED)
                    {
                        Console.WriteLine("DBT_DEVNODES_CHANGED");
                    }

                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEARRIVAL ||
                        n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVECOMPLETE)
                    {
                        Console.WriteLine(((WM_DEVICECHANGE_enum) n).ToString());

                        DEV_BROADCAST_HDR hdr = new DEV_BROADCAST_HDR();
                        Marshal.PtrToStructure(m.LParam, hdr);

                        try
                        {
                            switch (hdr.dbch_devicetype)
                            {
                                case DBT_DEVTYP_DEVICEINTERFACE:
                                    DEV_BROADCAST_DEVICEINTERFACE inter = new DEV_BROADCAST_DEVICEINTERFACE();
                                    Marshal.PtrToStructure(m.LParam, inter);
                                    log.InfoFormat("Interface {0}",
                                        ASCIIEncoding.Unicode.GetString(inter.dbcc_name, 0, inter.dbcc_size - (4 * 3)));
                                    break;
                                case DBT_DEVTYP_PORT:
                                    DEV_BROADCAST_PORT prt = new DEV_BROADCAST_PORT();
                                    Marshal.PtrToStructure(m.LParam, prt);
                                    log.InfoFormat("port {0}",
                                        ASCIIEncoding.Unicode.GetString(prt.dbcp_name, 0, prt.dbcp_size - (4 * 3)));
                                    break;
                            }
                        }
                        catch
                        {
                        }

                        //string port = Marshal.PtrToStringAuto((IntPtr)((long)m.LParam + 12));
                        //Console.WriteLine("Added port {0}",port);
                    }

                    log.InfoFormat("Device Change {0} {1} {2}", m.Msg, (WM_DEVICECHANGE_enum) m.WParam, m.LParam);

                    if (DeviceChanged != null)
                    {
                        try
                        {
                            DeviceChanged((WM_DEVICECHANGE_enum) m.WParam);
                        }
                        catch
                        {
                        }
                    }

                    foreach (var item in PluginLoader.Plugins)
                    {
                        item.Host.ProcessDeviceChanged((WM_DEVICECHANGE_enum) m.WParam);
                    }

                    break;
                case 0x86: // WM_NCACTIVATE
                    //var thing = Control.FromHandle(m.HWnd);

                    var child = Control.FromHandle(m.LParam);

                    if (child is Form)
                    {
                        if (child.Name != "CoordinatsModeForm")
                        {
                            log.Debug("ApplyThemeTo " + child.Name);
                            ThemeManager.ApplyThemeTo(child);
                        }
                    }

                    break;
                default:
                    //Console.WriteLine(m.ToString());
                    break;
            }

            base.WndProc(ref m);
        }

        const int DBT_DEVTYP_PORT = 0x00000003;
        const int WM_CREATE = 0x0001;
        const Int32 DBT_DEVTYP_HANDLE = 6;
        const Int32 DBT_DEVTYP_DEVICEINTERFACE = 5;
        const Int32 DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        const Int32 DIGCF_PRESENT = 2;
        const Int32 DIGCF_DEVICEINTERFACE = 0X10;
        const Int32 WM_DEVICECHANGE = 0X219;
        public static Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");


        public enum WM_DEVICECHANGE_enum
        {
            DBT_CONFIGCHANGECANCELED = 0x19,
            DBT_CONFIGCHANGED = 0x18,
            DBT_CUSTOMEVENT = 0x8006,
            DBT_DEVICEARRIVAL = 0x8000,
            DBT_DEVICEQUERYREMOVE = 0x8001,
            DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
            DBT_DEVICEREMOVECOMPLETE = 0x8004,
            DBT_DEVICEREMOVEPENDING = 0x8003,
            DBT_DEVICETYPESPECIFIC = 0x8005,
            DBT_DEVNODES_CHANGED = 0x7,
            DBT_QUERYCHANGECONFIG = 0x17,
            DBT_USERDEFINED = 0xFFFF,
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem item in MainMenu.Items)
            {
                if (e.ClickedItem == item)
                {
                    item.BackColor = ThemeManager.ControlBGColor;
                }
                else
                {
                    try
                    {
                        item.BackColor = Color.Transparent;
                        item.BackgroundImage = displayicons.bg; //.BackColor = Color.Black;
                    }
                    catch
                    {
                    }
                }
            }

            //MainMenu.BackColor = Color.Black;
            //MainMenu.BackgroundImage = MissionPlanner.Properties.Resources.bgdark;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // full screen
            if (fullScreenToolStripMenuItem.Checked)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void readonlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainV2.comPort.ReadOnly = readonlyToolStripMenuItem.Checked;
        }

        private void connectionOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConnectionOptions().Show(this);
        }

        private void MenuArduPilot_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://ardupilot.org/?utm_source=Menu&utm_campaign=MP");
            }
            catch
            {
                CustomMessageBox.Show("Failed to open url https://ardupilot.org");
            }
        }

        private void connectionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if (File.Exists(openFileDialog.FileName))
            {
                var lines = File.ReadAllLines(openFileDialog.FileName);

                Regex tcp = new Regex("tcp://(.*):([0-9]+)");
                Regex udp = new Regex("udp://(.*):([0-9]+)");
                Regex udpcl = new Regex("udpcl://(.*):([0-9]+)");
                Regex serial = new Regex("serial:(.*):([0-9]+)");

                ConcurrentBag<MAVLinkInterface> mavs = new ConcurrentBag<MAVLinkInterface>();

                Parallel.ForEach(lines, line =>
                        //foreach (var line in lines)
                    {
                        try
                        {
                            MAVLinkInterface mav = new MAVLinkInterface();

                            if (tcp.IsMatch(line))
                            {
                                var matches = tcp.Match(line);
                                var tc = new TcpSerial();
                                tc.client = new TcpClient(matches.Groups[1].Value,
                                    Int32.Parse(matches.Groups[2].Value));
                                mav.BaseStream = tc;
                            }
                            else if (udp.IsMatch(line))
                            {
                                var matches = udp.Match(line);
                                var uc = new UdpSerial(new UdpClient(Int32.Parse(matches.Groups[2].Value)));
                                uc.Port = matches.Groups[2].Value;
                                mav.BaseStream = uc;
                            }
                            else if (udpcl.IsMatch(line))
                            {
                                var matches = udpcl.Match(line);
                                var udc = new UdpSerialConnect();
                                udc.Port = matches.Groups[2].Value;
                                udc.client = new UdpClient(matches.Groups[1].Value,
                                    Int32.Parse(matches.Groups[2].Value));
                                mav.BaseStream = udc;
                            }
                            else if (serial.IsMatch(line))
                            {
                                var matches = serial.Match(line);
                                var port = new SerialPort();
                                port.PortName = matches.Groups[1].Value;
                                port.BaudRate = Int32.Parse(matches.Groups[2].Value);
                                mav.BaseStream = port;
                                mav.BaseStream.Open();
                            }
                            else
                            {
                                return;
                            }

                            mavs.Add(mav);
                        }
                        catch
                        {
                        }
                    }
                );

                foreach (var mav in mavs)
                {
                    MainV2.instance.BeginInvoke((Action) delegate
                    {
                        doConnect(mav, "preset", "0", false);
                        Comports.Add(mav);
                    });
                }
            }
        }

        private void MainV2_Load(object sender, EventArgs e)
        {
            //MyView.ShowScreen("FlightPlanner");
        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightPlanner");
        }

        public AircraftConnectionInfo getAircraftByButtonNumber(int butNum)
        {
            foreach (var aircraft in MainV2.Aircrafts)
            {
                if (aircraft.Value.MenuNum == butNum)
                {
                    return aircraft.Value;
                }
            }

            return null;
        }

        public static bool ConnectedAircraftExists()
        {
            foreach (var aircraft in MainV2.Aircrafts)
            {
                if (aircraft.Value.Connected)
                {
                    return true;
                }
            }

            return false;
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            //testThrottle();
            //MyView.ShowScreen("FlightData");
            //comPort.MAV.cs.ch1out = 1900;
            //comPort.MAV.cs.ch2out = 1900;
            //comPort.MAV.cs.ch3out = 1900;
            //comPort.MAV.cs.ch4out = 1900;
        }

        public static void setCurrentWP(ushort num)
        {
            try
            {
                //((Control)sender).Enabled = false;
                MainV2.comPort.setWPCurrent(MainV2.comPort.MAV.sysid, MainV2.comPort.MAV.compid, num); // set nav to
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
        }

        bool b = false;

        public void testThrottle()
        {
            if (b)
            {
                MainV2.comPort.setParam((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    "SERVO3_MIN", (float) 1500);
            }
            else
            {
                MainV2.comPort.setParam((byte) MainV2.comPort.sysidcurrent, (byte) MainV2.comPort.compidcurrent,
                    "SERVO3_MIN", (float) 1100);
            }

            b = !b;
        }


        private void label13_Click(object sender, EventArgs e)
        {
        }


        private void myButton5_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightData");
        }


        // GMapOverlay polyOverlay = new GMapOverlay("polygons");
        private static bool _isSitlLanding = false;

        public static bool IsSitlLanding
        {
            get => _isSitlLanding;
            set
            {
                if (value == _isSitlLanding)
                {
                    return;
                }

                _isSitlLanding = value;
                if (value)
                {
                    MainV2.instance.FlightPlanner.notificationControl1.timer1.Enabled = false;
                    StatusControlPanel.SitlEmulation.SetTargetState(SitlState.SitlStateName.LandingStart);
                }
            }
        }

        private static bool _isSitlLandComplete = false;

        public static bool IsSitlLandComplete
        {
            get => _isSitlLandComplete;
            set => _isSitlLandComplete = value;
        }

        private void myButton4_MouseUp(object sender, MouseEventArgs e)
        {
            //testVisualisation = !testVisualisation;
            //MyView.ShowScreen("SWConfig");
            UniversalCoordinatsController u =
                new UniversalCoordinatsController(new RectCoordinats(5213504.619, 11654079.966));
            CustomMessageBox.Show(CoordinatsConverter.toWGS_From_Rect(5213504.619, 11654079.966) + "  ________  " +
                                  u.wgs.Lat.ToString() + ", " + u.wgs.Lng.ToString());
            /*System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "E:\\test.wav";
            player.Play();*/
        }

        public static void homeScreen()
        {
            MainV2.instance.MyView.ShowScreen("FlightData");
        }

        private void myButton6_MouseUp(object sender, MouseEventArgs e)
        {
            if (FlightPlanner.panelWaypoints.Visible)
            {
                FlightPlanner.panelWaypoints.Visible = false;
                myButton6.Text = "Show wp list";
            }
            else
            {
                FlightPlanner.panelWaypoints.Visible = true;
                myButton6.Text = "Hide wp list";
            }
        }

        private void myButton4_Click_1(object sender, EventArgs e)
        {
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            int width = panel1.Size.Width;
            progressBar1.Location = new Point((int) width / 2 - 2, 140);
            progressBar2.Location = new Point(0, 140);
            progressBar1.Size = new Size(width / 2 + 2, 20);
            progressBar2.Size = new Size(width / 2 + 2, 20);
            label1.Location = new Point((int) width / 2 - 2 - label1.Size.Width / 2, 140);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (warnings.Count > 0)
            {
                FlightPlanner.notificationListControl1.fullList = true;
                FlightPlanner.notificationListControl1.redraw();
            }
        }

        public static void setCoordinatsMode()
        {
            try
            {
                if (instance.FlightPlanner.wpConfig != null)
                {
                    instance.FlightPlanner.wpConfig.setCoordsMode();
                }
            }
            catch
            {
            }
        }

        private void CTX_mainmenu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}