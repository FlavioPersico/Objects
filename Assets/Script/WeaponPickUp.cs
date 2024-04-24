using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
	protected override void PickMe(Character character)
	{
		//character.SetWeapon(newWeapon);
		base.PickMe(character);
	}
}
