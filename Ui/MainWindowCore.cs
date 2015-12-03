using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using LinqDemo.Core;

namespace LinqDemo.Ui {
	public partial class MainWindow {
		/// <summary>
		/// Transforms the string input in an array of ints
		/// </summary>
		/// <returns>The input, as int[].</returns>
		private int[] GetInput() {
			var toret = new List<int>();

			try {
				toret.AddRange(
					from s in this.edInput.Text.Split( ',' )
					select Convert.ToInt32( s )
				);
			} catch(FormatException) {
				// ignored
			}

			return toret.ToArray();
		}

		/// <summary>
		/// Shows a msg in the output.
		/// </summary>
		/// <param name="msg">A message to show, as a string.</param>
		private void ShowOutput(string msg)
		{
			this.txtOutput.Text += msg + System.Environment.NewLine + System.Environment.NewLine;
			this.txtOutput.SelectionStart = this.txtOutput.Text.Length;
			this.txtOutput.ScrollToCaret();
		}

		/// <summary>
		/// Prepares the output for a given demo,
		/// with complete input and output data.
		/// </summary>
		/// <returns>The complete output, as a string.</returns>
		/// <param name="result">A string with the result.</param>
		private string PrepareOutput(string result) {
			return ( Demo.ToString( this.GetInput() ) + System.Environment.NewLine + "->" + result );
		}

		private void OnDemoLinq(String clsName) {
			bool done = false;

			if ( clsName.Length > 0 ) {
				// Locate the class
				Type cls = this.GetType().Assembly.GetType( "LinqDemo.Core." + clsName );

				if ( cls != null ) {
					// Create an instance of the class derived from DemoLinqArray.
					var demoObj = Activator.CreateInstance( cls, new object[]{ this.GetInput() } );

					// We're only interested in the "ToString()" method.
					this.ShowOutput( this.PrepareOutput( demoObj.ToString() ) );
					done = true;
				}
			}

			if ( !done ) {
				this.ShowOutput( string.Format( "The '{0}' class was not found or impossible to build", clsName ) );
			}
		}

		private void OnGenerate(int max) {
			var strData = new StringBuilder();
			var randGen = new Random( (int) DateTime.Now.TimeOfDay.TotalSeconds );

			this.edInput.Text = "";
			for (int i = 0; i < max; ++i) {
				strData.Append( randGen.Next() % 1000 );

				if ( i < ( max - 1 ) ) {
					strData.Append( ", " );
				}
			}

			this.edInput.Text = strData.ToString();
			return;
		}
	}
}

