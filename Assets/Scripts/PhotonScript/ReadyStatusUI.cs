using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ReadyStatusUI : MonoBehaviourPunCallbacks
{
    public Text readyStatusText;
    int readyStatus = 0;
    public GameObject readyPanel;
    public GameObject sayacPanel;
    public GameObject karakterUIPanel;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        Time.timeScale = 0f;
        PhotonNetwork.LocalPlayer.CustomProperties["IsReady"] = false;

        PhotonNetwork.SetPlayerCustomProperties(PhotonNetwork.LocalPlayer.CustomProperties);
    }
    public void ReadyButtonClicked()
    {             
        PhotonNetwork.LocalPlayer.CustomProperties["IsReady"] = true;
        readyStatus += 1;

    }

    private void Update()
    {
        if(view.IsMine) {
            readyStatusText.text = readyStatus.ToString();

            if (readyStatus == 2)
            {
                StartGame();
            }
        }
        
    }
    void StartGame()
    {
        Time.timeScale = 1f;
        readyPanel.SetActive(false);
        sayacPanel.SetActive(true);
        karakterUIPanel.SetActive(true);

    }
}
