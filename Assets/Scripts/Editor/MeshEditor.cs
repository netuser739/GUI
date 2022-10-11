using UnityEngine;
using UnityEditor;

public class MeshEditor : EditorWindow
{

    public Color myColor;

    //public Transform myScale;

    public MeshRenderer GO;

    public Material myMaterial;

    [MenuItem("Tools/ Mesh generator")]
    public static void ShowMethod()
    {
        GetWindow(typeof(MeshEditor), false, "Генератор объектов");
    }

    private void OnGUI()
    {
        GO = (MeshRenderer)EditorGUILayout.ObjectField("Меш объекта", GO, typeof(MeshRenderer), true);
        myMaterial = (Material)EditorGUILayout.ObjectField("Материал объекта", myMaterial, typeof(Material), true);

        if (GO)
        {
            myColor = RGBSlider(new Rect(10, 40, 200, 20), myColor);
            GO.sharedMaterial.color = myColor;

        }
        else
        {
            if (GUI.Button(new Rect(10, 60, 75, 25), "Создать"))
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                MeshRenderer GORenderer = temp.GetComponent<MeshRenderer>();

                GORenderer.sharedMaterial = myMaterial;
                temp.transform.position = new Vector3(10f, 3f, -10f);

                GO = GORenderer;
            }
        }

        if (GUI.Button(new Rect(10, 170, 75, 25), "Удалить"))
        {
            DestroyImmediate(GO.gameObject);
            GO = null;
        }

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

    //Transform ScaleSlider(Rect screenRect, Transform scale)
    //{
    //    float XScale = LabelSlider(screenRect, 1f, 10f, "X");

    //    screenRect.y += 20;
    //    float YScale = LabelSlider(screenRect, 1f, 10f, "Y");

    //    screenRect.y += 20;
    //    float ZScale = LabelSlider(screenRect, 1f, 10f, "Z");

    //    scale.localScale += new Vector3(XScale, YScale, ZScale);

    //    return scale;
    //}
}
