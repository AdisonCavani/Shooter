using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Console
{
    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public void AddCommandToConsole()
        {
            DeveloperConsole.AddCommandsToConsole(Command, this);

#if UNITY_EDITOR
            string addMessage = " command has been added to the console";
            Debug.Log(Name + addMessage);
#endif
        }

        public abstract void RunCommand(string[] args);
    }

    public class DeveloperConsole : MonoBehaviour
    {
        public static DeveloperConsole Instance { get; private set; }
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

        [Header("UI Components")]
        public Canvas consoleCanvas;
        public TextMeshProUGUI consoleText;
        public GameObject inputText;
        public TMP_InputField consoleInput;

        [Header("UI Colors")]
        public static string LogColor = "#dadada";
        public static string WarningColor = "#ffba32";
        public static string ErrorColor = "#f74000";
        

        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            Instance = this;
            Commands = new Dictionary<string, ConsoleCommand>();
        }

        private void Start()
        {
            consoleCanvas.gameObject.SetActive(false);
            CreateCommands();
        }

        private void HandleLog(string logMessage, string stackTrace, LogType type)
        {

            if (type.ToString() == "Warning")
            {
                string _message = $"<color={WarningColor}>[" + type.ToString() + "] " + logMessage + "</color>";
                AddMessageToConsole(_message);
            }
            else if (type.ToString() == "Error")
            {
                string _message = $"<color={ErrorColor}>[" + type.ToString() + "] " + logMessage + "</color>";
                AddMessageToConsole(_message);
            }
            else
            {
                string _message = $"<color={LogColor}>[" + type.ToString() + "] " + logMessage + "</color>";
                AddMessageToConsole(_message);
            }
        }

        private void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        private void CreateCommands()
        {
            CommandQuit.CreateCommand();
            CommandClear.CreateCommand();
        }

        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if (!Commands.ContainsKey(_name))
            {
                Commands.Add(_name, _command);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote)) // Console keybind
            {
                consoleCanvas.gameObject.SetActive(!consoleCanvas.gameObject.activeInHierarchy); // Toggle command
            }

            if (consoleCanvas.gameObject.activeInHierarchy)
            {
                consoleInput.Select();

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (inputText.GetComponent<TMP_InputField>().text != "")
                    {
                        ParseInput(inputText.GetComponent<TMP_InputField>().text);

                        // Clear console after Enter was pressed
                        inputText.GetComponent<TMP_InputField>().text = "";
                        consoleInput.Select();
                        consoleInput.ActivateInputField();
                    }
                }
            }
        }

        private void AddMessageToConsole(string msg)
        {
            consoleText.text += msg + "\n";
        }

        public void ClearConsole()
        {
            consoleText.text = "";
        }

        private void ParseInput(string input)
        {
            string[] _input = input.Split(' ');
            string msg = input;

            if (_input.Length == 0 || _input == null)
            {
                Debug.LogWarning("Unknown command \"" + msg + "\"");
                return;
            }
            if (!Commands.ContainsKey(_input[0]))
            {
                Debug.LogWarning("Unknown command \"" + msg + "\"");
            }
            else
            {
                // Create a lit to leverage Linq
                List<string> args = _input.ToList();

                // Remove index 0 (the command)
                args.RemoveAt(0);

                // Check if '-help' was passed
                if (args.Contains("-help"))
                {
                    AddMessageToConsole("\n___________________________________");
                    AddMessageToConsole("<b>Name:</b>");
                    AddMessageToConsole(Commands[_input[0]].Name + "\n");
                    AddMessageToConsole("<b>Command:</b>");
                    AddMessageToConsole("<i>" + Commands[_input[0]].Command + "</i>\n");
                    AddMessageToConsole("<b>Description:</b>");
                    AddMessageToConsole(Commands[_input[0]].Description);
                    AddMessageToConsole("___________________________________\n\n");

                    return;
                }

                // Run the command and pass args
                Commands[_input[0]].RunCommand(args.ToArray());
            }
        }
    }
}