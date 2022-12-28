# 기술 독립적인 `Tic Tac Toe` 프로젝트 만들기

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
- 개발을 위한 **UseCase 단위 테스트 초안을 작성한다.**
- UseCase 단위 테스트 초안을 기반으로 **UseCase와 Entity을 구현한다.**
- 구현 과정속에서 **새로운 UseCase 단위 테스트를 발굴한다.**

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

dotnet add .\Src\TicTacToe.Entities\ package Ardalis.SmartEnum
dotnet add .\TicTacToe.Entities.UnitTest\ package FluentAssertions --version 6.8.0
dotnet add .\TicTacToe.UseCases.UnitTest\ package FluentAssertions --version 6.8.0
```

<br/>

## UseCase 단위 테스트
### UseCase 단위 테스트 초안
1. 먼저 플레이를 시작하는 플레이어는 X이다.
1. 플레이어는 이미 채워진 공간에는 표시를 할 수 없다.
1. 플레이어 X가 빈 공간에 X 표시를 하면 이 공간은 더 이상 사용할 수 없다.
1. 플레이어 O가 플레이어 X가 표시를 한 후에 표시할 수 있다.
1. 플레이어는 존재하지 않는 공간에는 표시할 수 없다.
1. 이미 사용된 공간에 표시를 하려고 하면 에외가 발생한다.
1. 플레이어 X가 한 행에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
1. 플레이어 X가 한 열에 세 게의 X 표시를 모두 하면 플레이어 X가 승리한다.
1. 플레이어 X가 대각선으로 세 개의 X 표시를 모두 하면 플레이어 X가 승리한다.
1. 모든 공간이 채워지고 승자가 없으면 게임은 무승부가 된다.

### UseCase 단위 테스트 최종
1. 먼저 플레이를 시작하는 플레이어는 X이다.
   ```
   Player_X_Is_The_First_To_Place_A_Marker
   ```
