using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize = new Vector2Int(1,1);
    [SerializeField] GameEventTransform objectEvent;
    [SerializeField] GameEvent gameOverEvent;
    [SerializeField] GameObject pointPrefab;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] bool drawGrid;
    public Dictionary<Transform, Vector2> objectsOnGridDictionary = new Dictionary<Transform, Vector2>();
    public static Dictionary<string, Queue<GameObject>> queueDictionary = new Dictionary<string, Queue<GameObject>>(); 
    float bombIndicator = 0.1f;
    float total;
    float precentage;
    float bombs;
    float points;

    RectTransform rectTransform;
    float width;
    float heigh;
    float rectCellWidth;
    float rectCellHeight;
  
    private float time = 1;

    private void Start()
    { 
        objectEvent.reciveEvent += RemoveFromList;
        gameOverEvent.reciveEvent += GameOver;

        Init();

        if(!queueDictionary.ContainsKey(bombPrefab.tag))
            queueDictionary.Add(bombPrefab.tag, new Queue<GameObject>());
        if(!queueDictionary.ContainsKey(pointPrefab.tag))
            queueDictionary.Add(pointPrefab.tag, new Queue<GameObject>());

        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            var gridPosition = new Vector2(Random.Range(0, gridSize.x),Random.Range(0, gridSize.y));
            var x = rectTransform.transform.position.x + rectCellWidth * gridPosition.x + rectCellWidth/2;
            var y = rectTransform.transform.position.y + rectCellHeight * gridPosition.y + rectCellHeight/2;

            if(objectsOnGridDictionary.ContainsValue(gridPosition))
                continue;

            var spawnedItem = RandomObject();

            
            if(queueDictionary[spawnedItem.tag].Count > 0)
            {
                spawnedItem = queueDictionary[spawnedItem.tag].Dequeue();
                objectsOnGridDictionary.Add(spawnedItem.transform, gridPosition);

                spawnedItem.transform.position = new Vector3(x, y, 0);
                spawnedItem.SetActive(true);
            }
            else
            {
                spawnedItem = Instantiate(spawnedItem, new Vector3(x, y, 0), Quaternion.identity, rectTransform.transform); 
                objectsOnGridDictionary.Add(spawnedItem.transform, gridPosition);  
            }

            yield return new WaitForSeconds(GameManager.instance.SpawnDificultyCalculating());
        }
    }
    private GameObject RandomObject()
    {
        total = bombs + points;
        precentage = (bombs/total) * 100;

        if(precentage > 10)
            bombIndicator -= 0.1f;
        else
            bombIndicator += 0.1f;

        bombIndicator = Mathf.Clamp01(bombIndicator);
        
        var value = Random.Range(0,1f);

        if(value < bombIndicator)
        {
            bombs += 1;
            return bombPrefab;
        }
        else
        {
            points += 1;
            return pointPrefab;
        }
    }
    

    public void RemoveFromList(Transform transform)
    { 
        if(objectsOnGridDictionary.ContainsKey(transform))
            objectsOnGridDictionary.Remove(transform);
    }

    private void Init()
    {
        rectTransform = GetComponent<RectTransform>();


        Vector3[] v = new Vector3[4];
        rectTransform.GetWorldCorners(v);

        width = (v[1] - v[2]).magnitude;
        heigh = (v[0] - v[1]).magnitude;

        rectCellWidth = width / (float)gridSize.x;
        rectCellHeight = heigh / (float)gridSize.y;
    }

  
    private void OnDrawGizmos() {
        if(!drawGrid)
            return;

        Init();

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                var xR = rectTransform.transform.position.x + rectCellWidth * x;
                var yR = rectTransform.transform.position.y + rectCellHeight * y;
                var point = new Vector2(xR,yR);
                Gizmos.DrawLine(point, point + Vector2.right * rectCellWidth);
                Gizmos.DrawLine(point, point + Vector2.up * rectCellHeight);
            }
        }
    }

    private void GameOver() => StopAllCoroutines();
    private void OnDestroy() {
        objectEvent.reciveEvent -= RemoveFromList;
        gameOverEvent.reciveEvent -= GameOver;
        queueDictionary.Clear();
    }
    
}
