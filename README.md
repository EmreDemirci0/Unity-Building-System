# Unity-Building-System
Simple implementation of a Building System like in simulator games.


[ENG]
First of all, we create the builditem scriptable object of the item we want (Right Click/Create/ScriptableObjects/BuildItem). We add the item to be built and the preshow item as prefab into this "build item" and enter the position we have. Whether they can be nested or not, whether they can be stacked or not can be examined from sample objects.
Sample objects can be examined with the item section in BuildingSystem.cs.
The ground where it can be placed should be given the "Ground" tag.
Floors that we cannot place should be labeled "CantPlaced".

 Gameplay
• Pick up with Mouse 0 as pre-show, build with Mouse 1.
• Change rotation with Mouse Scroll.
• Walk with W-A-S-D.


[TR]
Öncelikle istediğimiz itemin builditem scriptable objectini oluşturuyoruz (sağ tık/Create/ScriptableObjects/BuildItem). İçerisine build edilcek itemi ve preshow itemi prefab olarak atıyoruz ve elimizdeki konumunu giriyoruz. İç içe geçip geçmemesi, Stacklenebilip stacklenebilememesi örnek objelerden bakılıp incelenebilir.
BuildingSystem.cs içerisindeki item kısmı ile örnek objeler incelenebilir. Konulabilecek Zemine “Ground” Tagi verilmeli. Koyamayacağımız Zeminlere “CantPlaced” tagi verilmeli.

  Oynanış
• Yürümek için W-A-S-D tuşlarını kullanın.
• Mouse 0 ile Pre-Show görüntüsü, Mouse 1 ile Build et.
• MouseScroll ile Rotasyonunu değiştirin.
