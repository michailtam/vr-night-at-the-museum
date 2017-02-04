using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour {

  public GameObject museum;
  public GameObject videoVRDrivingExperience;
  public GameObject videoVRExperience;
  public GameObject videoVREngineering;
  public GameObject videoVRCustomerPreview;
  public GameObject videoVRAirbrush;

  private GameObject video;

  // Use this for initialization
  void Start () {
    
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  public void OnClickedHMD() {
    float sightlength = 10f;

    // Checks which video to play
    RaycastHit seen;
    Ray raydirection = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
    if (Physics.Raycast(raydirection, out seen, sightlength)) {
      museum.SetActive(false);    // Hide the museum

      Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -10));
      Camera.main.transform.Rotate(p);

      if (seen.collider.name == "HMD_1") {

      } else if (seen.collider.name == "HMD_2") {
        video = Instantiate(videoVRExperience, p, Quaternion.identity);
        
      } else if (seen.collider.name == "HMD_3") {

      } else if (seen.collider.name == "HMD_4") {

      } else if (seen.collider.name == "HMD_5") {

      }

      // This adds at last an event trigger to exit the video when the user clicks on it
      EventTrigger trigger = video.AddComponent<EventTrigger>();
      EventTrigger.Entry entry = new EventTrigger.Entry();
      entry.eventID = EventTriggerType.PointerClick;
      entry.callback.AddListener((eventData) => { OnExitVideo(); });
      trigger.triggers.Add(entry);
    }
  }

  // Exits the video that is playing
  private void OnExitVideo() {
    museum.SetActive(true);    // Unhide the museum
    if(video != null) 
      Destroy(video);
  }
}
