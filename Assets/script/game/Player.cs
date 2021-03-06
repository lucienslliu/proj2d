﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private int m_Energe = 0;
	private int m_EnergeMax = 100;
	private float m_EnergeInterval = 1f;
	private float m_EnergeTime = 0;

	private float m_GetCardInterval = 4.0f;
	private float m_GetCardTime = 0;
	
	public Transform m_propertyCard;
	public int m_Index;

	private int m_Life = 20;

	public UISlider progressBar;
	public UILabel m_LifeText;

	// Use this for initialization
	void Start () 
	{
		SetLife(m_Life);
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

	public int GetEnerge()
	{
		return m_Energe;
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
		PropertyCard property_card = m_propertyCard.GetComponent<PropertyCard>();
		property_card.GetOneCard(this);
	}

	public int GetLife()
	{
		return m_Life;
	}
	
	public void SetLife(int life)
	{
		m_Life = life;
		m_LifeText.text = "Life:" + m_Life.ToString();
		if (life <= 0)
		{
			GameManager.Instance.GameOver(this);
		}
	}
}
