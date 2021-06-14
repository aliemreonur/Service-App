using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour, IPanel
{
    public Text caseNumberText;
    public RawImage photoTaken;
    public InputField photoNotes;
    public GameObject overviewPanel;

    private void OnEnable()
    {
        caseNumberText.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;
    }

    // Start is called before the first frame update
    public void TakePictureButton()
    {
		TakePicture(512);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void TakePicture(int maxSize)
	{
		NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				// Create a Texture2D from the captured image
				Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}

                photoTaken.texture = texture;
                photoTaken.gameObject.SetActive(true);
			}
		}, maxSize);

		Debug.Log("Permission result: " + permission);
	}

	public void ProcessInfo()
    {
        UIManager.Instance.activeCase.photoTaken = photoTaken;
        UIManager.Instance.activeCase.photoNotes = photoNotes.text;
        
        if(!string.IsNullOrEmpty(photoNotes.text))
        {
            overviewPanel.gameObject.SetActive(true);
        }
    }
}
