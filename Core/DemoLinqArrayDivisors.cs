using System;
using System.Linq;

namespace LinqDemo.Core {
	/*
	 *  Examples about Linq:
	 *  https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack
	 * 
	 *  Added by Xoel Novoa Perez.
	 */
	public class DemoLinqArrayDivisors: DemoLinqArray {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinqDemo.Core.DemoLinqArrayDivisors"/> class.
		/// </summary>
		/// <param name="vector">A vector with data, as a T[]</param>
		public DemoLinqArrayDivisors(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Gets the items what are divider of the sumatory of the data passed to the constructor,
		/// calculating the divisors for the sum of all elements.
		/// </summary>
		/// <returns>The divisors items, as an int[].</returns>
		public int[] GetDivisorItems() {
			return
				( from x in this.Data
					where ( this.Data.Sum() % x == 0 )
					select x ).ToArray();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqArrayDivisors"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( this.GetDivisorItems() );
		}
	}
}
