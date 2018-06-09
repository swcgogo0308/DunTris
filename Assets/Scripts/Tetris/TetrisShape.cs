using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TetrisShape : MonoBehaviour {
    float fall = 0;

    float fallSpeed = 1;
    public float FallSpeed
    {
        get
        {
            return fallSpeed;
        }
        set
        {
            fallSpeed = value;
        }
    }

    bool isValidPosition;

    

    bool freeFall = true;

    bool doNotRotate;

    public bool DoNotRotate
    {
        set
        {
            doNotRotate = value;
        }
    }

    GameObject currentBlockType;


	// Use this for initialization
	void Start () {
        transform.position = new Vector2(6f,15f);
	}
	
	// Update is called once per frame
	void Update () {
        FallDown();
        CheckInput();
	}

    public void MoveHorizontal(Vector2 direction)
    {
        float deltaMovement = (direction.Equals(Vector2.right)) ? 1.0f : -1.0f;

        transform.position += new Vector3(deltaMovement, 0, 0);

        if (CheckIsValidPosition())
        {
            FindObjectOfType<TetrisManager>().UpdateGrid(this);
        }
        else
        {
            transform.position += new Vector3(-deltaMovement, 0, 0);
        }
    }

    void CheckInput()
    {
        if (!freeFall) return;

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(1f, 0f, 0f);

            if(!CheckIsValidPosition())
                transform.position += new Vector3(1f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1f, 0f, 0f);

            if (!CheckIsValidPosition())
                transform.position -= new Vector3(1f, 0f, 0f);
        }


        if(Input.GetKeyDown(KeyCode.UpArrow) && !doNotRotate)
        {
            transform.Rotate(0f, 0f, 90f);

            if (!CheckIsValidPosition())
                transform.Rotate(0f, 0f, -90f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            freeFall = false;
            FindObjectOfType<TetrisManager>().FallSpeedChange(0.01f);
        }
    }

    void FallDown()
    {
        if (Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);

            fall = Time.time;
        }

        if (!CheckIsValidPosition())
        {
            FindObjectOfType<TetrisManager>().FallSpeedChange(0.3f);
            transform.position += new Vector3(0, 1, 0);
            FindObjectOfType<TetrisManager>().DeleteRow(); //가로줄 체크
            
            enabled = false;

            FindObjectOfType<SpawnManager>().BlockSpawn();
            if (CheckIsLineOver()) FindObjectOfType<TetrisManager>().LineOver(); //세로줄 체크
        }
        else
        {
            FindObjectOfType<TetrisManager>().UpdateGrid(this);
        }
    }

    bool CheckIsValidPosition() //다 떨어졌는지 체크
    {
        foreach(Transform t in transform)
        {
            Vector2 pos = FindObjectOfType<TetrisManager>().Round(t.position);

            if (FindObjectOfType<TetrisManager>().CheckIsInsideGrid(pos) == false)
                return false;
            if (FindObjectOfType<TetrisManager>().GetTransformGridPosition(pos) != null && FindObjectOfType<TetrisManager>().GetTransformGridPosition(pos).parent != transform)
                return false;
        }
        return true;
    }

    bool CheckIsLineOver()
    {
        foreach (Transform t in transform)
        {
            Vector2 pos = FindObjectOfType<TetrisManager>().Round(t.position);

            if (FindObjectOfType<TetrisManager>().CheckLineOver(pos))
                return true;
        }
        return false;
    }
}
