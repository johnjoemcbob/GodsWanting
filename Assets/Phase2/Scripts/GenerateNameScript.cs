using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateNameScript : MonoBehaviour
{
	public RectTransform LimbList;
	public GameObject LimbTextPrefab;

	public string Name = "";

	private Body BodyMesh;

	void Start()
	{
		BodyMesh = transform.parent.parent.GetChild( 0 ).GetChild( 0 ).GetComponent<Body>();

		int limbcount = 0;
		Transform lasttransform = null;
		foreach ( Limb limb in BodyMesh.attachedLimbs )
		{
			// Add part description
			GameObject text = (GameObject) Instantiate( LimbTextPrefab );
			Transform textchild = text.transform.GetChild( 0 );
			text.transform.SetParent( LimbList );
			text.transform.localPosition = Vector3.zero + ( Vector3.up * -32 * limbcount );
			textchild.GetComponent<Text>().text = "- " + limb.name + " - " + limb.desc;

			// Set activation order
			if ( limbcount == 0 )
			{
				textchild.GetComponent<KeyframeAnimationHandlerScript>().OnActivate();
			}
			else
			{
				ActivateAfterScript after = textchild.gameObject.AddComponent<ActivateAfterScript>();
				after.OtherScript = lasttransform.GetComponent<KeyframeAnimationHandlerScript>();
				after.ToActivate = textchild.GetComponent<KeyframeAnimationHandlerScript>();
			}

			// Add to name
			if ( limb.type == "arm" )
			{
				Name += "arm";
			}

			lasttransform = textchild;
			limbcount++;
		}

		GetComponent<Text>().text = Name;
		print( Name );
	}
}
