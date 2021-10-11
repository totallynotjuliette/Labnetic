using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Unity.Mathematics;

public class UILineRenderer : Graphic {

    public Vector2Int gridSize;
    public float thickness;

    public UIGridRenderer grid;

    public List<Vector2> pointList;
    public GameObject GameCanvas;

    public GameObject Drag;

    public Vector2Int newGridSize;

    float width;
    float height;
    float unitWidth;
    float unitHeight;

    protected override void OnPopulateMesh(VertexHelper vh) {

        vh.Clear();

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        unitWidth = width / (float)gridSize.x;
        unitHeight = height / (float)gridSize.y;

        if (GameCanvas.GetComponent<GameGUI>().x2ButtonPressed == true){

            SetPoints(GameCanvas.GetComponent<GameGUI>().TimeListFloat, Drag.GetComponent<MeasuringTape>().DispListFloatRef, 2);

        } else {

            SetPoints(GameCanvas.GetComponent<GameGUI>().TimeListFloat, Drag.GetComponent<MeasuringTape>().DispListFloatRef, 1);

        }


        if (pointList.Count < 2) {
            
            return;
        }


        float angle = 0;

        for (int i = 0; i < pointList.Count - 1; i++) {

            Vector2 point = pointList[i];
            Vector2 point2 = pointList[i+1];

            if (i < pointList.Count - 1) {

                angle = GetAngle(pointList[i], pointList[i + 1]) + 90f;
            }
            DrawVerticesForPoint(point, point2, angle, vh);
        }


        for (int i = 0; i < pointList.Count - 1; i++) {
            int index = i * 4;
            vh.AddTriangle(index + 0, index + 1, index + 2);
            vh.AddTriangle(index + 1, index + 2, index + 3);
        }

    }



//--------------------------------------------------------------------------------------

    public void SetPoints(List<float> xAxis, List<float> yAxis, float xAxisExp){

        float MaxY = Mathf.Ceil (yAxis.Max());
        float MaxX = Mathf.Ceil (xAxis.Max());

        grid.GetComponentInChildren<UILineRenderer>().pointList.Clear();


        for (int i = 0; i < xAxis.Count ; i++){

            pointList.Add( new Vector2 ( Mathf.Pow(xAxis[i], xAxisExp) , yAxis[i] ) );

            }

        newGridSize = new Vector2Int( (int)( (Mathf.Pow(MaxX, xAxisExp)) + 1) , (int)(MaxY + (MaxY * .1)) );

    }




    public float GetAngle(Vector2 me, Vector2 target) {

        return (float)(Mathf.Atan2((target.y - me.y), (target.x - me.x)) * (180 / Mathf.PI));
    }





    void DrawVerticesForPoint(Vector2 point, Vector2 point2, float angle, VertexHelper vh) {

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x, unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x, unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point2.x, unitHeight * point2.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point2.x, unitHeight * point2.y);
        vh.AddVert(vertex);
    }





    void Update(){


        if(grid != null){

            if(gridSize != grid.gridSize){

                gridSize = grid.gridSize;
                SetVerticesDirty();

            }

        }
    }

}