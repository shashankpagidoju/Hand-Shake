using UnityEngine;

public class PathManager : MonoBehaviour
{
    public bool firstPathChosen = false;

    public bool pathABroken = false;
    public bool pathBBroken = false;

    public void ChoosePathA()
    {
        if (firstPathChosen)
            return;

        firstPathChosen = true;
        pathABroken = true;
    }

    public void ChoosePathB()
    {
        if (firstPathChosen)
            return;

        firstPathChosen = true;
        pathBBroken = true;
    }
}