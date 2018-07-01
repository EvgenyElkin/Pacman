using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public int Width;
	public int Height;
	public int SpawnX;
	public int SpawnY;
	public GameObject[] Figures;
	public GameObject Block;
	
	private GameObject[,] _map;
	private System.Random _rand;
	
	
	public void Start()
	{
		_map = new GameObject[Width, Height];
		_rand = new System.Random();
		CreateFigure();
	}
	public bool CanMove(FigureController figure, int x, int y)
	{
		if(x + figure.Form.GetLength(1) > Width || x < 0)
		{
			return false;
		}
		if(y + figure.Form.GetLength(0) > Height || y < 0)
		{
			return false;
		}
		return true;
	}
	public void Destroy(FigureController figure, int x, int y)
	{
		for(var j = 0; j < figure.Form.GetLength(0); j++)
		{
			for(var i = 0; i < figure.Form.GetLength(1); i++)
			{
				if(figure.Form[j, i])
				{
					Instantiate(Block, Transform( new Vector3(SpawnX + x + i, SpawnY - y - j, 0)), Quaternion.identity);
				}
			}
		}
		figure.gameObject.active = false;
		CreateFigure();
	}
	private void CreateFigure()
	{
		var figurePrefab = Figures[_rand.Next(Figures.Length)];
		var controller = figurePrefab.GetComponent<FigureController>();
		controller.Awake();
		var figure = Instantiate(figurePrefab,Transform(controller, new Vector3(SpawnX, SpawnY, 0)), Quaternion.identity);
		figure.GetComponent<FigureController>().SetGameController(this);
	}
	private Vector3 Transform(FigureController figure, Vector3 position)
	{
		return new Vector3(position.x + figure.Form.GetLength(1)/2f, position.y + figure.Form.GetLength(0)/2f, 0);
	}
	private Vector3 Transform(Vector3 position)
	{
		return new Vector3(position.x + 0.5f, position.y + 0.5f, 0);
	}
}