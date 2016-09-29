using UnityEngine;
using System.Collections;

public class TheGame : MonoBehaviour {
	private DungeonGenerator dg;
	
	// Use this for initialization
	void Start () {
		dg = gameObject.AddComponent<DungeonGenerator>();
		dg.initMap();
		/* A list of nice maps
		 * -124734362 // new fav
		 * 1189082372
		 * 1682143077
		 * -1957273271
		 * -1657662845
		 * -1481552593
		 * -895091740
		 * -846811415
		 */
		
		int [,] map = dg.getMap();
		// randomly place 4 AIs. 
		Random.seed = (int)System.DateTime.Now.Ticks;
		for(int i=0;i<1;i++) {
			bool devam = true;
			do {
				int x = (int)(Random.value * map.GetLength (0));
				int y = (int)(Random.value * map.GetLength (1));
				if(map[x,y] == 0) {
					devam = false;
					GameObject sai = Instantiate(Resources.Load ("Hero", typeof(GameObject))) as GameObject;
					sai.AddComponent<heroAttributes>();
					sai.AddComponent<Logic>();
					sai.tag = "Hero";
					sai.transform.position = new Vector3(x, 0, y);				


				}
			} while (devam);
		}
	//Minions
		for(int i=0;i<3;i++) {
			bool devam = true;
			do {
				int x = (int)(Random.value * map.GetLength (0));
				int y = (int)(Random.value * map.GetLength (1));
				if(map[x,y] == 0) {
					devam = false;
										
					GameObject minion = Instantiate(Resources.Load ("Enemy", typeof(GameObject))) as GameObject;
					minion.AddComponent<minionAttributes>();
					minion.tag = "Minion";
					minion.transform.position = new Vector3(x, 0, y);
				}
			} while (devam);
		}

	//Boss
		for(int i=0;i<1;i++) {
			bool devam = true;
			do {
				int x = (int)(Random.value * map.GetLength (0));
				int y = (int)(Random.value * map.GetLength (1));
				if(map[x,y] == 0) {
					devam = false;
					
					GameObject boss = Instantiate(Resources.Load ("Boss", typeof(GameObject))) as GameObject;
					boss.AddComponent<bossAttributes>();
					boss.tag = "Boss";
					boss.transform.position = new Vector3(x, 0, y);
				}
			} while (devam);
		}
	}
	
	public int[,] getMap() {
		return dg.getMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
