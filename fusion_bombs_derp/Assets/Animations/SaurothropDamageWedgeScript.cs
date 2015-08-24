using UnityEngine;
using System.Collections;

public class SaurothropDamageWedgeScript : MonoBehaviour {


	public Sprite damagedSprite;
	public Color color = Color.white;
	
	private SpriteRenderer spriteRenderer;
	private PartialDamageScript partialDamage;

	// Use this for initialization
	void Start () {
		partialDamage = GetComponent<PartialDamageScript>();
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		if(partialDamage.hp <= 0){
			spriteRenderer.sprite = damagedSprite;
			spriteRenderer.color = color;
		}
	}
}
