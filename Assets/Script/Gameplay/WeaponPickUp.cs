using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
	[SerializeField]
	private float timer;
	[SerializeField]
	private float PowerUpLifeTime;

	private void Awake()
	{
		//spawnProbability = 0.5f;
	}

	private void Update()
	{
		PowerUpLifeTimeEnd();
	}

	protected override void PickMe(Character character)
	{
		character.GetComponent<Player>().PowerUp(true);
		base.PickMe(character);
	}

	private void PowerUpLifeTimeEnd()
	{
		timer += Time.deltaTime;
		if (timer > PowerUpLifeTime)
		{
			Destroy(gameObject);
		}
	}

	public override float SpawnProbability()
	{
		return base.SpawnProbability();
	}
}
