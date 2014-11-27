using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour {

	bool naming = false, over = false, flip, valideMovement = false;
    NameIt nI;
    string catName;
	float score, tpsDeJeu, tpsDeNom, scorePlacement;
	GameObject[] elements;
	Dictionary<string, char> varietyDico;
	int varietyScore, arm, ear, eye, leg, moustache, nbElement;
	List<GameObject> mouths;
	Vector3 talkPosition;
	string[] catTalk = {"Miaou ?","MIAOU !","Miaou !","Miaou\nMiaou","Ron-Ron"};

	public GameObject talkZone, talk;
	
    void Start() {

        nI = GameObject.Find("CatName").GetComponent<NameIt>();
		score = 0;
		scorePlacement = 0;
		varietyDico = new Dictionary<string, char>();
		arm = 0; ear = 0; eye = 0; leg = 0; moustache = 0;
		nbElement = 0;
		mouths = new List<GameObject>();

    }

	public void ElementDroped(GameObject elem){

		int i;
		flip = false;
		if(elem.name.Substring(0,5).Equals("Mouth") && !mouths.Contains(elem)) mouths.Add(elem);
		i = Random.Range(0,4+mouths.Count);

		if(i > 3){
			i -= 4;
			talkPosition = mouths[i].transform.position;
			if(talkPosition.x >= -4.5){
				talkPosition.x -= 2;
				flip = true;
			}
			else talkPosition.x += 2;
			this.StartCoroutine("InvokeTalk");
		}

	}

	IEnumerator InvokeTalk() {

		talkPosition.z -= 2;
		GameObject talkzone = (GameObject)Instantiate(talkZone,talkPosition,talkZone.transform.rotation);
		if(flip) talkzone.transform.localScale *= -1;
		talkPosition.z -= 1;
		if(flip) talkPosition.x -= 0.2f;
		else talkPosition.x += 0.2f;
		GameObject talktext = (GameObject)Instantiate(talk,talkPosition,Quaternion.identity);
		talktext.GetComponent<TextMesh>().text = TalkGenerator ();

		yield return new WaitForSeconds(2f);

		Destroy(talkzone);
		Destroy(talktext);

	}

	string TalkGenerator(){

		return catTalk[Random.Range(0,catTalk.Length)];

	}

	void CountVariety(string element){

		switch(element){

			case "Arm" :
			arm = 1;
			break;
			case "Ear" :
			ear = 1;
			break;
			case "Eye" :
			eye = 1;
			break;
			case "Leg" :
			leg = 1;
			break;
			case "Moustache" :
			moustache = 1;
			break;
			default :
			break;

		}

		varietyScore = arm + ear + eye + leg + moustache;

	}

    void OnMouseUpAsButton() {

        if (over) {
            // Game Over
        }
        else if (!naming) {
            nI.Naming();
            naming = true;
			tpsDeJeu = Time.fixedTime;
        }
        else {
            nI.Naming();
            catName = nI.GetName();
            over = true;
			tpsDeNom = Time.fixedTime - tpsDeJeu;
			ComputeScore();							// Score is computed here
        }

    }

	void ComputeScore(){

		AnalyseElements();

		score = 0;

		if(tpsDeJeu > 60) score += 15;
		else if(tpsDeJeu > 30) score += 10;
		else if(tpsDeJeu > 15) score += 5;

		if(tpsDeNom > 15) score +=5;

		if(nbElement > 17) score += 30;
		else if(nbElement > 15) score += 20;
		else if(nbElement > 14) score += 10;

		if(varietyScore > 2) score += 20;
		else if(varietyScore > 0) score += 10;

		score += scorePlacement;

		Debug.Log((int)score);

	}

	void AnalyseElements(){

		elements = GameObject.FindGameObjectsWithTag("Element");
		string elem;
		char nbElem, nbElemTemp;

		foreach(GameObject element in elements){

			if(element.transform.position.x <= -1){

				elem = element.name;
				nbElement++;

				if(char.Equals(elem[0],'L') || char.Equals(elem[0],'R')){
					nbElem = elem[elem.Length-8];
					elem = elem.Substring(1,elem.Length-9);

					if(varietyDico.TryGetValue(elem, out nbElemTemp)) if(!nbElemTemp.Equals(nbElem)) CountVariety (elem);
					else varietyDico.Add(elem, nbElem);
				}

				elem = element.name;
				elem = elem.Substring(0,elem.Length-8);
				scorePlacement += ScoreDistance(DistanceFromModel(elem, element.transform.position));

			}
		}

		if(nbElement > 0) scorePlacement = scorePlacement / nbElement;

	}

	float DistanceFromModel(string model, Vector3 props){

		Vector2 posProps = new Vector2(props.x, props.y);
		float dist;

		switch(model){

			case "LEye" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.69f,1.705f));
			break;
			case "REye" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.072f,1.772f));
			break;
			case "Nose" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.423f,1.488f));
			break;
			case "Tete" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.489f,1.404f));
			break;
			case "Mouth" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.423f,1.287f));
			break;
			case "LMoustache" :
			dist =  Vector2.Distance(posProps,new Vector2(-5.56f,1.471f));
			break;
			case "RMoustache" :
			dist =  Vector2.Distance(posProps,new Vector2(-3.603f,1.638f));
			break;
			case "Corps" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.322f,-0.451f));
			break;
			case "LArm" :
			dist =  Vector2.Distance(posProps,new Vector2(-5.259f,-0.568f));
			break;
			case "RArm" :
			dist =  Vector2.Distance(posProps,new Vector2(-3.235f,-0.451f));
			break;
			case "LLeg" :
			dist =  Vector2.Distance(posProps,new Vector2(-4.757f,-2.625f));
			break;
			case "RLeg" :
			dist =  Vector2.Distance(posProps,new Vector2(-3.469f,-2.759f));
			break;
			case "Tail" :
			dist =  Vector2.Distance(posProps,new Vector2(-5.994f,-2.474f));
			break;
			default :
			dist = 0f;
			break;
		}
		return dist;
	}

	int ScoreDistance(float dist){

		if(dist > 1) return 30;
		else if (dist > 0.5) return 20;
		else return 0;

	}

	void OnMouseOver() {
		if(transform.position.y <= -4.468) valideMovement = true;
		if(transform.position.y >= -4.35) valideMovement = false;
		if(valideMovement) transform.position = new Vector3(transform.position.x, transform.position.y-((-4.47f-transform.position.y)/10), transform.position.z);
		else transform.position = new Vector3(transform.position.x, transform.position.y+((-4.47f-transform.position.y)/10), transform.position.z);
	}

}