using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private Player myPlayer;
    public Vector2 direction;
	public float angleToRotate;
	private bool powerUp;
	// Start is called before the first frame update
	void Start()
    {
        myPlayer = GetComponent<Player>();
    }

	private void Update()
	{

		powerUp = myPlayer.GetPowerUp();
		if (powerUp)
		{
			if(Input.GetMouseButton(0))
			{
				myPlayer.Attack();
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				myPlayer.Attack();
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			bool updateNukeUI = UiManager.singleton.UpdateNuke("Use");

			if (updateNukeUI)
			{
				myPlayer.NukeBomb();
			}
		}
	}

	void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");


		direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		angleToRotate = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;

		myPlayer.Move(new Vector2 (horizontalInput, verticalInput), angleToRotate);
	}
}
