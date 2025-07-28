<div align="center">
<h2> 🎮 스파르타 메타버스 프로젝트 🎮 </h2>
<img width="752" height="417" alt="image" src="https://github.com/user-attachments/assets/3dd58df7-0c97-43ca-b884-bf077fde7559" />
<p>
<b>'Modern City'</b>는 작은 도시 속에서 NPC들과 대화를 나누고, 미니게임으로 하루를 보낼 수 있는 게임입니다.   
특정 장소에서 열리는 미니게임에 도전해 높은 점수를 기록하고, 리더보드에서 친구들과 경쟁해보세요!
</p>
</div>

## 목차
  - [개요](#개요) 
  - [게임 설명](#게임-설명)
  - [게임 플레이 방식](#게임-플레이-방식)
  - [게임 시연](#게임-시연)
  - [구현 기능 (필수 기능)](#구현-기능-(필수-기능))
  - [구현 기능 (도전 기능)](#구현-기능-(도전-기능))
  - [핵심 기능](#핵심-기능)
  - [트러블 슈팅](#트러블-슈팅)
  - [프로젝트 회고](#프로젝트-회고)

<br>

## 개요
게임 스타일의 맵과 상호작용을 기반으로 한 2D 미니 게임
- 게임 이름: Modern City
- 장르 : Top-Down
- 특징 : NPC 상호작용, 미니게임
- 프로젝트 기간: 2025.07.21 - 2025.07.28
- 개발 언어: C#, Unity(2022.3.17f1)

<br>

## 게임 설명
|![image](https://github.com/user-attachments/assets/f3e46123-8a42-4ce9-99fa-2b5141951ba0)|
|:---:|
|시작 화면|

|![image](https://github.com/user-attachments/assets/42d17575-a0a2-42b4-a2cb-28a68a76141a)|![image](https://github.com/user-attachments/assets/ebce9475-35ab-4387-a7bd-90552732619e)|
|:---:|:---:|
|미니게임 화면|NPC 상호작용 화면|


<b>'Modern City'</b>에서는 NPC와 상호작용, 미니게임을 플레이할 수 있습니다. 


<br>

## 게임 플레이 방식
- (조작법)
  <p>캐릭터 조작법 : QWER로 이동</p>
  <p>미니게임 조작법 : 마우스 클릭</p>
  <p>NPC 대화넘기기 : Button UI 클릭</p>

<br>

## 게임 시연
![1](https://github.com/user-attachments/assets/bb6ad21f-7842-47ad-95c1-b70a5fa0d9bf)
![2](https://github.com/user-attachments/assets/4fd1e0f1-cac7-4819-80ff-e0a817aa14db)
![3](https://github.com/user-attachments/assets/8a9303da-dd0d-4cb3-b7ba-9313c8ea1f09)
![4](https://github.com/user-attachments/assets/512410c0-1337-4f43-a539-f3486017f8de)
![5](https://github.com/user-attachments/assets/a47e7065-339e-4be6-a078-c08237422bda)

<br>

## 구현 기능 (필수 기능)
(캐릭터 이동 및 맵 탐색)
<p>간단한 소개와 할 수 있는 행동을 알려줍니다.</p>
<img width="1191" height="703" alt="title" src="https://github.com/user-attachments/assets/f3e46123-8a42-4ce9-99fa-2b5141951ba0" />

<br>
(맵 설계 및 상호작용 영역)
<p>캐릭터의 정보를 표시합니다.</p>
<img width="852" height="450" alt="status" src="https://github.com/user-attachments/assets/1cf1bb56-1b2d-4619-9b7b-07bd12c5714d" />

<br>
<br>
(미니게임 실행)<br>
<p>전투가 시작되면 1~4마리 교도관이 랜덤으로 등장합니다. (예시에서는 3명이 등장했습니다)</p>
<img width="1207" height="663" alt="battle" src="https://github.com/user-attachments/assets/48ef8e28-8a68-4c3c-9314-2e75405da45a" />
&nbsp;

(점수 시스템)
<p>플레이어가 공격을 선택하면 교도관 앞에 숫자가 표시되고, 공격할 수 있습니다.</p>
<img width="1205" height="703" alt="player attack" src="https://github.com/user-attachments/assets/94fd7e4b-8e2c-4fe3-abb3-4548230ee0f1" />
&nbsp;

<p>이미 죽은 교도관을 선택하거나, 없는 숫자를 입력하면 "잘못된 입력입니다"를 출력합니다.</p>
<img width="1207" height="672" alt="input error" src="https://github.com/user-attachments/assets/72a58d6f-20f4-4a96-973d-cdfd3b78f100" />
&nbsp;

<p>공격력은 다음과 같이 오차를 가집니다.</p>
<p>(기본 공격력 - 기본 공격력의 10%) ~ (기본 공격력 + 기본 공격력의 10%)</p>
<img width="852" height="450" alt="status" src="https://github.com/user-attachments/assets/1cf1bb56-1b2d-4619-9b7b-07bd12c5714d" />
<img width="1206" height="677" alt="attackVariance" src="https://github.com/user-attachments/assets/ea30fe00-1804-4f5d-8bd2-c605b0802179" />
&nbsp;

<p>죽은 몬스터는 Dead로 표시하고, 텍스트는 어두운 색으로 표시합니다.</p>
<img width="1211" height="740" alt="enemy dead" src="https://github.com/user-attachments/assets/d86d0ae8-b3fd-4da3-9cab-57928024ab76" />
&nbsp;

(게임 종료 및 복귀)
</p>플레이어의 공격이 끝나면, 교도관이 공격합니다.</p>
<img width="1203" height="727" alt="enemy attack" src="https://github.com/user-attachments/assets/c24bedee-c4e4-42c9-85c9-8cebdb5bc2c2" />
&nbsp;

<p>다음을 입력하면 다음 교도관이 차례대로 공격합니다.</p>
<img width="1205" height="708" alt="enemy turn1" src="https://github.com/user-attachments/assets/bfbb4420-d347-4c01-9dfa-c6d42e23e147" />
<img width="1206" height="721" alt="enemy turn2" src="https://github.com/user-attachments/assets/d03149ae-24d8-4e82-87c3-b1a182550f60" />
&nbsp;

<p>몬스터 차례가 끝나면, 플레이어의 턴으로 돌아옵니다.</p>
<img width="1208" height="788" alt="player turn" src="https://github.com/user-attachments/assets/2fd00e1e-5ec3-44e2-b93f-f430e03e9fe4" />
&nbsp;

(카메라 추적 기능)
<p>모든 교도관이 Dead 상태가 되면 승리, 플레이어가 Dead 상태가 되면 패배하게 됩니다.</p>
<img width="1130" height="702" alt="win" src="https://github.com/user-attachments/assets/42d17575-a0a2-42b4-a2cb-28a68a76141a" />
<img width="880" height="693" alt="lose" src="https://github.com/user-attachments/assets/ebce9475-35ab-4387-a7bd-90552732619e" />
&nbsp;

## 구현 기능 (도전 기능)
(리더보드 시스템)
<p>이름과 나의 모습을 선택하면 캐릭터가 생성됩니다.</p>
<img width="1208" height="570" alt="name" src="https://github.com/user-attachments/assets/02d034d4-621e-455f-b3ac-5e0a3f97d047" />
<img width="1203" height="675" alt="job" src="https://github.com/user-attachments/assets/8fa384b3-e464-45ce-8d57-58de77dc5448" />
&nbsp;

(NPC와 대화 시스템)
<p>몬스터 : 신입교도관, 선임교도관, 교도부사관, 교도관리소장</p>
<img width="1207" height="663" alt="battle" src="https://github.com/user-attachments/assets/48ef8e28-8a68-4c3c-9314-2e75405da45a" />
&nbsp;

(아이템 적용)
<p>아이템을 장착, 장착해제할 수 있습니다.</p>
<img width="1205" height="420" alt="equip item" src="https://github.com/user-attachments/assets/dfa13e4e-dad2-4889-9679-88a9beb0f169" />
&nbsp;

(회복 아이템)
<p>담배, 각성제로 체력과 마나를 회복할 수 있습니다.</p>
<img width="1207" height="826" alt="store" src="https://github.com/user-attachments/assets/56e8a43d-b62e-40a5-a91d-e447764af37a" />
&nbsp;

## 핵심 기능
<img width="1110" height="622" alt="singleton" src="https://github.com/user-attachments/assets/48dea3c5-42c9-479c-a880-4a3df6462e34" />
<img width="1107" height="618" alt="management class" src="https://github.com/user-attachments/assets/3c729962-9515-482c-a52e-c6b782eb4519" />

<br><br>

## 트러블 슈팅
<img width="1110" height="621" alt="trouble shooting1-1" src="https://github.com/user-attachments/assets/11abc978-c0b5-4682-8327-d26bbd750bea" />
<img width="1111" height="622" alt="trouble shooting1-2" src="https://github.com/user-attachments/assets/aebdd0ea-c7ea-425b-8c02-846597bf8269" />

<br><br>

## 프로젝트 회고 
<img width="1111" height="622" alt="project " src="https://github.com/user-attachments/assets/ce243454-8fe1-4653-8947-ee4c8082a952" />
