using System;
using System.Linq;

namespace LinqDemo.Core {
	/*
	 *  Examples about Linq:
	 *  https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack
	 */
	public class DemoLinqArrayAverage: DemoLinqArray {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinqDemo.Core.DemoLinqArraySum"/> class.
		/// </summary>
		/// <param name="vector">A vector with data, as a T[]</param>
		public DemoLinqArrayAverage(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Gets the average of the collection.
		/// </summary>
		/// <returns>The average, as an int.</returns>
		public int[] GetAverage() {
			var toret = new int[]{ 0 };

			if ( this.Data.Length > 0 ) {
				toret = new int[]{ (int) this.Data.Average() };
			}

			return toret;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqArrayAverage"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( this.GetAverage() );
		}
	}
}
