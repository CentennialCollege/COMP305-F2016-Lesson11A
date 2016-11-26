using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	public AudioSource CoinSound;

	private WaitForSeconds waitTime = new WaitForSeconds(0.6f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (PlayCoinSound ());
		}


	}

	// CoRoutine
	IEnumerator PlayCoinSound() {
		CoinSound.Play ();
		yield return this.waitTime;
		Destroy (this.gameObject);
	}

}
