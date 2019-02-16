using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinUI : MonoBehaviour
{

    public Image modelDisplayPanel;
    private GameObject displayModel;
    public Button skin1;
    public Button skin2;
    public Button skin3;
    public Button skin4;
    public Button skin5;
    public GameObject lockButtonHolder;
    public GameObject playBtnHolder;
    public Button lockButton;
    public Button playButton;
    public Animator confirmation;
    public AudioSource buttonPress;
    public GameObject modelTextCostHolder;

    public Text confirmationText;
    public Text CoinText;
    public Text ModelCostText;

    private Vector3 displayPosition;
    private Vector3 modelRotation;
    private GameObject clone;
    private bool modelIsShowing;
    private float spinSpeed = 70f;
    private int characterSelectionIndex;

    private int skin1Lock;
    private int skin2Lock;
    private int skin3Lock;
    private int skin4Lock;
    private int skin5Lock;
    private int skin6Lock;

    private modelData modelData;

    private int playerCoins;
    private static int selectedSkinsCost;

    void Start()
    {
        playerCoins = PlayerPrefs.GetInt("Coins", 0);
        InitializeLocks();
        PlayerPrefs.SetInt("skinLock1", 1);
        displayPosition = new Vector3(113.1584f, 0.1132f, 51.0033f);
        modelRotation = new Vector3(0, 180, 0);
        modelIsShowing = false;
        CoinText.text = playerCoins.ToString();
        ModelCostText.text = "Cost: 0";
        modelTextCostHolder.SetActive(false);
    }

    void Update()
    {
        if (modelIsShowing == true)
        {
            clone.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        }
    }

    public void LockButton()
    {
        buttonPress.Play();
        confirmationText.text = "Confirm Purchase: " + selectedSkinsCost;
        confirmation.SetBool("Confirmation", true);
        Debug.Log(selectedSkinsCost);
    }

    public void ShowSkin1()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("PlayerDisplay", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = PlayerPrefs.GetInt("skinLock1");
        if (skin1Lock == 0)
        {
            playBtnHolder.SetActive(false);
            lockButtonHolder.SetActive(true);
            modelTextCostHolder.SetActive(true);
        }
        else
        {
            lockButtonHolder.SetActive(false);
            playBtnHolder.SetActive(true);
            modelTextCostHolder.SetActive(false);
        }
        ModelCostText.text = "Cost: " + modelData.cost;
        selectedSkinsCost = 0;
        modelIsShowing = true;
        closeConfirmationMenu();
    }

    public void ShowSkin2()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player2Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = PlayerPrefs.GetInt("skinLock2");
        if (skin2Lock == 0)
        {
            playBtnHolder.SetActive(false);
            lockButtonHolder.SetActive(true);
            modelTextCostHolder.SetActive(true);
        }
        else
        {
            lockButtonHolder.SetActive(false);
            playBtnHolder.SetActive(true);
            modelTextCostHolder.SetActive(false);
        }
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin3()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player3Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = PlayerPrefs.GetInt("skinLock3");
        if (skin3Lock == 0)
        {
            playBtnHolder.SetActive(false);
            lockButtonHolder.SetActive(true);
            modelTextCostHolder.SetActive(true);
        }
        else
        {
            lockButtonHolder.SetActive(false);
            playBtnHolder.SetActive(true);
            modelTextCostHolder.SetActive(false);
        }
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin4()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player4Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = PlayerPrefs.GetInt("skinLock4");
        if (skin4Lock == 0)
        {
            playBtnHolder.SetActive(false);
            lockButtonHolder.SetActive(true);
            modelTextCostHolder.SetActive(true);
        }
        else
        {
            lockButtonHolder.SetActive(false);
            playBtnHolder.SetActive(true);
            modelTextCostHolder.SetActive(false);
        }
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void ShowSkin5()
    {
        buttonPress.Play();
        Destroy(clone);
        displayModel = Resources.Load("Player5Display", typeof(GameObject)) as GameObject;
        clone = Instantiate(displayModel, displayPosition, Quaternion.Euler(modelRotation));
        modelData = displayModel.GetComponent<modelData>();
        modelData.lockStatus = PlayerPrefs.GetInt("skinLock5");
        if (skin5Lock == 0)
        {
            playBtnHolder.SetActive(false);
            lockButtonHolder.SetActive(true);
            modelTextCostHolder.SetActive(true);
        }
        else
        {
            lockButtonHolder.SetActive(false);
            playBtnHolder.SetActive(true);
            modelTextCostHolder.SetActive(false);
        }
        modelIsShowing = true;
        ModelCostText.text = "Cost: " + modelData.cost.ToString();
        selectedSkinsCost = modelData.cost;
        closeConfirmationMenu();
    }

    public void LoadGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene("Game");
        PlayerPrefs.SetInt("characterIndex", modelData.charIndex);
        closeConfirmationMenu();
    }

    public void InitializeLocks()
    {
        skin1Lock = PlayerPrefs.GetInt("skin1Lock", 1);
        skin2Lock = PlayerPrefs.GetInt("skin2Lock", 0);
        skin3Lock = PlayerPrefs.GetInt("skin3Lock", 0);
        skin4Lock = PlayerPrefs.GetInt("skin4Lock", 0);
        skin5Lock = PlayerPrefs.GetInt("skin5Lock", 0);
        skin6Lock = PlayerPrefs.GetInt("skin6Lock", 0);
    }

    public void closeConfirmationMenu()
    {
        confirmation.SetBool("Confirmation", false);
    }

    public void declinePurchaseButton()
    {
        buttonPress.Play();
        confirmation.SetBool("Confirmation", false);
    }

    public void acceptPurchase()
    {
        buttonPress.Play();
        if (playerCoins >= selectedSkinsCost)
        {
            StartCoroutine("subtractCoins");
            confirmation.SetBool("Confirmation", false);
            PlayerPrefs.SetInt(modelData.lockStat, 1);
            lockButtonHolder.SetActive(false);
            playBtnHolder.SetActive(true);
            InitializeLocks();
            PlayerPrefs.SetInt("Coins", playerCoins - modelData.cost);
        }
        else
        {
            StartCoroutine("FlashDeclinedPurchase");
        }
    }

    IEnumerator FlashDeclinedPurchase()
    {
        confirmationText.text = "Not Enough Coins!";
        yield return new WaitForSeconds(0.4f);
        confirmationText.enabled = false;
        yield return new WaitForSeconds(0.4f);
        confirmationText.enabled = true;
        yield return new WaitForSeconds(0.4f);
        confirmationText.enabled = false;
        yield return new WaitForSeconds(0.4f);
        confirmationText.text = "Confirm Purchase: " + selectedSkinsCost;
        confirmationText.enabled = true;
    }

    IEnumerator subtractCoins()
    {
        for (int i = 0; i <= selectedSkinsCost; i++)
        {
            yield return new WaitForSeconds(0.0000000000001f);
            CoinText.text = playerCoins.ToString();
            playerCoins--;
            Debug.Log(playerCoins);
        }
    }
}
