using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace LinqDemo.Core {
	public class DemoLinqXml: Demo {
		public DemoLinqXml(int[] data)
			: base( data )
		{
		}

		public static string ToXml(int[] data) {
			var xmlDoc = new XDocument();
			var toret = new StringWriter();
			var xmlWriter = new XmlTextWriter( toret );

			xmlDoc.Add( new XElement( "Data" ) );

			foreach (var x in data) {
				xmlDoc.Root.Add(
					new XElement( "DataItem", x.ToString() ) );
			}

			xmlWriter.Formatting = Formatting.Indented;
			xmlDoc.WriteTo( xmlWriter );
			return toret.ToString();
		}

		public override string ToString()
		{
			return ToXml( this.Data );	
		}
	}
}

