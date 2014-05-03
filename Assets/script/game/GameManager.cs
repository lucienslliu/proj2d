using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour 
{
	public Player player1;
	public Player player2;

	public BattleField m_BattleField;

	public static GameManager Instance;

	public GameObject m_GameOverWidget;


	// Use this for initialization
	void Start ()
	{
		Instance = this;
		m_GameOverWidget.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void GameOver(Player loser)
	{
		int i = 0;
		if (loser == player1)
		{
			i = 1;
		}

		m_GameOverWidget.SetActive(true);
	}

	public Player GetOtherPlayer(Player p)
	{
		if (p == player1)
		{
			return player2;
		}

		return player1;
	}

	public void OnClickRestart()
	{
		Application.LoadLevel("Game");
	}

}
