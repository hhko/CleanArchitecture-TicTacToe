# Chapter 06. 기술 독립적인 객체지향 `Tic Tac Toe`
> **기술 독립적인란?**
> - Core 레이어인 UseCases와 Entities 레이어만 구현한다.
> - 구체적인 기술을 구현하는 Adapters(Presentation, Infrastructure) 레이어는 구현하지 않는다.

<br/>

## 목차
1. 목표
1. 솔루션 구성
   - 프로젝트 폴더 구성
   - 프로젝트 생성 명령
   - 프로젝트 참조 명령
1. UseCase 단위 테스트
   - UseCase 단위 테스트 초안
   - UseCase 단위 테스트 최종

<br/>

## 목표
- Tic Tac Toe을 **UseCase 단위 테스트 기반으로 개발한다.**

<br/>

## 솔루션 구성
### 프로젝트 폴더 구성
```
TicTacToe  
 ├─Src  
 │  ├─TicTacToe.Entities  
 │  └─TicTacToe.UseCases  
 └─Tests  
    ├─TicTacToe.Entities.UnitTest  
    └─TicTacToe.UseCases.UnitTest  
```

### 프로젝트 생성 명령
```shell
# 솔루션 생성
# - TicTacToe 폴더 생성
# - TicTacToe 플더에서 명령 실행
dotnet new sln -n TicTacToe

# 프로젝트 생성
# - Src 폴더 생성
# - Src 폴더에서 명령 실행
dotnet new classlib -o TicTacToe.Entities
dotnet new classlib -o TicTacToe.UseCases

# 단위 테스트 프로젝트 생성
# - Tests 폴더 생성
# - Tests 폴더에서 명령 실행
dotnet new xunit -o TicTacToe.Entities.UnitTest
dotnet new xunit -o TicTacToe.UseCases.UnitTest

# 솔루션에 모든 프로젝트 추가
# - TicTacToe 폴더에서 명령 실행(.sln 파일이 있는 경로)
dotnet sln add (ls -r **\*.csproj)

# 빌드 & 테스트
dotnet build
dotnet test
```

### 프로젝트 참조 명령
```shell
dotnet add .\Src\TicTacToe.UseCases\ reference .\Src\TicTacToe.Entities\
dotnet add .\Tests\TicTacToe.UseCases.UnitTest\ reference .\Src\TicTacToe.UseCases\
dotnet add .\Tests\TicTacToe.UseCases.UnitTest\ reference .\Src\TicTacToe.Entities\

dotnet add .\Src\TicTacToe.Entities\ package Ardalis.SmartEnum --version 2.1.0
dotnet add .\TicTacToe.Entities.UnitTest\ package FluentAssertions --version 6.8.0
dotnet add .\TicTacToe.UseCases.UnitTest\ package FluentAssertions --version 6.8.0
```

<br/>

## UseCase 단위 테스트
### UseCase 단위 테스트 초안
- [x] 01. 먼저 플레이를 시작하는 플레이어는 X이다.
- [x] 02. 플레이어는 이미 채워진 공간에는 표시를 할 수 없다.
- [ ] 03. 플레이어 X가 빈 공간에 X 표시를 하면 이 공간은 더 이상 사용할 수 없다.
- [x] 04. 플레이어 O가 플레이어 X가 표시를 한 후에 표시할 수 있다.
- [x] 05. ~~플레이어는 존재하지 않는 공간에는 표시할 수 없다.~~
- [x] 06. 이미 사용된 공간에 표시를 하려고 하면 에외가 발생한다.
- [x] 07. 플레이어 X가 한 행에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
- [x] 08. 플레이어 X가 한 열에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
- [x] 09. 플레이어 X가 대각선으로 세 개의 X 표시를 모두 하면 플레이어 X가 승리한다.
- [ ] 10. 모든 공간이 채워지고 승자가 없으면 게임은 무승부가 된다.

### UseCase 단위 테스트 최종
- [x] 01-1. 먼저 플레이를 시작하는 플레이어는 X이다.
  ```cs
  public void Player_X_Is_The_First_To_Place_A_Marker()
  ```
- [x] 01-2. **추가됨 : 첫 번째 플레이어는 어디에든 표시할 수 있다.**
  ```cs
  public void The_First_Player_Can_Place_Marker_Anywhere()
  ```
- [x] 02. 플레이어는 이미 채워진 공간에는 표시를 할 수 없다.
  ```cs
  public void After_A_Player_Places_A_Marker_The_Square_Is_Unavailable()
  ```
- [ ] 03. 플레이어 X가 빈 공간에 X 표시를 하면 이 공간은 더 이상 사용할 수 없다.
- [x] 04. 플레이어 O가 플레이어 X가 표시를 한 후에 표시할 수 있다.
  ```cs
  public void Player_O_Will_Be_Next_To_Take_A_Turn_After_Player_X_Has_Placed_A_Marker()
  ```
- [x] 05. ~~플레이어는 존재하지 않는 공간에는 표시할 수 없다.~~
  ```cs
  public void A_Player_Cannot_Place_A_Marker_In_A_Zone_Than_Does_Not_Exist()
  ```
  > 물리적(컴파일 타임과 런타임)으로 존재할 수 없는 테스트 시나리오이다.
  - dotnet build 실패(`컴파일 타임 에러`) : int -> Row 타입으로 변환할 수 없다.
    ```cs
    // 'int'에서 'TicTacToe.Entities.Row'(으)로 변환할 수 없습니다.
    bool result = ticTacToe.CanPlaceMarkerAt(100, 200);
    ```
  - dotnet test 실패(`런타임 에러`) : 올바른 객체를 생성할 수 없다.
    ```cs
    // Ardalis.SmartEnum.SmartEnumNotFoundException : No Row with Value 100 found.
    bool result = ticTacToe.CanPlaceMarkerAt(Row.FromValue(100), Column.FromValue(200));
    ```
- [x] 06(03). 이미 사용된 공간에 표시를 하려고 하면 에외가 발생한다.
  ```cs
  public void Exception_Will_Be_Thrown_If_Player_Tries_To_Place_Marker_In_A_Taken_Square()
  ```
- [x] 07-1. 플레이어 X가 한 행에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
  ```cs
  public void If_Player_X_Gets_Three_Xs_In_A_Row_Then_The_Game_Is_Won_By_Player_X()
  ```
- [x] 07-2. 누군가 승리하거나 혹은 게임이 비기지 않은 이상 플레이어 X나 플레이어 O가 표시해야 할 순서인 상태가 있을 수 있다
  ```cs
  public void The_Game_Status_Should_Be_Awaiting_Either_Player_X_Or_O_If_The_Game_Is_Not_Won_Or_Drawn()
  ```
- [x] 08. 플레이어 X가 한 열에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
  ```cs
  public void If_Player_X_Gets_Three_Xs_In_A_Column_Then_The_Game_Is_Won_By_Player_X()
  ```
- [x] 09. 플레이어 X가 대각선으로 세 개의 X 표시를 모두 하면 플레이어 X가 승리한다.
  ```cs
  public void If_Player_X_Gets_Three_Xs_In_A_Diagonal_Then_The_Game_Is_Won_By_Player_X()
  ```

<br/>

## TODO
- 단위 테스트 구현
- 액션아이템과 구현 연동
- if ... -> switch 구분 변경
- VSCode task 통합 : 빌드, 테스트
- VSCode Unit Test 확장 도구
- VSCode Code Coverage
- dotnet CLI test 로그
- dotnet CLI Code Coverage
- GitHub CI/CD
- Clean Architecture 다이어그램과 Layer 설명
- UseCase 개념(Application Service)으로 리팩토링


## nuget 명령
### NuGET 패키지 복원이 정상적으로 안될 때
```shell
# dotnet build
#   warning NU1803:
#     You are running the 'restore' operation with an 'HTTP' source,
#     'http://package.xyz.co.kr/nuget'. Non-HTTPS access will be removed in a future version. Consider migrating to an 'HTTPS' source.

# http://package.xyz.co.kr/nuget을 확인한다
dotnet nuget list source

# http://package.xyz.co.kr/nuget 이름으로 비활성화 한다
dotnet nuget disable source 이름

# dotnet build을 다시 수행한다
```
