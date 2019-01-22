using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Updater : MonoBehaviour {

    [SerializeField] Text text; // Variablen müssen nicht public sein
    [SerializeField] string inputtext;
    public GameObject circleColor;
    // color nicht gebraucht
    public GameObject[] shuffleCircles;

    [SerializeField] GameObject circlePosition;

    private List<Color> colorList;
    private System.Random rnd = new System.Random();
    
    private void Start()
    {
       // input text soll nicht überschrieben werden

        colorList = new List<Color> {
            Color.red,
            Color.blue,
            Color.green, // comma vergessen
            Color.magenta
        };
    }

    public void UpdateTextWithInspectorInput()
    {
        text.text = inputtext; //Text muss text sein
    }

    public void UpdateCircleColor()
    {
        SpriteRenderer circleRenderer = circleColor.GetComponent<SpriteRenderer>(); 
        byte r = (byte)rnd.Next(0, 255);
        byte g = (byte)rnd.Next(0, 255);
        byte b = (byte)rnd.Next(0, 255);
        byte a = (byte)rnd.Next(0, 255); 

        circleRenderer.color = new Color32(r, g, b, a);
    }
	
    public void UpdateObjectPosition()
    {
        Transform circleTransform = circlePosition.GetComponent<Transform>();
        
        float randomPosX = UnityEngine.Random.Range(5, 433); //.Range statt .Next benutzen
        circleTransform.localPosition = new Vector3(randomPosX, circleTransform.localPosition.y, circleTransform.localPosition.z);
    }

    public void ShuffleColorsInCircles()
    {
        List<SpriteRenderer> objectList = new List<SpriteRenderer>();
        
        foreach(GameObject item in shuffleCircles)
        {
            objectList.Add(item.GetComponent<SpriteRenderer>());
        }

        colorList.Shuffle();

        for(int i = 0; i < objectList.Count; i++)
        {
            objectList[i].color = colorList[i];
        }
    }
}
