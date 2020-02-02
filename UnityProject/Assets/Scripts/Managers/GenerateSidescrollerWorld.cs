using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GenerateSidescrollerWorld : MonoBehaviour
{
    public Transform target;
    public List<GameObject> trapPrefabs;
    public Vector2 borderBoundaries;

    public float generationDistance = 30;
    public float generationCheckDistance = 10;
    public float checkStep = 1f;
    [Range(0, 1)]
    public float spawnThreshold = .5f;
    public float noiseScale = 2;


    private Queue<Vector2> queue;
    private float nextSpawnFromX = 0;

    private void Awake()
    {
        queue = new Queue<Vector2>();
    }
    //private void Start()
    //{
    //    StartNewGeneratio();
    //}

    private void Update()
    {
        if (queue is null || queue.Count <= 0)
            return;
        do
        {
            Vector2 position = queue.Dequeue();
            int index = Random.Range(0, trapPrefabs.Count);
            float zAngle = Random.Range(-180, 180);
            Quaternion randomZRotation = Quaternion.Euler(0, 0, zAngle);

            GameObject trap = Instantiate(trapPrefabs[index], position, randomZRotation, transform) as GameObject;
        } while (queue.Count > 0);
    }
    private void FixedUpdate()
    {
        if (target is null) return;

        if (target.position.x >= nextSpawnFromX - generationCheckDistance)
        {
            StartNewGeneratio();
        }
    }
    public void StartNewGeneratio()
    {
        Thread t = new Thread(GenerateChunk);
        t.Start(nextSpawnFromX);
        nextSpawnFromX += generationDistance;
    }

    private void GenerateChunk(System.Object obj)
    {
        float startingX = (float)obj;
        for (float x = startingX; x < nextSpawnFromX; x += checkStep)
        {
            for (float y = borderBoundaries.x; y <= borderBoundaries.y; y += checkStep)
            {
                float noiseValue = Mathf.PerlinNoise(x * noiseScale, y * noiseScale);
                if (noiseValue >= spawnThreshold)
                    queue.Enqueue(new Vector2(x, y));
            }
        }
    }
}
