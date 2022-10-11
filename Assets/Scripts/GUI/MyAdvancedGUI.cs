using UnityEngine;

public class MyAdvancedGUI : MonoBehaviour
{
    [SerializeField]
    [Header("Отладочная переменная")]
    [Range(0, 100)]
    [Tooltip("Значение находится в диапазоне от 0 до 100")]
    private float mySlider = 1.0f;

    [SerializeField][TextArea(5, 10)] private string my2Slider;
    [SerializeField] private int my3Slider = 1;

    public Color myColor;

    public MeshRenderer GO;

    void OnGUI()
    {

        myColor = RGBSlider(new Rect(10, 50, 200, 20), myColor);
        GO.sharedMaterial.color = myColor;

    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {

        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); 
        return sliderValue;
    }


    Color RGBSlider(Rect screenRect, Color rgb)
    {

        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "Alpha");

        return rgb;
    }
}