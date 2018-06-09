using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : MonoBehaviour {
    public static int gridWidth = 11;
    public static int gridHeight = 15;

    public float fallSpeed;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    #region Methods

    void Start () {
        FindObjectOfType<SpawnManager>().BlockSpawn();
	}
	
	void Update () {
        FindObjectOfType<TetrisShape>().FallSpeed = fallSpeed;
    }

    public bool IsFullRowAt (int y)
    {
        
        for(int x = 1; x < gridWidth; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteBlockAt (int y)
    {
        for (int x = 1; x < gridWidth; ++x)
        {
            Destroy(grid[x, y].gameObject);

            grid[x, y] = null;
        }
    }

    public void MoveRowDown(int y)
    {
        for(int x = 1; x< gridWidth; ++x)
        {
            if(grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];

                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowsDown(int y)
    {
        for(int i = y; i < gridHeight; ++i)
        {
            MoveRowDown(i);
        }
    }

    public void DeleteRow()
    {
        for(int y = 0; y < gridHeight; ++y)
        {
            if (IsFullRowAt(y))
            {
                DeleteBlockAt(y);
                MoveAllRowsDown(y + 1);
                --y;
            }
        }
    }

    public void UpdateGrid(TetrisShape tetris)
    {
        for(int y = 0; y < gridHeight; ++y)
        {
            for(int x = 0; x < gridWidth; ++x)
            {
                if(grid[x,y] != null)
                {
                    if(grid[x,y].parent == tetris.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach(Transform mino in tetris.transform)
        {
            Vector2 pos = Round(mino.position);

            if(pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    public Transform GetTransformGridPosition(Vector2 pos)
    {
        if(pos.y > gridHeight - 1)
        {
            return null;
        } else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    public bool CheckLineOver(Vector2 pos)
    {
        return ((int)pos.y >= gridHeight);
    }

    public void LineOver()
    {
        FindObjectOfType<SpawnManager>().IsSpawning = false;
    }

    public bool CheckIsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 1 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round(Vector3 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public void FallSpeedChange(float fallSpeed)
    {
        this.fallSpeed = fallSpeed;
    }
    #endregion

}
