using UnityEngine;
using System.Collections;

public class Property
{
	public int m_life;
	public int m_attack;
}

public class Unit : MonoBehaviour 
{
	public Property m_Property;

	public UILabel m_life;
	public UILabel m_attack;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void UpdateUnit()
	{

	}
}
