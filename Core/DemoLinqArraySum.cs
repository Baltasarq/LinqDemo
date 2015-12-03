using System;
using System.Linq;

namespace LinqDemo.Core {
	/*
	 *  Examples about Linq:
	 *  https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack
	 */
	public class DemoLinqArraySum: DemoLinqArray {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinqDemo.Core.DemoLinqArraySum"/> class.
		/// </summary>
		/// <param name="vector">A vector with data, as a T[]</param>
		public DemoLinqArraySum(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqArraySum"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( new int[]{ this.Data.Sum() } );
		}
	}
}
