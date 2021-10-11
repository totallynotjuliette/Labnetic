using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StartMenu : MonoBehaviour
{
  public GameObject HypothesisCanvas;
  public TextMeshProUGUI Text;

  public void HypothesisPopUp(){

    HypothesisCanvas.SetActive(true);

  }

  public void ToLabScene(){

    SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)+1);
    
  }

  public void StartGame(){

    Text.SetText("\n Hm. Gotcha. Now let's find out how right your science-y intuition was...");
    Text.fontSize=25;

    Invoke("ToLabScene", 3);

  }

}

