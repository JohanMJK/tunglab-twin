DaTable
@ 2019 Niwashi Games
Version 1.0.1

DaTable is a data list of such as items and monsters.
You can create paramaters in your script.



[DaTable]
This is an asset with a data list.

Create
Create using DaTable Creator Window,
Manage the list in DaTable Window.

- GetElement<T>(int number)
- GetElement<T>(string name)
- GetElementWithID<T>(string id)
Get list element.

- int elementCount
Property for the number of elements in the list.



[DaTable Element]
Inherits DaTable Element and uses it as a data class.

- int number
List number.

- strint id
32 alphanumeric characters.



■How to use
[DaTable Asset]
1. Create script from ‘Assets-> Create-> C #-> DaTable Element’.
2. Open DaTable Creator Window from ‘Tools-> DaTable-> Window-> DaTable Creator’.
3. Set the script created in '2.' to DaTable Element Script.
4. Enter the asset name and press Create to create it.

[DaTable Window]
1. Open DaTable Window from ‘Tools-> DaTable-> Window-> DaTable’.
2. Select the DaTable asset from the 'Project Window'.
3. Click the Add button to add an element.
4. Select an element and set the data in the Inspector window.

■Version history
1.0.1
- Fixed asset path text in DaTable window
1.0.0
- First release
