using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuGroup : MonoBehaviour {
	
	public Button firstSelect;
	public GameObject firstSelectGO;
	
	void Start () {
		// firstSelect.Select();
		// GameObject myEventSystem = GameObject.Find("EventSystem");
		// myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstSelect);
	}
	
	void OnEnable () {
		// firstSelect.Select();
		// GameObject myEventSystem = GameObject.Find("EventSystem");
		// myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstSelect);
		// Invoke("SelectFirst", 0.01f);
		StartCoroutine("SelectFirst");
	}
	
	IEnumerator SelectFirst () {
		
		yield return null;
		firstSelect.Select();
	}
}
