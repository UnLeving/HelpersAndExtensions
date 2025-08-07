using System;
using Helpers;
using UnityEngine;

public class Test : Singleton<Test>
{
    public void Fu()
    {
        
    }
}

public class Test2 : MonoBehaviour
{
    private void Awake()
    {
        Test.Instance.Fu();
    }
}