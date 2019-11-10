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

[halation ghost 【WPF Prism episode: 4.5 ～ ReactiveProperty からはじまる MVVM 狂想曲 ～】](https://elf-mission.net/programming/wpf/episode045/)、  
[halation ghost 【WPF Prism episode: 5 ～ TreeView の MVVM には ReactiveProperty が埋まっている ～】](https://elf-mission.net/programming/wpf/episode05/) で作成したサンプル。

MVVM パターンで TreeView へデータをバインドするサンプル。  
TreeView の各 Item 毎に VM を用意してバインドする例を紹介しています。  
MVVM パターン入門で紹介したサンプルプロジェクトを追加。（2019/4/18 追記）

## 04_episode06

[halation ghost 【WPF Prism extra: 1 ～ TreeViewItem を MVVM パターンで展開する ～】](https://elf-mission.net/programming/wpf/extra01/) 、  
[halation ghost 【WPF Prism episode: 6 ～ されどイベントは ViewModel と踊る ～】](https://elf-mission.net/programming/wpf/episode06/) 、  
[halation ghost 【WPF Prism episode: 6.5 ～ いつだって Prism の画面遷移は RequestNavigation だった。 ～】](https://elf-mission.net/programming/wpf/episode065/)で作成したサンプル。

EventToReactiveCommand（View 側）と ReactiveCommand（VM 側） を利用して TreeView.SelectedItemChanged イベントを VM 処理するサンプル。  
イベントパラメータ（EventArgs）を受け取って Prism の RequestNavigation メソッドで別の View に切り替えるまでを紹介しています。
又、extra: 1 では TreeViewItem.IsExpanded プロパティをバインドする方法を紹介しています。

## 05_episode07

[halation ghost 【WPF Prism extra: 2 ～ TreeViewItem を MVVM パターンで選択する ～】](https://elf-mission.net/programming/wpf/extra02/) 、  
[halation ghost 【WPF Prism episode: 7 ～ 画面遷移のパラメータたちが INavigationAware から来るそうですよ？ ～】](https://elf-mission.net/programming/wpf/episode07/) で作成したサンプル。

Prism の NavigationContext と INavigationAware を利用して遷移先画面の VM にパラメータを渡すサンプル。  
View と VM は Prism の BindableBase でバインドする例を紹介。
UserControl.Loaded イベントを ReactiveCommand とバインドして TreeView の SelectedItem を設定するサンプルも含んでいます。

## 06_episode08

[halation ghost 【WPF Prism extra: 3 ～ とある TreeView の状況一覧 (Context menu) ～】](https://elf-mission.net/programming/wpf/extra03/)、  
[halation ghost 【WPF Prism episode: 8 ～ ReactiveProperty がバインドできないのはどう考えても Navigation が悪い！ ～】](https://elf-mission.net/programming/wpf/episode08/) で作成したサンプル。

List 型メンバを編集するための View がどのメンバに対応する View かを Prism の INavigationAware.IsTarget を使用して判定するサンプル。  
TreeView に追加したコンテキストメニューから ReactiveCollection へ項目を追加すると TreeView に子 Item が追加されるサンプルも併せて紹介しています。  
又、ReactiveCommand からコントロールの IsEnabled を設定する方法や ReactiveProperty を使用して VM ⇔ Model 間を双方向でバインドするサンプルも含んでいます。

## 07_episode09

[halation ghost 【WPF Prism episode: 9、9' ～ ReactiveProperty の Validation は DataAnnotation じゃないと思った？～】](https://elf-mission.net/programming/wpf/episode09/) で作成したサンプル。  
[halation ghost 【WPF Prism extra: 4 ～ Extended WPF Toolkit™ で数値と日付を入力 ～】](https://elf-mission.net/programming/wpf/extra04/) で作成したサンプル。

ReactiveProperty へバリデーション（DataAnnotation）を設定するサンプルと Xceed の Extended WPF Toolkit™ を使用するサンプル。

## 08_episode10

[halation ghost 【WPF Prism episode: 10 ～ ErrorTemplate は Resources タグ、時々、ResourceDictionary ファイルのなか。～】](https://elf-mission.net/programming/wpf/episode10/) で作成したサンプル。

episode: 9、9' で設定したバリデーションの ErrorTemplate を設定するサンプル。

## 09_episode11

[halation ghost 【WPF Prism episode: 11 ～ Prism が画面遷移キャンセルするのは IConfirmNavigationRequest だけど INavigationAware じゃない～】](https://elf-mission.net/programming/wpf/episode11/) で作成したサンプル。

Prism の IConfirmNavigationRequest を使用して画面遷移をキャンセルするサンプル。

## 10_episode12

[halation ghost 【WPF Prism episode: 12 ～ Prism メッセージボックスの Service な日常 ～】](https://elf-mission.net/programming/wpf/episode12/) で作成したサンプル。

Prism 組み込みのメッセージボックスを表示するサンプル。

## 11_episode13

[halation ghost 【WPF Prism episode: 13 ～ カスタマイズしたらメッセージボックスだった件 ～】](https://elf-mission.net/programming/wpf/episode13/) で作成したサンプル。

Prism 組み込みのメッセージボックスをカスタマイズするサンプル。

## 12_episode14

[halation ghost 【WPF Prism episode: 14 ～ ListBox 相手は ReactiveCollection、ダイアログな、Prism。 ～】](https://elf-mission.net/programming/wpf/episode14/) で作成したサンプル。

Prism からダイアログウィンドウを表示するサンプル。

## 13_episode15

[halation ghost 【WPF Prism episode: 15 ～ FolderBrowserDialog の為ならば、Prism の InteractionRequest はもしかしたらコモンダイアログも Popup できるかもしれない。 ～】](https://elf-mission.net/programming/wpf/episode15/) で作成したサンプル。

Prism から FolderBrowserDialog や OpenFileDialog 等のコモンダイアログを表示するサンプル。

## 14_episode16

[halation ghost 【WPF Prism episode: 16 ～ Prism7.2、ダイアログは IDialogService でって言ったよね！ ～】](https://elf-mission.net/programming/wpf/episode16/) で作成したサンプル。

Prism 7.2 から新たに追加された IDialogService でダイアログを表示するサンプル。

## 15_episode17

[halation ghost 【WPF Prism episode: 17 ～ IDialogService にコモンダイアログを求めるのは間違っているだろうか ～】](https://elf-mission.net/programming/wpf/episode17/) と  
[halation ghost 【WPF Prism extra: 5 ～ ReactvieProperty の変更通知を Subscribe して MVVM 的にデータを更新する ～】](https://elf-mission.net/programming/wpf/extra05/) で作成したサンプル。

Prism からファイルを開くダイアログやファイルに名前を付けて保存ダイアログ等のコモンダイアログを表示するサンプル。
Window API Code Pack のフォルダ選択ダイアログを表示する方法も含んでいます。

## 16_episode18

[halation ghost 【WPF Prism episode: 18 ～ Livet が Prism に「IDisposable 呼び出し用」としてゲッツされた件 ～】](https://elf-mission.net/programming/wpf/episode18/)

Prism 7.2 で追加された IDestractible と[分割導入できるようになった Livet](https://github.com/runceel/Livet) を Prism で作成したサンプルに導入してWindow Close 時に Window と UserControl の VM を Disposeするサンプル。  
今回からプロジェクトのフレームワークを .NET Core に変更しています。

## 17_episode19/PrismNetCoreApp

[halation ghost 【WPF Prism episode: 19 ～ MahApps.Metro と Material Design In XAML Toolkit たちは Prism でも余裕で生き抜くようです! ～】](https://elf-mission.net/programming/wpf/episode19/)

サンプルアプリに MahApps.Metro と Material Design In XAML Toolkit をインストールしてマテリアルデザイン風の画面にするサンプル。

## QA_MvvmSampleApp
[halation ghost episode: 16](https://elf-mission.net/programming/wpf/episode16/) のコメントに書かれた質問への回答用サンプル。

Prism + ReactivePropertyでMVVMアプリを作成するためには定石とも言える構造を紹介するために作成したサンプル。  
モデル層の変更をReactivePropertyを使用してVMへ伝播する方法を理解するのに向いていると思います。

## QA_VmLoadTest
[halation ghost episode: 16](https://elf-mission.net/programming/wpf/episode16/) のコメントに書かれた質問への回答用サンプル。

Prism Shell起動時にPrism ModuleのViewを非表示でLoadしたい場合の裏技的な方法を紹介するためのサンプル。
重いViewをアプリ起動時にあらかじめLoadしておきたい場合を想定していますがあまりお勧めの方法とは言えないような気がします。

