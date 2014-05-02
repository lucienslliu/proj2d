using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour 
{
	public Player player1;
	public Player player2;

	public BattleField m_BattleField;

	public static GameManager Instance;

	// Use this for initialization
	void Start ()
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void GameOver()
	{

	}
}
