using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] public Vector2Int gridSize = new Vector2Int(1,1);
    [SerializeField] private AnimationCurve dificultyCurveLvl;
    [SerializeField] private GameEventTransform objectEvent;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] float bombIndicator = 0.1f;
    [SerializeField] float total;
    [SerializeField] float precentage;
    public Dictionary<Transform, Vector2> objectsOnGridDictionary = new Dictionary<Transform, Vector2>();

    float width;
    float heigh;
    float rectCellWidth;
    float rectCellHeight;
    RectTransform rectTransform;
    float bombs;
    float points;
    private void Start()
    {
        objectEvent.reciveEvent += RemoveFromList;

        Init();

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

            var spawnedObject = Instantiate(RandomObject(), new Vector3(x, y, 0), Quaternion.identity, rectTransform.transform); 

            objectsOnGridDictionary.Add(spawnedObject.transform, gridPosition);

            yield return new WaitForSeconds(dificultyCurveLvl.Evaluate(time));
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
    
    float time = 0;

    public void RemoveFromList(Transform transform)
    { 
        if(objectsOnGridDictionary.ContainsKey(transform))
            objectsOnGridDictionary.Remove(transform);
    }

    private void Update() {
        time += Time.deltaTime;
        
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

    [SerializeField] bool drawGrid;
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

    private void OnDestroy() {
        objectEvent.reciveEvent -= RemoveFromList;
    }
    
}
