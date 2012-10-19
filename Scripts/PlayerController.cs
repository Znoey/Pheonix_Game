using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float MAX_SPEED = 90.0f;
	public float attackSpeed = 0.5f;
	private float _atkSpd = 0.0f;
	private Vector3 uForce = Vector3.zero;
	
	public GameObject bulletPrefab;
		
	// Update is called once per frame
	void Update () {
	
		uForce = Vector3.zero;
		
		uForce.x += Input.GetAxis("Horizontal");
		uForce.y += Input.GetAxis("Vertical");
		uForce.Normalize();
		
		if( uForce != Vector3.zero )
		{
			//Debug.Log(uForce);
			rigidbody.AddForce(MAX_SPEED * uForce);
		}
		else
		{
			rigidbody.velocity = rigidbody.velocity * 0.99f;
		}
		
		if( Input.GetButton("Fire1") && _atkSpd <= 0.0f)
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
	}
	
	
}
