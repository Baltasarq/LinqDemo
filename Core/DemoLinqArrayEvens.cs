using System;
using System.Linq;

namespace LinqDemo.Core {
	/*
	 *  Examples about Linq:
	 *  https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack
	 */

	public class DemoLinqArrayEvens: DemoLinqArray {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinqDemo.Core.DemoLinqArray"/> class.
		/// </summary>
		/// <param name="vector">A vector with data, as a T[]</param>
		public DemoLinqArrayEvens(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Gets the even items of the data passed to the constructor, filtering just for even ones.
		/// </summary>
		/// <returns>The even items, as an int[].</returns>
		public int[] GetEvenItems() {
			return
				( from x in this.Data
				  where ( x % 2 == 0 )
					select x ).ToArray();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqArray"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( this.GetEvenItems() );
		}
	}
}

