using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
	[SerializeField]
	private Material mat1;
	[SerializeField]
	private Material mat2;
	[SerializeField]
	private Material startMat;
	private MazeData mazeGenerator;

	public bool Showdebug;


	public int[ , ] data { get; private set; }

	void Awake()
	{
		data = new int[,]
		{
			{1, 1, 1},
			{1, 0, 1},
			{1, 1, 1}
		};
		mazeGenerator = new MazeData();
	}
	void OnGUI()
	{
		if (!Showdebug)
		{
			return;
		}
		int[,] maze = data;
		int rMax = maze.GetUpperBound(0);
		int cMax = maze.GetUpperBound(1);

		string msg = "";

		for (int i = rMax; i >= 0; i--)
		{
			for (int j = 0; j <= cMax; j++)
			{
				if (maze[i, j] == 0)
				{
					msg += "......";
				}
				else {
					msg += "==";
				}
			}
			msg += "\n";
		}
		GUI.Label(new Rect(20, 20, 50, 200),msg);	
	}
	public void GenerateMaze(int sRows, int sCols)
	{
		if (sRows % 2 == 0 && sCols % 2 == 0)
		{
			Debug.LogError("Odd numbers");
		}
		data = mazeGenerator.SetUpData(sRows, sCols);
	}

}
