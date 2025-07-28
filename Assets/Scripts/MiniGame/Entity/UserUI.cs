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
        // 이름을 PlayerPrefs에 저장
        nameField = GameObject.Find("NameField").GetComponent<TMP_InputField>();
        PlayerPrefs.SetString("Name", nameField.text);
        Debug.Log($"입력한 이름 : {PlayerPrefs.GetString("Name")}");

        // 랭킹 계산 작업
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


        // 삽질 과정 
        //// 1. JSON 데이터를 랭킹리스트에 넣는다. 

        //// 1-1. 만약 JSON 데이터가 없으면 ranking.json 파일을 새로 만든다. (JSON 파일이 없었다는 건 처음 게임 시작한것)
        //if (!isExistJson)
        //{
        //    _playerData = new PlayerData();
        //    _playerData.name = PlayerPrefs.GetString("Name");
        //    _playerData.score = PlayerPrefs.GetInt("Score");
        //    PlayerData.playerDatas.Add(_playerData);
        //    SavePlayerDataToJson();
        //}
        //// 2. 랭킹리스트에 내 점수(최고점수)를 넣을 수 있는지 확인한다. (5개 점수들 중 지금 점수보다 낮은 점수가 있는지 확인)
        //else
        //{
        //    _playerData = new PlayerData();
        //    _playerData.name = PlayerPrefs.GetString("Name");
        //    _playerData.score = PlayerPrefs.GetInt("Score");

        //    // 최고점수를 넣을 수 있는지 확인. 넣을 수 있으면 넣고(else) 리스트가 꽉 찼으면 바꿀 수 있는지 확인 후 바꾸기.
        //    _playerData.Enable(_playerData);
        //    _playerData.Sort(); // 정렬 

        //    SavePlayerDataToJson();
        //}
        //// 2-1. 랭킹리스트에 내 점수를 넣을 수 있다면 
        //// 2-1-1. 랭킹리스트에 내 점수와 이름, 순위를 넣고 정렬한다. (클래스로 저장한다.)
        //// 2-1-2. 랭킹리스트를 ranking.json에 저장한다. 

        //// 2-2. 랭킹리스트에 내 점수를 넣을 수 없다면
        //// 2-2-1. 랭킹리스트에서 5개 점수 중 지금 점수(최고점수)보다 낮은 점수를 찾는다.
        //// 2-2-2. 낮은 점수를 지금 점수로 대체하고 이름도 바꿔서 리스트에 저장한다.
        //// 2-2-3. 랭킹리스트를 ranking.json에 저장한다. 

        _gameManager.ActiveTime();
        _miniGameUIManager.InActiveUI(UIType.User);


        _gameManager.ActiveTime();
        _gameManager.PlayerVisibleMode(_player);
        _gameManager.LoadScene("MainScene");

        // 게임 결과 UI 띄우기 
        // MainScene에서 MainUIManager로 게임 결과 UI띄우기
        _gameManager.RequestResultUI();
    }

    private void SavePlayerDataToJson()
    {
        // ToJson을 사용하면 JSON형태로 포멧팅된 문자열이 생성된다  
        string jsonData = JsonUtility.ToJson(_playerDataPakage);
        // 데이터를 저장할 경로 지정
        string path = Path.Combine(Application.dataPath, "ranking.json");
        // 파일 생성 및 저장
        File.WriteAllText(path, jsonData);
    }

    private void LoadPlayerDataFromJson()
    {
        // 데이터를 불러올 경로 지정
        string path = Path.Combine(Application.dataPath, "ranking.json");

        if (!File.Exists(path))
        {
            _playerDataPakage = new PlayerDataPakage();
            return;
        }
        // 파일의 텍스트를 string으로 저장
        string jsonData = File.ReadAllText(path);
        // 이 Json데이터를 역직렬화하여 playerData에 넣어줌
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
            //(5개 점수들 중 지금 점수보다 낮은 점수가 있는지 확인)
            if (playerDatas.Count == 5)
            {
                // playerDatas라는 리스트에서 5개 정수들 중 내가 넣을 려는 점수(playerData.score)보다 낮은 점수가 있는지 확인하고 있으면 그 점수와 그친구의 이름을 playerData.score, playerData.name으로 바꾸고 싶어. 이걸 LINQ로 짜줄래?
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
