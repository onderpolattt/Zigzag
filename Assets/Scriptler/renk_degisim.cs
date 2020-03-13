using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renk_degisim : MonoBehaviour
{
	public Color[] renkler;
	Color ilk_renk;
	Color ikinci_renk;
	int br_renk;
	public Material	 zemin_material;
    void Start()
    {
		 br_renk = Random.Range (0,renkler.Length);
		zemin_material.color = renkler[br_renk];
		Camera.main.backgroundColor = renkler[br_renk];
		ikinci_renk = renkler[ikinci_renk_belirle()];
	}
	int ikinci_renk_belirle(){
		int ik_renk;
		if (renkler.Length <= 1) {
			ik_renk = br_renk;
			return ik_renk;
		}
		 ik_renk = Random.Range (0,renkler.Length);
		while (ik_renk==br_renk) {
			ik_renk = Random.Range (0,renkler.Length);
		}
		return ik_renk;
	}

    void Update()
    {
		Color fark = zemin_material.color - ikinci_renk;
		if (Mathf.Abs (fark.r) +Mathf.Abs(fark.g)+Mathf.Abs(fark.b) < 0.2f  ){
			ikinci_renk = renkler[ikinci_renk_belirle()];
		}
	zemin_material.color = Color.Lerp(zemin_material.color,ikinci_renk,0.003f);
		Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor ,ikinci_renk, 0.0007f);
    }
}
