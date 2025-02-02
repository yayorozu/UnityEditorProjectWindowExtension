# UnityEditorProjectWindowExtension

Project Window で拡張子を表示させたいなど、さまざまなニーズに対応できる汎用的な拡張ツールを作成しました。

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/h/hacchi_man/20201116/20201116012209.png" width="300" alt="ProjectWindow Extension">

---

## On/Off 設定

Preferences に On/Off を切り替える UI を追加しており、必要な機能ごとに個別に On/Off を選択することが可能です。

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/h/hacchi_man/20201116/20201116012243.png" width="300" alt="OnOff 設定">

---

## 独自拡張の追加

`ProjectGUIModule` を継承したクラスを作成することで、独自の機能を Project Window に追加することができます。  
以下はサンプルコードです:

```csharp
using Yorozu.EditorTools.Project;

namespace EditorTools
{
    public class ProjectExtensionTest : ProjectGUIModule
    {
        /// <summary>
        /// ProjectWindow に表示する文言
        /// 空文字列を返せば表示しません
        /// </summary>
        public override string Display(string path)
        {
            return "test";
        }

        /// <summary>
        /// Preferences に表示する名称
        /// </summary>
        public override string PreferenceName()
        {
            return "Test";
        }
    }
}
```

以下は、サンプル拡張を有効にした場合の Project Window 表示例です。

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/h/hacchi_man/20201116/20201116012620.png" width="300">


<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/h/hacchi_man/20201116/20201116012958.png" width="300">
