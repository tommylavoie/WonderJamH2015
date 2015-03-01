using UnityEngine;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {
    public float radius = 0.5f;
    public float speed = 2;
	Transform target;
	Map map;
	Path path;
	PathNode node;
	Animator anim;
	bool mort = false;

	// Use this for initialization
	void Start () {
		map = Map.Instance;
		anim = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!map.isGameOver())
		{
			if(!mort){
				transform.LookAt(node.gameObject.transform.position);
				transform.position = Vector3.MoveTowards (transform.position, node.gameObject.transform.position, speed * Time.deltaTime);
			}
		}
        //transform.Translate(new Vector3(0, 0, 0.05f));
    }

	public void setPath(Path path){
		this.path = path;
		node = path.getNextEdge().getNodeTo();
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.name.Equals("F1")){
			anim.SetTrigger("Fini");
			Invoke("detruire", 1.3f);
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
		mort = true;
		SoundEffectScript.Instance.MakeFillette_ohnonSound();
		anim.SetTrigger ("Mort");
		Invoke("detruire", 2);
	}

	void detruire(){
		Destroy (this.gameObject);
	}
}
