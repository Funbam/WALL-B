using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;
    [SerializeField] private int maxUsernameLen;
    private string publicLeaderboardKey = "581efd9771149f70475fbd307d0744913d697976d63b98b7123ab97e111cefab";


    private void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg)=> {
            int loopLen = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLen; ++i)
            {
                int revIndex = loopLen - 1 - i;
                float min = Mathf.FloorToInt(msg[i].Score / 60);
                float sec = Mathf.FloorToInt(msg[i].Score % 60);
                scores[revIndex].text = string.Format("{0:00} : {1:00}", min, sec);
                names[revIndex].text = msg[i].Username;
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.DeleteEntry(publicLeaderboardKey);
        Debug.Log(score);
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
            GetLeaderboard();
        }));
    }


}
