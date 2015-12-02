using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace LinqDemo.Core {
	public class DemoLinqXml: DemoLinqArrayPrimes {
		public DemoLinqXml(int[] data)
			: base( data )
		{
		}

		public static string ToXml(int[] data) {
			var xmlDoc = new XDocument();
			var toret = new StringWriter();
			var xmlWriter = new XmlTextWriter( toret );

			xmlDoc.Add( new XElement( "Data" ) );
			xmlDoc.Root.Add( data );

			xmlDoc.WriteTo( xmlWriter );
			return toret.ToString();
		}

		public override string ToString()
		{
			return ToXml( this.GetPrimeItems() );	
		}
	}
}

