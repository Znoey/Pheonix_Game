using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(!GameManager.Exists)
			GameManager.instance.Create();
		else
			Destroy(gameObject);
	}
}
