using UnityEngine;

public class Stat
{
	private int m_statBase;

	public Stat()
	{
		m_statBase = 1;
	}

	public virtual int Base
	{
		get { return m_statBase; }
		set { m_statBase = value; }
	}
}
