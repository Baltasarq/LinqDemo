using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace LinqDemo.Ui {
	public partial class MainWindow: Form {
		public MainWindow()
		{
			this.Build();
			this.edInput.Focus();
		}

		private ListBox BuildListBoxWithClassesDerivedFrom(string baseClsName) {
			var toret = new ListBox() {
				Dock = DockStyle.Top,
				SelectionMode = SelectionMode.One
			};

			// Get all classes derived from DemoLinqArray
			toret.Items.AddRange(
				( from t in this.GetType().Assembly.GetTypes()
					where ( t.IsClass
						 && t.BaseType.Name == baseClsName )
					orderby t.Name
					select t.Name ).ToArray()
			);

			toret.SelectedIndex = 0;
			return toret;
		}

		private void BuildListBoxLinqXmlDemos() {
			this.lbDemoXml = new ListBox() {
				Dock = DockStyle.Top,
				SelectionMode = SelectionMode.One
			};

			// Get all classes derived from DemoLinqArray
			this.lbDemoXml.Items.AddRange(
				( from t in this.GetType().Assembly.GetTypes()
					where ( t.IsClass
						&& t.BaseType.Name == "DemoLinqXml" )
					orderby t.Name
					select t.Name ).ToArray()
			);
			this.lbDemoXml.SelectedIndex = 0;
		}

		private void Build() {
			var pnlMain = new Panel() { Dock = DockStyle.Fill };
			pnlMain.SuspendLayout();

			var pnlButtons = new TableLayoutPanel() { Dock = DockStyle.Right };

			this.txtOutput = new TextBox() {
				Multiline = true,
				ReadOnly = true,
				ScrollBars = ScrollBars.Vertical,
				Dock = DockStyle.Fill,
				Text = "Results:" + Environment.NewLine + Environment.NewLine,
			};
			this.txtOutput.SelectionStart = this.txtOutput.Text.Length;
			this.txtOutput.SelectionLength = 0;

			this.btDemoArray = new Button() {
				Dock = DockStyle.Top,
				Text = "Execute Linq for Arrays demo"
			};
			this.btDemoArray.Click += (sender, e) => this.OnDemoLinq( (string) this.lbDemoArray.SelectedItem );

			this.btDemoXml = new Button() {
				Dock = DockStyle.Top,
				Text = "Execute Linq for Arrays demo"
			};
			this.btDemoXml.Click += (sender, e) => this.OnDemoLinq( (string) this.lbDemoXml.SelectedItem );

			this.btGenerate = new Button() {
				Dock = DockStyle.Top,
				Text = "Generate random input data"
			};
			this.btGenerate.Click += (sender, e) => this.OnGenerate( 10 );

			this.edInput = new TextBox() { Dock = DockStyle.Bottom };

			var lblExplanation = new Label() {
				Dock = DockStyle.Fill,
				Text = "Write integer numbers separated by commas below and press a button."
			};

			this.lbDemoArray = this.BuildListBoxWithClassesDerivedFrom( "DemoLinqArray" );
			this.lbDemoXml = this.BuildListBoxWithClassesDerivedFrom( "DemoLinqXml" );
			pnlButtons.Controls.Add( this.lbDemoArray );
			pnlButtons.Controls.Add( this.btDemoArray );
			pnlButtons.Controls.Add( this.lbDemoXml );
			pnlButtons.Controls.Add( this.btDemoXml );
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
		private Button btDemoArray;
		private ListBox lbDemoArray;
		private Button btDemoXml;
		private ListBox lbDemoXml;
		private Button btGenerate;
		private TextBox edInput;
	}
}
