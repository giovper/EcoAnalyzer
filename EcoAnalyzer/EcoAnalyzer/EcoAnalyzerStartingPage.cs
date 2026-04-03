//LOGHI
// https://cooltext.com/
// https://www.flamingtext.com/Cool-Text-Generator/

namespace EcoAnalyzer
{
    public partial class EcoAnalyzerStartingPage : Form
    {
        public EcoAnalyzerStartingPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Temp().ShowDialog();
        }
    }
}
