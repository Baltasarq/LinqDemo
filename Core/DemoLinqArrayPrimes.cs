using System;
using System.Linq;

namespace LinqDemo.Core {
	/*
	 *  Examples about Linq:
	 *  https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack
	 */

	public class DemoLinqArrayPrimes: Demo {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinqDemo.Core.DemoLinqArray"/> class.
		/// </summary>
		/// <param name="vector">A vector with data, as a T[]</param>
		public DemoLinqArrayPrimes(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Determines whether the specified x is prime.
		/// It goes from 2 to sqrt( x ).
		/// </summary>
		/// <returns><c>true</c> if is prime the specified x; otherwise, <c>false</c>.</returns>
		/// <param name="x">An int number.</param>
		private bool IsPrime(int x) {
			bool toret = true;

			for (int i = 2; i < Math.Sqrt( x ); ++i) {
				if ( x % i == 0 ) {
					toret = false;
					break;
				}
			}

			return toret;
		}

		/// <summary>
		/// Gets the even items of the data passed to the constructor, filtering just for even ones.
		/// </summary>
		/// <returns>The even items, as an int[].</returns>
		public int[] GetPrimeItems() {
			return
				( from x in this.Data
					where this.IsPrime( x )
					select x ).ToArray();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqArray"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( this.GetPrimeItems() );
		}
	}
}

