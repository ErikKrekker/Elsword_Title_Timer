using System.Data;


namespace _Elsword__Title_Timer {

    public class Preset {
        public int Value_custom_Minimize { get; set; }
        public int Value_custom_ChangeTitle { get; set; }
        public int Value_custom_NPWG { get; set; }
        public int Value_custom_NPWG_Skill { get; set; }
        public int Value_custom_FreedShadow { get; set; }
        public int Value_custom_The_Setting_Sun { get; set; }
        public int Value_custom_Natural_Flow { get; set; }
        public int Value_custom_Awakening { get; set; }
        public int Value_custom_Onion { get; set; }
        public int Value_custom_Superhuman_Apple { get; set; }
        public int Value_custom_Reset { get; set; }
        public bool Value_show_NPWG { get; set; }
        public bool Value_show_FreedShadow { get; set; }
        public bool Value_show_The_Setting_Sun { get; set; }
    }

    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private TimerOverlay timerOverlay;

        private Preset currentPreset = new Preset();
        private string presetFileName = "";
        private List<string> presetFiles = new List<string>();
        private string presetDirectory = "Presets"; // Preset save directory
        private int selectedPresetIndex = 0; // Selected preset index


        public static bool IsCapturing_Switching = false;
        public static bool IsCapturing_NPWG = false;
        public static bool IsCapturing_NPWG_Skill = false;
        public static bool IsCapturing_FreedShadow = false;
        public static bool IsCapturing_Dusk = false;
        public static bool IsCapturing_Natural = false;
        public static bool IsCapturing_Awakening = false;
        public static bool IsCapturing_Onion = false;
        public static bool IsCapturing_Apple = false;
        public static bool IsCapturing_FOD = false;
        public static bool IsCapturing_TimerReset = false;

        const string REGISTERED_KEY_TEXT = "Currently registered key\r\n";

        public Form1(TimerOverlay overlay)
        {
            InitializeComponent();
            timerOverlay = overlay; // Store TimerOverlay instance
            this.FormClosing += OnFormClosing; // Register FormClosing event handler
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (!Directory.Exists(presetDirectory))
            {
                Directory.CreateDirectory(presetDirectory);
            }

            // Load existing preset files
            LoadPresetFiles();
            StartPreset();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            timerOverlay.Close(); // Call TimerOverlay's Close method
        }

        private void StartPreset()
        {
            using (StreamWriter writer = new StreamWriter("recent_used.txt"))
            {
                if (File.Exists("recent_used.txt"))
                {
                    presetFileName = (string)reader.ReadLine();
                }
                else
                {
                    writer.WriteLine("");
                }
            }

            LoadPreset(presetFileName);
        }

        private void SavePreset()
        {
            string filePath = Path.Combine(presetDirectory, text_Preset.Text + ".txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(timerOverlay.form_custom_ChangeTitle);
                writer.WriteLine(timerOverlay.form_custom_NPWG);
                writer.WriteLine(timerOverlay.form_custom_NPWG_Skill);
                writer.WriteLine(timerOverlay.form_custom_FreedShadow);
                writer.WriteLine(timerOverlay.form_custom_Dusk);
                writer.WriteLine(timerOverlay.form_custom_Natural);
                writer.WriteLine(timerOverlay.form_custom_Awakening);
                writer.WriteLine(timerOverlay.form_custom_Onion);
                writer.WriteLine(timerOverlay.form_custom_Apple);
                writer.WriteLine(timerOverlay.form_custom_FOD);
                writer.WriteLine(timerOverlay.form_custom_TimerReset);
                writer.WriteLine(timerOverlay.Show_NPWG);
                writer.WriteLine(timerOverlay.Show_FreedShadow);
                writer.WriteLine(timerOverlay.Show_Dusk);
                writer.WriteLine(timerOverlay.form_Use_NPWG_FOD);
                writer.WriteLine(timerOverlay.form_Use_FreedShadow_FOD);
                writer.WriteLine(timerOverlay.form_Use_Dusk_FOD);
                writer.WriteLine(timerOverlay.form_ADD_User);
                writer.WriteLine(timerOverlay.allowResize);
            }


            using (StreamWriter writer = new StreamWriter("recent_used.txt"))
            {
                writer.WriteLine(text_Preset.Text);
            }
        }

        private void LoadPreset(string fileName)
        {
            string filePath = Path.Combine(presetDirectory, fileName + ".txt");

            if (File.Exists(filePath))
            {
                presetFileName = fileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    timerOverlay.form_custom_ChangeTitle = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_NPWG = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_NPWG_Skill = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_FreedShadow = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Dusk = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Natural = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Awakening = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Onion = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_Apple = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_FOD = int.Parse(reader.ReadLine());
                    timerOverlay.form_custom_TimerReset = int.Parse(reader.ReadLine());
                    timerOverlay.Show_NPWG = bool.Parse(reader.ReadLine());
                    timerOverlay.Show_FreedShadow = bool.Parse(reader.ReadLine());
                    timerOverlay.Show_Dusk = bool.Parse(reader.ReadLine());
                    timerOverlay.form_Use_NPWG_FOD = bool.Parse(reader.ReadLine());
                    timerOverlay.form_Use_FreedShadow_FOD = bool.Parse(reader.ReadLine());
                    timerOverlay.form_Use_Dusk_FOD = bool.Parse(reader.ReadLine());
                    timerOverlay.form_ADD_User = bool.Parse(reader.ReadLine());
                    timerOverlay.allowResize = bool.Parse(reader.ReadLine());

                    label_Switching.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_ChangeTitle + "]";
                    label_NPWG.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_NPWG + "]";
                    label_NPWG_Skill.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_NPWG_Skill + "]";
                    label_FreedShadow.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_FreedShadow + "]";
                    label_Dusk.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_Dusk + "]";
                    label_Natural.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_Natural + "]";
                    label_Awakening.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_Awakening + "]";
                    label_Onion.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_Onion + "]";
                    label_Apple.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_Apple + "]";
                    label_FOD.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_FOD + "]";
                    label_TimerReset.Text = REGISTERED_KEY_TEXT + "[" + (Keys)timerOverlay.form_custom_TimerReset + "]";
                    check_NPWG.Checked = timerOverlay.Show_NPWG;
                    check_FreedShadow.Checked = timerOverlay.Show_FreedShadow;
                    check_Dusk.Checked = timerOverlay.Show_Dusk;
                    check_NPWG_FOD.Checked = timerOverlay.form_Use_NPWG_FOD;
                    check_FreedShadow_FOD.Checked = timerOverlay.form_Use_FreedShadow_FOD;
                    check_Dusk_FOD.Checked = timerOverlay.form_Use_Dusk_FOD;
                    check_ADD_User.Checked = timerOverlay.form_ADD_User;
                    check_Resize.Checked = timerOverlay.allowResize;
                }

                using (StreamWriter writer = new StreamWriter("recent_used.txt"))
                {
                    writer.WriteLine(presetFileName);
                }

                comboBox_Preset.Text = presetFileName;
            }
            else
            {
                System.Console.WriteLine("Preset file not found!");
            }
        }

        private void LoadPresetFiles()
        {
            presetFiles.Clear();
            if (Directory.Exists(presetDirectory))
            {
                presetFiles.AddRange(Directory.GetFiles(presetDirectory, "*.txt").Select(Path.GetFileNameWithoutExtension).Distinct()); // Remove duplicates
                comboBox_Preset.Items.AddRange(presetFiles.ToArray());
            }
        }

        private void DisableOtherControls()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = false; // Disable other controls
            }
        }

        private void EnableOtherControls()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true; // Enable all controls
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int keycode = -1;
            keycode = (int)e.KeyCode;

            if (e.KeyCode == Keys.ShiftKey)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)))
                {
                    keycode = (int)Keys.LShiftKey;
                }
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
                {
                    keycode = (int)Keys.RShiftKey;
                }
            }

            if (e.KeyCode == Keys.ControlKey)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)))
                {
                    keycode = (int)Keys.LControlKey;
                }
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                {
                    keycode = (int)Keys.RControlKey;
                }
            }

            if (e.KeyCode == Keys.Menu)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
                {
                    keycode = (int)Keys.LMenu;
                }
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
                {
                    keycode = (int)Keys.RMenu;
                }
            }

            if (IsCapturing_Switching)
            {
                IsCapturing_Switching = false; // End key capture state
                // When a key input is detected, change the button and label text
                timerOverlay.form_custom_ChangeTitle = keycode;
                btn_Switching.Text = "Title switching key\r\nregister button";
                label_Switching.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_NPWG)
            {
                IsCapturing_NPWG = false;
                btn_NPWG.Text = "NPWG direction key\r\nregister button";
                timerOverlay.form_custom_NPWG = keycode;
                label_NPWG.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_NPWG_Skill)
            {
                IsCapturing_NPWG_Skill = false;
                btn_NPWG_Skill.Text = "NPWG skill key\r\nregister button";
                timerOverlay.form_custom_NPWG_Skill = keycode;
                label_NPWG_Skill.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_FreedShadow)
            {
                IsCapturing_FreedShadow = false;
                btn_FreedShadow.Text = "Freed Shadow direction key\r\nregister button";
                timerOverlay.form_custom_FreedShadow = keycode;
                label_FreedShadow.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Dusk)
            {
                IsCapturing_Dusk = false;
                btn_Dusk.Text = "Dusk direction key\r\nregister button";
                timerOverlay.form_custom_Dusk = keycode;
                label_Dusk.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Natural)
            {
                IsCapturing_Natural = false;
                btn_Natural.Text = "Natural Flow direction key\r\nregister button";
                timerOverlay.form_custom_Natural = keycode;
                label_Natural.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Awakening)
            {
                IsCapturing_Awakening = false;
                btn_Awakening.Text = "Awakening key\r\nregister button";
                timerOverlay.form_custom_Awakening = keycode;
                label_Awakening.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Onion)
            {
                IsCapturing_Onion = false;
                btn_Onion.Text = "Onion use key\r\nregister button";
                timerOverlay.form_custom_Onion = keycode;
                label_Onion.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_Apple)
            {
                IsCapturing_Apple = false;
                btn_Apple.Text = "Apple use key\r\nregister button";
                timerOverlay.form_custom_Apple = keycode;
                label_Apple.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_FOD)
            {
                IsCapturing_FOD = false;
                btn_FOD.Text = "Pseudo FOD key\r\nregister button";
                timerOverlay.form_custom_FOD = keycode;
                label_FOD.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }
            else if (IsCapturing_TimerReset)
            {
                IsCapturing_TimerReset = false;
                btn_TimerReset.Text = "Timer reset key\r\nregister button";
                timerOverlay.form_custom_TimerReset = keycode;
                label_TimerReset.Text = REGISTERED_KEY_TEXT + "[" + (Keys)keycode + "]";
            }

            // Unregister the event handler so that no more key input is processed
            this.KeyDown -= Form1_KeyDown; // Unregister the event handler

            EnableOtherControls();
        }

        private void btn_Switching_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_Switching, btn_Switching);
        }

        private void btn_NPWG_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_NPWG, btn_NPWG);
        }

        private void btn_NPWG_Skill_Click(object sender, EventArgs e)
        {   
            StartKeyCapture(ref IsCapturing_NPWG_Skill, btn_NPWG_Skill);
        }

        private void btn_FreedShadow_Click(object sender, EventArgs e) {
            StartKeyCapture(ref IsCapturing_FreedShadow, btn_FreedShadow);
        }

        private void btn_Dusk_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_Dusk, btn_Dusk);
        }

        private void btn_Natural_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_Natural, btn_Natural);
        }

        private void btn_Awakening_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_Awakening, btn_Awakening);
        }

        private void btn_Onion_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_Onion, btn_Onion);
        }

        private void btn_Apple_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_Apple, btn_Apple);
        }

        private void btn_FOD_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_FOD, btn_FOD);
        }

        private void btn_TimerReset_Click(object sender, EventArgs e)
        {
            StartKeyCapture(ref IsCapturing_TimerReset, btn_TimerReset);
        }

        private void btn__Switching_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Switching = false;
            timerOverlay.form_custom_ChangeTitle = -1;
            btn_Switching.Text = "Title switching key\r\nregister button";
            label_Switching.Text = "Currently registered key\r\n[None]";
        }

        private void btn_NPWG_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_NPWG = false;
            timerOverlay.form_custom_NPWG = -1;
            btn_NPWG.Text = "NPWG direction key\r\nregister button";
            label_NPWG.Text = "Currently registered key\r\n[None]";
        }

        private void btn_NPWG_Skill_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_NPWG_Skill = false;
            timerOverlay.form_custom_NPWG_Skill = -1;
            btn_NPWG_Skill.Text = "NPWG skill key\r\nregister button";
            label_NPWG_Skill.Text = "Currently registered key\r\n[None]";
        }

        private void btn_FreedShadow_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_FreedShadow = false;
            timerOverlay.form_custom_FreedShadow = -1;
            btn_FreedShadow.Text = "Freed Shadow direction key\r\nregister button";
            label_FreedShadow.Text = "Currently registered key\r\n[None]";
        }

        private void btn_Dusk_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Dusk = false;
            timerOverlay.form_custom_Dusk = -1;
            btn_Dusk.Text = "Dusk direction key\r\nregister button";
            label_Dusk.Text = "Currently registered key\r\n[None]";
        }

        private void btn_Natural_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Natural = false;
            timerOverlay.form_custom_Natural = -1;
            btn_Natural.Text = "Natural Flow direction key\r\nregister button";
            label_Natural.Text = "Currently registered key\r\n[None]";
        }

        private void btn_Awakening_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Awakening = false;
            timerOverlay.form_custom_Awakening = -1;
            btn_Awakening.Text = "Awakening key\r\nregister button";
            label_Awakening.Text = "Currently registered key\r\n[None]";
        }

        private void btn_Onion_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Onion = false;
            timerOverlay.form_custom_Onion = -1;
            btn_Onion.Text = "Onion use key\r\nregister button";
            label_Onion.Text = "Currently registered key\r\n[None]";
        }

        private void btn_Apple_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_Apple = false;
            timerOverlay.form_custom_Apple = -1;
            btn_Apple.Text = "Apple use key\r\nregister button";
            label_Apple.Text = "Currently registered key\r\n[None]";
        }

        private void btn_FOD_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_FOD = false;
            timerOverlay.form_custom_FOD = -1;
            btn_FOD.Text = "Pseudo FOD key\r\nregister button";
            label_FOD.Text = "Currently registered key\r\n[None]";
        }

        private void btn_TimerReset_reset_Click(object sender, EventArgs e)
        {
            IsCapturing_TimerReset = false;
            timerOverlay.form_custom_TimerReset = -1;
            btn_TimerReset.Text = "Timer reset key\r\nregister button";
            label_TimerReset.Text = "Currently registered key\r\n[None]";
        }

        private void comboBox_Preset_SelectedIndexChanged(object sender, EventArgs e)
        {
            presetFileName = comboBox_Preset.Text;
        }

        private void btn_savePreset_Click(object sender, EventArgs e)
        {
            SavePreset();
            comboBox_Preset.Text = text_Preset.Text;
        }

        private void btn_loadPreset_Click(object sender, EventArgs e)
        {
            LoadPreset(comboBox_Preset.Text);
        }

        private void check_NPWG_CheckedChanged(object sender, EventArgs e)
        {
            if (check_NPWG.Checked)
            {
                timerOverlay.Show_NPWG = true;
            }
            else
            {
                timerOverlay.Show_NPWG = false;
            }
        }

        private void check_FreedShadow_CheckedChanged(object sender, EventArgs e)
        {
            if (check_FreedShadow.Checked)
            {
                timerOverlay.Show_FreedShadow = true;
            }
            else
            {
                timerOverlay.Show_FreedShadow = false;
            }
        }

        private void check_Dusk_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Dusk.Checked)
            {
                timerOverlay.Show_Dusk = true;
            }
            else
            {
                timerOverlay.Show_Dusk = false;
            }
        }

        private void check_NPWG_FOD_CheckedChanged(object sender, EventArgs e)
        {
            if (check_NPWG_FOD.Checked)
            {
                timerOverlay.form_Use_NPWG_FOD = true;
            }
            else
            {
                timerOverlay.form_Use_NPWG_FOD = false;
            }
        }

        private void check_FreedShadow_FOD_CheckedChanged(object sender, EventArgs e)
        {
            if (check_FreedShadow_FOD.Checked)
            {
                timerOverlay.form_Use_FreedShadow_FOD = true;
            }
            else
            {
                timerOverlay.form_Use_FreedShadow_FOD = false;
            }
        }

        private void check_Dusk_FOD_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Dusk_FOD.Checked)
            {
                timerOverlay.form_Use_Dusk_FOD = true;
            }
            else
            {
                timerOverlay.form_Use_Dusk_FOD = false;
            }
        }

        private void check_ADD_User_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ADD_User.Checked)
            {
                timerOverlay.form_ADD_User = true;
            }
            else
            {
                timerOverlay.form_ADD_User = false;
            }
        }

        private void text_Fontsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers and backspace
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers and backspace
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void chang_Fontsize_Click(object sender, EventArgs e)
        {
            int fontSize_perCent = int.Parse(text_Fontsize.Text);
            timerOverlay.fontScale = (fontSize_perCent / 100f);
            timerOverlay.isInitialized = false;
        }

        private void btn_Chg_Imgsize_Click(object sender, EventArgs e)
        {
            int imgSize_perCent = int.Parse(text_imgSize.Text);
            timerOverlay.imgScale = (imgSize_perCent / 100f);
            timerOverlay.isInitialized = false;
        }

        private void check_Resize_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Resize.Checked)
            {
                timerOverlay.allowResize = true;
            }
            else
            {
                timerOverlay.allowResize = false;
            }
        }
        
        // Generalized handler for key capture buttons
        private void StartKeyCapture(ref bool captureFlag, Button button)
        {
            captureFlag = true;
            button.Text = "Please enter a key";
            DisableOtherControls();
            // Enable the form's KeyDown event to wait for key input
            this.KeyPreview = true; // Set the form to receive key events
            this.KeyDown += Form1_KeyDown; // Register the KeyDown event handler
        }
    }
}
