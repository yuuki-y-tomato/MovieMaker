using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MG_StateManager : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    public enum States
    {
        Ready, Retry, Gameplay, Replay,end
    }
    Clapper a;
    public List<PC_Base> CharacterOrder;
    public int CurrentActor = 0;
    public static States state;
    public Material fademat;
    private Coroutine StateChanger;
    #endregion

    public int Takes;
    public int Actors;

    public Action OnReplay;

    public void Start()
    {

        Takes = 0;
        Actors = CharacterOrder.Count;
        PC_Control.UpdateTarget(CharacterOrder[0]);
        FindObjectOfType<CAM_Gameplay>().UpdateTarget(CharacterOrder[0]);
        StartCoroutine(ChangeState(States.Ready));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AdvanceScene();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RestartScene();
        }
        if(state==States.Replay&&!fading)
        {
            TL_TimeLineMng.run(true);
        }
    }

    private bool fading = false;

    public void RestartScene()
    {
        Debug.Log("aaa");
        if (!fading)
        {
            fading = true;
            CharacterOrder[CurrentActor].HardReset();

            foreach (var b in CharacterOrder)
            {
                b.ResetInput();
                b.completed = false;
            }


            PC_Control.TargetTL.EventList.Clear();
            //        TL_TimeLineMng.ResetTimer();
            StartCoroutine(ChangeState(States.Ready));
            Takes += 1;

            TL_TimeLineMng.run(false);
        }


    }
    public void AdvanceScene()
    {
        if (CurrentActor < CharacterOrder.Count - 1)
        {

            foreach (var b in CharacterOrder)
            {
                b.ResetInput();
                b.completed = false;

            }

            CurrentActor++;
            PC_Control.UpdateTarget(CharacterOrder[CurrentActor]);

            StartCoroutine(ChangeState(States.Ready));

            FindObjectOfType<CAM_Gameplay>().UpdateTarget(CharacterOrder[CurrentActor]);
        }
        else//REPLAY
        {
            if (FindObjectOfType<Camera>().GetComponent<CAM_Replay>().isactive == true)
            {
                StartCoroutine(ChangeState(States.end));
            }
            foreach (var b in CharacterOrder)
            {
                b.ResetInput();
                b.completed = false;
            }

            FindObjectOfType<Camera>().GetComponent<CAM_Gameplay>().isactive = false;
            FindObjectOfType<Camera>().GetComponent<CAM_Replay>().isactive = true;
            TL_TimeLineMng.ResetTimer();

            StartCoroutine(ChangeState(States.Replay));

        }

    }


    IEnumerator ChangeState(States tgt)
    {

        float k = 1;
        while (k > 0)
        {
            k -= Time.deltaTime * 4;
            fademat.SetFloat("_Fade", k);
            yield return null;
        }
        TL_TimeLineMng.ResetTimer();
        TL_TimeLineMng.run(false);
        yield return new WaitForSeconds(0.5f);
        if (tgt == States.end)
        {
            SceneManager.LoadScene("Selection");
        }
        if(tgt==States.Replay)
        {
        yield return new WaitForSeconds(1.0f);
        }
        state = tgt;

        while (k < 1)
        {
            k += Time.deltaTime * 4;
            fademat.SetFloat("_Fade", k);
            yield return null;
        }
        fading = false;
    }



}
