using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider scaleSlider; 
    public GameObject targetScaleObject; 
    public Vector3 minScale = Vector3.one;
    public Vector3 maxScale = new Vector3(2, 2, 2);

    public GameObject cube;

    public GameObject Screen1;

    public void UpdateScale(float value)
    {
        float t = value / scaleSlider.maxValue; 
        targetScaleObject.transform.localScale = Vector3.Lerp(minScale, maxScale, t);
    }
    public void cubeAppear(){
        cube.SetActive(true);
        targetScaleObject.SetActive(false);
    }
    public void cubeDisappear(){
        cube.SetActive(false);
        targetScaleObject.SetActive(true);
    }
    public void uicontrol(){
        Screen1.SetActive(true);

    }
}
