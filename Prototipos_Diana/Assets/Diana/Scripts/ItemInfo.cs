using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class ItemInfo
{ 
	[XmlAttribute("nome")]
	public string nome;
	[XmlAttribute("peso")]
	public float peso;
	[XmlAttribute("equipavel")]
	public bool equipavel;
	[XmlAttribute("instantaneo")]
	public bool instantaneo;
	[XmlAttribute("municao")]
	public bool municao;
}

