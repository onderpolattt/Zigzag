using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{


	Vector3 yon;
	public float hız;
	public float hızlanma_zorlugu;
	public Zemin_olusturma zemin_olustur;
	public static bool dustu_mu;
	public int skor_artmasi;
	public Text text_skor; 
	float skor;
	int high_score;

    void Start()
    {
		high_score = PlayerPrefs.GetInt("highscore");
		dustu_mu = false;
		yon = Vector3.back;
        
    }

    // Update is called once per frame
    void Update()
    {
		if (dustu_mu == true) {
			return;
		}
      if(Input.GetMouseButtonDown (0)){
			if (yon.x == 0) {
				yon = Vector3.right;
			}
			else{
				yon = Vector3.back;
    }
		}
		if (transform.position.y<0.1f) {
			olunce();
		}
	}
	void olunce(){
		if (high_score < (int)skor) {
			high_score = (int)skor;
			PlayerPrefs.SetInt("highscore",high_score);
			Debug.Log("Yeni Yüksek Skor"); 	
		}
		dustu_mu = true;
		Debug.Log("öldün");
	}
	void FixedUpdate(){
		if (dustu_mu) {
			return;
		}

		Vector3 hareket = yon * Time.deltaTime * hız;
		transform.position +=hareket;
		hız+= hızlanma_zorlugu * Time.deltaTime;
		skor+= (skor_artmasi * hız * Time.deltaTime );
		text_skor.text = ((int) skor).ToString();
	}
	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag == "zemin") {
			StartCoroutine(Kaldır (coll.gameObject));
	 		zemin_olustur.Zemin_olustur();
		}
	}
	IEnumerator Kaldır(GameObject kaldırılacak){
		yield return new WaitForSeconds (0.225f);
		kaldırılacak.AddComponent<Rigidbody> ();
		yield return new WaitForSeconds (1.5f);
		Destroy(kaldırılacak);
	}


}
