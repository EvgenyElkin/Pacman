using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
	public FigureType Type;
	public bool[,] Form;
	public float Speed;
	public int Period = 10;
	
	private int _counter;
	
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
			case FigureType.Triangle: 
				InitTriangle();
				break;
			case FigureType.LeftZ: 
				InitLeftZ();
				break;
			case FigureType.RightZ: 
				InitRightZ();
				break;
			case FigureType.LeftSix: 
				InitLeftSix();
				break;
			case FigureType.RightSix: 
				InitRightSix();
				break;
		}
	}
	public void Update()
	{
		_counter++;
		if(_counter % Period == 0)
		{
			var horizontalDirection = Input.GetAxis("Horizontal");
			if(horizontalDirection != 0)
			{
				var horizontalSpeed = horizontalDirection > 0 ? 1: -1;
				transform.position = new Vector3(transform.position.x + horizontalSpeed * Speed, transform.position.y, 0f);				
			}
			transform.position = new Vector3(transform.position.x, transform.position.y -Speed, 0f);
		}
		
	}
	#region inits
	private void InitPlane()
	{
		Form = new bool[,]
		{
			{true, true, true, true}
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
	private void InitTriangle()
	{
		Form = new bool[,]
		{
			{false, true, false},
			{true, true, true}
		};
	}
	private void InitLeftZ()
	{
		Form = new bool[,]
		{
			{true, false},
			{true, true},
			{false, true}
		};
	}
	private void InitRightZ()
	{
		Form = new bool[,]
		{
			{false, true},
			{true, true},
			{true, false}
		};
	}
	private void InitLeftSix()
	{
		Form = new bool[,]
		{
			{true, false},
			{true, true},
			{true, true}
		};
	}
	private void InitRightSix()
	{
		Form = new bool[,]
		{
			{false, true},
			{true, true},
			{true, true}
		};
	}
	#endregion
}
public enum FigureType
{
	Plane,
	Square,
	Triangle,
	LeftZ,
	RightZ,
	LeftSix,
	RightSix,
	LeftG,
	RightG
}
