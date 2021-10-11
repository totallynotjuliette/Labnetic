using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.Mathematics;
using TMPro;

public class UIGridRenderer : Graphic
{
    public GameObject Line;
    public GameObject gridBackground;
    public Vector2Int gridSize = new Vector2Int(1, 1);
    //((gridBackground.GetComponent<Marks>().NumberOfMarks), ((int)Mathf.Ceil((gridBackground.GetComponent<Marks>().Displacements.Max()))));
    public float thickness = 10f;

    float width;
    float height;
    float cellWidth;
    float cellHeight;
    float numbersPerCell = 5;
    public GameObject xAxisNum;
    public GameObject yAxisNum;
    public float yAxisNum_Xpos = -320;
    public float xAxisNum_Ypos = -90;

    

    protected override void OnPopulateMesh(VertexHelper vh)
    {   
        //clears verticies
        vh.Clear();

        //defines new grid size depending on maxX and maxY recorded by user
        gridSize = Line.GetComponent<UILineRenderer>().newGridSize;

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        //defines dimensions of each cell (width of grid / number of cells)
        cellWidth = width / (float)gridSize.x;
        cellHeight = (height*numbersPerCell) / (float)gridSize.y;

        int count = 0;

        for(int y=0; y<(gridSize.y/numbersPerCell); y++)
        {
            for(int x=0; x<gridSize.x; x++)
            {
                DrawCell(x, y, count, vh);
                
                count++;
                
            }
        }

        //Axis Num Labels Instantiation
        if(Application.isPlaying){

            Vector3 graphBottomLeft = gameObject.transform.localPosition;
            xAxisNum.GetComponent<TMP_Text>().SetText("");
            yAxisNum.GetComponent<TMP_Text>().SetText("");
            

                //X-AXIS
                for(int x=0; x<=gridSize.x+1; x++){

                    GameObject a = Instantiate(xAxisNum);
                    a.gameObject.tag = "xAxisNum";

                    xAxisNum.GetComponent<TMP_Text>().SetText(((int)(x)).ToString());
                    
                    a.transform.SetParent(gridBackground.transform, false);
                    a.transform.localPosition = new Vector3((graphBottomLeft.x-cellWidth) + (cellWidth*x) , xAxisNum_Ypos );
                }

                //Y-AXIS
                for(int x = 0; x<=(gridSize.y/numbersPerCell)+1; x++){

                    GameObject b = Instantiate(yAxisNum);
                    b.gameObject.tag = "yAxisNum";

                    yAxisNum.GetComponent<TMP_Text>().SetText(((int)(numbersPerCell * x)).ToString());

                    b.transform.SetParent(gridBackground.transform, false);
                    b.transform.localPosition = new Vector3( yAxisNum_Xpos , (graphBottomLeft.y-cellHeight) + (cellHeight*x) );
            }
        }
    }


//--------------------------------------------------------------------------------------------------------------
    private void DrawCell(int x, int y, int index, VertexHelper vh)
    {
        float xPos = cellWidth * x;
        float yPos = cellHeight * y;


        //outside square border

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + cellHeight);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + cellWidth, yPos + cellHeight);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + cellWidth, yPos);
        vh.AddVert(vertex);

       // vh.AddTriangle(0, 1, 2);
       // vh.AddTriangle(2, 3, 0);

        float widthSqr = thickness * thickness;
        float distanceSqr = widthSqr / 2f;
        float distance = Mathf.Sqrt(distanceSqr);


        //inside square border

        vertex.position = new Vector3(xPos + distance, yPos + distance);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + distance, yPos + (cellHeight - distance));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (cellWidth - distance), yPos + (cellHeight - distance));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (cellWidth - distance), yPos + distance);
        vh.AddVert(vertex);


        int offset = index * 8;
        //Left Edge
        vh.AddTriangle(offset + 0, offset + 1, offset + 5);
        vh.AddTriangle(offset + 5, offset + 4, offset + 0);

        //Top Edge
        vh.AddTriangle(offset + 1, offset + 2, offset + 6);
        vh.AddTriangle(offset + 6, offset + 5, offset + 1);

        //Right Edge
        vh.AddTriangle(offset + 2, offset + 3, offset + 7);
        vh.AddTriangle(offset + 7, offset + 6, offset + 2);

        //Bottom Edge
        vh.AddTriangle(offset + 3, offset + 0, offset + 4);
        vh.AddTriangle(offset + 4, offset + 7, offset + 3);

    }
    

    public void DestoryAllNumLabels(){

        var yClones = GameObject.FindGameObjectsWithTag("yAxisNum");
 
        foreach (var yAxisNum in yClones){

             Destroy(yAxisNum);
           }


        var xClones = GameObject.FindGameObjectsWithTag("xAxisNum");
 
        foreach (var xAxisNum in xClones){

             Destroy(xAxisNum);
           }
    
    }
    
    
    
    
    
    
    }