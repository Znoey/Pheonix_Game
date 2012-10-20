using UnityEngine;
using System.Collections;

public class AEnemy : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireRate = 0.5f;
	private float rate = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rate -= Time.deltaTime;
		if( rate <= 0.0f)
		{
			rate = fireRate;
			if( Random.Range(0, 100) < 50)
			{
				FireBullet();
			}
		}
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
	
	}
	
	public void FireBullet()
	{
		
	}
}
