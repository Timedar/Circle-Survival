using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRendererHUD : Graphic
{
    [SerializeField] public Vector2Int gridSize = new Vector2Int(1,1);
    public float thickness = 10f;
    public List<Vector3> midles = new List<Vector3>();
    float width;
    float heigh;
    float rectCellWidth;
    float rectCellHeight;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.K))
        {
            var pos = new Vector2(Random.Range(0, gridSize.x+1),Random.Range(0, gridSize.y+1));
            SetPoint((int)pos.x,(int)pos.y);

            int xke, yke;
            GetXY(Input.mousePosition, out   xke,   out yke );
            Debug.Log($"x: {xke} y: {yke }");
        }
    }
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        midles.Clear();

        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        rectCellWidth = width / (float)gridSize.x;
        rectCellHeight = height / (float)gridSize.y;

        int count = 0;
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                DrawGrid(vh, x, y, count);
                count++;
            }
        }

    }

    private void DrawGrid(VertexHelper vh, float width, float height, int index)
    {

        float xPos = rectCellWidth * width;
        float yPos = rectCellHeight * height;



        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;




        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, rectCellHeight + yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(rectCellWidth+ xPos, rectCellHeight + yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(rectCellWidth+ xPos, yPos);
        vh.AddVert(vertex);

        // vh.AddTriangle(0,1,2);
        // vh.AddTriangle(2,3,0);


        float widthSqr = thickness * thickness;
        float disctanceSqr = widthSqr / 2f;
        float distance = Mathf.Sqrt(disctanceSqr);

        vertex.position = new Vector3(distance + xPos, distance + yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(distance + xPos, yPos +(rectCellHeight - distance));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (rectCellWidth - distance), yPos + (rectCellHeight - distance));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (rectCellWidth - distance), yPos + distance);
        vh.AddVert(vertex);

        int offset = index *8;

        //left edge
        vh.AddTriangle(0 + offset, 1 + offset, 5+ offset);
        vh.AddTriangle(5 + offset, 4 + offset, 0+ offset);

        //top edge
        vh.AddTriangle(1 + offset, 2 + offset, 6+ offset);
        vh.AddTriangle(6 + offset, 5 + offset, 1+ offset);

        //right edge
        vh.AddTriangle(2 + offset, 3 + offset, 7+ offset);
        vh.AddTriangle(7 + offset, 6 + offset, 2+ offset);

        //bottom edge
        vh.AddTriangle(3+ offset, 0+ offset, 4+ offset);
        vh.AddTriangle(4+ offset, 7+ offset, 3+ offset);
    }
    private void GetXY(Vector2 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - GetComponent<RectTransform>().rect.min).x / rectCellWidth);
        y = Mathf.FloorToInt((worldPosition - GetComponent<RectTransform>().rect.min).y / rectCellHeight);
    }

    Vector2 point;
    float xCellSize;
    float yCellSize;
    private void SetPoint(int x, int y)
    {
        var rt = GetComponent<RectTransform>();
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);

        xCellSize = (v[1] - v[2]).magnitude/gridSize.x;
        yCellSize = (v[0] - v[1]).magnitude/gridSize.x;

        Debug.Log($" xCellSize: {xCellSize} yCellSize: {yCellSize} ");

        point = new Vector2(GetComponent<RectTransform>().position.x + x * xCellSize + xCellSize/2, GetComponent<RectTransform>().position.y + y * yCellSize + yCellSize/2) ;    
        Debug.Log(point);
    }
    
    private void OnDrawGizmos() {
        Gizmos.DrawSphere(point,0.5f);
    }
}
