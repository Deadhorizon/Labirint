using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeData
{
	public float placementTreshold;
	public MazeData()
	{
		placementTreshold = .1f;
	}
	public int[,] SetUpData(int sRow, int sCol)
	{
		int[,] maze = new int[sRow, sCol];
		return maze;
	}
}