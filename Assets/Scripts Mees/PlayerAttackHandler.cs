using UnityEngine;


public class PlayerAttackHandler : MonoBehaviour
{
    public GameObject ChoiceArrow;
    public GameObject[] MoveBoxes;
    public int SelectedMove = 0;
    void Start()
    {
        ChoiceArrow.transform.position = MoveBoxes[0].transform.position - new Vector3(330, 0, 0);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SelectedMove = (SelectedMove + 1) % MoveBoxes.Length;
            ChoiceArrow.transform.position = MoveBoxes[SelectedMove].transform.position - new Vector3(330, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectedMove = (SelectedMove - 1 + MoveBoxes.Length) % MoveBoxes.Length;
            ChoiceArrow.transform.position = MoveBoxes[SelectedMove].transform.position - new Vector3(330, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Selected Move: " + SelectedMove);
        }
    }


    
}
