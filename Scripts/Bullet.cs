using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 40.0f;
	public Vector3 direction = Vector3.up;
	
	private Transform myTransform;
	private Ray ray;
	private RaycastHit hit;
	private bool bDestroy = false;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if( !bDestroy )
			myTransform.position += direction * speed;
		ray = new Ray(myTransform.position, direction);
		if( Physics.Raycast(ray, out hit) )
		{
			if( bDestroy )
			{
				Destroy(this.gameObject);
				return;
			}
			if( hit.distance < speed )
			{
				bDestroy = true;
				speed = hit.distance;
				//Destroy(this.gameObject);
				hit.collider.gameObject.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
			}
		}
	
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("Bullet Collision hit=" + collision.collider.name);
		if( collision.collider.name == "top" )
		{
			Destroy(gameObject);
		}
		else if( collision.collider.name.Contains("Enemy"))
		{
			Destroy(this.gameObject);
		}
	}
}
