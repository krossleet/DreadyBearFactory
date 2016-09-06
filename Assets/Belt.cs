﻿using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Belt : MonoBehaviour 
{
	public Transform startMarker;
	//public Transform endMarker;
	public Belt nextBelt;
	public float speed;

	public List<Bear> bears = new List<Bear>();




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nextBelt == null || nextBelt.startMarker == null)
			return;
		
		Transform endMarker = nextBelt.startMarker;
		
		foreach(Bear bear in bears)
		{
			bear.transform.position = Vector3.MoveTowards( bear.transform.position, endMarker.position, speed * Time.deltaTime );
		}

		foreach( Bear bear in bears)
		{
			if (Vector3.Distance( bear.transform.position, endMarker.position ) < 0.001f)
			{
				bears.Remove( bear );
				nextBelt.AddToBelt( bear );
				break; // TODO: shame 
			}
		}

	
	}

	public void AddToBelt(Bear bear)
	{
		bear.transform.position = startMarker.position;
		bears.Add(bear);
	}

	public bool IsRoomOnBelt()
	{
		return true;
	}


}