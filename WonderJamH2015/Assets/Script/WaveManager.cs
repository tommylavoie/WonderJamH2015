//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18052
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;
public class WaveManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public Map map;
	public int timeBetweenWaves;
	public int timeBetweenEnnemies;
	int level;
	int numberOfEnemies;
	bool waveStarted;
	bool waveInvoked;
	bool ennemiesInvoked;
	
	void Start()
	{
		map = Map.Instance;
		level = 0;
		numberOfEnemies = -1;
		waveStarted = false;
		ennemiesInvoked = false;
		waveInvoked = false;
		timeBetweenWaves = 5;
		timeBetweenEnnemies = 3;
	}

	void FixedUpdate()
	{
		if (numberOfEnemies > 0 && !ennemiesInvoked) 
		{
			Invoke ("addEnnemies", timeBetweenEnnemies);
			ennemiesInvoked = true;
		} 
		if (!waveStarted && !waveInvoked) 
		{
			Invoke ("startNextWave", timeBetweenWaves);
			waveInvoked = true;
		}

		GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
		if(ennemies.Length <= 0 && numberOfEnemies <= 0)
		{
			waveStarted = false;
		}
	}
	public void startNextWave()
	{
		level++;	
		numberOfEnemies = level*2;
		waveStarted = true;
		waveInvoked = false;
	}

	public Path getEnemyPath(string startNode)
	{
		Path path = map.createPath(map.getNodeByName(startNode), map.getNodeByName("F1"));
		return path;
	}

	public void addEnnemies()
	{
		string[] startNode = new string[] {"A1", "A2", "A3"};
		for(int i=0;i<3;i++)
		{
			if(numberOfEnemies > 0)
			{
				Path enemyPath = getEnemyPath(startNode[i]);
				enemyPrefab.transform.position = map.getNodeByName(startNode[i]).gameObject.transform.position;
				GameObject enemyObject = (GameObject)Instantiate(enemyPrefab);
				EnemyScript enemy = enemyObject.GetComponent<EnemyScript>();
				enemy.setPath(enemyPath);
				numberOfEnemies--;
			}
		}
		ennemiesInvoked = false;
	}
}

