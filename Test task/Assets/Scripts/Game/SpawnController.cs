using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GeneralData data;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector2 spawnRange;
    [SerializeField] private Vector2 spawnFromPlayer;

    private Transform playerTransform;
    private List<GameObject> enableEnemyObjects = new List<GameObject>();
    private List<GameObject> disableEnemyObjects = new List<GameObject>();

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        InvokeRepeating("SpawnEnemy", 1, data.EnemyGenerateInterval);
        InvokeRepeating("SpawnBonus",1,data.BonusGenerateInterval);
    }

    public void SetObjectInDisable(GameObject _object)
    {
        _object.SetActive(false);
        disableEnemyObjects.Add(_object);
        enableEnemyObjects.Remove(enableEnemyObjects.Find(item => item.gameObject == _object));
    }

    private void SpawnEnemy()
    {
        Vector2 randomPosition = FindRandomPosition();
        if (disableEnemyObjects.Count == 0)
        {
            GameObject newEnemyObject = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enableEnemyObjects.Add(newEnemyObject);
        }
        else
        {
            GameObject newEnemyObject = disableEnemyObjects[0];
            disableEnemyObjects.RemoveAt(0);
            enableEnemyObjects.Add(newEnemyObject);
            newEnemyObject.transform.position = randomPosition;
            newEnemyObject.SetActive(true);
        }
    }

    private void SpawnBonus()
    {
        if (data.BonusPrefabs.Count != 0)
        {
            int numberBonus = Random.Range(0, data.BonusPrefabs.Count);
            Vector2 randomPosition = FindRandomPosition();
            GameObject newBonusObject = Instantiate(data.BonusPrefabs[numberBonus], randomPosition, Quaternion.identity);
            newBonusObject.name = data.BonusPrefabs[numberBonus].name;
        }
    }

    private Vector2 FindRandomPosition()
    {
        int x = Random.Range(Mathf.RoundToInt(-spawnRange.x), Mathf.RoundToInt(spawnRange.x));
        int y = Random.Range(Mathf.RoundToInt(-spawnRange.y), Mathf.RoundToInt(spawnRange.y));
        while (Mathf.Abs(playerTransform.position.x - x) < 2 
            && Mathf.Abs(playerTransform.position.y - y) < 2)
        {
            x = Random.Range(Mathf.RoundToInt(-spawnRange.x), Mathf.RoundToInt(spawnRange.x));
            y = Random.Range(Mathf.RoundToInt(-spawnRange.y), Mathf.RoundToInt(spawnRange.y));
        }
        return new Vector2(x, y);
    }
}
