# halation ghost WPF

## 01_episode03

[halation ghost 【WPF Prism episode: 3 ～ Re: ゼロから始める Prism 生活～】](https://elf-mission.net/programming/wpf/episode03/) で作成したサンプル。

Prism のプロジェクトを新規作成して Prism の Module を Shell に読み込む部分までを紹介。  
Prism の Bootstrapper に設定する内容を紹介しています。

## 02_episode03_Prism7.1

[halation ghost 【WPF Prism episode: 3 ～ Re: ゼロから始める Prism 生活～】](https://elf-mission.net/programming/wpf/episode03/) で作成したサンプルの Prism 7.1 対応版。

Prism のプロジェクトを新規作成して Prism の Module を Shell に読み込む部分までを紹介。  
Prism 7.1 で変更になった部分も併せて紹介しています。

## 02_episode04

[halation ghost 【WPF Prism episode: 4 ～ DI だけど Unity さえあれば関係ないよねっ～】](https://elf-mission.net/programming/wpf/episode04/) で作成したサンプル。

Prism の Shell ⇔ Module 間で受け渡すデータをプロジェクト作成時に選択した DI コンテナ（ここでは Unity）を介してやり取りするサンプル。

## 03_episode05

[halation ghost 【WPF Prism episode: 5 ～ご注文は TreeView ですか？～】](https://elf-mission.net/programming/wpf/episode05/) で作成したサンプル。

MVVM パターンで TreeView へデータをバインドするサンプル。  
TreeView の各 Item 毎に VM を用意してバインドする例を紹介しています。

## 04_episode06

[halation ghost 【WPF Prism episode: 6 ～されどイベントは ViewModel と踊る～】](https://elf-mission.net/programming/wpf/episode06/) で作成したサンプル。

EventToReactiveCommand（View 側）と ReactiveCommand（VM 側） を利用して TreeView.SelectedItemChanged イベントを VM 処理するサンプル。  
イベントパラメータ（EventArgs）を受け取って Prism の RequestNavigation メソッドで別の View に切り替えるまでを紹介しています。

## 05_episode07

[halation ghost 【WPF Prism episode: 7 ～ ReactiveProperty がバインドできないのはどう考えても Navigation が悪い！～】](https://elf-mission.net/programming/wpf/episode07/) で作成したサンプル。

Prism の NavigationContext と INavigationAware を利用して遷移先画面の VM にパラメータを渡すサンプル。  
View と VM は ReactiveProperty でバインドされていて、VM は INotifyPropertyChanged をインプリメントしたモデルと ToReactivePropertyAsSynchronized メソッドで同期されていて、その同期しているモデルを差し替える例も紹介しています。

## 06_episode08

[halation ghost 【WPF Prism episode: 8 ～とある TreeView の状況一覧 (Context menu) ～】](https://elf-mission.net/programming/wpf/episode08/) で作成したサンプル。

List 型メンバを編集するための View がどのメンバに対応する View かを Prism の INavigationAware.IsTarget を使用して判定するサンプル。  
TreeView に追加したコンテキストメニューから ReactiveCollection へ項目を追加すると TreeView に子 Item が追加されるサンプルも併せて紹介しています。

## 07_episode09

[halation ghost 【WPF Prism episode: 9、9' ～ ReactiveProperty の Validation は DataAnnotation じゃないと思った？～】](https://elf-mission.net/programming/wpf/episode09/) で作成したサンプル。

ReactiveProperty へバリデーション（DataAnnotation）を設定するサンプル。

## 08_episode10

[halation ghost 【WPF Prism episode: 10 ～ ErrorTemplate は Resources タグ、時々、ResourceDictionary ファイルのなか。～】](https://elf-mission.net/programming/wpf/episode10/) で作成したサンプル。

episode: 9、9' で設定したバリデーションの ErrorTemplate を設定するサンプル。

## 09_episode11

[halation ghost 【WPF Prism episode: 11 ～ Prism が画面遷移キャンセルするのは IConfirmNavigationRequest だけど INavigationAware じゃない～】](https://elf-mission.net/programming/wpf/episode11/) で作成したサンプル。

Prism の IConfirmNavigationRequest を使用して画面遷移をキャンセルするサンプル。
