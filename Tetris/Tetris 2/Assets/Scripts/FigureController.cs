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
	private GameController _game;
	private int _x;
	private int _y;
	
	public void SetGameController(GameController game)
	{
		_game = game;
		_x = 6;
		_y = 0;
	}
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
			case FigureType.LeftG: 
				InitLeftG();
				break;
			case FigureType.RightG: 
				InitRightG();
				break;
			case FigureType.N: 
				InitN();
				break;
			case FigureType.Plus: 
				InitPlus();
				break;
			case FigureType.T: 
				InitT();
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
				if(_game.CanMove(this, _x + horizontalSpeed, _y))
				{
					transform.position = new Vector3(transform.position.x + horizontalSpeed * Speed, transform.position.y, 0f);
					_x += horizontalSpeed;
				}				
			}	
			if(_game.CanMove(this, _x, _y + 1))
			{
				transform.position = new Vector3(transform.position.x, transform.position.y -Speed, 0f);
				_y += 1;
			}
			else
			{
				_game.Destroy(this, _x, _y);
			}
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
			{true, true, true},
			{false, true, false}
		};
	}
	private void InitLeftZ()
	{
		Form = new bool[,]
		{
			{true, true, false},
			{false, true, true}
		};
	}
	private void InitRightZ()
	{
		Form = new bool[,]
		{
			{false, true, true},
			{true, true, false}
		};
	}
	private void InitLeftSix()
	{
		Form = new bool[,]
		{
			{true, true, true},
			{false, true, true}
		};
	}
	private void InitRightSix()
	{
		Form = new bool[,]
		{
			{true, true, true},
			{true, true, false}
		};
	}
	private void InitLeftG()
	{
		Form = new bool[,]
		{
			{true, false, false},
			{true, true, false},
			{false, true, true}
		};
	}
	private void InitRightG()
	{
		Form = new bool[,]
		{
			{false, false, true},
			{false, true, true},
			{true, true, false}
		};
	}
	private void InitN()
	{
		Form = new bool[,]
		{
			{true, true, true},
			{true, false, true}
		};
	}
	private void InitPlus()
	{
		Form = new bool[,]
		{
			{false, true, false},
			{true, true, true},
			{false, true, false}
		};
	}
	private void InitT()
	{
		Form = new bool[,]
		{
			{true, true, true},
			{false, true, false},
			{false, true, false}
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
	RightG,
	N,
	Plus,
	T
}
