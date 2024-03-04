# ターン制バトルのクリーンアーキテクチャ実装
RPGのターン制バトルをクリーンアーキテクチャにて実装した

#  クリーンアーキテクチャについて
今回クリーンアーキテクチャにより実装をするにあたって以下の点を意識して実装、設計を行った

- 依存関係の逆転（Dependency Inversion）: 内側のレイヤーは外側のレイヤーに依存せず、外側のレイヤーが内側のレイヤーに依存する。
- インターフェース適応: 外側のレイヤー（UI, データベース, フレームワークなど）は、内側のレイヤーと通信するためにインターフェースを通じて適応する。
- 関心の分離（Separation of Concerns）: システムを複数のレイヤーに分割し、各レイヤーは独自の関心事を持つ。
- エンティティの独立性: ビジネスルールとエンティティはフレームワークやUIから独立している。
- テスト容易性: ビジネスロジックがUIやデータベースから独立しているため、テストが容易になる。
- フレームワークの独立性: システムのビジネスルールは、使用しているフレームワークから独立している

短くまとめると以下のようなメリット、デメリットがある

メリット
- 変更しやすくなる
- 設計について共通認識ができる
- テストしやすくなる

デメリット
- 設計に時間がかかる

しっかりした思想の元設計、実装することで、共通認識をもってシステムを作り上げる所がポイントだと感じている


## 階層
今回のターン制バトルの構成を説明する

Fremework

&#124;

InterfaceAdapter

&#124;

Usecase

&#124;

DomainModel

## 解説
### Fremework層

この層では、Unityなどフレームワークを使った処理、またOSなどに関係するファイル読み書きなどを実装するレイヤーとなっている
具体的にはMonobehaviorを使ったUI作成関連処理はこのレイヤーで実装し、他のレイヤーからはインタフェースを通じてアクセスする(依存性の逆転）

CardGameFremeworkが、MonobehaviorとなっておりここでUnityとのつなぎ合わせを行っている
各種UIを作るコンポーネントもこのレイヤで実装している
GameLifetimeScopeはDIの実施を、インタラクターで使うUIはここから渡すようにしている
CharcterRepositoryImplはリポジトリの実装を行っている


### InterfaceAdapter

Battlecontrolerが、フレームワーク層から送られてきたイベントを整理して、
インタラクターのインタフェースに指示を送る
Unityから独立した処理をさばくコントローラとして実現している

### Usecase
実際のビジネスロジック、ゲームのロジックを実装している
ターンゲームのロジックである、TurnBasedBattleInteractorと
ダメージ計算ロジックのBattleActionがある
ドメイン層ととインタフェースに依存しているだけでテストしやすい

### DomainModel
ユースケースを成り立たせるデータ群
データのみなので独立性が高い
