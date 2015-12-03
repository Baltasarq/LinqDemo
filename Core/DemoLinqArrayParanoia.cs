using System;
using System.Linq;

namespace LinqDemo.Core {
	/*
	 *  Added by Hugo Gzlez. Labrador
	 *  Examples about Linq:
	 *  https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/viewsamplepack
	 */

	public class DemoLinqArrayParanoia: DemoLinqArray {
		/// <summary>
		/// Initializes a new instance of the <see cref="LinqDemo.Core.DemoLinqArrayParanoia"/> class.
		/// </summary>
		/// <param name="vector">A vector with data, as a T[]</param>
		public DemoLinqArrayParanoia(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Gets a list of ints that is the aggregated sum of all the elements in the list using the 
		/// current item as the seed for the aggregation function
		/// </summary>
		/// <returns>The paranoia items, as an int[].</returns>
		public int[] GetParanoiaItems() {
			return 
				( from x in this.Data
					select this.Data.Aggregate (x, (current, next) => current * next) ).ToArray()
				;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqArrayParanoia"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( this.GetParanoiaItems() );
		}
	}
}

