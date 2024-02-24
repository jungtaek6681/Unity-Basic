/****************************************************
 *              디자인 패턴 Observer                *
 ****************************************************/

/*
 * <옵저버 패턴>
 * 객체가 상태 변화가 있을 때 반응할 객체들을 호출하는 방식이 아닌
 * 관찰자들이 관찰대상객체의 상태 변화에 반응하는 방법을 구현하는 방법
 * 
 * 
 * <구현>
 * 1. 관찰대상객체에 관찰자들의 목록과 관찰자의 등록, 해제를 구현
 * 2. 관찰자는 관찰대상객체에 상태 변화를 확인하고 싶은 경우 목록에 등록
 * 3. 관찰대상객체에 상태 변화가 있는 경우 목록의 관찰자들을 순회하며 알림
 * 
 * <장점>
 * 1. 클래스간의 느슨한 연결구조로 유연한 객체지향 시스템을 구축
 * 2. 개방폐쇄원칙을 준수하게 됨
 * 
 * <주의점>
 * 1. 알림이 가는 순서를 보장하지는 않음
 * 2. 이벤트 연쇄, 순환 구조 등의 문제를 주의해야 함
 */


using System.Collections.Generic;

namespace DesignPattern
{
    public class Observer
    {
        public void Notify() { }
    }

    public class Subject
    {
        private List<Observer> observerList = new List<Observer>();

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
}