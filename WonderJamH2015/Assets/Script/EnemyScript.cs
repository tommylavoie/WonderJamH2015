using UnityEngine;
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!map.isGameOver())
			transform.position = Vector3.MoveTowards (transform.position, node.gameObject.transform.position, 10 * Time.deltaTime);
        //transform.Translate(new Vector3(0, 0, 0.05f));
    }

	public void setPath(Path path){
		this.path = path;
		node = path.getNextEdge().getNodeTo();
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

	public void kill()
	{
		Destroy(gameObject);
	}
}
