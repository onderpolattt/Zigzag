using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin_olusturma : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject son_zemin;
    void Start()
    {
        for (int i = 0; i < 50; i++) {
			Zemin_olustur();	

        }
    }

   
   public void Zemin_olustur()
    {
		Vector3 yon;
		if (Random.Range (0,2) == 0) {
			yon = Vector3.right;
		}
		else{
			yon = Vector3.back;
		}
	son_zemin =	Instantiate (son_zemin, son_zemin.transform.position + yon, son_zemin.transform.rotation);
    }
	void Update (){
	}
}
