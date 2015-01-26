using System.IO;
using System.Text;

namespace WindowsFormsApplication1
{
    class ConsoleStringWriter : TextWriter
    {
        MainForm _output = null;
        StringBuilder sb = new StringBuilder();
        public ConsoleStringWriter(MainForm output)
        {
            _output = output;
        }

        public void refresh()
        {
            _output.UpdateConsole(sb.ToString());
            sb.Clear();
        }

        public override void Write(char value)
        {
            base.Write(value);

            sb.Append(value.ToString());
            //_output.UpdateConsole(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}