using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
	public FigureType Type;
	public bool[,] Form;
	
	public void Start()
	{
		switch(Type)
		{
			case FigureType.Plane: 
				InitPlane();
				break;
			case FigureType.Square: 
				InitSquare();
				break;
		}
	}
	private void InitPlane()
	{
		Form = new bool[,]
		{
			{true},
			{true},
			{true},
			{true}
		};
	}
	private void InitSquare()
	{
		Form = new bool[,]
		{
			{true, true},
			{true, true}
		};
	}
}
public enum FigureType
{
	Plane,
	Square,
	
}
