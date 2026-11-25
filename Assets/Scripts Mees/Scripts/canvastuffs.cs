using UnityEngine;
using UnityEngine.UI;

public class canvastuffs : MonoBehaviour
{
    [System.Serializable]
    public class MenuData
    {
        public GameObject menu;
        public GameObject arrow;
        public Transform[] arrowstuffs;
        public Button firstButton;
    }

    [SerializeField] MenuData menu1;
    [SerializeField] MenuData menu2;

    private MenuData currentMenu;
    private int arrowindex;

    private void Start()
    {
        SwitchMenu(1);
    }

    private void Update()
    {

        MenuData active = menu2.menu.activeInHierarchy ? menu2 : menu1;
        if (active != currentMenu)
        {
            SwitchMenu(active == menu1 ? 1 : 2);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrowindex++;
            MoveArrow();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrowindex--;
            MoveArrow();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B pressed, current menu: " + currentMenu.menu.name);

            if (currentMenu == menu2)
            {
                SwitchMenu(1);
            }
        }
    }

    public void SwitchMenu(int menuNumber)
    {
        menu1.menu.SetActive(menuNumber == 1);
        menu2.menu.SetActive(menuNumber == 2);

        currentMenu = menuNumber == 1 ? menu1 : menu2;

        if (currentMenu.firstButton != null)
        {
            currentMenu.firstButton.Select();
        }

        arrowindex = 0;
        MoveArrow();
    }

    void MoveArrow()
    {
        if (currentMenu.arrow == null || currentMenu.arrowstuffs == null || currentMenu.arrowstuffs.Length == 0)
        {

            return;
        }

        arrowindex = Mathf.Clamp(arrowindex, 0, currentMenu.arrowstuffs.Length - 1);

        Canvas.ForceUpdateCanvases();
        currentMenu.arrow.transform.position = currentMenu.arrowstuffs[arrowindex].position;
    }
}
