using UnityEngine;
using System.Collections.Generic;

public class Board : MonoBehaviour 
{
	Map map;
	// Use this for initialization
	void Start () 
	{
		map = new Map();
		createMap();
		Path path = map.createPath(map.getNodeByName("a1"), map.getNodeByName("f1"));
	}

	void createMap()
	{
		PathNode a1 = new PathNode("a1");
		PathNode a2 = new PathNode("a2");
		PathNode a3 = new PathNode("a3");

		PathNode b1 = new PathNode("b1");
		PathNode b2 = new PathNode("b2");
		PathNode b3 = new PathNode("b3");
		PathNode b4 = new PathNode("b4");
		PathNode b5 = new PathNode("b5");

		PathNode c1 = new PathNode("c1");
		PathNode c2 = new PathNode("c2");
		PathNode c3 = new PathNode("c3");
		PathNode c4 = new PathNode("c4");
		PathNode c5 = new PathNode("c5");

		PathNode d1 = new PathNode("d1");
		PathNode d2 = new PathNode("d2");
		PathNode d3 = new PathNode("d3");
		PathNode d4 = new PathNode("d4");
		PathNode d5 = new PathNode("d5");

		PathNode e1 = new PathNode("e1");
		PathNode e2 = new PathNode("e2");
		PathNode e3 = new PathNode("e3");
		PathNode e4 = new PathNode("e4");
		PathNode e5 = new PathNode("e5");

		PathNode f1 = new PathNode("f1");

		a1.addEdge(b2);
		a2.addEdge(b3);
		a3.addEdge(b4);

		b1.addEdge(c1);
		b1.addEdge(b2);
		b2.addEdge(b1);
		b2.addEdge(b3);
		b2.addEdge(c2);
		b3.addEdge(b2);
		b3.addEdge(b4);
		b3.addEdge(c3);
		b4.addEdge(b3);
		b4.addEdge(b5);
		b4.addEdge(c4);
		b5.addEdge(b4);
		b5.addEdge(c5);

		c1.addEdge(d1);
		c1.addEdge(c2);
		c2.addEdge(c1);
		c2.addEdge(c3);
		c2.addEdge(d2);
		c3.addEdge(c2);
		c3.addEdge(c4);
		c3.addEdge(d3);
		c4.addEdge(c3);
		c4.addEdge(c5);
		c4.addEdge(d4);
		c5.addEdge(c4);
		c5.addEdge(d5);

		d1.addEdge(e1);
		d1.addEdge(d2);
		d2.addEdge(d1);
		d2.addEdge(d3);
		d2.addEdge(e2);
		d3.addEdge(d2);
		d3.addEdge(d4);
		d3.addEdge(e3);
		d4.addEdge(d3);
		d4.addEdge(d5);
		d4.addEdge(e4);
		d5.addEdge(d4);
		d5.addEdge(e5);

		e1.addEdge(f1);
		e1.addEdge(e2);
		e2.addEdge(e1);
		e2.addEdge(e3);
		e2.addEdge(f1);
		e3.addEdge(e2);
		e3.addEdge(e4);
		e3.addEdge(f1);
		e4.addEdge(e3);
		e4.addEdge(e5);
		e4.addEdge(f1);
		e5.addEdge(e4);
		e5.addEdge(f1);

		map.addNode(a1);
		map.addNode(a2);
		map.addNode(a3);
		map.addNode(b1);
		map.addNode(b2);
		map.addNode(b3);
		map.addNode(b4);
		map.addNode(b5);
		map.addNode(c1);
		map.addNode(c2);
		map.addNode(c3);
		map.addNode(c4);
		map.addNode(c5);
		map.addNode(d1);
		map.addNode(d2);
		map.addNode(d3);
		map.addNode(d4);
		map.addNode(d5);
		map.addNode(e1);
		map.addNode(e2);
		map.addNode(e3);
		map.addNode(e4);
		map.addNode(e5);
		map.addNode(f1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
