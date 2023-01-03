# Chapter 00. 몸 풀기 | 클린 아키텍처 준비

## 주요 개념
1. **분리**
   - `기술 독립적인 코드`와 `기술 의존적인 코드`를 분리한다.
   > - 기술 독립적인 코드란?
   >   - 비즈니스 요구사항을 구현하기 위해 `프로그래밍 언어`에만 의존하는 코드
   > - 기술 의존적인 코드란?
   >   - 비즈니스 요구사항을 동작시키 위해 `구체적인 기술`에 의존하는 코드
1. **통합**
   - 기술 독립적인 코드와 기술 의존적인 코드를 `유스 케이스`로 공통분모를 만든다.
   - 유스 케이스란?
     - 기술 독립적인 코드다.
1. **도메인 중심**
   - 기술 의존적인 코드 > 유스 케이스 > 기술 독립적인 코드(중심)
1. **의존성 방향**
   - 기술 의존적인 코드(입력) `→` 유스 케이스 → 기술 독립적인 코드
   - 기술 의존적인 코드(출력) `→` 유스 케이스 → 기술 독립적인 코드
1. **제어 흐름(의존성 역전)**
   - 기술 의존적인 코드(입력) `→` 유스 케이스 → 기술 독립적인 코드
   - 기술 의존적인 코드(출력) `←(의존성 역전)` 유스 케이스 → 기술 독립적인 코드

## 레이어 용어
- `Adapter`
  - `Input Adapter`
  - `Output Adapter`
- `Use Cases`
  - `Input Port(interface)`
  - `Output Port(interface)`
  - `Use Case`
- `Entities`
  - `Entity`
  - `Value Object`

## 참고 자료
- [Use code coverage for unit testing](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)
