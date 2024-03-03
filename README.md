# ターン制バトルのクリーンアーキテクチャ実装
RPGにおける、ターン制のバトルをクリーンアーキテクチャにて実装した

## 階層
Fremework

&#124;

InterfaceAdapter

&#124;

Usecase

&#124;

DomainModel

## 解説
Fremework層

CardGameFremeworkが、MonobehaviorとなっておりここでUnityとのつなぎ合わせを行っている
InterfaceAdapterのBattleControllerをUnity側の仕組みから依存をさせないようにしている

GameLifetimeScopeが、DIを行い、CharcterRepositoryImplはリポジトリの実装を行っている
このあたりも、システムの外側の昨日をフレームワーク層にまとめている

InterfaceAdapter
