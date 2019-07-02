using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer.Vermeer.bin.Cefsharp
{
    public class SettingsUI : UserControl
    {
        public SettingsUI()
        { this.Size = new Size(560, 300); }
    }

    public class SettingsWindowManager
    {
        List<SettingsUI> UI = new List<SettingsUI>();

        public SettingsWindowManager()
        {

        }

        public Form GetSettingsForm(Size FormSize)
        {
            Form settingsForm = new Form(); settingsForm.Size = FormSize;

            return settingsForm;
        }

        public void AddUIControl(SettingsUI UI) { this.UI.Add(UI); }
    }
}
