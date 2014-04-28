using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private int m_Energe = 0;
	private int m_EnergeMax = 100;
	private float m_EnergeInterval = 0.2f;
	private float m_EnergeTime = 0;

	private float m_GetCardInterval = 2.0f;
	private float m_GetCardTime = 0;
	
	private PropertyCard m_propertyCard;

	public UISlider progressBar;


	// Use this for initialization
	void Start () 
	{
		m_propertyCard = new PropertyCard();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameUpdate();
	}

	public void GameUpdate()
	{
		UpdateEnerge();
		UpdateCard();
	}

	private void UpdateEnerge()
	{
		if (m_EnergeTime > m_EnergeInterval)
		{
			if (m_Energe < m_EnergeMax)
			{
				SetEnerge(m_Energe + 1);
			}
			m_EnergeTime = 0;
		}
		else
		{			
			m_EnergeTime += Time.deltaTime;
		}
	}

	public void SetEnerge(int energe)
	{
		m_Energe = energe;
		progressBar.value = m_Energe / 100.0f;
	}
	
	private void UpdateCard()
	{
		if (m_GetCardTime > m_GetCardInterval)
		{
			GetOneCard();
			m_GetCardTime = 0;
		}
		else
		{			
			m_GetCardTime += Time.deltaTime;
		}
	}

	public void GetOneCard()
	{
		m_propertyCard.GetOneCard();
	}
	

}
