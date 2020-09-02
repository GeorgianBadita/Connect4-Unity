using UnityEngine;

public class SetPiece : MonoBehaviour
{

    public void Col1Pressed()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(0, PlayerType.HUMAN);
    }


    public void Col2Pressed()
    {

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(1, PlayerType.HUMAN);
    }

    public void Col3Pressed()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(2, PlayerType.HUMAN);
    }

    public void Col4Pressed()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(3, PlayerType.HUMAN);
    }

    public void Col5Pressed()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(4, PlayerType.HUMAN);
    }

    public void Col6Pressed()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(5, PlayerType.HUMAN);
    }

    public void Col7Pressed()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameManager gm = camera.GetComponent<GameManager>();
        gm.MakeMove(6, PlayerType.HUMAN);
    }
}
