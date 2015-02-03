using UnityEngine;
using System.Collections;

public class WeaponShoot : MonoBehaviour {
	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;

	Vector3 mousePosition;
//	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;

	void Awake()
	{   
		shootableMask = LayerMask.GetMask ("Shootable");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
		gunLight.enabled = false;	
	}
	void Update () {
		
		//timer += Time.deltaTime;

	}
	public void DisableEffects ()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}
	public void Shoot ()
	{

		//timer = 0f;

		gunAudio.Play ();
		
		gunLight.enabled = true;
		
		gunParticles.Stop ();
		gunParticles.Play ();
		
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		
		shootRay.origin = transform.position;

		shootRay.direction = transform.forward;
		
		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			/*EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{   if(shootHit.collider.Equals(enemyHealth.GetComponent<CapsuleCollider>())) 
				{enemyHealth.TakeDamage (damagePerShot, shootHit.point);}
				else if (shootHit.collider.Equals(enemyHealth.GetComponent<SphereCollider>()))
				{
					enemyHealth.TakeDamage ((damagePerShot*2), shootHit.point);
				}
			} */
			gunLine.SetPosition (1, shootHit.point);
			Debug.Log("enemy shooted");
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}

		DisableEffects ();
	}

}
