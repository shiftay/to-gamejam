 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;

 public class GridScript : MonoBehaviour {
     public int rows = 4;
     public int columns = 4;
     private float buttonWidth;                                        //Change
     private float buttonHeight;                                        //Change
     public Button prefab;
     private Button button;
     void Start() {
         RectTransform myRect = GetComponent<RectTransform>();        //Change
         buttonHeight = myRect.rect.height / (float)rows;            //Change
         buttonWidth = myRect.rect.width / (float)columns;            //Change
         GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
         grid.cellSize = new Vector2(buttonWidth, buttonHeight);
         for (int i = 0; i < rows; i++) {
             for (int j = 0; j < columns; j++) {
                 button = (Button)Instantiate(prefab);
                 button.transform.SetParent(transform, false);        //Change
             }
         }
     }
 }
