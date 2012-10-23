using UnityEngine;
using System.Collections;
using NotificationCenter;

public class PlayerController : MonoBehaviour {
	
	public readonly float MAX_HEALTH = 100f;
	public float MAX_SPEED = 900.0f;
	public float attackSpeed = 0.5f;
	private float _atkSpd = 0.0f;
	private Vector3 uForce = Vector3.zero;
	public bool bFireAllTheTime = true;
	
	[SerializeField]
	private float m_fHealth;
	public float Health
	{
		get { return m_fHealth;}
		set { m_fHealth = value;}
	}
	
	
	public GameObject bulletPrefab;
	
	void Start()
	{
		Health = 100.0f;
	}
	
	void TakeDamage(float damage)
	{
		Health -= damage;
		GetComponent<tk2dSprite>().color = Color.Lerp(Color.red, Color.white, Health / MAX_HEALTH);
		Notify.Post(new PlayerHealthChanged(this, Health));
	}
	
			
	// Update is called once per frame
	void Update () 
	{
	
		uForce = Vector3.zero;
		
		if( Input.GetButton("Fire1"))
		{
			Vector3 dir = Input.mousePosition - transform.position;
			uForce = dir;
			
		}
		
		uForce.x += Input.GetAxis("Horizontal");
		uForce.y += Input.GetAxis("Vertical");
		uForce.z = 0;
		uForce.Normalize();
		
		if( uForce != Vector3.zero )
		{
			//Debug.Log(uForce);
			rigidbody.AddForce(MAX_SPEED * uForce);
		}
		else
		{
			rigidbody.velocity = rigidbody.velocity * 0.9f;
		}
		
		if( (Input.GetButton("Fire1") && _atkSpd <= 0.0f) ||
			(bFireAllTheTime && _atkSpd <= 0.0f))
		{
			FireWeapon();
			_atkSpd = attackSpeed;
		}
		if( _atkSpd > 0)
			_atkSpd -= Time.deltaTime;
			
	
	}
	
	public void FireWeapon()
	{
		// TODO: Enable the weapon to fire.
		var bullet = GameObject.Instantiate(bulletPrefab) as GameObject;
		bullet.transform.parent = transform.parent;
		bullet.transform.localPosition = transform.localPosition;
		bullet.GetComponent<Bullet>().direction = Vector3.up;
		bullet.GetComponent<Bullet>().speed = 20.0f;
		bullet.GetComponent<Bullet>().Source = this.gameObject;
	}
}

public class PlayerHealthChanged : Notification<float>
{
	public PlayerHealthChanged (object _Sender, float Health) : base(_Sender, Health){}
}
