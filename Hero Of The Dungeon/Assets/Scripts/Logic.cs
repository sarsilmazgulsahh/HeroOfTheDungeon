using UnityEngine;
using System.Collections;

public class Logic : MonoBehaviour {

	public bossAttributes boss;
	public minionAttributes minion;
	public heroAttributes hero;

	public minionAttributes currentMinion;

	float timeLast;
	float timeLastAttack;
	float totalHealth = 0;
	float currentHp;
	float currentMp;

	string damType;

	void SwordAttack(){
			if (currentMinion.hp > 0){
				currentMinion.hp--;

			if(currentMinion.hp<=0){

				GameObject.FindGameObjectWithTag("Hero").GetComponent<Astar>().Move();
				Destroy(currentMinion.gameObject);
			}

			//currentMinion.hp = currentMinion.hp - hero.swordDam;
			} else {
				currentMinion.hp = 0;
			}

	}


	void BowAttack(){
			if (currentMinion.hp > 0) {
			currentMinion.hp--;
			//currentMinion.hp = currentMinion.hp - hero.bowDam;
		


			if (currentMinion.hp <= 0) {

				Destroy(currentMinion.gameObject);
			
				GameObject.FindGameObjectWithTag ("Hero").GetComponent<Astar> ().Move ();
				Destroy(currentMinion.gameObject);
			}
		}
		else {
				currentMinion.hp = 0;
			}
	
	}




	void Start()
	{
		boss = GameObject.FindWithTag("Boss").GetComponent<bossAttributes>();
		minion = GameObject.FindWithTag("Minion").GetComponent<minionAttributes>();
		hero = GameObject.FindWithTag("Hero").GetComponent<heroAttributes>();

		currentHp = hero.hp;
		currentMp = hero.mp;
	}

	void Update()
		{


	

		float timeSinceLast = Time.time - timeLast;
		float timeSinceLastAttack = Time.time - timeLastAttack;

		if (timeSinceLastAttack > 1 && damType == "sword") {
			SwordAttack();
			timeLastAttack = Time.time;
		}

		if (timeSinceLastAttack > 1 && damType == "bow") {
			BowAttack();
			timeLastAttack = Time.time;
		}
		




		if (timeSinceLast > 1 && currentMp < hero.mp) {
			
			manaRegen();
			timeLast = Time.time;
		}

		if (timeSinceLast > 1 && currentHp < hero.hp) {

			hpRegen();
			timeLast = Time.time;
		}

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, fwd, out hit, 5) && hit.collider.tag == "Minion") 
		{

			currentMinion = hit.collider.gameObject.GetComponent<minionAttributes>();
			Debug.Log(hit.collider.name);
			Decide();

		}
	}

	void Decide()
	{
		Debug.Log ("Decide girdi");
		Attack ();


		totalHealth = hero.hp;
		if (hero.hp < totalHealth * 3 / 10) 
		{
			
		}

	}

	void manaRegen(){
		hero.hp += hero.hpGen;
	}
	void hpRegen() {
		hero.mp += hero.mpGen;
	}

	void Attack(){
		Debug.Log ("Attack girdi");
		int number = enGucluAtak ();
		Debug.Log ("Number döndü: " + number);

		if (true) {
			switch (number) {
			case 0:

				Debug.Log ("Sword Dam");
				damType = "sword";

				break;
			case 1:
				Debug.Log ("Bow Dam");
				damType = "bow";

				break;
			case 2:
				currentMinion.hp = currentMinion.hp - hero.staffDam;
				Debug.Log ("Staff Dam");
				break;
			case 3:
				currentMinion.hp = currentMinion.hp - hero.magicMiss;
				Debug.Log ("Magic Miss");
				break;


			}
		}
	}
	
	int enGucluAtak(){
		int[] powerfull;
		powerfull = new int[]{hero.swordDam, hero.bowDam, hero.staffDam, hero.magicMiss};
		
		int enBuyuk = powerfull[0];
		int sayi = 0;
		for(int i=1;i<3;i++){
			
			if(enBuyuk < powerfull[i]){
				enBuyuk = powerfull[i];
				sayi = i;
			}
		}
		return sayi;
	}

//		bool manaEnough(){
//			return true;
//		}
	}




