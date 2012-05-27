using UnityEngine;

public class Modifier : Stat 
{
	private int m_modifierStack;
	private int m_modifierStackMax;
	private float m_modifierTime;
	private float m_modifierTimeMax;

	public Modifier()
	{
		Base = 1;
		m_modifierStack = 0;
		m_modifierStackMax = 1;
		m_modifierTime = 0;
		m_modifierTimeMax = 0;
	}

	public int Stack
	{
		get { return m_modifierStack; }
		set { m_modifierStack = value; }
	}

	public int MaxStack
	{
		get { return m_modifierStackMax; }
		set { m_modifierStackMax = value; }
	}

	public float Duriation
	{
		get { return m_modifierTime; }
		set { m_modifierTime = value; }
	}

	public float MaxDuriation
	{
		get { return m_modifierTimeMax; }
		set { m_modifierTimeMax = value; }
	}
}
