using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract game state is used by the GameManager 
/// </summary>
public abstract class AbstractGameState 
{
	protected readonly GameManager gameManager;
	protected bool m_bPaused;
	
	public AbstractGameState(GameManager manager)
	{
		gameManager = manager;
	}
	
	public abstract IEnumerator Enter();
	public abstract IEnumerator Pause(bool bPaused);
	public abstract void Update();
	public abstract IEnumerator Exit();
}
