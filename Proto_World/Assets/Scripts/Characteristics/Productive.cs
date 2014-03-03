using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Product {
	public Transform spawningPoint;
	public Transform productPrefab;
	public bool oneTimeProduct;
	public bool isProducing;
	public int quantity;
	public float productionRate;
}

public class Productive : BaseCharacteristic {

	public List<Product> products;

	public IEnumerator Produce(Product product) {
		while(product.isProducing){
			yield return new WaitForSeconds(product.productionRate);
			Instantiate(
				product.productPrefab, 
				product.spawningPoint.position, 
				Quaternion.identity);
		}
	}
}
