using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour {

	// PUBLIC VARIABLES FOR TESTING
	public Transform FlashPoint;
	public GameObject MuzzleFlash;
	public GameObject Explosion;
	public GameObject BulletImpact;
	public AudioSource RifleShotSound;
	public Transform PlayerCam;

	// PRIVATE VARIABLES

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame (for Physics)
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			// show the MuzzleFlash at the FlashPoint without any rotation
			Instantiate (this.MuzzleFlash, this.FlashPoint.position, Quaternion.identity);

			// need a variable to hold the location of our Raycast Hit
			RaycastHit hit;

			// if raycast hits an object then do something...
			if (Physics.Raycast (this.PlayerCam.position, this.PlayerCam.forward, out hit)) {

				if (hit.transform.gameObject.CompareTag ("Enemy")) {
					Instantiate (this.Explosion, hit.point, Quaternion.identity);
					Destroy (hit.transform.gameObject);
				} else {
					Instantiate (this.BulletImpact, hit.point, Quaternion.identity);
				}


			}

			// Play Rifle Sound
			this.RifleShotSound.Play();
		}
	}

	void OnTriggerEnter(Collider other) {
		SceneManager.LoadScene ("OutDoor");	
	}

}
