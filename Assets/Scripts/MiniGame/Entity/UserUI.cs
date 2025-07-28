using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UserUI;

public class UserUI : MonoBehaviour
{
    public Button okButton;

    private GameManager _gameManager;
    private MiniGameUIManager _miniGameUIManager;

    private GameObject _player;

    public TMP_InputField nameField;

    private PlayerData _playerData;

    private PlayerDataPakage _playerDataPakage = new PlayerDataPakage();


    private void Awake()
    {
        okButton.onClick.AddListener(OnClickOKButton);
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _miniGameUIManager = MiniGameUIManager.Instance;
        _player = _gameManager.GetPlayer();
    }

    private void OnClickOKButton()
    {
        // �̸��� PlayerPrefs�� ����
        nameField = GameObject.Find("NameField").GetComponent<TMP_InputField>();
        PlayerPrefs.SetString("Name", nameField.text);
        Debug.Log($"�Է��� �̸� : {PlayerPrefs.GetString("Name")}");

        // ��ŷ ��� �۾�
        string playerName = nameField.text;
        int playerScore = PlayerPrefs.GetInt("Score");

        PlayerData newPlayerData = new PlayerData
        {
            name = playerName,
            score = playerScore
        };

        LoadPlayerDataFromJson();

        _playerDataPakage.Enable(newPlayerData);
        _playerDataPakage.Sort();

        SavePlayerDataToJson();


        // ���� ���� 
        //// 1. JSON �����͸� ��ŷ����Ʈ�� �ִ´�. 

        //// 1-1. ���� JSON �����Ͱ� ������ ranking.json ������ ���� �����. (JSON ������ �����ٴ� �� ó�� ���� �����Ѱ�)
        //if (!isExistJson)
        //{
        //    _playerData = new PlayerData();
        //    _playerData.name = PlayerPrefs.GetString("Name");
        //    _playerData.score = PlayerPrefs.GetInt("Score");
        //    PlayerData.playerDatas.Add(_playerData);
        //    SavePlayerDataToJson();
        //}
        //// 2. ��ŷ����Ʈ�� �� ����(�ְ�����)�� ���� �� �ִ��� Ȯ���Ѵ�. (5�� ������ �� ���� �������� ���� ������ �ִ��� Ȯ��)
        //else
        //{
        //    _playerData = new PlayerData();
        //    _playerData.name = PlayerPrefs.GetString("Name");
        //    _playerData.score = PlayerPrefs.GetInt("Score");

        //    // �ְ������� ���� �� �ִ��� Ȯ��. ���� �� ������ �ְ�(else) ����Ʈ�� �� á���� �ٲ� �� �ִ��� Ȯ�� �� �ٲٱ�.
        //    _playerData.Enable(_playerData);
        //    _playerData.Sort(); // ���� 

        //    SavePlayerDataToJson();
        //}
        //// 2-1. ��ŷ����Ʈ�� �� ������ ���� �� �ִٸ� 
        //// 2-1-1. ��ŷ����Ʈ�� �� ������ �̸�, ������ �ְ� �����Ѵ�. (Ŭ������ �����Ѵ�.)
        //// 2-1-2. ��ŷ����Ʈ�� ranking.json�� �����Ѵ�. 

        //// 2-2. ��ŷ����Ʈ�� �� ������ ���� �� ���ٸ�
        //// 2-2-1. ��ŷ����Ʈ���� 5�� ���� �� ���� ����(�ְ�����)���� ���� ������ ã�´�.
        //// 2-2-2. ���� ������ ���� ������ ��ü�ϰ� �̸��� �ٲ㼭 ����Ʈ�� �����Ѵ�.
        //// 2-2-3. ��ŷ����Ʈ�� ranking.json�� �����Ѵ�. 

        _gameManager.ActiveTime();
        _miniGameUIManager.InActiveUI(UIType.User);


        _gameManager.ActiveTime();
        _gameManager.PlayerVisibleMode(_player);
        _gameManager.LoadScene("MainScene");

        // ���� ��� UI ���� 
        // MainScene���� MainUIManager�� ���� ��� UI����
        _gameManager.RequestResultUI();
    }

    private void SavePlayerDataToJson()
    {
        // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�  
        string jsonData = JsonUtility.ToJson(_playerDataPakage);
        // �����͸� ������ ��� ����
        string path = Path.Combine(Application.dataPath, "ranking.json");
        // ���� ���� �� ����
        File.WriteAllText(path, jsonData);
    }

    private void LoadPlayerDataFromJson()
    {
        // �����͸� �ҷ��� ��� ����
        string path = Path.Combine(Application.dataPath, "ranking.json");

        if (!File.Exists(path))
        {
            _playerDataPakage = new PlayerDataPakage();
            return;
        }
        // ������ �ؽ�Ʈ�� string���� ����
        string jsonData = File.ReadAllText(path);
        // �� Json�����͸� ������ȭ�Ͽ� playerData�� �־���
        _playerDataPakage = JsonUtility.FromJson<PlayerDataPakage>(jsonData);
    }

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class PlayerDataPakage
    {
        public List<PlayerData> playerDatas = new List<PlayerData>();

        public void Enable(PlayerData playerData)
        {
            //(5�� ������ �� ���� �������� ���� ������ �ִ��� Ȯ��)
            if (playerDatas.Count == 5)
            {
                // playerDatas��� ����Ʈ���� 5�� ������ �� ���� ���� ���� ����(playerData.score)���� ���� ������ �ִ��� Ȯ���ϰ� ������ �� ������ ��ģ���� �̸��� playerData.score, playerData.name���� �ٲٰ� �;�. �̰� LINQ�� ¥�ٷ�?
                PlayerData lowerScorePlayerData = playerDatas.FirstOrDefault(data => data.score < playerData.score);

                if (lowerScorePlayerData != null)
                {
                    lowerScorePlayerData.name = playerData.name;
                    lowerScorePlayerData.score = playerData.score;
                }
            }
            else
            {
                playerDatas.Add(playerData);
            }
        }

        public void Sort()
        {
            playerDatas = playerDatas.OrderByDescending(data => data.score).ToList();
        }
    }
}
