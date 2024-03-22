using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProceduralLevelGenerator : MonoBehaviour
{
    public Transform playerTransform;
    public Transform groundTransform;

    public float minGapBetweenObstacles = 30f;
    public float maxGapBetweenObstacles = 60f;
    public float gapIncrease = 4f;
    public float obstacleDestroyDistance = 20f;
    public float initialSpawnPositionZ = 50f;
    
    public float levelFinishPoint = 500f;
    public int maxObstaclesPerLine = 6;
    public GameObject obstaclePrefab;
    public GameObject finishLineTrigger;

    private List<GameObject> spawnedObstacleRows = new List<GameObject>();
    private float obstacleSpawnLimitX;

    private void Start()
    {
        int levelNum = GameManager.LevelNum;
        levelFinishPoint = levelNum * levelFinishPoint;

        obstacleSpawnLimitX = groundTransform.transform.localScale.x / 2 - 1;

        for (int i = 0; i < 10; i++)
        {
            SpawnObstacleRow();
        }

        Instantiate(finishLineTrigger, new Vector3(0f, 0f, levelFinishPoint + minGapBetweenObstacles), Quaternion.identity);
    }

    private void Update()
    {
        CheckSpawnObstacleRow();
    }

    private void CheckSpawnObstacleRow()
    {
        if (!spawnedObstacleRows.Any()) return;

        GameObject firstObstacleRow = spawnedObstacleRows[0];

        if (playerTransform && playerTransform.position.z - obstacleDestroyDistance > firstObstacleRow.transform.position.z)
        {
            Destroy(firstObstacleRow);
            spawnedObstacleRows.RemoveAt(0);
            SpawnObstacleRow();
        }
    }


    private void SpawnObstacleRow()
    {
        float currentSpawnPositionZ = initialSpawnPositionZ;
        if (currentSpawnPositionZ > levelFinishPoint) return;

        float obstacleWidth = obstaclePrefab.transform.localScale.x;
        GameObject obstacleRow = new GameObject("ObstacleRow");
        obstacleRow.transform.position = new Vector3(0, 0, currentSpawnPositionZ);

        int obstacleCount = 0;

        for (float spawnPositionX = -obstacleSpawnLimitX; spawnPositionX <= obstacleSpawnLimitX; spawnPositionX += obstacleWidth)
        {
            if (Random.Range(0, 2) % 2 == 1) continue;
            if (obstacleCount >= maxObstaclesPerLine) break;
            SpawnObstacle(obstaclePrefab, new Vector3(spawnPositionX, 1.1f, currentSpawnPositionZ), obstacleRow.transform);
            obstacleCount++;
        }

        spawnedObstacleRows.Add(obstacleRow);
        minGapBetweenObstacles += gapIncrease / 2;
        maxGapBetweenObstacles += gapIncrease;
        initialSpawnPositionZ += Random.Range(minGapBetweenObstacles, maxGapBetweenObstacles);
    }

    private void SpawnObstacle(GameObject prefab, Vector3 position, Transform parent)
    {
        GameObject obstacle = Instantiate(prefab, position, Quaternion.identity);
        obstacle.transform.parent = parent;
    }
}
