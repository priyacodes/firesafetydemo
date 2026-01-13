using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif


    ///<Summary>
    /// Set the scene (usually a fieltrip) to load & any additional delay.
    ///</Summary>

    ///<Remarks>
    /// 
    ///</Remarks>

    ///<ToDoList>
    /// Would be nice to get scenes in build on a dropdown rather than typed
    ///</ToDoList>
    public class SceneSwitcher : MonoBehaviour
    {
        public string SceneToLoad;

        public bool successfulEvacuation;
    public static SceneSwitcher Instance; // A static reference to the single instance

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy new instances if one already exists
        }
    }
    void Start()
        {

            //if (LoadAfterDelay)
            //    StartCoroutine(TimeInSceneLoad());
        }

        public IEnumerator TimeInSceneLoad()
        {
            yield return new WaitForSeconds(0.2f);
            //SceneManager.LoadScene(SceneToLoad);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        public void LoadThisScene(string name)
        {
            StartCoroutine(LoadSceneAsync(name));

        }

        public static IEnumerator LoadSceneAsync(string sceneName)
        {

            // yield return new WaitForSeconds(0.2f);
            yield return new WaitForSeconds(5);


            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {  
                yield return null;
            }
        }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            StartCoroutine(LoadSceneAsync("FireSimV2"));

        if (Input.GetKeyDown(KeyCode.G))
            StartCoroutine(LoadSceneAsync("GreenRoom"));

        //if (Input.GetKeyDown(KeyCode.L))
        //    StartCoroutine(LoadSceneAsync("LobbyScene"));
    }


}

