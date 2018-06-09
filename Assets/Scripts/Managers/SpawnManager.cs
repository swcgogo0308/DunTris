using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockColor
{
    public GameObject[] blocks;
}

public class SpawnManager : MonoBehaviour {

    bool isSpawning = true;

    public bool IsSpawning
    {
        get
        {
            return isSpawning;
        }
        set
        {
            isSpawning = value;
        }
    }

    public Transform blockHolder;
    public BlockColor[] blockColors;

    public static int blockCount = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BlockSpawn()
    {
        if (!isSpawning) return;

        int randomColor = Random.Range(0, blockColors.Length);
        int randomBlock = Random.Range(0, blockColors[randomColor].blocks.Length);

        // Spawn Group at current Position
        GameObject temp = Instantiate(blockColors[randomColor].blocks[randomBlock]);

        temp.name = "block" + blockCount;
        blockCount++;


        StartCoroutine(blockChildSetting(temp));



        temp.transform.parent = blockHolder;
        temp.transform.position = new Vector3(6f, 10f, 0f);

        temp.AddComponent<TetrisShape>();
        if (randomBlock == 3) temp.GetComponent<TetrisShape>().DoNotRotate = true;
    }

    IEnumerator blockChildSetting(GameObject temp)
    {
        SpriteRenderer[] tempChilds = temp.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < tempChilds.Length; i++)
        {
            tempChilds[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

        yield return null;
    }
}
