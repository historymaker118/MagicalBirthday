using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PicaVoxel;

public class ExplodeOnCollide : MonoBehaviour {

	public AudioSource audioExplode;
	public AudioClip explosion;
	public AudioClip unexpected;
	public AudioSource audioMove;

	private Exploder exploder;
	private Rigidbody2D rb;

	void Start () {
		exploder = GetComponent<Exploder>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		if (rb.velocity.magnitude > 0.1f){
			if (audioMove.isPlaying){
				return;
			}
			audioMove.Play();
		} else {
			audioMove.Stop();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (!GameManager.Instance.AllowExplosions
			|| col.gameObject.tag == "Trolley" 
			|| col.gameObject.tag == "Collectable"
			|| col.gameObject.tag == "NPC"
			|| col.gameObject.tag == "Hazard"
			|| col.gameObject.tag == "Player"){
			return;
		}
		if (Random.Range(0f, 1f) > 0.1f){
			audioExplode.clip = explosion;
		} else {
			audioExplode.clip = unexpected;
		}
		audioExplode.Play();
		exploder.Explode();
	}
}
