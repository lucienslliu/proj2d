using UnityEngine;
using System.Collections;

public class Property
{
	public int m_life;
	public int m_attack;
}

public class Unit : MonoBehaviour 
{
	public Property m_Property = new Property();

	public UILabel m_life;
	public UILabel m_attack;

	public Player m_Owner;

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

	public void SetProperty(cardInfo info)
	{
		m_Property.m_attack = info.attack;
		m_Property.m_life = info.life;

		UpdatePropertyDisp();
	}

	private void UpdatePropertyDisp()
	{
		m_life.text = "life: " + m_Property.m_life.ToString();
		m_attack.text = "atk: " + m_Property.m_attack.ToString();

		if (m_Owner.m_Index == 0)
		{
			m_life.color = new Color(1, 0, 0, 1);
			m_attack.color = new Color(1, 0, 0, 1);
		}
		else
		{
			m_life.color = new Color(0, 1, 0, 1);
			m_attack.color = new Color(0, 1, 0, 1);
		}
	}
}
