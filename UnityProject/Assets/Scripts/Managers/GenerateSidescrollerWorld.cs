using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GenerateSidescrollerWorld : MonoBehaviour
{
    public Transform target;
    public List<GameObject> trapPrefabs;
    public List<GameObject> wallPrefabs;
    public Vector2 borderBoundaries;
    public float wallOffset = -1;
    public float wallUnitLength = 15;

    public float generationDistance = 30;
    public float generationCheckDistance = 10;
    public float checkStep = 1f;
    [Range(0, 1)]
    public float spawnThreshold = .5f;
    public float noiseScale = 2;

    public Transform trapParrent;
    public Transform wallParent;

    public float minSize = .95f;
    public float maxSize = 1.35f;

    private Queue<Vector2> trapQueue;
    private float nextSpawnFromX = 0;

    private void Awake()
    {
        trapQueue = new Queue<Vector2>();
    }

    private void Update()
    {
        if (trapQueue is null || trapQueue.Count <= 0)
            return;
        do
        {
            Vector2 position = trapQueue.Dequeue();
            int index = Random.Range(0, trapPrefabs.Count);
            float zAngle = Random.Range(-180, 180);
            Vector3 size = Vector3.one * Random.Range(minSize, maxSize);
            Quaternion randomZRotation = Quaternion.Euler(0, 0, zAngle);

            GameObject trap = Instantiate(trapPrefabs[index], position, randomZRotation, trapParrent ?? transform) as GameObject;
            trap.transform.localScale = size;
            SelfDestroy sd = trap.AddComponent<SelfDestroy>();
            sd.target = target;
            sd.destroyThreshold = generationCheckDistance;
        } while (trapQueue.Count > 0);
    }
    private void FixedUpdate()
    {
        if (target is null) return;

        if (target.position.x >= nextSpawnFromX - generationCheckDistance)
        {
            StartNewGeneration();
        }
    }
    public void StartNewGeneration()
    {
        Thread t = new Thread(GenerateChunk);
        t.Start(nextSpawnFromX);
        GenerateWalls(nextSpawnFromX);
        nextSpawnFromX += generationDistance;
    }

    public void GenerateWalls(float x)
    {
        for (int i = 1; i <= generationDistance / (wallUnitLength * 2); i++)
        {
            for (int j = 0; j < 2; j++)
            {
                int index = Random.Range(0, wallPrefabs.Count);
                Vector2 position = new Vector2(x + i * wallUnitLength * 2, (borderBoundaries[j] - Mathf.Pow((-1), j) * wallOffset));
                Quaternion rotation = Quaternion.Euler(0, 0, 90 * Mathf.Pow((-1), j));
                GameObject wall = Instantiate(wallPrefabs[index], position, rotation, wallParent) as GameObject;
                SelfDestroy sd = wall.AddComponent<SelfDestroy>();
                sd.target = target;
                sd.destroyThreshold = wallUnitLength + generationCheckDistance;
            }
        }
    }

    private void GenerateChunk(System.Object obj)
    {
        float startingX = (float)obj;
        for (float x = startingX; x < startingX + generationDistance; x += checkStep)
        {
            for (float y = borderBoundaries.x; y <= borderBoundaries.y; y += checkStep)
            {
                float noiseValue = Mathf.PerlinNoise(x * noiseScale, y * noiseScale);
                if (noiseValue >= spawnThreshold)
                    trapQueue.Enqueue(new Vector2(x, y));
            }
        }
    }
}
