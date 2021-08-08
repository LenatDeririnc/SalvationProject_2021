## Как создать новый уровень:
- Создаёте новую папку, в которой:
   - Создаёте новую сцену: `Create/Scene`
   - Создаёте информацию о сцене: `Create/Scriptable Objects/Scene/SceneData`
- Переименуйте внутри нового `SceneData`-объекта поле `Scene Name` на то, как у вас называется сцена.
- Добавьте в настройках Unity во вкладке `File/Build Settings`
- Кидаете на сцену префабы из папки Scenes/ScenePrefabs. В основном понадобятся 3 из них:
   - `__scene__`
   - `__scene_loader__`
   - `__spawners__`
- В `__scene__` добавляете
   - В поле `Scene Info` ваш ранее созданный `SceneData` из папки уровня
   - В поле `Init Scene Data`- объект из папки `Scenes/InitSceneData`
   - В поле `Spawner Manager Component` добавляете объект **внутри** вашего уровня, который называется `__spawners__`
- Если необходим шейдер PS1, то добавляете также в уровень объект из папки `Scenes/Volumes/_Default Global Volume`

## Как сделать спавнеры уровней:
- Создайте игровой объект двери, и добавьте на него два компонента:
   * `Interactable Object`
   * `Door Object`
- Создайте в папке уровня папки `Holders` и `Spawns`, если они отсутствуют.
- В папке `Holders` создаёте новый `Scriptable Object`, кликнув правой кнопкой мыши по папке, и выберите `Create/Scriptable Objects/GameObjectHolderData`
- На новый `GameObjectHolderData` кидаете информацию о сцене (`SceneData`), которая расположена рядом с уровнем