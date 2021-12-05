

<h3 align='center'> Варіант №4 </h3>

___

Розробити програму, яка б надавала інформацію про персонажів
комп’ютерної гри. Вони бувають трьох видів: 
1. Люди (фізично найслабші),
2. Тролі (середні).
3. Орки (найсильніші). 

Кожен з персонажів має рівень захисту та
силу. Сила залежить від початкової величини та він того, яким озброєнням
володіє персонаж (луки, мечі, булава, кинджали, сокири). Персонаж може
заволодіти будь-яким видом озброєння. Рівень захисту залежить від
одягу (обладунки) та щитів(дерев’яні, металеві). Програма повинна
створювати персонажів усіх видів. Для вибраного героя здійснювати
перевірку, чи є хтось сильніший за нього, та чи є персонажі, яких він може
побити за 1, 5 чи 10 ударів (чи перевищує сила його удару чи групи ударів
чийсь захист). При розробці скористатись шаблонами [Facade](https://refactoring.guru/design-patterns/facade/csharp/example) та [Decorator](https://metanit.com/sharp/patterns/4.1.php).

---

UML Diagram (Class Diagram):

![image](https://user-images.githubusercontent.com/55552780/144760931-ee1d01d2-092a-4002-b446-cd626c28b179.png)   
Додаткові класи (в тому числі й Фасад):       
![image](https://user-images.githubusercontent.com/55552780/144760992-95141022-eed1-458d-9125-830b727ecd9a.png)

---

Початковий вигляд UI:
![image](https://user-images.githubusercontent.com/55552780/144746805-e5dee9f1-076f-4adb-95ed-7f920f0fe2d0.png)

Основні контролери створення персонажа:  
![overview1](https://user-images.githubusercontent.com/55552780/144762183-2ad13722-e501-48a2-aec3-b35b10565e4a.gif)
Функціонал стовпчикової діаграми: 

