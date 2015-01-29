using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadarGenerator : MonoBehaviour {

    public float spriteScale;
    public float bottomPadding;
    public Sprite mapBackgroundSprite;

    Image mapBackground;

	void Awake () {
        GameObject radarAgentHandler = getChildGameObject("radarAgentsContainer");
        mapBackground = radarAgentHandler.AddComponent<Image>();
        mapBackground.sprite = mapBackgroundSprite;
        mapBackground.preserveAspect = true;
        mapBackground.type = Image.Type.Tiled;
        radarAgentHandler.GetComponent<RectTransform>().sizeDelta = new Vector2(mapBackground.sprite.bounds.size.x * 100, mapBackground.sprite.bounds.size.y * 100);
        float referenceOffset = (mapBackground.sprite.bounds.size.y / (2 * spriteScale)) * 100 - bottomPadding;
        radarAgentHandler.GetComponent<RectTransform>().localPosition += new Vector3(0, -referenceOffset, 0);
        //radarAgentHandler.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
    }

    public GameObject getChildGameObject(string withName)
    {
        Transform[] ts = GetComponent<Transform>().GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

}
