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
			this.edInput.Text = "";
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

		private void OnDemoLinqArrayEvens() {
			this.ShowOutput( this.PrepareOutput( new DemoLinqArrayEvens( this.GetInput() ).ToString() ) );
		}

		private void OnDemoLinqArrayPrimes() {
			this.ShowOutput( this.PrepareOutput( new DemoLinqArrayPrimes( this.GetInput() ).ToString() ) );
		}

		private void OnDemoLinqArrayParanoia() {
			this.ShowOutput( this.PrepareOutput( new DemoLinqArrayParanoia( this.GetInput() ).ToString() ) );
		}

		private void OnDemoLinqToXml() {
			this.ShowOutput( this.PrepareOutput( new DemoLinqXml( this.GetInput() ).ToString() ) );
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

