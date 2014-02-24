using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public ItemInfo info;
	public bool equipado = false;

	public Item(ItemInfo i){
		info = i;
		equipado = false;
	}

	public void Instanciar(){

	}
}