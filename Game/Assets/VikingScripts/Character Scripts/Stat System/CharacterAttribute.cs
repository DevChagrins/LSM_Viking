using System.Collections.Generic;

public class Attribute : Stat
{
	private SortedDictionary<string, Modifier> m_AttributeCollection;

	private int CalculateBase()
	{
		int baseTotal = Base;
		foreach (KeyValuePair<string,Modifier> att in m_AttributeCollection)
		{
			baseTotal += att.Value.Base;
		}

		return baseTotal;
	}

	public Attribute()
	{
		Base = 1;
	}

	public override int Base
	{
		get { return CalculateBase(); }
	}

	// Create a way to get parts of this attribute
	// Create a way to set parts of this attribute
	
	//public Attribute this[int index]
	//{
	//    get
	//    {
	//        if (index >= m_AttributeCollection.Count)
	//        {
	//            return null;
	//        }

	//        if (index < 0 || m_AttributeCollection.Count <= 0)
	//        {
	//            return null;
	//        }

	//        return m_AttributeCollection[index];
	//    }

	//    set
	//    {
	//        if (index >= m_AttributeCollection.Count)
	//        {
	//            return;
	//        }

	//        if (index < 0 || m_AttributeCollection.Count <= 0)
	//        {
	//            return;
	//        }

	//        m_AttributeCollection[index] = value;
	//    }
	//}
}

public enum AttributeName
{
	Strength,
	Intelligence,
	Dexterity,
	Agility,
	Fortitude,
	Willpower,
	Resilience,
	Toughness
}