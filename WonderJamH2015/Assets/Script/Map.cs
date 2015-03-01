//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18052
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
	private List<PathNode> nodes;
	private System.Random random;
	private bool Started = false;
	private bool GameOver = false;
	private bool WaveStarted = false;


	private static Map instance;
	
	private Map() 
	{
		random = new System.Random();
		nodes = new List<PathNode>();
	}
	
	public static Map Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new Map();
			}
			return instance;
		}
	}

	public void restartInstance()
	{
		instance = new Map();
	}

	public void addNode(PathNode node)
	{
		nodes.Add(node);
	}
	
	public PathNode getNodeByName(string name)
	{
		foreach(PathNode node in nodes)
		{
			if(node.name.Equals(name))
			{
				return node;
			}
		}

		return null;
	}

	public bool isNewNode(List<PathNode> nodesInPath, PathNode node)
	{
		foreach(PathNode n in nodesInPath)
		{
			if(n == node)
			{
				return false;
			}
		}
		return true;
	}

	public Path createPath(PathNode startNode, PathNode endNode)
	{
		Path path = new Path();
		PathNode actualNode = startNode;
		List<PathNode> nodesInPath = nodesInPath = new List<PathNode>();

		while(actualNode != endNode)
		{
			PathEdge edge = null;
			List<PathEdge> edges = actualNode.getEdges();
			int edgesCount = edges.Count;
			bool found = false;
			while(!found)
			{
				int rand = getRandomInt(0, edgesCount);
				edge = edges[rand];
				found = isNewNode(nodesInPath, edge.getNodeTo());
			}
			nodesInPath.Add(edge.getNodeTo());
			path.addEdge(edge);
			actualNode = edge.getNodeTo();
		}

		return path;
	}

	public int getRandomInt(int min, int max)
	{
		int rand = random.Next(0, max);
		return rand;
	}

	public bool isStarted()
	{
		return Started;
	}
	
	public void setStarted(bool over)
	{
		Started = over;
	}

	public bool isGameOver()
	{
		return GameOver;
	}

	public void setGameOver(bool over)
	{
		GameOver = over;
	}

	public bool isWaveStarted()
	{
		return WaveStarted;
	}
	
	public void setWaveStarted(bool over)
	{
		WaveStarted = over;
	}
}

