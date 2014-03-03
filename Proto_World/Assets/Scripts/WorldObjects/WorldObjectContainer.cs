using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
[XmlRoot("AllWO")]
public class WorldObjectContainer
{
	[XmlArray("WorldObjects")]
	[XmlArrayItem("WorldObject")]
	public List<WorldObjectInfo> worldObjects = new List<WorldObjectInfo>();
	
	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(WorldObjectContainer));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static WorldObjectContainer Load(string path)
	{
		var serializer = new XmlSerializer(typeof(WorldObjectContainer));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as WorldObjectContainer;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static WorldObjectContainer LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(WorldObjectContainer));
		return serializer.Deserialize(new StringReader(text)) as WorldObjectContainer;
	}
}

