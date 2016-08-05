using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateNameScript : MonoBehaviour
{
	public RectTransform LimbList;
	public GameObject LimbTextPrefab;

	public string Name = "";

	public string[] BaseName = new string[] {
		"Oru",
		"Dziethew",
		"Massev",
		"Meloon",
		"Udros Of The Sun,",
		"Toesis Of War,",
		"Radon Of The Ocean,",
		"Sodes Of Earth,",
	};

	private Body BodyMesh;

	void Start()
	{
		BodyMesh = transform.parent.parent.GetChild( 0 ).GetChild( 0 ).GetComponent<Body>();

		int arms = 0;
		int horns = 0;
		int limbcount = 0;
		Transform lasttransform = null;
		foreach ( Limb limb in BodyMesh.attachedLimbs )
		{
			if ( limb == null ) continue;
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
				//Name += "arm";
				arms++;
			}
			if ( limb.type == "horn" )
			{
				horns++;
			}

			lasttransform = textchild;
			limbcount++;
		}

		// Prefix
		Name = "";
		if ( horns > 0 )
		{
			Name = "Horned ";
		}

		// Base Name
		Name += BaseName[Random.Range( 0, BaseName.Length )];

		// Special Cases
		if ( arms > 10 )
		{
			Name += " The Massive";
		}
		else if ( arms > 5 )
		{
			Name += " The Many Armed";
		}
		else if ( arms > 2 )
		{
			Name += " The Large";
		}
		else if ( arms == 2 )
		{
			Name += " The Human";
		}
		else if ( arms == 1 )
		{
			Name += " The One Armed";
		}
		if ( limbcount == 0 )
		{
			Name += " The Purist";
		}

		BodyMesh.godName = Name;
		GetComponent<Text>().text = Name;
		print( Name );
	}
}
