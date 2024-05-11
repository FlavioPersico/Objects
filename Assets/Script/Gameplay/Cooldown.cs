using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private Image cooldown;
	[SerializeField] private bool coolingDown;
    private float waitTime = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if(coolingDown == true)
        {
            cooldown.fillAmount -= 1.0f/waitTime * Time.deltaTime;
            if(cooldown.fillAmount <= 0.0f)
            {
                SetCollingDown(false);
            }
        }
    }

    public bool GetCollingDown()
    {
        return coolingDown;
	}

	public void SetCollingDown(bool collingDownParam)
	{
        if (collingDownParam == true)
        {
			cooldown.fillAmount = 1.0f;
		}
		coolingDown = collingDownParam;
	}
}
