using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : UnitySingleton<EnemyManager> {

	public int numEnemies = 5;
	private List<GameObject> m_lEnemies = new List<GameObject>();
	public GameObject [] EnemyPrefabArray;
	
	public override void Init ()
	{
		base.Init ();

		CreateEnemies();
	}

	public void CreateEnemies ()
	{
		Transform start = GameObject.Find ("Start").transform;
		for (int i = 0; i < numEnemies; i++) {
			var go = GameObject.Instantiate(EnemyPrefabArray[0]) as GameObject;
			go.transform.position = start.position + (Vector3.right * 100) * i;
			go.transform.parent = start.parent;
		}
	}
}
