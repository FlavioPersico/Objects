using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeUI : MonoBehaviour
{
    [SerializeField] private Image[] nukeUI;

    public void AddNuke()
    {
        for(int i = 0; i < nukeUI.Length; i++)
        {
            if (!nukeUI[i].IsActive())
            {
                nukeUI[i].gameObject.SetActive(true);
                return;
            }
        }
    }

	public void UseNuke()
	{
		for (int i = (nukeUI.Length-1); i >= 0; i--)
		{
			if (nukeUI[i].IsActive())
			{
				nukeUI[i].gameObject.SetActive(false);
				return;
			}
		}
	}

    public bool FullNukeUI()
    {
		for (int i = 0; i < nukeUI.Length; i++)
		{
			if (!nukeUI[i].IsActive())
			{
				return false;
			}
		}
		return true;
	}

	public bool EmptyNukeUI()
	{
		for (int i = (nukeUI.Length-1); i >= 0; i--)
		{
			if (nukeUI[i].IsActive())
			{
				return false;
			}
		}
		return true;
	}

}
