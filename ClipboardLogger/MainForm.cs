using System;
using System.Windows.Forms;

namespace ClipboardLogger
{
    public partial class MainForm : Form
    {
        private ClipboardListener listener;

        public MainForm()
        {
            InitializeComponent();
            listener = new ClipboardListener(Handle);
            listener.ClipboardChanged += DisplayClipboardData;
        }

        protected override void WndProc(ref Message m)
        {
            if (listener != null)
            {
                listener.WndProc(ref m, base.WndProc);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void DisplayClipboardData()
        {
            string strClip = string.Empty;
            try
            {
                IDataObject dataObject = new DataObject();
                dataObject = Clipboard.GetDataObject();
                if (dataObject.GetDataPresent(DataFormats.UnicodeText) && (dataObject.GetData(DataFormats.UnicodeText).ToString() != string.Empty))
                {
                    strClip = dataObject.GetData(DataFormats.UnicodeText).ToString();
                }
                else if (dataObject.GetDataPresent(DataFormats.Text) && ((string)dataObject.GetData(DataFormats.StringFormat) != string.Empty))
                {
                    strClip = (string)dataObject.GetData(DataFormats.StringFormat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            clipList?.Items.Add(strClip);
        }
    }
}