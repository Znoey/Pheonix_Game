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
		rigidbody.isKinematic = true;
	}
	
	void TakeDamage(float damage)
	{
		Health -= damage;
		if( Health <= 0 ){
			Health = 0;
			Notify.Post(new PlayerDeath(this));
		}
		GetComponent<tk2dSprite>().color = Color.Lerp(Color.red, Color.white, Health / MAX_HEALTH);
		Notify.Post(new PlayerHealthChanged(this, Health));
	}
	
			
	// Update is called once per frame
	void Update () 
	{
		if( rigidbody.isKinematic ){
			KinematicControls ();
		}
		else {
			PhysicsControls ();
		}
		
		
		if( (_atkSpd <= 0.0f) &&  (Input.GetButton("Fire1") || bFireAllTheTime)){
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

	public void KinematicControls ()
	{
		uForce = Vector3.zero;
		uForce.x += Input.GetAxis("Horizontal");
		uForce.y += Input.GetAxis("Vertical");
		
		if( Input.GetButton("Fire1")){
			Vector3 dir = Input.mousePosition - transform.position;
			dir.z = 0;
			dir.Normalize();
			uForce = dir;
		}
		if( uForce != Vector3.zero ) {
			uForce.Normalize();
			transform.position += uForce * MAX_SPEED * Time.deltaTime;
		}
		
		// TODO: Collision is breaking here because of the kinematic body maybe?
		// I can hand write this if i need to but shouldn't unity handle it for me?
	}

	public void PhysicsControls ()
	{
		uForce = Vector3.zero;
		if( Input.GetButton("Fire1")){
			Vector3 dir = Input.mousePosition - transform.position;
			uForce = dir;
		}
		
		uForce.x += Input.GetAxis("Horizontal");
		uForce.y += Input.GetAxis("Vertical");
		uForce.z = 0;
		uForce.Normalize();
		
		if( uForce != Vector3.zero ){
			//Debug.Log(uForce);
			rigidbody.AddForce(MAX_SPEED * uForce);
		}
		if( rigidbody.velocity.magnitude > MAX_SPEED)
			rigidbody.velocity = Vector3.Normalize(rigidbody.velocity) * MAX_SPEED;
	}
}

namespace NotificationCenter
{
	public class PlayerHealthChanged : Notification<float>
	{
		public PlayerHealthChanged (object _Sender, float Health) : base(_Sender, Health){}
	}
	public class PlayerDeath : AbstractNotification
	{
		public PlayerDeath(object _Sender) : base(_Sender, _Sender) {}
	}
}


