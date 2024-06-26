using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon: ScriptableObject
{
    [SerializeField] private Bullet bulletReference;
	[SerializeField] private string name;
	[SerializeField] private Sprite icon;
	[SerializeField] public int damage;
    [SerializeField] public float fireRate;
    [SerializeField] private AudioClip shotAudio;
	[SerializeField] private AudioClip nukeAudio;

	public Weapon()
    {

    }
    public Weapon(Bullet bullet)
    {
        this.bulletReference = bullet;
    }

    public void Shoot(Vector2 position, Quaternion direction, string tag)
    {
		Bullet tempBullet = GameObject.Instantiate(bulletReference, position, direction);
        SoundControl.audioPlayer.PlayOneShot(shotAudio, 2f);
		tempBullet.SetUpBullet(tag, damage);
	}

    public void ExplodeNuke()
    {
        var foundEnemies = FindObjectsOfType<Enemy>();

		SoundControl.audioPlayer.PlayOneShot(nukeAudio, 10f);
		for (int i = 0; i < foundEnemies.Length; i++)
        {
            Destroy(foundEnemies[i].gameObject);
            ScoreManager.singleton.IncreaseScore();
        }
	}
}
