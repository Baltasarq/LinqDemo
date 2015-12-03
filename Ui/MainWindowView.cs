using System.Drawing;
using System.Windows.Forms;

namespace LinqDemo.Ui {
	public partial class MainWindow: Form {
		public MainWindow()
		{
			this.Build();
			this.edInput.Focus();
		}

		private void Build() {
			var pnlMain = new Panel();
			pnlMain.SuspendLayout();
			pnlMain.Dock = DockStyle.Fill;

			var pnlButtons = new TableLayoutPanel();
			pnlButtons.Dock = DockStyle.Right;

			this.txtOutput = new TextBox();
			this.txtOutput.Multiline = true;
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Dock = DockStyle.Fill;
			this.txtOutput.Text = "Results:" + System.Environment.NewLine + System.Environment.NewLine;
			this.txtOutput.SelectionStart = this.txtOutput.Text.Length;
			this.txtOutput.ScrollBars = ScrollBars.Vertical;

			this.btDemoArray1 = new Button();
			this.btDemoArray1.Dock = DockStyle.Top;
			this.btDemoArray1.Text = "Linq for arrays (even)";
			this.btDemoArray1.Click += (sender, e) => this.OnDemoLinqArrayEvens();

			this.btDemoArray2 = new Button();
			this.btDemoArray2.Dock = DockStyle.Top;
			this.btDemoArray2.Text = "Linq for arrays (primes)";
			this.btDemoArray2.Click += (sender, e) => this.OnDemoLinqArrayPrimes();

			this.btDemoArrayParanoia = new Button();
			this.btDemoArrayParanoia.Dock = DockStyle.Top;
			this.btDemoArrayParanoia.Text = "Linq for array (Guess what it does XD)";
			this.btDemoArrayParanoia.Click += (sender, e) => this.OnDemoLinqArrayParanoia();

			this.btDemoArray3 = new Button();
			this.btDemoArray3.Dock = DockStyle.Top;
			this.btDemoArray3.Text = "Linq to XML";
			this.btDemoArray3.Click += (sender, e) => this.OnDemoLinqToXml();

			this.btGenerate = new Button();
			this.btGenerate.Dock = DockStyle.Top;
			this.btGenerate.Text = "Generate random input data";
			this.btGenerate.Click += (sender, e) => this.OnGenerate( 10 );

			this.edInput = new TextBox();
			this.edInput.Dock = DockStyle.Bottom;

			var lblExplanation = new Label();
			lblExplanation.Dock = DockStyle.Fill;
			lblExplanation.Text = "Write integer numbers separated by commas below and press a button.";

			pnlButtons.Controls.Add( this.btDemoArray1 );
			pnlButtons.Controls.Add( this.btDemoArray2 );
			pnlButtons.Controls.Add( this.btDemoArray3 );
			pnlButtons.Controls.Add( this.btDemoArrayParanoia );
			pnlButtons.Controls.Add( lblExplanation );
			pnlButtons.Controls.Add( this.btGenerate );
			pnlMain.Controls.Add( this.txtOutput );
			pnlMain.Controls.Add( pnlButtons );
			pnlMain.Controls.Add( this.edInput );
			this.Controls.Add( pnlMain );

			this.MinimumSize = new Size( 640, 480 );
			this.Text = "Linq Demo";

			pnlMain.ResumeLayout( false );
		}

		private TextBox txtOutput;
		private Button btDemoArray1;
		private Button btDemoArray2;
		private Button btDemoArray3;
		private Button btDemoArrayParanoia;
		private Button btGenerate;
		private TextBox edInput;
	}
}
