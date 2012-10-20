using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public PlayerController player;
	tk2dSlicedSprite sprite;
	Vector3 dimensions;
	float MaxX;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		sprite = GetComponent<tk2dSlicedSprite>();
		dimensions = sprite.dimensions;
		MaxX = dimensions.x;
	}
	
	// Update is called once per frame
	void Update () {

		dimensions.x = player.Health / player.MAX_HEALTH * MaxX;
		if(dimensions.x > 0)
			sprite.dimensions = dimensions;
		else 
			gameObject.active = false;
	}
}
