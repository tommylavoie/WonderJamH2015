﻿using UnityEngine;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {
    public float radius = 0.5f;
	Transform target;
	Map map;
	Path path;
	PathNode node;

	// Use this for initialization
	void Start () {
		map = Map.Instance;
		path = map.createPath(map.getNodeByName("A1"), map.getNodeByName("F1"));
		node = path.getNextEdge().getNodeTo();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, node.gameObject.transform.position, 2 * Time.deltaTime);
	}

	public void setPath(Path path){
		this.path = path;
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.name.Equals("F1")){
			Destroy (this.gameObject);
		}
		if (collision.tag != "Noeud") {
			return;
		}
		if (collision.gameObject.name == node.name) {
			node = path.getNextEdge().getNodeTo();
		}
	}
}
