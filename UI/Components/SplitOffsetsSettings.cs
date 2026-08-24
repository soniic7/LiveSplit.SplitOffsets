using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.SplitOffsets
{
    public partial class SplitOffsetsSettings : UserControl
    {
        public bool EnableOffsets { get; set; } = true;
        public string TagEnclosure { get; set; } = "Square Brackets [ ]";

        public SplitOffsetsSettings()
        {
            InitializeComponent();

            chkEnable.DataBindings.Add("Checked", this, nameof(EnableOffsets), false, DataSourceUpdateMode.OnPropertyChanged);

            // Sets initial dropdown selection so it is never blank on fresh component creation
            cmbTagStyle.SelectedItem = TagEnclosure;

            cmbTagStyle.SelectedIndexChanged += (s, e) =>
            {
                if (cmbTagStyle.SelectedItem != null)
                {
                    TagEnclosure = cmbTagStyle.SelectedItem.ToString();
                }
            };
        }

        public void SetSettings(XmlNode settings)
        {
            if (settings["EnableOffsets"] != null && bool.TryParse(settings["EnableOffsets"].InnerText, out bool enable))
            {
                EnableOffsets = enable;
            }

            if (settings["TagEnclosure"] != null)
            {
                TagEnclosure = settings["TagEnclosure"].InnerText;
            }

            chkEnable.Checked = EnableOffsets;

            if (cmbTagStyle.Items.Contains(TagEnclosure))
            {
                cmbTagStyle.SelectedItem = TagEnclosure;
            }
            else
            {
                cmbTagStyle.SelectedIndex = 0;
            }
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");

            var enableEl = document.CreateElement("EnableOffsets");
            enableEl.InnerText = EnableOffsets.ToString();
            parent.AppendChild(enableEl);

            var enclosureEl = document.CreateElement("TagEnclosure");
            enclosureEl.InnerText = TagEnclosure;
            parent.AppendChild(enclosureEl);

            return parent;
        }
    }
}