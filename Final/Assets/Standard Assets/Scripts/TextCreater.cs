using UnityEngine;
using System.Collections;

/// <summary>
/// Creates GUIText
/// </summary>
public class TextCreater {

    GameObject TurnIntoText(GameObject GO)
    {
        GO = new GameObject("GUI Text");
        GO.AddComponent("GUIText");
        GO.guiText.anchor = TextAnchor.MiddleCenter;
        return GO;
    }

    public GameObject CreateNewText(GameObject GO, string text, Vector3 Position)
    {
        GO = TurnIntoText(GO);
        ChangeText(GO, text);
        ChangePosition(GO, Position);
        return GO;
    }

    public GameObject CreateNewText(GameObject GO, string text, Vector3 Position, Color C, int Size)
    {
        GO = TurnIntoText(GO);
        ChangeText(GO, text);
        ChangePosition(GO, Position);
        ChangeSize(GO, Size);
        ChangeColor(GO, C);
        return GO;
    }

    public GameObject ChangeColor(GameObject GO, Color C)
    {
        GO.guiText.material.color = C;
        return GO;
    }

    public GameObject ChangePosition(GameObject GO, Vector3 Position)
    {
        GO.transform.position = Position;
        return GO;
    }

    public GameObject ChangeSize(GameObject GO, int Size)
    {
        GO.guiText.fontSize = Size;
        return GO;

    }

    public GameObject ChangeText(GameObject GO, string Text)
    {
        GO.guiText.text = Text;
        return GO;
    }
	
}
