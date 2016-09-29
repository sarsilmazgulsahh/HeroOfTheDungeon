using UnityEngine;
using System.Collections;

public class heroAttributes : MonoBehaviour {

	int points = 10;
	int dexStart = 1;
	int magStart = 1;
	int strStart = 1;
	int vitStart = 1;
	public int dex = 0;
	public int str = 0;
	public int mag = 0;
	public int vit = 0;

	public float hp;
	public float mp;
	public float hpGen;
	public float mpGen;
	public int swordDam;
	public int bowDam;
	public int staffDam;
	public int magicMiss;
	public int cureWound;




	float hpCalculation(int str, int vit){
		return (10 * vit) + (5 * str);			
	}

	float mpCalculation(int dex, int mag){
		return (10 * mag) + (5 * dex);			
	}

	float hpGenerate(float hp){
		return 110/hp;			
	}

	float mpGenerate(float mp){
		return 110/mp;			
	}

	int swordDamage(int dex, int str){
		return (3 * str) + dex + 1;
	}

	int bowDamage(int dex, int str){
		return (3 * dex) + str + 1;
	}

	int staffDamage(int dex, int str){
		return (2 * str) + (2 * dex) + 1;
	}

	int magicMissile(int dex, int mag){
		return (3 * mag) + dex + 1;
	}

	int cureWounds(int mag, int vit){
		return -(3 * mag + vit + 1);
	}


	void setStats(){
	
		hp = hpCalculation(str, vit);
		mp = mpCalculation(dex, mag);
		hpGen = hpGenerate(hp);
		mpGen = mpGenerate(mp);
		swordDam = swordDamage(dex, str);
		bowDam = bowDamage(dex, str);
		staffDam = staffDamage(dex, str);
		magicMiss = magicMissile(dex, mag);
		cureWound = cureWounds(mag, vit);
	}



	int enBuyukBul (){
		int i = 0;
		int[] hangisi;
		hangisi = new int[]{dex, str, mag, vit};

		int enBuyuk = hangisi[0];
		int sayi = 0;
		for(i=1;i<3;i++){

			if(enBuyuk < hangisi[i]){
				enBuyuk = hangisi[i];
				sayi = i;
			}
		}
		return sayi;
	
	}

	// Use this for initialization
	void Awake () {
		int numb = 0;

		dex = Random.Range (0, 9);
		points -= dex;
		dex += dexStart;
		str = Random.Range (0, points);
		points -= str;
		str += strStart;
		mag = Random.Range (0, points);
		points -= mag;
		mag += magStart;
		vit = Random.Range (0, points);
		points -= vit;
		vit += vitStart;


//		Debug.Log ("Dex: " + dex);
//		Debug.Log ("Str: " + str);
//		Debug.Log ("Mag: " + mag);
//		Debug.Log ("Vit: " + vit);
	

		numb = enBuyukBul ();
//		Debug.Log ("En buyuk: " + numb);

		switch (numb) {
		case 0:
			dex += points;
			break;
		case 1:
			str += points;
			break;
		case 2:
			mag += points;
			break;
		case 3:
			vit += points;
			break;
		}


//		Debug.Log ("Kalan: " + points);
		setStats ();

	}

	// Update is called once per frame
	void Update () {

	}
}
