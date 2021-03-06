﻿using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    void Start() {
        var pool = Pools.pool;
        pool.GetGroup(Matcher.Vector3);
        pool.GetGroup(Matcher.GameObject);
        pool.GetGroup(Matcher.AllOf(Matcher.GameObject, Matcher.Vector3));
        pool.GetGroup(Matcher.AllOf(Matcher.GameObject, Matcher.Vector3));

        createTestEntities(pool);
        createTestEntityWithNullValues(pool);
    }

    void createTestEntities(Pool pool) {
        for (int i = 0; i < 2; i++) {
            var e = pool.CreateEntity();

            // Unity's builtIn
            e.AddBounds(new Bounds());
            e.AddColor(Color.red);
            e.AddAnimationCurve(AnimationCurve.EaseInOut(0f, 0f, 1f, 1f));
            e.AddMyEnum(MyEnumComponent.MyEnum.Item2);
            e.AddMyFloat(4.2f);
            e.AddMyInt(42);
            e.AddRect(new Rect(1f, 2f, 3f, 4f));
            e.AddMyString("Hello, world!");
            e.AddVector2(new Vector2(1f, 2f));
            e.AddVector3(new Vector3(1f, 2f, 3f));
            e.AddVector4(new Vector4(1f, 2f, 3f, 4f));
            e.AddMyBool(true);
            e.AddUnityObject(new UnityEngine.Object());
            e.AddGameObject(new GameObject("Player"));

            // Custom
            e.AddCustomObject(new CustomObject("Custom Object"));
            e.AddSystemObject(new object());
            e.AddDateTime(DateTime.Now);
            e.AddAnArray(new [] { "Hello", ", ", "world", "!" });
            e.AddArray2D(new int[2, 3]);
            e.AddArray3D(new int[2, 3, 4]);
            string[][] jaggedArray = new string[2][];
            jaggedArray[0] = new [] { "Entity", "Component", "System" };
            jaggedArray[1] = new [] { "For", "C#" };
            e.AddJaggedArray(jaggedArray);
            var listArray = new List<string>[] {
                new List<string> { "1", "2", "3" },
                new List<string> { "One", "Two", "Three" }
            };
            e.AddListArray(listArray);
            e.AddList(new List<string>{ "Apple", "Banana", "Peach" });
            var dict = new Dictionary<string, string> {
                { "1", "One" },
                { "2", "Two" },
                { "3", "Three" },
            };
            e.AddDictionary(dict);
            var dict2 = new Dictionary<int, string[]> {
                { 1, new [] { "One", "Two", "Three" } },
                { 2, new [] { "Four", "Five", "Six" } }
            };
            var dictArray = new Dictionary<int, string[]>[] {
                new Dictionary<int, string[]> {
                    { 1, new [] { "One", "Two", "Three" } },
                    { 2, new [] { "Four", "Five", "Six" } }
                }, new Dictionary<int, string[]> {
                    { 3, new [] { "One", "Two", "Three" } },
                    { 4, new [] { "Four", "Five", "Six" } }
                }
            };
            e.AddDictArray(dict2, dictArray);
            e.AddHashSet(new HashSet<string> { "One", "Two", "Three" });
            e.AddUnsupportedObject(new UnsupportedObject("Unsupported Object"));
        }
    }

    void createTestEntityWithNullValues(Pool pool) {
        var e = pool.CreateEntity();

        // Unity's builtIn
        AnimationCurve animationCurve = null;
        e.AddAnimationCurve(animationCurve);
        String myString = null;
        e.AddMyString(myString);
        UnityEngine.Object unityObject = null;
        e.AddUnityObject(unityObject);
        GameObject go = null;
        e.AddGameObject(go);

        // Custom
        CustomObject customObject = null;
        e.AddCustomObject(customObject);
        object systemObject = null;
        e.AddSystemObject(systemObject);
        string[] array = null;
        e.AddAnArray(array);
        int[,] array2d = null;
        e.AddArray2D(array2d);
        int[,,] array3d = null;
        e.AddArray3D(array3d);
        string[][] jaggedArray = null;
        e.AddJaggedArray(jaggedArray);
        List<string>[] listArray = null;
        e.AddListArray(listArray);
        List<string> list = null;
        e.AddList(list);
        Dictionary<string, string> dict = null;
        e.AddDictionary(dict);
        Dictionary<int, string[]> dict2 = null;
        Dictionary<int, string[]>[] dictArray = null;
        e.AddDictArray(dict2, dictArray);
        HashSet<string> hashset = null;
        e.AddHashSet(hashset);
        UnsupportedObject unsupportedObject = null;
        e.AddUnsupportedObject(unsupportedObject);
    }
}

