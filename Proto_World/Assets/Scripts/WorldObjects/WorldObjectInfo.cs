using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class WorldObjectInfo {
	[XmlAttribute("name")]
	public string name;
	[XmlAttribute("id")]
	public int id;
}
