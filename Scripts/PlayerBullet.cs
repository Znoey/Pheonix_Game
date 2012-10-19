using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	public float speed = 40.0f;
	public Vector3 direction = Vector3.up;
	
	private Transform myTransform;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.position += Vector3.up * speed * Time.deltaTime;
	}
	
	
	void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("Bullet Collision" + collider.ToString() + "-" + collision.collider.name);
		if( collision.collider.name == "top" )
		{
			Destroy(gameObject);
		}
	}
}
