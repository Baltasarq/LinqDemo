using System;
using System.Linq;

namespace LinqDemo.Core {
	/// <summary>
	/// Demo linq max element.
	/// Addded by Mario Yañez Borrajo
	/// </summary>
	public class DemoLinqArrayMaxElement: DemoLinqArray {
		public DemoLinqArrayMaxElement(int[] data)
			: base( data )
		{
		}

		/// <summary>
		/// Gets the max element.
		/// </summary>
		/// <returns>The max element.</returns>
		public int[] GetMaxElement() {
			return new int[]{ this.Data.Max() };
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.DemoLinqMaxElement"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> int the form of { 1 2 3 }.</returns>
		public override string ToString()
		{
			return ToString( this.GetMaxElement() );
		}
	}
}

