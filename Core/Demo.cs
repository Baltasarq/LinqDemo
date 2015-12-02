using System;
using System.Text;

namespace LinqDemo.Core {
	public class Demo {
		public Demo(int[] data)
		{
			this.Data = data;
		}

		/// <summary>
		/// Gets the data, passed in the constructor.
		/// </summary>
		/// <value>The data, as an int[].</value>
		public int[] Data {
			get; private set;
		}

		/// <summary>
		/// Converts a given vector to a string representation.
		/// </summary>
		/// <returns>A string, in the form { 1, 2, 3 }.</returns>
		/// <param name="data">A generic vector.</param>
		public static string ToString<T>(T[] data)
		{
			var toret = new StringBuilder();

			toret.Append( "{ " );
			for (int i = 0; i < data.Length; ++i) {
				toret.Append( data[ i ] );

				if ( i < data.Length - 1 ) {
					toret.Append( ", " );
				}
			}
			toret.Append( " }" );

			return toret.ToString();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LinqDemo.Core.Demo"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> of all items, as passed to the constructor.</returns>
		public override string ToString()
		{
			return ToString( this.Data );
		}
	}
}

