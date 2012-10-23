using UnityEngine;
using System.Collections;
using NotificationCenter;

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
		Notify.AddObserver<PlayerHealthChanged>(this, OnPlayerHealthChanged);
	}

	void OnPlayerHealthChanged(AbstractNotification note)
	{
		PlayerHealthChanged phc = note as PlayerHealthChanged;

		dimensions.x = player.Health / player.MAX_HEALTH * MaxX;
		if(dimensions.x > 0)
			sprite.dimensions = dimensions;
		else 
			gameObject.active = false;
	}
}
