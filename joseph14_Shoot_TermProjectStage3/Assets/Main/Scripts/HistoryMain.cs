using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoryMain : MonoBehaviour
{

    public Button exit;
    public Transform panel;
    public GameObject EntryAdmin;
    public GameObject EntryOther;
    public GameObject HeaderAdmin;
    public GameObject HeaderOther;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("File");
        });

        // Admins see differently than other users
        if (toolbar.isAdmin)
        {

            GameObject h = (GameObject)Instantiate(HeaderAdmin);
            h.transform.SetParent(panel.transform, false);

            for (int i = 0; i < Login.auth.users.Count; i++)
            {
                GameObject a = (GameObject)Instantiate(EntryAdmin);
                Text[] t = a.GetComponentsInChildren<Text>();
                t[0].text = Login.auth.users[i].username;
                //t[1].text = Login.auth.users[Login.UserIndex].history.logins[Login.auth.users[Login.UserIndex].history.logins.Count - 1];
                //t[2].text = Login.auth.users[Login.UserIndex].history.durations[Login.auth.users[Login.UserIndex].history.durations.Count - 1];
                t[3].text = Login.auth.users[0].status;
               // Debug.Log(Login.auth.users[Login.UserIndex].history.logins[0]);
                if (Login.auth.users[i].history.logins.Count < 1)
                {
                    t[1].text = Login.auth.users[i].history.logins[0];
                    t[2].text = "No previous Logins";
                }
                else
                {
                    t[1].text = Login.auth.users[i].history.logins[Login.auth.users[i].history.logins.Count - 1];
                    t[2].text = Login.auth.users[i].history.durations[Login.auth.users[i].history.durations.Count - 1];
                }

                a.transform.SetParent(panel.transform, false);
            }
        }
        else
        {
            GameObject h = (GameObject)Instantiate(HeaderOther);
            h.transform.SetParent(panel.transform, false);

            int countLogins = Login.auth.users[Login.UserIndex].history.logins.Count;
            int countDurations = Login.auth.users[Login.UserIndex].history.durations.Count;
            for (int i = 0; i < countLogins; i++)
            {
                GameObject a = (GameObject)Instantiate(EntryOther);
                Text[] t = a.GetComponentsInChildren<Text>();

                t[0].text = Login.auth.users[Login.UserIndex].history.logins[i];

                if (i < countDurations)
                {
                    t[1].text = Login.auth.users[Login.UserIndex].history.durations[i];
                }
                else
                {
                    t[1].text = "In Progress";
                }

                a.transform.SetParent(panel.transform, false);
            }
        }       
    }
}
