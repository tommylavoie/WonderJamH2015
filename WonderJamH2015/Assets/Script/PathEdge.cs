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

public class PathEdge
{
	PathNode from;
	PathNode to;
	
	public PathEdge (PathNode from, PathNode to)
	{
		this.from = from;
		this.to = to;
	}

	public PathNode getNodeTo()
	{
		return to;
	}
}