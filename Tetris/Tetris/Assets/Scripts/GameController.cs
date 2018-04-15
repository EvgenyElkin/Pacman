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
	
	private GameObject[,] _map;
	private System.Random _rand;
	
	public void Start()
	{
		_map = new GameObject[Width, Height];
		_rand = new System.Random();
		CreateFigure();
		CreateFigure();
		CreateFigure();
	}

	private void CreateFigure()
	{
		var figure = Figures[_rand.Next(Figures.Length)];
		Instantiate(figure, new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
	}
}