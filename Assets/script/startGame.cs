using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame()
	{
		Debug.Log("Login with UserName!");
		Application.LoadLevel("Game");
	}
}
