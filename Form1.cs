namespace SpielParadies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SpielAuswahl(this).Show();
            this.Hide();
        }
    }
}
