using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireRate = 0.5f;
	private float rate = 0.0f;
	public float MAX_HEALTH = 30.0f;
	
	[SerializeField]
	private float m_fHealth;
	public float Health
	{
		get { return m_fHealth;}
		set { m_fHealth = value;}
	}
	
	

	// Use this for initialization
	void Start () {
		Health = MAX_HEALTH;
	}
	
	void TakeDamage(float damage){
		Health -= damage;
		GetComponent<tk2dSprite>().color = Color.Lerp(Color.red, Color.white, Health / MAX_HEALTH);
		if( Health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
		rate -= Time.deltaTime;
		if( rate <= 0.0f)
		{
			rate = Random.Range(fireRate / 2, fireRate * 2);
			if( Random.Range(0, 100) < 50)
			{
				FireBullet();
			}
		}
	
	}
	
	public void FireBullet()
	{
		var bullet = GameObject.Instantiate(bulletPrefab) as GameObject;
		bullet.transform.parent = transform.parent;
		bullet.transform.position = transform.position;
		bullet.GetComponent<Bullet>().direction = -Vector3.up;
		bullet.GetComponent<Bullet>().speed = 10.0f;
		bullet.GetComponent<Bullet>().Source = this.gameObject;
		bullet.GetComponent<tk2dSprite>().color = Color.magenta;
	}
}
