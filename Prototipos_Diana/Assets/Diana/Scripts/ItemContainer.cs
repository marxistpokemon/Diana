using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[XmlRoot("ItemColecao")]
[System.Serializable]
public class ItemContainer
{
	[XmlArray("Itens")]
	[XmlArrayItem("Item")]
	public List<ItemInfo> Itens = new List<ItemInfo>();
	
	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(ItemContainer));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static ItemContainer Load(string path)
	{
		var serializer = new XmlSerializer(typeof(ItemContainer));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as ItemContainer;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static ItemContainer LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(ItemContainer));
		return serializer.Deserialize(new StringReader(text)) as ItemContainer;
	}
}
