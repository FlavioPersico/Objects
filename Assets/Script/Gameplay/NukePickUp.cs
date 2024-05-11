using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickUp : PickUp
{
	[SerializeField]
	private float timer;
	[SerializeField]
	private float nukeLifeTime;

	private void Awake()
	{
		//spawnProbability = 0.3f;
	}

	private void Update()
	{
		NukeLifeTimeEnd();
	}

	protected override void PickMe(Character character)
	{
		bool pickUp = UiManager.singleton.UpdateNuke("Add");

		if (pickUp)
		{
			base.PickMe(character);
		}
	}

	private void NukeLifeTimeEnd()
	{
		timer += Time.deltaTime;
		if (timer > nukeLifeTime) 
		{
			Destroy(gameObject);
		}
	}

	public override float SpawnProbability()
	{
		return base.SpawnProbability();
	}
}
