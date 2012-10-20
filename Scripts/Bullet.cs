using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public GameObject Source {get; set;}
	public float Damage {get; set;}
	public float speed = 40.0f;
	public Vector3 direction = Vector3.up;
	
	private Transform myTransform;
	private Ray ray;
	private RaycastHit hit;
	private bool bDestroy = false;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		Damage = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if( !bDestroy )
			myTransform.position += direction * speed;
		ray = new Ray(myTransform.position, direction * speed);
		if( Physics.Raycast(ray, out hit) )
		{
			if( hit.distance < speed )
			{
				bDestroy = true;
				speed = hit.distance;
				Destroy(this.gameObject);
				hit.collider.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
			}
		}
	
	}
}
