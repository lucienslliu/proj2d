using UnityEngine;
using System.Collections;

public class CardMgr : MonoBehaviour 
{
	public static CardMgr Instance;

	public cardInfo[] cardTemplate = new cardInfo[2];

	// Use this for initialization
	void Start () 
	{
		Instance = this;
		cardTemplate.SetValue(new cardInfo(0, 10, 5, 2), 0);
		cardTemplate.SetValue(new cardInfo(0, 20, 7, 3), 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
