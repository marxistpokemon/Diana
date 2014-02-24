using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gInventario : MonoBehaviour {

	public List<Item> itensCarregando;
	public ItemContainer todosItens;
	public float pesoMaximo;
	public float pesoAtual;

	public string municao;

	private ItemContainer container;
	public TextAsset arquivoItens;

	// Use this for initialization
	void Start () {
		itensCarregando = new List<Item>();
		pesoAtual = 0f;

		todosItens = ItemContainer.LoadFromText(arquivoItens.text);
	}

	float PesoCarregando(){
		float pesoNovo = 0;
		itensCarregando.ForEach(item => pesoNovo += item.info.peso);
		return pesoNovo;
	}
	
	public bool CarregaItem (ItemInfo itemInfo, int quantidade) {
		if((itemInfo.peso * quantidade) + pesoAtual < pesoMaximo){
			for (int i = 0; i < quantidade; i++) {
				itensCarregando.Add(new Item(itemInfo));
			}
			pesoAtual = PesoCarregando();
			return true;
		}
		return false;
	}

	public Item BuscaItemCarregado (string nome) {
		return itensCarregando.Find(item => item.info.nome == nome);
	}

	public bool DescarregaItem(Item item){
		bool res = itensCarregando.Remove(item);
		pesoAtual = PesoCarregando();
		return res;
	}

	public int ContaItem(string nome){
		return itensCarregando.FindAll(i => i.info.nome == nome).Count;
	}

	public int ContaItem(Item item){
		return itensCarregando.FindAll(i => i.info.nome == item.info.nome).Count;
	}
}
