using UnityEngine;
using System.Collections;

public class minionAttributes : MonoBehaviour {
	
	int numb;
	int numb2;

	public int dex = 1;
	public int str = 1;
	public int mag = 1;
	public int vit = 1;
	
	public float hp;
	public float mp;

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
	
		swordDam = swordDamage(dex, str);
		bowDam = bowDamage(dex, str);
		staffDam = staffDamage(dex, str);
		magicMiss = magicMissile(dex, mag);
		cureWound = cureWounds(mag, vit);
	}
	
	
	int giveMeRandom (){
		int random;
		random = Random.Range (0, 3);
		return random;
	
	}



	
	// Use this for initialization
	void Awake () {
		
		
				
		
		


		do {
			numb = giveMeRandom();
			numb2 = giveMeRandom ();
			if(numb != numb2) break;
		} while(numb == numb2);
		

		switch (numb) {
		case 0:
			dex++;
			break;
		case 1:
			str++;
			break;
		case 2:
			mag++;
			break;
		case 3:
			vit++;
			break;
		}
		switch (numb2) {
		case 0:
			dex++;
			break;
		case 1:
			str++;
			break;
		case 2:
			mag++;
			break;
		case 3:
			vit++;
			break;
		}

		


		Debug.Log ("Dex: " + dex);
		Debug.Log ("Str: " + str);
		Debug.Log ("Mag: " + mag);
		Debug.Log ("Vit: " + vit);

		Debug.Log ("//////////");
		
		
			
		setStats ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
