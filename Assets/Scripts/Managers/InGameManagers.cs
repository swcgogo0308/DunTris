using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(TetrisManager))]
[RequireComponent(typeof(SpawnManager))]

public class InGameManagers : MonoBehaviour {

    private static TetrisManager _tetrisManager;
    public static TetrisManager Tetris
    {
        get { return _tetrisManager; }
    }

    private static SpawnManager _spawnManager;
    public static SpawnManager Spawn
    {
        get { return _spawnManager; }
    }

	// Use this for initialization
	void Awake () {
        _tetrisManager = GetComponent<TetrisManager>();
        _spawnManager = GetComponent<SpawnManager>();

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
