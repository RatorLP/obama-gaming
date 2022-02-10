using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DebugController : MonoBehaviour
{
    GameObject dataManager; //Variable declaration
    DDOL gameController;

    bool showConsole = false;

    string input; //input for cheats

    public List<object> commandList;

    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\  CHEATS & COMMANDS  \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    public static DebugCommand KILL_ALL;
    public static DebugCommand HEALTH_PLUS;

    private void Awake()
    {
        KILL_ALL = new DebugCommand("kill_all", "Removes all enemys from the scene.", "kill_all", () =>
        {
            Debug.Log("Killing all enemys");
            //gameController.KillAllEnemys();         - KillAllEnemys function not yet implemented
        });

        HEALTH_PLUS = new DebugCommand("health+", "Adds 1000 HP", "health+", () =>
        {
            Debug.Log("Adding 1000 HP");
            gameController.maxHealth += 1000;
            gameController.health += 1000;
        });

        commandList = new List<object>
        {
            KILL_ALL,
            HEALTH_PLUS
        };
    }
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    void Start()
    {
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Enable Debug Button 1"))
        {
            showConsole = !showConsole;
            if (showConsole) //pauses the game, while the console is displayed
            {
                gameController.PauseGame(true);
            } else
            {
                gameController.PauseGame(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (showConsole) //Handles input, when enter is pressed and the textbox is not in focus anymore
            {
                HandleInput();
                input = "";
            }
        }
    }

    private void OnGUI()
    {
        if (!showConsole) { return; } // prevents from executing the method while showConsole is set to false

        float y = 0;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0); 
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

        if (Event.current.keyCode == KeyCode.Return) //Handles input, when enter is pressed and the textbox is still in focus
        {
            HandleInput();
            input = "";
        }

        // EventSystem.current.SetSelectedGameObject(inputField.gameObject, null); //trying to automatically focus on the input field. (doesnt work yet)
        // inputField.ActivateInputField();
    }

    private void HandleInput()
    {
        for(int i=0; i<commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if(input.Contains(commandBase.commandID))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
