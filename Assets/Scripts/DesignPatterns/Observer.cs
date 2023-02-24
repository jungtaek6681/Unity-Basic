using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//========================================
//##		디자인 패턴 Observer			##
//========================================
/*
	옵저버 패턴 :
	옵저버는 객체의 상태 변화를 관찰하는 관찰자
	관찰대상객체는 옵저버들의 목록을 등록하여 보관
	관찰대상객체에 상태 변화가 있을 때마다 등록한 옵저버들에게 알림

	구현 :
	0. C#의 경우 event delegate를 이용하여 옵저버 패턴을 적용가능
	0. Unity의 경우 UnityEvent를 이용하여 옵저버 패턴을 적용가능

	1. 관찰대상객체에 옵저버들의 목록과 옵저버의 등록, 해제를 구현
	2. 옵저버는 관찰대상객체에 상태 변화를 알림 받고 싶은 경우 목록에 등록
	3. 관찰대상객체에 상태 변하가 있는 경우 목록의 옵저버들을 순회하며 알림

	장점 :
	1. 클래스간의 느슨한 연결구조로 유연한 객체지향 시스템을 구축
	2. 개방폐쇄원칙을 준수하게 됨
	3. 프레임마다 상태 변화를 확인하는 방법보다 콜백방식을 통해 연산량을 줄일 수 있음

	단점 :
	1. 알림이 가는 순서를 보장할 수 없음
	2. 부주의한 사용은 이벤트 연쇄, 순환 구조 등의 문제가 생길 수 있음
*/

public class Observer
{
	public void Notify() { }
}

public class Subject
{
	private List<Observer> observerList;

	public void RegisterObserver(Observer observer)
	{
		observerList.Add(observer);
	}

	public void UnregisterObserver(Observer observer)
	{
		observerList.Remove(observer);
	}

	private void NotifyObserver()
	{
		foreach (Observer observer in observerList)
		{
			observer.Notify();
		}
	}
}
