using System;
using UnityEngine;
using UnityEngine.Events;

public class TestEvent : MonoBehaviour
{
	event Action csharpEv0;
	UnityEvent unityEv0 = new UnityEvent();
 
	void Start()
	{
		AddCsharpListener();
		AddUnityListener();
		AddCsharpListener2();
		AddUnityListener2();
		AddCsharpListener3();
		AddUnityListener3();
		AddCsharpListener4();
		AddUnityListener4();
	}
 
	void AddCsharpListener()
	{
		csharpEv0 += NoOp;
	}
 
	void AddUnityListener()
	{
		unityEv0.AddListener(NoOp);
	}
 
	void AddCsharpListener2()
	{
		csharpEv0 += NoOp;
	}
 
	void AddUnityListener2()
	{
		unityEv0.AddListener(NoOp);
	}
 
	void AddCsharpListener3()
	{
		csharpEv0 += NoOp;
	}
 
	void AddUnityListener3()
	{
		unityEv0.AddListener(NoOp);
	}
 
	void AddCsharpListener4()
	{
		csharpEv0 += NoOp;
	}
 
	void AddUnityListener4()
	{
		unityEv0.AddListener(NoOp);
	}
 
	static void NoOp(){}
}
