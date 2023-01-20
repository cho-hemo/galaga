using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public static class GioleFunc
{
    //! 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildObj(
        this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;


        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            // if (searchResult.name.Equals(objName_)){
            //     return searchResult;
            // }
            // else {/*Do nothing*/}
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {

                searchResult = searchTarget;

                // Debug.Log($"{targetObj_}, {searchResult}");

                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, objName_);
                if (searchResult != default)
                {
                    return searchResult;
                }
            }
        }
        return searchResult;
        // Debug.Log($"{targetObj_}, {searchResult}");
    }

    //! 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach (GameObject rootObj in rootObjs_)
        {
            if (rootObj.name.Equals(objName_))
            {
                targetObj_ = rootObj;
                return targetObj_;
            }
            else { continue; }
        }       // loop

        return targetObj_;
    }       // GetRootObj()

    //! 현재 활성화 되어 있는 씬을 찾아주는 함수
    private static Scene GetActiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    }

    public static void LoadScene(string sceneName_)
    {
        //! 다른 씬을 로드하는 함수
        SceneManager.LoadScene(sceneName_);
    }
    public static void QuitThisGame()
    {
        // 게임 종료 함수
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }       // QuitThisGame()

    public static void SetTmpText(GameObject obj_, string text_)
    {
        //! 텍스트매쉬프로 형태의 컴포넌트의 텍스트를 설정하는 경우
        TMP_Text tmpTXT = obj_.GetComponent<TMP_Text>();
        if (tmpTXT == null || tmpTXT == default)
        {
            return;
        }       // if: 가져올 텍스트매쉬 컴포넌트가 없는 경우 리턴


        // 가져올 텍스트매쉬 컴포넌트가 존재하는 경우
        tmpTXT.text = text_;
    }       // SetTextMeshPro()


}
