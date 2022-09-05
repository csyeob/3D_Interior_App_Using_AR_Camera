using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VR_capture : MonoBehaviour
{
    public GameObject parent_img;
    GameObject r1;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-mm-dd_HH-mm-ss") + "png";
        GameObject r = Instantiate(parent_img, this.transform.position, Quaternion.identity);
        Sprite r_sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        r.name = i.ToString();
        r.AddComponent<RawImage>().texture = r_sprite.texture;
        r.transform.parent = parent_img.transform;
        i++;

        //NativeGallery.SaveImageToGallery(texture, "Myapp pictures", name);
        //Destroy(texture);
        

    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void TakeScreenShot()
    {
        
        StartCoroutine("Screenshot");
    }
}
