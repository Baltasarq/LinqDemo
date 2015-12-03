using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqDemo.Core {
	public class DemoLinqXmlRead: DemoLinqXml {
		public DemoLinqXmlRead(int[] data)
			: base( data )
		{
		}

		public int[] ReadXmlFilterEven() {
			var toret = new int[0];
			// Convert the data to XML in string and parse it back
			string strDoc = ToXml( this.Data );
			XDocument doc = XDocument.Parse( strDoc );

			// Select those nodes that hold even int values
			try {
				toret = ( from node in doc.Root.Elements( DataTag )
					where Convert.ToInt32( ( (XElement) node ).Value ) % 2 == 0
					select Convert.ToInt32( ( (XElement) node ).Value ) ).ToArray();
			} catch(FormatException) {
				// Ignored - int[0] will be returned
			}

			return toret;
		}

		public override string ToString ()
		{
			return ToXml( this.ReadXmlFilterEven() );
		}
	}
}

