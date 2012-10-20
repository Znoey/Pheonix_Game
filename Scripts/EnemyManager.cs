using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : UnitySingleton<EnemyManager> {
	
	private List<GameObject> m_lEnemies = new List<GameObject>();
	public GameObject [] EnemyPrefabArray;
	
	public override void Init ()
	{
		base.Init ();
		
		
	}
}
